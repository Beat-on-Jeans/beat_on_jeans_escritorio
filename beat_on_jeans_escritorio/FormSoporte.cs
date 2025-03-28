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
    public partial class FormSoporte: Form
    {
        public FormSoporte()
        {
            InitializeComponent();
        }

        private void FormSoporte_Load(object sender, EventArgs e)
        {
            gridBorderRedondos();
            esconderLabels();
            cargarDatosGrid();
            clickGrid();
        }

        // En el FormSoporte, modifica el método clickGrid y añade el manejador de eventos
        private void clickGrid()
        {
            dataGridViewTickets.CellClick += DataGridViewTickets_CellClick;
        }

        private void DataGridViewTickets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Ignorar clicks en los encabezados de columna
                if (e.RowIndex < 0) return;

                // Obtener la fila seleccionada
                var row = dataGridViewTickets.Rows[e.RowIndex];

                // Obtener los IDs del usuario y técnico
                int usuarioId = Convert.ToInt32(row.Cells["Usuario_ID"].Value);
                int tecnicoId = Convert.ToInt32(row.Cells["Tecnico_ID"].Value);

                // Obtener los nombres
                var (nombreUsuario, nombreTecnico) = TicketsOrm.GetNombresUsuarioYTecnico(usuarioId, tecnicoId);

                // Mostrar los nombres en los labels
                labelNombreUsuario.Text = nombreUsuario;
                labelNombreTecnico.Text = nombreTecnico;

                // Hacer visibles los labels
                labelNombreTecnico.Visible = true;
                label1.Visible = true;
                labelNombreUsuario.Visible = true;
                label2.Visible = true;
                buttonCerrarTicket.Visible = true;
                pictureBox1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los nombres: " + ex.Message,
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void cargarDatosGrid()
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

        private void esconderLabels()
        {
            labelNombreTecnico.Visible = false;
            label1.Visible = false;
            labelNombreUsuario.Visible = false;
            label2.Visible = false;
            buttonCerrarTicket.Visible = false;
            pictureBox1.Visible = false;
        }

        private void gridBorderRedondos()
        {
            DataGridViewBordeRedondo.RedondearBordes(dataGridViewTickets, 20);
        }

        private void buttonCerrarTicket_Click(object sender, EventArgs e)
        {
            // Verificar que hay una fila seleccionada
            if (dataGridViewTickets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un ticket primero.",
                              "Advertencia",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show("¿Estás seguro de que quieres cerrar y eliminar este ticket?",
                                                  "Confirmar cierre",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    int ticketId = Convert.ToInt32(dataGridViewTickets.SelectedRows[0].Cells["ID"].Value);

                    TicketsOrm.DeleteTicket(ticketId);

                    cargarDatosGrid();
                    esconderLabels();

                    MessageBox.Show("Ticket cerrado correctamente.",
                                  "Éxito",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cerrar el ticket: " + ex.Message,
                                  "Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
        }
    }
}
