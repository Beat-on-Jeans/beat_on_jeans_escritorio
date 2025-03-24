using System;
using System.Drawing;
using System.Windows.Forms;
using beat_on_jeans_escritorio.Models;

namespace beat_on_jeans_escritorio
{
    public partial class ucDays : UserControl
    {
        private string _day, date, weekday;
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

            // Formatear la fecha correctamente
            date = $"{FormCalendario._month}/{_day}/{FormCalendario._year}";

            // Verificar y resaltar días con actuaciones
            if (ActuacionLocalOrm.TieneActuacion(date))
            {
                ResaltarDiaConActuacion();
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_day)) return;

            // Obtener actuaciones para esta fecha
            var actuaciones = ActuacionLocalOrm.GetActuacionesPorFecha(date);

            // Mostrar mensaje con la información
            if (actuaciones.Count > 0)
            {
                string mensaje = $"Actuaciones para el {date}:\n";
                foreach (var actuacion in actuaciones)
                {
                    mensaje += $"- {actuacion.NombreLocal}\n";
                }
                MessageBox.Show(mensaje, "Actuaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"No hay actuaciones para el {date}", "Actuaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (!string.IsNullOrEmpty(_day))
            {
                sundays();
            }
        }
    }
}