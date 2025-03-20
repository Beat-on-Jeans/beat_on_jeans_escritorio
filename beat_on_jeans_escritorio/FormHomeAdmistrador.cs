using beat_on_jeans_escritorio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace beat_on_jeans_escritorio
{
    public partial class FormHomeAdmistrador : Form
    {
        public FormHomeAdmistrador()
        {
            InitializeComponent();

            cargarDatosActuaciones();
            configurarFondoGrid();
        }

        private void configurarFondoGrid()
        {
            // Definir el color RGB (255, 243, 226)
            Color colorFondo = Color.FromArgb(255, 243, 226);

            // Configurar el color de fondo del DataGridView
            //dataGridViewEventosProgramados.BackgroundColor = colorFondo;
            //dataGridViewEventosProgramados.BackgroundColor = colorFondo;
            //dataGridViewEventosProgramados.BackgroundColor = colorFondo;

            // Configurar el color de fondo de las celdas
            dataGridViewEventosProgramados.DefaultCellStyle.BackColor = colorFondo;
            dataGridViewEventosProgramados.DefaultCellStyle.BackColor = colorFondo;
            dataGridViewEventosProgramados.DefaultCellStyle.BackColor = colorFondo;

            
        }

        private void cargarDatosActuaciones()
        {
            // Obtener la lista de actuaciones desde la base de datos
            List<Actuacion> actuaciones = ActuacionOrm.Select();

            // Asignar la lista de actuaciones al DataGridView
            dataGridViewEventosProgramados.DataSource = actuaciones;

            // Hacer que el DataGridView sea de solo lectura
            dataGridViewEventosProgramados.ReadOnly = true;

            // Configurar el DataGridView para que genere automáticamente las columnas
            dataGridViewEventosProgramados.AutoGenerateColumns = true;

            // Asegurarse de que las columnas estén visibles
            foreach (DataGridViewColumn column in dataGridViewEventosProgramados.Columns)
            {
                column.Visible = true;
            }
        }

        private void FormHomeAdmistrador_Load(object sender, EventArgs e)
        {
            DataGridViewBordeRedondo.RedondearBordes(dataGridViewEventosProgramados, 20);
            DataGridViewBordeRedondo.RedondearBordes(dataGridViewListaMusicosLocales, 20);
            DataGridViewBordeRedondo.RedondearBordes(dataGridViewCambiosMusicosLocales, 20);
        }
    }
}
