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
            _year = DateTime.Now.Year;
            _month = DateTime.Now.Month;
        }

        private void FormCalendario_Load(object sender, EventArgs e)
        {
            showDays(_month, _year);
        }

        private void pictureBox2_Click(object sender, EventArgs e) // Siguiente mes
        {
            _month += 1;
            if (_month > 12)
            {
                _month = 1;
                _year += 1;
            }
            showDays(_month, _year);
        }

        private void pictureBox1_Click(object sender, EventArgs e) // Mes anterior
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