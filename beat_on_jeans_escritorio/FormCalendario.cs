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
            // Configurar el label de Ubicación
            labelUbicacion.AutoSize = true;
            labelUbicacion.ForeColor = Color.Black;
            labelUbicacion.Text = "Ubicación: ";
            labelUbicacion.MaximumSize = new Size(150, 0);

            // Configurar el label de Local
            labelLocal.AutoSize = true;
            labelLocal.ForeColor = Color.Black;
            labelLocal.Text = "Local: ";

            // Configurar el label de Músico
            labelMusico.AutoSize = true;
            labelMusico.ForeColor = Color.Black;
            labelMusico.Text = "Músico: ";
        }

        public void MostrarActuaciones(List<dynamic> actuaciones)
        {
            // Limpiar los labels
            labelUbicacion.Text = "Ubicación: ";
            labelLocal.Text = "Local: ";
            labelMusico.Text = "Músico: ";

            if (actuaciones == null || actuaciones.Count == 0)
            {
                labelUbicacion.Text = "No hay actuaciones para esta fecha";
                return;
            }

            // Mostrar la información en los labels
            var primeraActuacion = actuaciones[0];
            labelUbicacion.Text = $"Ubicación: {primeraActuacion.DireccionLocal}";
            labelLocal.Text = $"Local: {primeraActuacion.NombreLocal}";
            labelMusico.Text = $"Músico: {primeraActuacion.NombreMusico}";
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