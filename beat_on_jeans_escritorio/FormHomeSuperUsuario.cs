using beat_on_jeans_escritorio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            cargarDatosMusicos();
            cargarDatosLocales();
            cargarDatosTickets();
            configurarFondoContenidoGrid();
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

            // Configurar el color de fondo de las filas alternas (si las hay)
            dataGridViewMusicos.AlternatingRowsDefaultCellStyle.BackColor = colorFondo;
            dataGridViewLocales.AlternatingRowsDefaultCellStyle.BackColor = colorFondo;
            dataGridViewTickets.AlternatingRowsDefaultCellStyle.BackColor = colorFondo;
        }

        private void cargarDatosTickets()
        {
            // Obtener la lista de tickets de soporte desde la base de datos
          //  List<Soporte> tickets = SoporteOrm.Select();

            // Asignar la lista de tickets al DataGridView
           // dataGridViewTickets.DataSource = tickets;

            // Hacer que el DataGridView sea de solo lectura
            dataGridViewTickets.ReadOnly = true;

            // Configurar el DataGridView para que genere automáticamente las columnas
            dataGridViewTickets.AutoGenerateColumns = true;

            // Asegurarse de que las columnas estén visibles
            foreach (DataGridViewColumn column in dataGridViewTickets.Columns)
            {
                column.Visible = true;
            }
        }

        private void cargarDatosLocales()
        {
            // Obtener la lista de locales desde la base de datos
           // List<Locales> locales = LocalOrm.Select();

            // Asignar la lista de locales al DataGridView
           // dataGridViewLocales.DataSource = locales;

            // Hacer que el DataGridView sea de solo lectura
            dataGridViewLocales.ReadOnly = true;

            // Configurar el DataGridView para que genere automáticamente las columnas
            dataGridViewLocales.AutoGenerateColumns = true;

            // Asegurarse de que las columnas estén visibles
            foreach (DataGridViewColumn column in dataGridViewLocales.Columns)
            {
                column.Visible = true;
            }
        }

        private void cargarDatosMusicos()
        {
            // Obtener la lista de músicos desde la base de datos
           // List<Musicos> musicos = MusicoOrm.Select();

            // Asignar la lista de músicos al DataGridView
           // dataGridViewMusicos.DataSource = musicos;

            // Hacer que el DataGridView sea de solo lectura
            dataGridViewMusicos.ReadOnly = true;

            // Configurar el DataGridView para que genere automáticamente las columnas
            dataGridViewMusicos.AutoGenerateColumns = true;

            // Asegurarse de que las columnas estén visibles
            foreach (DataGridViewColumn column in dataGridViewMusicos.Columns)
            {
                column.Visible = true;
            }
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