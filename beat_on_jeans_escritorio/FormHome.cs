using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using beat_on_jeans_escritorio.Models;

namespace beat_on_jeans_escritorio
{
    public partial class FormHome : Form
    {
        private UsuariosCSharp usuarioActual;

        // Constructor que recibe el usuario como parámetro
        public FormHome(UsuariosCSharp usuario)
        {
            InitializeComponent();
            this.usuarioActual = usuario;
            configurarInterfaz();
            configurarImagenRedonda();
            hoverBotones();

            // Cargar el formulario por defecto (Home) al iniciar
            CargarFormulario(new FormHomeSuperUsuario()); // Cambia "FormHomeSuperUsuario" si es necesario
        }

        // Constructor sin parámetros (opcional, por si lo necesitas)
        public FormHome()
        {
            InitializeComponent();
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

        // Método para configurar la interfaz según el rol del usuario
        private void configurarInterfaz()
        {
            if (usuarioActual == null)
            {
                MessageBox.Show("Error: El usuario no está inicializado.");
                return;
            }

            // Configuramos la interfaz según el rol del usuario
            //if (usuarioActual.rol == 1) // Administrador
            //{
            //    buttonGestionSoporte.Enabled = true;
            //    buttonGestionUsuarios.Enabled = true;
            //    buttonGestionMusicos.Enabled = true;
            //    buttonGestionLocales.Enabled = true;
            //    buttonGestionDatosSistema.Enabled = true;
            //    buttonMapas.Enabled = true;
            //}
            //else if (usuarioActual.rol == 2) // Usuario con rol menos privilegios
            //{
            //    buttonGestionSoporte.Enabled = false;
            //    buttonGestionUsuarios.Enabled = false;
            //    buttonGestionMusicos.Enabled = true;
            //    buttonGestionLocales.Enabled = true;
            //    buttonGestionDatosSistema.Enabled = true;
            //    buttonMapas.Enabled = true;
            //}
            //else // Rol básico
            //{
            //    buttonGestionSoporte.Enabled = false;
            //    buttonGestionUsuarios.Enabled = false;
            //    buttonGestionMusicos.Enabled = false;
            //    buttonGestionLocales.Enabled = false;
            //    buttonGestionDatosSistema.Enabled = true;
            //    buttonMapas.Enabled = true;
            //}
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

        // Eventos de los botones

        // Botón Home
        private void buttonHome_Click(object sender, EventArgs e)
        {
            CargarFormulario(new FormHomeSuperUsuario()); // Cargar el formulario correspondiente
        }

        // Botón Gestión de Usuarios
        private void buttonGestionUsuarios_Click(object sender, EventArgs e)
        {
            CargarFormulario(new FormGestionUsuarios()); // Cargar el formulario de gestión de usuarios
        }

        private void panelCargarForms_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonEventos_Click(object sender, EventArgs e)
        {
            CargarFormulario(new FormCalendario()); // Cargar el formulario de gestión de usuarios
        }
    }
}