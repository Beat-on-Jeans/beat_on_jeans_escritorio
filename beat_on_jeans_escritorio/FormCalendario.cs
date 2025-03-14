using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace beat_on_jeans_escritorio
{
    public partial class FormCalendario : Form
    {
        public static int _year, _month;

        public FormCalendario()
        {
            InitializeComponent();
            this.Size = new Size(800, 600); // Tamaño inicial del formulario
        }

        private void FormCalendario_Load(object sender, EventArgs e)
        {
            showDays(DateTime.Now.Month, DateTime.Now.Year);
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

        private void showDays(int month, int year)
        {
            flowLayoutPanel1.Controls.Clear();
            _year = year;
            _month = month;

            string monthName = new DateTimeFormatInfo().GetMonthName(month);
            lbMonth.Text = monthName.ToUpper() + " " + year;

            DateTime startOfTheMonth = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);

            // Obtener el día de la semana del primer día del mes (0 = Domingo, 1 = Lunes, ..., 6 = Sábado)
            int startDayOfWeek = (int)startOfTheMonth.DayOfWeek;

            // Agregar cuadros vacíos para los días anteriores al primer día del mes
            for (int i = 0; i < startDayOfWeek; i++)
            {
                ucDays uc = new ucDays("");
                flowLayoutPanel1.Controls.Add(uc);
            }

            // Agregar los días del mes
            for (int i = 1; i <= daysInMonth; i++)
            {
                ucDays uc = new ucDays(i.ToString());
                flowLayoutPanel1.Controls.Add(uc);
            }
        }
    }
}