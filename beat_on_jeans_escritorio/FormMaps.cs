using System;
using System.Data;
using System.Device.Location;
using System.Drawing;
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

            // Aplicar bordes redondeados al GMapControl
            SetRoundedCorners(gMapControl1, 20); // 20 es el radio de los bordes redondeados
        }

        // Método para aplicar bordes redondeados al GMapControl
        private void SetRoundedCorners(GMapControl mapControl, int radius)
        {
            // Crear una GraphicsPath para definir la forma redondeada
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90); // Esquina superior izquierda
            path.AddArc(mapControl.Width - radius, 0, radius, radius, 270, 90); // Esquina superior derecha
            path.AddArc(mapControl.Width - radius, mapControl.Height - radius, radius, radius, 0, 90); // Esquina inferior derecha
            path.AddArc(0, mapControl.Height - radius, radius, radius, 90, 90); // Esquina inferior izquierda
            path.CloseAllFigures();

            // Asignar la región del control a la forma redondeada
            mapControl.Region = new Region(path);
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
    }
}
