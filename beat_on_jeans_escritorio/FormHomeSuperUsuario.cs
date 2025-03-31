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
            configurarFondoContenidoGrid();
            autoSeleccionarGrid();
        }

        private void autoSeleccionarGrid()
        {
            dataGridViewMusicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewLocales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTickets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void cargarDatosTickets()
        {
            try
            {
                // Obtener los tickets
                var tickets = TicketsOrm.SelectTicketsWithIncidentType();

                // Configurar el origen de datos
                bindingSourceTickets.DataSource = tickets;
                dataGridViewTickets.DataSource = bindingSourceTickets;

                // Configurar el mapeo de columnas (asegúrate que los nombres coincidan exactamente)
                dataGridViewTickets.Columns["ID"].DataPropertyName = "ID";
                dataGridViewTickets.Columns["Usuario_ID"].DataPropertyName = "Usuario_ID";
                dataGridViewTickets.Columns["Tecnico_ID"].DataPropertyName = "Tecnico_ID";
                dataGridViewTickets.Columns["TipoIncidencia"].DataPropertyName = "TipoIncidencia";
                dataGridViewTickets.Columns["Fecha_Creacion"].DataPropertyName = "Fecha_Creacion";
                dataGridViewTickets.Columns["Fecha_Cierre"].DataPropertyName = "Fecha_Cierre";

                // Formato de fechas
                dataGridViewTickets.Columns["Fecha_Creacion"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridViewTickets.Columns["Fecha_Cierre"].DefaultCellStyle.Format = "dd/MM/yyyy";

                // Configurar visualización
                dataGridViewTickets.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridViewTickets.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridViewTickets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Actualizar la vista
                dataGridViewTickets.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tickets: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método auxiliar para agregar columnas
        private void AddColumn(string propertyName, string headerText, int width)
        {
            dataGridViewTickets.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = propertyName,
                HeaderText = headerText,
                Width = width,
                Name = propertyName
            });
        }

        private void cargarDatosMusicos()
        {
            var musicos = UsuariosCSharpOrm.SelectMusicos();

            bindingSourceMusicos.DataSource = musicos;
            dataGridViewMusicos.DataSource = bindingSourceMusicos;

            // Ajustar a los nombres reales de las propiedades
            dataGridViewMusicos.Columns["Nombre"].DataPropertyName = "Nombre";
            dataGridViewMusicos.Columns["Correo"].DataPropertyName = "Correo";
            dataGridViewMusicos.Columns["Codigo_Postal"].DataPropertyName = "Codigo_Postal";

            // Configurar visualizacion
            dataGridViewMusicos.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewMusicos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void cargarDatosLocales()
        {
            var locales = UsuariosCSharpOrm.SelectLocales();

            bindingSourceLocales.DataSource = locales;
            dataGridViewLocales.DataSource = bindingSourceLocales;

            // Ajustar a los nombres reales de las propiedades
            dataGridViewLocales.Columns["NombreLocal"].DataPropertyName = "NombreLocal";
            dataGridViewLocales.Columns["CorreoLocal"].DataPropertyName = "CorreoLocal";
            dataGridViewLocales.Columns["ValoracionMedia"].DataPropertyName = "ValoracionMedia";
            dataGridViewLocales.Columns["Ubicacion"].DataPropertyName = "Ubicacion";

            // Configurar visualizacion
            dataGridViewLocales.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewLocales.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void configurarFondoContenidoGrid()
        {
            // Definir el color RGB (255, 243, 226)
            Color colorFondo = Color.FromArgb(255, 243, 226);

            // Configurar el color de fondo del DataGridView
            dataGridViewMusicos.BackgroundColor = colorFondo;
            dataGridViewLocales.BackgroundColor = colorFondo;
            dataGridViewTickets.BackgroundColor = colorFondo;

            // Configurar el color de fondo de las celdas
            dataGridViewMusicos.DefaultCellStyle.BackColor = colorFondo;
            dataGridViewLocales.DefaultCellStyle.BackColor = colorFondo;
            dataGridViewTickets.DefaultCellStyle.BackColor = colorFondo;
        }

        

        private void gridBordesRedondos()
        {
            // Aplicar bordes redondeados a los DataGridView
            DataGridViewBordeRedondo.RedondearBordes(dataGridViewMusicos, 20);
            DataGridViewBordeRedondo.RedondearBordes(dataGridViewLocales, 20);
            DataGridViewBordeRedondo.RedondearBordes(dataGridViewTickets, 20);
        }
    }
}