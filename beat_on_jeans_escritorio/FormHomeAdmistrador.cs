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
            autoSelecccionarGrid();
            cargarDatosActuaciones();
            cargarDatosMusicos();
            cargarDatosLocales();
            configurarFondoContenidoGrid();
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

        private void cargarDatosActuaciones()
        {
            var actuaciones = ActuacionesHomeOrm.GetActuacionesConNombres();

            bindingSourceActuaciones.DataSource = actuaciones;

            dataGridViewEventosProgramados.DataSource = bindingSourceActuaciones;

            dataGridViewEventosProgramados.Columns["Fecha"].DataPropertyName = "Fecha";
            dataGridViewEventosProgramados.Columns["Local"].DataPropertyName = "Local";
            dataGridViewEventosProgramados.Columns["Musico"].DataPropertyName = "Musico";

            // Configurar visualizacion
            dataGridViewEventosProgramados.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewEventosProgramados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void autoSelecccionarGrid()
        {
            dataGridViewMusicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewLocales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewEventosProgramados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void configurarFondoContenidoGrid()
        {
            // Definir el color RGB (255, 243, 226)
            Color colorFondo = Color.FromArgb(255, 243, 226);

            // Configurar el color de fondo del DataGridView
            dataGridViewMusicos.BackgroundColor = colorFondo;
            dataGridViewLocales.BackgroundColor = colorFondo;
            dataGridViewEventosProgramados.BackgroundColor = colorFondo;

            // Configurar el color de fondo de las celdas
            dataGridViewMusicos.DefaultCellStyle.BackColor = colorFondo;
            dataGridViewLocales.DefaultCellStyle.BackColor = colorFondo;
            dataGridViewEventosProgramados.DefaultCellStyle.BackColor = colorFondo;
        }

        

        private void FormHomeAdmistrador_Load(object sender, EventArgs e)
        {
            DataGridViewBordeRedondo.RedondearBordes(dataGridViewEventosProgramados, 20);
            DataGridViewBordeRedondo.RedondearBordes(dataGridViewMusicos, 20);
            DataGridViewBordeRedondo.RedondearBordes(dataGridViewLocales, 20);
        }
    }
}
