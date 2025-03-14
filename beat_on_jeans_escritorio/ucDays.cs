using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace beat_on_jeans_escritorio
{
    
    public partial class ucDays: UserControl
    {
        String _day, date, weekday;

        private void panel1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                checkBox1.Checked = true;
                this.BackColor = Color.FromArgb(255, 150, 79);
            }
            else 
            {
                checkBox1.Checked = false;
                this.BackColor = Color.White;
            }
        }

        public ucDays(string day)
        {
            InitializeComponent();
            _day = day;
            label1.Text = day;
            checkBox1.Hide();
            date = FormCalendario._month + "/" + _day + "/" + FormCalendario._year;
        }

        private void sundays() 
        {
            try
            {
                DateTime day = DateTime.Parse(date);
                weekday = day.ToString("ddd");
                if (weekday == "Sun")
                {
                    label1.ForeColor = Color.FromArgb(64, 64, 64);

                }
            }
            catch (Exception) { }
        }

        private void ucDays_Load(object sender, EventArgs e)
        {
            sundays();
        }

        
    }
}
