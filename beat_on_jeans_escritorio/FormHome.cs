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

        /// <summary>
        /// Cargamos los labels con el nombre del usuario y el nombre de su rol.
        /// </summary>
        private void cargarLabels()
        {
            labelNombreUsuario.Text = usuarioActual.Nombre;
            string nombreRol = ObtenerNombreRol(usuarioActual.ROL_ID);
            labelRol.Text = nombreRol;
        }

        /// <summary>
        /// Obtenemos el nombre del rol dependiendo del rolId que tenga el usuario.
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns>Devolvemos el rol al nombre</returns>
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

        /// <summary>
        /// Depende del usuario se le cargara un formulario.
        /// </summary>
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

        /// <summary>
        /// Configuramos la interfaz, algunos usuarios no tienen algunas opciones.
        /// </summary>
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

        /// <summary>
        /// Desde este metodo se cargan los formularios dentro del panel con un pequeño estilo.
        /// </summary>
        /// <param name="formulario"></param>
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

        /// <summary>
        /// Cuando pase el cursor por encima de los botones enseña una imagen.
        /// </summary>
        private void hoverBotones()
        {
            PictureBoxHandler.AttachHoverBehavior(pictureBoxHome, buttonHome);
            PictureBoxHandler.AttachHoverBehavior(pictureBoxEstadistica, buttonSoporte);
            PictureBoxHandler.AttachHoverBehavior(pictureBoxNotificaciones, buttonMapa);
            PictureBoxHandler.AttachHoverBehavior(pictureBoxEventos, buttonEventos);
            PictureBoxHandler.AttachHoverBehavior(pictureBoxGestionUsuarios, buttonGestionUsuarios);
        }

        /// <summary>
        /// Cuando le de click al boton de Home ejecuta el metodo para ajustar el form al panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHome_Click(object sender, EventArgs e)
        {
            cargarFormularioPorRol(); // Recargar el formulario según el rol
        }

        /// <summary>
        /// Cuando le de click al boton de Soporte ejecuta el metodo para ajustar el form al panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSoporte_Click(object sender, EventArgs e)
        {
            CargarFormulario(new FormSoporte());
        }

        /// <summary>
        /// Cuando le de click al boton de Mapa ejecuta el metodo para ajustar el form al panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMapa_Click(object sender, EventArgs e)
        {
            CargarFormulario(new FormMaps());
        }

        /// <summary>
        /// Cuando le de click al boton de Eventos ejecuta el metodo para ajustar el form al panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEventos_Click(object sender, EventArgs e)
        {
            CargarFormulario(new FormCalendario()); // Cargar el formulario de calendario
        }

        /// <summary>
        /// Cuando le de click al boton de Gestion Usuarios ejecuta el metodo para ajustar el form al panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGestionUsuarios_Click(object sender, EventArgs e)
        {
            CargarFormulario(new FormGestionUsuarios(usuarioActual.ROL_ID ?? 0));
        }

        /// <summary>
        /// Cerrará sesión del usuario actual.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();

            FormLogin login = new FormLogin();
            login.Show();
        }
    }
}