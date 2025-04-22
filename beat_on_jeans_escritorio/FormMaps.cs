using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using beat_on_jeans_escritorio.Models;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;


namespace beat_on_jeans_escritorio
{
    public partial class FormMaps : Form
    {
        private GMapOverlay markerOverlay;
        private DataTable dt;



        public FormMaps()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Se ejecuta la primera vez que se ejecuta el form y es para configurar el mapa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMaps_Load(object sender, EventArgs e)
        {
            bindingSourceUbicaciones.DataSource = LocalesMapsOrm.SelectUbicacionesLocales();

            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Descripción", typeof(string)));
            dt.Columns.Add(new DataColumn("Lat", typeof(double)));
            dt.Columns.Add(new DataColumn("Long", typeof(double)));

            esconderLabels();
            ConfigureMap();
        }

        /// <summary>
        /// Escondemos los labels.
        /// </summary>
        private void esconderLabels()
        {
            labelNombreLocal.Visible = false;
            labelLocal.Visible = false;
            labelValoracionMedia.Visible = false;
            labelValoracion.Visible = false;
            labelUbicacionLocal.Visible = false;
            labelUbicacion.Visible = false;
        }

        /// <summary>
        /// Configuramos el mapa para que añada un marcador en el mapa.
        /// </summary>
        private void ConfigureMap()
        {
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 12;
            gMapControl1.AutoScroll = true;

            markerOverlay = new GMapOverlay("Marcador");
            gMapControl1.Overlays.Add(markerOverlay);

            SetRoundedCorners(gMapControl1, 20);
        }

        
        /// <summary>
        /// Toma una ubicación y intenta coger las coordenadas de esta dirección.
        /// </summary>
        /// <param name="direccion"></param>
        private void MostrarUbicacionSeleccionada(string direccion)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                buttonAceptar.Enabled = false;
                Refresh();

                var coords = Geocoder.GetCoordinates(direccion);

                if (coords.IsEmpty)
                {
                    coords = Geocoder.GetCoordinates($"{direccion}, Barcelona, Spain");
                }

                if (!coords.IsEmpty)
                {
                    UpdateMapWithNewLocation(direccion, coords);
                }
                else
                {
                    var approximateCoords = new PointLatLng(41.3851, 2.1734);
                    UpdateMapWithNewLocation($"[APROXIMADO] {direccion}", approximateCoords);
                    MessageBox.Show("No se pudo encontrar la ubicación exacta. Mostrando ubicación en Barcelona.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la ubicación: {ex.Message}\n\nIntente nuevamente en unos segundos.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                buttonAceptar.Enabled = true;
            }
        }

        /// <summary>
        /// Ubicamos el mapa con las coordenadas indicadas.
        /// </summary>
        /// <param name="direccion"></param>
        /// <param name="coords"></param>
        private void UpdateMapWithNewLocation(string direccion, PointLatLng coords)
        {
            try
            {
                gMapControl1.Position = coords;
                gMapControl1.Zoom = 17;

                markerOverlay.Markers.Clear();
                var newMarker = new GMarkerGoogle(coords, GMarkerGoogleType.red)
                {
                    ToolTipMode = MarkerTooltipMode.Always,
                    ToolTipText = $"Local: {direccion}\nLatitud: {coords.Lat:F6}\nLongitud: {coords.Lng:F6}"
                };

                markerOverlay.Markers.Add(newMarker);
                gMapControl1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el mapa: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Ponemos los bordes del mapa redondo.
        /// </summary>
        /// <param name="mapControl"></param>
        /// <param name="radius"></param>
        private void SetRoundedCorners(GMapControl mapControl, int radius)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(mapControl.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(mapControl.Width - radius, mapControl.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, mapControl.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            mapControl.Region = new Region(path);
        }

        /// <summary>
        /// Cuando le da a este boton enseña la ubicación en el mapa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBoxCalles.Text))
            {
                MessageBox.Show("Por favor, ingrese o seleccione una ubicación.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mostrar la ubicación en el mapa
            MostrarUbicacionSeleccionada(comboBoxCalles.Text);

            // Mostrar los labels con la información del local
            MostrarInformacionLocal(comboBoxCalles.Text);

            if (!comboBoxCalles.Items.Contains(comboBoxCalles.Text))
            {
                comboBoxCalles.Items.Add(comboBoxCalles.Text);
            }
        }

        /// <summary>
        /// Enseña la información del local con los labels y los hacemos visibles.
        /// </summary>
        /// <param name="direccion"></param>
        private void MostrarInformacionLocal(string direccion)
        {
            try
            {
                // Obtener información del local desde la base de datos
                var local = LocalesMapsOrm.SelectLocalPorUbicacion(direccion);

                if (local != null)
                {
                    // Mostrar los labels
                    labelNombreLocal.Visible = true;
                    labelLocal.Visible = true;
                    labelValoracionMedia.Visible = true;
                    labelValoracion.Visible = true;
                    labelUbicacionLocal.Visible = true;
                    labelUbicacion.Visible = true;

                    // Asignar los valores a los labels
                    labelLocal.Text = local.NombreLocal; // Nombre del local
                    labelValoracion.Text = local.Valoracion?.ToString("0.0") ?? "N/A"; // Valoración
                    labelUbicacion.Text = local.Ubicacion; // Ubicación
                }
                else
                {
                    MessageBox.Show("No se encontró información detallada para este local.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener información del local: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
