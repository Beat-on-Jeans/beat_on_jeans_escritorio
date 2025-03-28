using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Collections.Generic;

namespace beat_on_jeans_escritorio
{
    public partial class FormCalendario : Form
    {
        public static int _year, _month;

        public FormCalendario()
        {
            InitializeComponent();
            _year = DateTime.Now.Year;
            _month = DateTime.Now.Month;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(800, 600);

            // Configurar estilo de los labels
            ConfigurarLabels();
        }

        private void ConfigurarLabels()
        {
            // Inicialmente ocultos
            label8.Visible = false;
            labelUbicacion.Visible = false;
            label10.Visible = false;
            labelLocal.Visible = false;
            label12.Visible = false;
            labelMusico.Visible = false;

            // Configurar el label de Ubicación
            labelUbicacion.AutoSize = true;
            labelUbicacion.ForeColor = Color.Black;
            labelUbicacion.MaximumSize = new Size(200, 0); // Aumentado para mejor visualización

            // Configurar el label de Local
            labelLocal.AutoSize = true;
            labelLocal.ForeColor = Color.Black;
            labelLocal.MaximumSize = new Size(300, 0);

            // Configurar el label de Músico
            labelMusico.AutoSize = true;
            labelMusico.ForeColor = Color.Black;
            labelMusico.MaximumSize = new Size(300, 0);
        }

        public void MostrarActuaciones(List<dynamic> actuaciones)
        {
            try
            {
                // Limpiar los labels
                labelUbicacion.Text = "Ubicación: ";
                labelLocal.Text = "Local: ";
                labelMusico.Text = "Músico: ";

                // Ocultar labels si no hay datos
                if (actuaciones == null || actuaciones.Count == 0)
                {
                    labelUbicacion.Text = "No hay actuaciones para esta fecha";
                    OcultarLabelsInformacion();
                    return;
                }

                // Mostrar todos los labels de información
                MostrarLabelsInformacion();

                // Mostrar todos los datos de las actuaciones
                foreach (dynamic actuacion in actuaciones)
                {
                    // Obtener valores con manejo de nulos
                    string ubicacion = actuacion.UbicacionLocal != null ?
                                     actuacion.UbicacionLocal.ToString() :
                                     "Ubicación no disponible";

                    string local = actuacion.NombreLocal != null ?
                                 actuacion.NombreLocal.ToString() :
                                 "Local desconocido";

                    string musico = actuacion.NombreMusico != null ?
                                  actuacion.NombreMusico.ToString() :
                                  "Músico desconocido";

                    // Mostrar en los labels (concatenar si hay múltiples actuaciones)
                    labelUbicacion.Text = $"📍 {ubicacion}";
                    labelLocal.Text = $"🏠 {local}";
                    labelMusico.Text = $"🎵 {musico}";
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                labelUbicacion.Text = "Error al cargar los datos de la actuación";
                Console.WriteLine($"ERROR en MostrarActuaciones: {ex.Message}");

                // Mostrar detalles adicionales del error
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"INNER EXCEPTION: {ex.InnerException.Message}");
                }
            }
        }

        private void MostrarLabelsInformacion()
        {
            label8.Visible = true;        // Label "Ubicación:"
            labelUbicacion.Visible = true;
            label10.Visible = true;      // Label "Local:"
            labelLocal.Visible = true;
            label12.Visible = true;       // Label "Músico:"
            labelMusico.Visible = true;
        }

        private void OcultarLabelsInformacion()
        {
            label8.Visible = false;
            labelUbicacion.Visible = false; 
            label10.Visible = false;
            labelLocal.Visible = false;
            label12.Visible = false;
            labelMusico.Visible = false;
        }

        private void FormCalendario_Load(object sender, EventArgs e)
        {
            showDays(_month, _year);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            _month -= 1;
            if (_month < 1)
            {
                _month = 12;
                _year -= 1;
            }
            showDays(_month, _year);
            OcultarLabelsInformacion(); // Ocultar al cambiar de mes
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            _month += 1;
            if (_month > 12)
            {
                _month = 1;
                _year += 1;
            }
            showDays(_month, _year);
            OcultarLabelsInformacion(); // Ocultar al cambiar de mes
        }

        private void showDays(int month, int year)
        {
            flowLayoutPanel1.Controls.Clear();
            _year = year;
            _month = month;

            string monthName = new DateTimeFormatInfo().GetMonthName(month);
            lbMonth.Text = monthName.ToUpper() + " " + year;

            DateTime startOfTheMonth = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);
            int startDayOfWeek = (int)startOfTheMonth.DayOfWeek;

            // Días vacíos para alinear el primer día
            for (int i = 0; i < startDayOfWeek; i++)
            {
                ucDays uc = new ucDays("", this);
                flowLayoutPanel1.Controls.Add(uc);
            }

            // Días del mes
            for (int i = 1; i <= daysInMonth; i++)
            {
                ucDays uc = new ucDays(i.ToString(), this);
                flowLayoutPanel1.Controls.Add(uc);
            }
        }
    }
}