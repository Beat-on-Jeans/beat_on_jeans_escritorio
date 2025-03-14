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
                _month += 1;
            }
            showDays(_month, _year);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            _month -= 1;
            if (_month > 12)
            {
                _month = 12;
                _month -= 1;
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
            DateTime startodTheMonth = new DateTime(year, month, 1);
            int day = DateTime.DaysInMonth(year, month);
            int week = Convert.ToInt32(startodTheMonth.DayOfWeek.ToString("d")) + 1;
            for (int i = 1; i< week; i++)
            {
                ucDays uc = new ucDays("");
                flowLayoutPanel1.Controls.Add(uc);
            }
            for (int i = 1; i< day; i++)
            {
                ucDays uc = new ucDays(i + "");
                flowLayoutPanel1.Controls.Add(uc);
            }


        }



    }
}