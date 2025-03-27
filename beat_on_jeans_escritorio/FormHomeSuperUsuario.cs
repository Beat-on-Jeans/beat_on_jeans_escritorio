using beat_on_jeans_escritorio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace beat_on_jeans_escritorio
{
    public partial class FormHomeSuperUsuario : Form
    {
        public FormHomeSuperUsuario()
        {
            InitializeComponent();
        }

        private void FormHomeSuperUsuario_Load(object sender, EventArgs e)
        {
            gridBordesRedondos();
            cargarDatosLocales();
            cargarDatosMusicos();
            cargarDatosTickets();
            cargarJsonRegistro();
            configurarFondoContenidoGrid();
            autoSeleccionarGrid();
        }

        private void autoSeleccionarGrid()
        {
            dataGridViewMusicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewLocales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTickets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUltimosRegistros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void cargarJsonRegistro()
        {
            
        }

        private void cargarDatosTickets()
        {
            try
            {
                // Obtener los datos de los tickets con el tipo de incidencia
                var tickets = TicketsOrm.SelectTicketsWithIncidentType();

                // Configurar el DataGridView
                dataGridViewTickets.AutoGenerateColumns = false;
                dataGridViewTickets.DataSource = tickets;

                    // Configurar las propiedades de las columnas
                    dataGridViewTickets.Columns["ID"].DataPropertyName = "ID";
                    dataGridViewTickets.Columns["Usuario_ID"].DataPropertyName = "Usuario_ID";
                    dataGridViewTickets.Columns["Tecnico_ID"].DataPropertyName = "Tecnico_ID";
                    dataGridViewTickets.Columns["TipoIncidencia"].DataPropertyName = "TipoIncidencia";
                    dataGridViewTickets.Columns["Fecha_Creacion"].DataPropertyName = "Fecha_Creacion";
                    dataGridViewTickets.Columns["Fecha_Cierre"].DataPropertyName = "Fecha_Cierre";

                    // Formato de fechas
                    dataGridViewTickets.Columns["Fecha_Creacion"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    dataGridViewTickets.Columns["Fecha_Cierre"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                

                // Configuración de visualización
                dataGridViewTickets.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridViewTickets.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los tickets: " + ex.Message,
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void cargarDatosMusicos()
        {
            try
            {
                // Obtener los datos de los locales
                var datosMusicos = MusicosOrm.SelectMusicosInfo();

                // Configurar el DataGridView
                dataGridViewMusicos.AutoGenerateColumns = false;
                dataGridViewMusicos.DataSource = datosMusicos;

                // Configurar las columnas para que usen las propiedades correctas
                dataGridViewMusicos.Columns["NombreMusico"].DataPropertyName = "NombreMusico";
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
                var datosLocales = LocalesOrm.SelectLocalesInfo();

                dataGridViewLocales.AutoGenerateColumns = false;
                dataGridViewLocales.DataSource = datosLocales;

                dataGridViewLocales.Columns["NombreLocal"].DataPropertyName = "NombreLocal";
                dataGridViewLocales.Columns["ValoracionMedia"].DataPropertyName = "ValoracionMedia";
                dataGridViewLocales.Columns["Ubicacion"].DataPropertyName = "Ubicacion";

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

        private void configurarFondoContenidoGrid()
        {
            // Definir el color RGB (255, 243, 226)
            Color colorFondo = Color.FromArgb(255, 243, 226);

            // Configurar el color de fondo del DataGridView
            dataGridViewMusicos.BackgroundColor = colorFondo;
            dataGridViewLocales.BackgroundColor = colorFondo;
            dataGridViewTickets.BackgroundColor = colorFondo;
            dataGridViewUltimosRegistros.BackgroundColor = colorFondo;

            // Configurar el color de fondo de las celdas
            dataGridViewMusicos.DefaultCellStyle.BackColor = colorFondo;
            dataGridViewLocales.DefaultCellStyle.BackColor = colorFondo;
            dataGridViewTickets.DefaultCellStyle.BackColor = colorFondo;
            dataGridViewUltimosRegistros.DefaultCellStyle.BackColor = colorFondo;
        }

        

        private void gridBordesRedondos()
        {
            // Aplicar bordes redondeados a los DataGridView
            DataGridViewBordeRedondo.RedondearBordes(dataGridViewMusicos, 20);
            DataGridViewBordeRedondo.RedondearBordes(dataGridViewLocales, 20);
            DataGridViewBordeRedondo.RedondearBordes(dataGridViewTickets, 20);
            DataGridViewBordeRedondo.RedondearBordes(dataGridViewUltimosRegistros, 20);
        }
    }
}