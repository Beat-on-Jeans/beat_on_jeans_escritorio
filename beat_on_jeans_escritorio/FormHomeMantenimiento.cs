using beat_on_jeans_escritorio.Clases;
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

        /// <summary>
        /// Se ejecutara la primera vez que se ejecute este form y redondeara los bordes del grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Carga los datos de los musicos en el dataGridView.
        /// </summary>
        private void cargarDatosMusicos()
        {
            var musicos = UsuariosCSharpOrm.SelectMusicos();

            if (musicos == null || !musicos.Any())
            {
                // Si no hay tickets, aseguramos que el DataGridView esté vacío
                bindingSourceMusicos.DataSource = new List<object>();  // Cargar una lista vacía
                bindingSourceMusicos.DataSource = bindingSourceMusicos;
                dataGridViewMusicos.Refresh();  // Refrescar para que el DataGridView esté vacío
                return;  // Salir del método para evitar el resto del código
            } 

            bindingSourceMusicos.DataSource = musicos;
            dataGridViewMusicos.DataSource = bindingSourceMusicos;

            // Ajustar a los nombres reales de las propiedades
            dataGridViewMusicos.Columns["NombreMusico"].DataPropertyName = "Nombre";
            dataGridViewMusicos.Columns["CorreoMusico"].DataPropertyName = "Correo";
            dataGridViewMusicos.Columns["CodigoPostal"].DataPropertyName = "Ubicacion";

            // Configurar visualizacion
            dataGridViewMusicos.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewMusicos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        /// <summary>
        /// Carga los datos de los locales en el dataGridView.
        /// </summary>
        private void cargarDatosLocales()
        {
            try
            {
                var datosLocales = HomeSuperUsuarioOrm.SelectLocales();

                if (datosLocales == null || !datosLocales.Any())
                {
                    // Si no hay tickets, aseguramos que el DataGridView esté vacío
                    dataGridViewMusicos.DataSource = new List<object>();  // Cargar una lista vacía
                    dataGridViewMusicos.DataSource = dataGridViewMusicos;
                    dataGridViewMusicos.Refresh();  // Refrescar para que el DataGridView esté vacío
                    return;  // Salir del método para evitar el resto del código
                }

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

        /// <summary>
        /// Autoselecciona la columna entera del grid.
        /// </summary>
        private void autoSeleccionarGrid()
        {
            dataGridViewMusicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewLocales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /// <summary>
        /// Configuración del fondo del grid.
        /// </summary>
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
