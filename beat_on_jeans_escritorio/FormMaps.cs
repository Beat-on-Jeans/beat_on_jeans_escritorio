using System;
using System.Data;
using System.Device.Location; // Necesario para usar GeoCoordinateWatcher
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace beat_on_jeans_escritorio
{
    public partial class FormMaps : Form
    {
        GMarkerGoogle marker;
        GMapOverlay markerOverlay;
        DataTable dt;
        GeoCoordinateWatcher watcher;

        public FormMaps()
        {
            InitializeComponent();
            watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
            watcher.PositionChanged += Watcher_PositionChanged;
            watcher.Start(); // Iniciar el seguimiento de la ubicación
        }

        private void FormMaps_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Descripción", typeof(string)));
            dt.Columns.Add(new DataColumn("Lat", typeof(double)));
            dt.Columns.Add(new DataColumn("Long", typeof(double)));

            // Crear dimensiones del GMAPCONTROL (herramienta)
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 9;
            gMapControl1.AutoScroll = true;

            // Inicializar el overlay del marcador
            markerOverlay = new GMapOverlay("Marcador");
            gMapControl1.Overlays.Add(markerOverlay);
        }

        private void Watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            // Obtener la nueva ubicación
            double lat = e.Position.Location.Latitude;
            double lng = e.Position.Location.Longitude;

            // Actualizar el mapa y el marcador
            gMapControl1.Position = new PointLatLng(lat, lng);
            gMapControl1.Zoom = 15; // Ajustar el zoom al cambiar de ubicación

            // Si el marcador ya existe, lo actualizamos; si no, lo creamos
            if (marker == null)
            {
                marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.green);
                markerOverlay.Markers.Add(marker);
            }
            else
            {
                marker.Position = new PointLatLng(lat, lng);
            }

            // Actualizar el tooltip del marcador
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            marker.ToolTipText = string.Format("Ubicación:\n Latitud:{0}\n Longitud:{1}", lat, lng);

            // Refrescar el mapa
            gMapControl1.Refresh();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            
            //UsuariosCSharp usuarioActual = new UsuariosCSharp();

            // Cerrar FormMaps y abrir Form2, pasando el usuarioActual
            this.Hide();

            //FormHome formularioMenu = new FormHome(usuarioActual);
            //formularioMenu.ShowDialog();
        }

    }
}
