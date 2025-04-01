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
    public partial class FormHomeMantenimiento : Form
    {
        public FormHomeMantenimiento()
        {
            InitializeComponent();
            redondearGrid();
            cargarDatosMusicos();
            cargarDatosLocales();
            autoSeleccionarGrid();
            configuracionFondoGrid();
        }

        private void FormHomeMantenimiento_Load(object sender, EventArgs e)
        {
            DataGridViewBordeRedondo.RedondearBordes(dataGridViewMusicos, 20);
            DataGridViewBordeRedondo.RedondearBordes(dataGridViewLocales, 20);
        }
        private void redondearGrid()
        {
            DataGridViewBordeRedondo.RedondearBordes(dataGridViewMusicos, 20);
            DataGridViewBordeRedondo.RedondearBordes(dataGridViewLocales, 20);
        }

        private void cargarDatosMusicos()
        {
            try
            {
                var datosMusicos = HomeSuperUsuarioOrm.SelectMusicos();

                // Configurar el DataGridView
                dataGridViewMusicos.AutoGenerateColumns = false;
                dataGridViewMusicos.DataSource = datosMusicos;

                // Configurar las columnas para que usen las propiedades correctas
                dataGridViewMusicos.Columns["NombreMusico"].DataPropertyName = "NombreMusico";
                dataGridViewMusicos.Columns["CorreoMusico"].DataPropertyName = "CorreoMusico";
                dataGridViewMusicos.Columns["CodigoPostal"].DataPropertyName = "CodigoPostal";

                // Configuración de visualización
                dataGridViewMusicos.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridViewMusicos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de locales: " + ex.Message,
                               "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        private void cargarDatosLocales()
        {
            try
            {
                var datosLocales = HomeSuperUsuarioOrm.SelectLocales();

                // Configurar el DataGridView
                dataGridViewLocales.AutoGenerateColumns = false;
                dataGridViewLocales.DataSource = datosLocales;

                // Configurar las columnas para que usen las propiedades correctas
                dataGridViewLocales.Columns["NombreLocal"].DataPropertyName = "NombreLocal";
                dataGridViewLocales.Columns["CorreoLocal"].DataPropertyName = "CorreoLocal";
                dataGridViewLocales.Columns["Ubicacion"].DataPropertyName = "Ubicacion";
                dataGridViewLocales.Columns["ValoracionTotal"].DataPropertyName = "ValoracionTotal";


                // Configuración de visualización
                dataGridViewLocales.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridViewLocales.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de locales: " + ex.Message,
                               "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        private void autoSeleccionarGrid()
        {
            dataGridViewMusicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewLocales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void configuracionFondoGrid()
        {
            // Definir el color RGB (255, 243, 226)
            Color colorFondo = Color.FromArgb(255, 243, 226);

            // Configurar el color de fondo del DataGridView
            dataGridViewMusicos.BackgroundColor = colorFondo;
            dataGridViewLocales.BackgroundColor = colorFondo;

            // Configurar el color de fondo de las celdas
            dataGridViewMusicos.DefaultCellStyle.BackColor = colorFondo;
            dataGridViewLocales.DefaultCellStyle.BackColor = colorFondo;
        }
    }
}
