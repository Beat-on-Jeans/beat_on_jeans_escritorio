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
            configurarImagenRedonda();
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
            // cambiar roles a 3,4,5.
            switch (roleId)
            {
                case 1:
                    return "Superusuario";
                case 2:
                    return "Administrador";
                case 3:
                    return "Mantenimiento de Datos";
                default:
                    return "Rol Desconocido";
            }
        }

        private void cargarFormularioPorRol()
        {
            if (usuarioActual.ROL_ID == 1) // Superusuario
            {
                CargarFormulario(new FormHomeSuperUsuario());
            }
            else if (usuarioActual.ROL_ID == 2) // Admin
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
            if (usuarioActual.ROL_ID == 1) // Superusuario
            {
                buttonHome.Enabled = true;
                buttonEstadisticas.Enabled = true;
                buttonRegistro.Enabled = true;
                buttonNotificaciones.Enabled = true;
                buttonEventos.Enabled = true;
                buttonGestionUsuarios.Enabled = true;
                buttonConfiguracion.Enabled = true;

            }
            else if (usuarioActual.ROL_ID == 2) // Usuario normal
            {
                buttonHome.Enabled = true;
                buttonEstadisticas.Enabled = true;
                buttonRegistro.Enabled = true;
                buttonNotificaciones.Enabled = true;
                buttonEventos.Enabled = true;
                buttonGestionUsuarios.Enabled = false;
                buttonConfiguracion.Enabled = true;
            }
            else // Rol básico
            {
                buttonHome.Enabled = true;
                buttonEstadisticas.Enabled = true;
                buttonRegistro.Enabled = true;
                buttonNotificaciones.Enabled = true;
                buttonEventos.Enabled = true;
                buttonGestionUsuarios.Enabled = false;
                buttonConfiguracion.Enabled = true;
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

        // Método para redondear la imagen del PictureBox
        private void configurarImagenRedonda()
        {
            // Crear un gráfico a partir de la imagen actual.
            Bitmap originalBitmap = new Bitmap(pictureBox.Image);
            int diametro = Math.Min(originalBitmap.Width, originalBitmap.Height);

            // Crear una nueva imagen con el mismo tamaño que la imagen
            Bitmap roundBitmap = new Bitmap(diametro, diametro);

            // Crear un objeto Graphics para dibujar la nueva imagen
            using (Graphics g = Graphics.FromImage(roundBitmap))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);  // Fondo transparente

                // Crear una ruta de gráficos con una forma circular
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, diametro, diametro);

                // Establecer la región del gráfico como la forma circular
                g.SetClip(path);

                // Dibujar la imagen original en la imagen redonda
                g.DrawImage(originalBitmap, new Rectangle(0, 0, diametro, diametro));
            }

            // Asignar la imagen redonda al PictureBox
            pictureBox.Image = roundBitmap;
        }

        // Método para configurar el comportamiento de hover en los botones
        private void hoverBotones()
        {
            PictureBoxHandler.AttachHoverBehavior(pictureBoxHome, buttonHome);
            PictureBoxHandler.AttachHoverBehavior(pictureBoxEstadistica, buttonEstadisticas);
            PictureBoxHandler.AttachHoverBehavior(pictureBoxRegistro, buttonRegistro);
            PictureBoxHandler.AttachHoverBehavior(pictureBoxNotificaciones, buttonNotificaciones);
            PictureBoxHandler.AttachHoverBehavior(pictureBoxEventos, buttonEventos);
            PictureBoxHandler.AttachHoverBehavior(pictureBoxGestionUsuarios, buttonGestionUsuarios);
            PictureBoxHandler.AttachHoverBehavior(pictureBoxConf, buttonConfiguracion);
        }

        // Eventos de los botones

        // Botón Home
        private void buttonHome_Click(object sender, EventArgs e)
        {
            cargarFormularioPorRol(); // Recargar el formulario según el rol
        }

        // Botón Gestión de Usuarios
        private void buttonGestionUsuarios_Click(object sender, EventArgs e)
        {
            CargarFormulario(new FormGestionUsuarios()); // Cargar el formulario de gestión de usuarios
        }

        private void panelCargarForms_Paint(object sender, PaintEventArgs e)
        {
            // No es necesario hacer nada aquí
        }

        private void buttonEventos_Click(object sender, EventArgs e)
        {
            CargarFormulario(new FormCalendario()); // Cargar el formulario de calendario
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();

            FormLogin login = new FormLogin();
            login.Show();
        }
    }
}