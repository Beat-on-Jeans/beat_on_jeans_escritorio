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
        private DataGridView dataGridViewActuaciones;

        public FormCalendario()
        {
            InitializeComponent();
            _year = DateTime.Now.Year;
            _month = DateTime.Now.Month;

            this.StartPosition = FormStartPosition.CenterScreen;

            ConfigurarDataGridView();
        }

        private void ConfigurarDataGridView()
        {
            // Configurar columnas
            //dataGridViewActuacion.Columns.Add("Fecha", "Fecha y Hora");
            //dataGridViewActuacion.Columns.Add("Musico", "Músico");
            //dataGridViewActuacion.Columns.Add("Local", "Local");

            //dataGridViewActuacion.Columns["Fecha"].DefaultCellStyle.Format = "g";
            //dataGridViewActuacion.Columns["Fecha"].Width = 150;

            //this.Controls.Add(dataGridViewActuacion);
        }

        public void MostrarActuaciones(List<dynamic> actuaciones)
        {
            //dataGridViewActuacion.Rows.Clear();

            if (actuaciones == null || actuaciones.Count == 0)
            {
                //dataGridViewActuacion.Rows.Add("No hay actuaciones para esta fecha");
                return;
            }

            //foreach (var actuacion in actuaciones)
            //{
                //dataGridViewActuacion.Rows.Add(
                  //  actuacion.FechaActuacion,
                    //actuacion.NombreMusico,
                    //actuacion.NombreLocal
              //  );
            }
        

        private void FormCalendario_Load(object sender, EventArgs e)
        {
            showDays(_month, _year);
        }

        // Método para navegar al mes anterior (PictureBox1)
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

        // Método para navegar al siguiente mes (PictureBox2)
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