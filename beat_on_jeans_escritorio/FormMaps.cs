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

        // Ruta automatizada(dirección)
        bool trazarRuta = false;
        int contadorIndicadoresRuta = 0;
        PointLatLng inicio;
        PointLatLng final;

        int filasSeleccionadas = 0;
        double latInicial = 20.9688132813906;
        double lngInicial = -89.6250915527344;



        // https://www.youtube.com/watch?v=nkbq0EiEpCc

        public FormMaps()
        {
            InitializeComponent();
            
        }

        private void FormMaps_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Descripción", typeof(string)));
            dt.Columns.Add(new DataColumn("Lat", typeof (double)));
            dt.Columns.Add(new DataColumn("Long", typeof (double)));

            // insertar datos al dt para mostrar la lista
            dt.Rows.Add("Ubicación", latInicial, lngInicial);
            dataGridView1.DataSource = dt;

            // desactivar columnas de lat y long
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;

            // crear dimensiones del GMAPCONTROL (herramienta)
            gMapControl1.DragButton=MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider=GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(latInicial, lngInicial);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 9;
            gMapControl1.AutoScroll = true;

            // Marcador
            markerOverlay = new GMapOverlay("Marcador");
            marker = new GMarkerGoogle(new PointLatLng(latInicial,lngInicial), GMarkerGoogleType.green);
            markerOverlay.Markers.Add(marker); // agregamos al mapa

            // agregamos un tooltip de texto a los marcadores
            marker.ToolTipMode = MarkerTooltipMode.Always;
            marker.ToolTipText = string.Format("Ubicación:\n Latitud:{0}\n Longitud:{1}", latInicial, lngInicial);

            // ahora agregamos el mapa y el marcador al control map
            gMapControl1.Overlays.Add(markerOverlay);


        }
    }
}
