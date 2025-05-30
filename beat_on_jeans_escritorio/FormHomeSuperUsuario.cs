﻿using beat_on_jeans_escritorio.Clases;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace beat_on_jeans_escritorio
{
    public partial class FormHomeSuperUsuario : Form
    {
        public FormHomeSuperUsuario()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Se ejecutara la primera vez que se ejecute el formulario y ejecutara los siguientes metodos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormHomeSuperUsuario_Load(object sender, EventArgs e)
        {
            gridBordesRedondos();
            cargarDatosLocales();
            cargarDatosMusicos();
            cargarDatosTickets();
            configurarFondoContenidoGrid();
            autoSeleccionarGrid();
        }

        /// <summary>
        /// Autoselecciona el grid cuando lo clicas, la fila entera.
        /// </summary>
        private void autoSeleccionarGrid()
        {
            dataGridViewMusicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewLocales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTickets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /// <summary>
        /// Carga los datos de Tickets en el dataGridView.
        /// </summary>
        private void cargarDatosTickets()
        {
            try
            {
                // Obtener los tickets
                var tickets = TicketsOrm.SelectTicketsWithIncidentType();

                // Verificar si no hay tickets
                if (tickets == null || !tickets.Any())
                {
                    // Si no hay tickets, aseguramos que el DataGridView esté vacío
                    bindingSourceTickets.DataSource = new List<object>();  // Cargar una lista vacía
                    dataGridViewTickets.DataSource = bindingSourceTickets;
                    dataGridViewTickets.Refresh();  // Refrescar para que el DataGridView esté vacío
                    return;  // Salir del método para evitar el resto del código
                }

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

        /// <summary>
        /// Carga los datos de los Musicos en el dataGridView.
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
            dataGridViewMusicos.Columns["Nombre"].DataPropertyName = "Nombre";
            dataGridViewMusicos.Columns["Correo"].DataPropertyName = "Correo";
            dataGridViewMusicos.Columns["Codigo_Postal"].DataPropertyName = "Ubicacion";

            // Configurar visualizacion
            dataGridViewMusicos.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewMusicos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        /// <summary>
        /// Carga los datos de los Locales en el dataGridView.
        /// </summary>
        private void cargarDatosLocales()
        {
            var locales = UsuariosCSharpOrm.SelectLocales();

            if (locales == null || !locales.Any())
            {
                // Si no hay tickets, aseguramos que el DataGridView esté vacío
                bindingSourceLocales.DataSource = new List<object>();  // Cargar una lista vacía
                bindingSourceLocales.DataSource = bindingSourceLocales;
                dataGridViewLocales.Refresh();  // Refrescar para que el DataGridView esté vacío
                return;  // Salir del método para evitar el resto del código
            }

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

        /// <summary>
        /// Configura el grid con un fondo de color.
        /// </summary>
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

        /// <summary>
        /// Configura el grid con bordes redondos.
        /// </summary>
        private void gridBordesRedondos()
        {
            // Aplicar bordes redondeados a los DataGridView
            DataGridViewBordeRedondo.RedondearBordes(dataGridViewMusicos, 20);
            DataGridViewBordeRedondo.RedondearBordes(dataGridViewLocales, 20);
            DataGridViewBordeRedondo.RedondearBordes(dataGridViewTickets, 20);
        }
    }
}