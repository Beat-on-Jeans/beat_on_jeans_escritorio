using System;
using System.Drawing;
using System.Windows.Forms;
using beat_on_jeans_escritorio.Models;

namespace beat_on_jeans_escritorio
{
    public partial class ucDays : UserControl
    {
        private string _day;
        private DateTime _date;
        private string _weekday;
        private FormCalendario _parentForm;

        public ucDays(string day, FormCalendario parentForm)
        {
            InitializeComponent();
            _day = day;
            _parentForm = parentForm;
            label1.Text = day;
            checkBox1.Hide();

            if (string.IsNullOrEmpty(day))
            {
                this.Enabled = false;
                label1.Text = "";
                return;
            }

            try
            {
                _date = new DateTime(FormCalendario._year, FormCalendario._month, int.Parse(day));

                // Verificar y resaltar días con actuaciones
                if (ActuacionLocalOrm.TieneActuacion(_date))
                {
                    ResaltarDiaConActuacion();
                }
            }
            catch
            {
                this.Enabled = false;
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_day)) return;

            try
            {
                var actuaciones = ActuacionLocalOrm.GetActuacionesPorFecha(_date);
                _parentForm.MostrarActuaciones(actuaciones);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar actuaciones: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResaltarDiaConActuacion()
        {
            this.BackColor = Color.FromArgb(255, 150, 79); // Naranja
            checkBox1.Checked = true;
        }

        private void sundays()
        {
            try
            {
                _weekday = _date.ToString("ddd");
                if (_weekday == "Sun")
                {
                    label1.ForeColor = Color.FromArgb(64, 64, 64);
                }
            }
            catch { }
        }

        private void ucDays_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_day))
            {
                sundays();
            }
        }
    }
}