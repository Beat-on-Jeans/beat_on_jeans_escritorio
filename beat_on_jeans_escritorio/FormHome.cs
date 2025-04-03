using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using beat_on_jeans_escritorio.Models;

namespace beat_on_jeans_escritorio
{
    public partial class FormHome : Form
    {
        private Usuarios usuarioActual;

        // Constructor que recibe el usuario como parámetro
        public FormHome(Usuarios usuario)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.usuarioActual = usuario;

            // Configurar la interfaz y cargar el formulario según el rol
            configurarInterfaz();
            cargarFormularioPorRol();
            cargarLabels();
            hoverBotones();
        }

        private void cargarLabels()
        {

            labelNombreUsuario.Text = usuarioActual.Nombre;
            string nombreRol = ObtenerNombreRol(usuarioActual.ROL_ID);
            labelRol.Text = nombreRol;
        }

        private string ObtenerNombreRol(int? roleId)
        {
            switch (roleId)
            {
                case 3:
                    return "Superusuario";
                case 4:
                    return "Administrador";
                case 5:
                    return "Mantenimiento";
                default:
                    return "Rol Desconocido";
            }
        }

        private void cargarFormularioPorRol()
        {
            if (usuarioActual.ROL_ID == 3) // Superusuario
            {
                CargarFormulario(new FormHomeSuperUsuario());
            }
            else if (usuarioActual.ROL_ID == 4) // Admin
            {
                CargarFormulario(new FormHomeAdmistrador());
            }
            else // Mantenimiento
            {
                CargarFormulario(new FormHomeMantenimiento());
            }
        }

        private void configurarInterfaz()
        {
            // Configuramos la interfaz según el rol del usuario
            if (usuarioActual.ROL_ID == 3) // Superusuario
            {
                buttonHome.Enabled = true;
                buttonSoporte.Enabled = true;
                buttonMapa.Enabled = true;
                buttonEventos.Enabled = true;
                buttonGestionUsuarios.Enabled = true;

            }
            else if (usuarioActual.ROL_ID == 4) // Usuario normal
            {
                buttonHome.Enabled = true;
                buttonSoporte.Enabled = false;
                buttonMapa.Enabled = true;
                buttonEventos.Enabled = true;
                buttonGestionUsuarios.Enabled = true;
            }
            else // Rol básico
            {
                buttonHome.Enabled = true;
                buttonSoporte.Enabled = false;
                buttonMapa.Enabled = true;
                buttonEventos.Enabled = true;
                buttonGestionUsuarios.Enabled = true;
            }
        }

        // Método para cargar formularios dentro del panel
        private void CargarFormulario(Form formulario)
        {
            // Limpiar el panel antes de cargar un nuevo formulario
            panelCargarForms.Controls.Clear();

            // Configurar el formulario
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            // Agregar el formulario al panel
            panelCargarForms.Controls.Add(formulario);
            formulario.Show();
        }

        private void hoverBotones()
        {
            PictureBoxHandler.AttachHoverBehavior(pictureBoxHome, buttonHome);
            PictureBoxHandler.AttachHoverBehavior(pictureBoxEstadistica, buttonSoporte);
            PictureBoxHandler.AttachHoverBehavior(pictureBoxNotificaciones, buttonMapa);
            PictureBoxHandler.AttachHoverBehavior(pictureBoxEventos, buttonEventos);
            PictureBoxHandler.AttachHoverBehavior(pictureBoxGestionUsuarios, buttonGestionUsuarios);

        }

        // Eventos de los botones

        // Botón Home
        private void buttonHome_Click(object sender, EventArgs e)
        {
            cargarFormularioPorRol(); // Recargar el formulario según el rol
        }

        private void buttonSoporte_Click(object sender, EventArgs e)
        {
            CargarFormulario(new FormSoporte());
        }

        private void buttonMapa_Click(object sender, EventArgs e)
        {
            CargarFormulario(new FormMaps());
        }

        private void buttonEventos_Click(object sender, EventArgs e)
        {
            CargarFormulario(new FormCalendario()); // Cargar el formulario de calendario
        }

        private void buttonGestionUsuarios_Click(object sender, EventArgs e)
        {
            CargarFormulario(new FormGestionUsuarios(usuarioActual.ROL_ID ?? 0));
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();

            FormLogin login = new FormLogin();
            login.Show();
        }
    }
}