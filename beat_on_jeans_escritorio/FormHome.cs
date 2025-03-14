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

            // Habilitar barras de desplazamiento en el panel
            panelCargarForms.AutoScroll = true;
            panelCargarForms.AutoScrollMinSize = new Size(800, 600);

            // Cargar el formulario por defecto (Home) al iniciar
            CargarFormulario(new FormHomeSuperUsuario());

            // Manejar el evento Resize
            this.Resize += FormHome_Resize;
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
            Bitmap originalBitmap = new Bitmap(pictureBox.Image);
            int diametro = Math.Min(originalBitmap.Width, originalBitmap.Height);

            Bitmap roundBitmap = new Bitmap(diametro, diametro);

            using (Graphics g = Graphics.FromImage(roundBitmap))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, diametro, diametro);

                g.SetClip(path);
                g.DrawImage(originalBitmap, new Rectangle(0, 0, diametro, diametro));
            }

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

            // Configura la interfaz según el rol del usuario
        }

        // Método para cargar formularios dentro del panel
        private void CargarFormulario(Form formulario)
        {
            // Limpiar el panel antes de cargar un nuevo formulario
            panelCargarForms.Controls.Clear();

            // Configurar el formulario
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill; // Ajustar el formulario al tamaño del panel

            // Agregar el formulario al panel
            panelCargarForms.Controls.Add(formulario);
            formulario.Show();

            // Hacer que el formulario cargado se ajuste al tamaño del panel
            formulario.Resize += (s, e) => AjustarControlesFormulario(formulario);
        }

        // Método que ajusta los controles dentro del formulario cargado
        private void AjustarControlesFormulario(Form formulario)
        {
            // Aquí puedes recorrer los controles del formulario cargado y ajustar sus tamaños y posiciones
            foreach (Control control in formulario.Controls)
            {
                // Ajuste de tamaños y posición para cada control en el formulario cargado
                control.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            }
        }

        // Manejar el evento Resize
        private void FormHome_Resize(object sender, EventArgs e)
        {
            // Ajustar el tamaño del panel al nuevo tamaño del formulario principal
            panelCargarForms.Size = new Size(this.ClientSize.Width - panelCargarForms.Location.X, this.ClientSize.Height - panelCargarForms.Location.Y);

            // Redimensionar el formulario cargado (si existe)
            if (panelCargarForms.Controls.Count > 0 && panelCargarForms.Controls[0] is Form)
            {
                Form formularioCargado = (Form)panelCargarForms.Controls[0];
                formularioCargado.Size = panelCargarForms.Size;

                // Llamar al método que ajusta los controles dentro del formulario cargado
                AjustarControlesFormulario(formularioCargado);
            }
        }

        // Eventos de los botones
        private void buttonHome_Click(object sender, EventArgs e)
        {
            CargarFormulario(new FormHomeSuperUsuario());
        }

        private void buttonGestionUsuarios_Click(object sender, EventArgs e)
        {
            CargarFormulario(new FormGestionUsuarios());
        }

        private void buttonEventos_Click(object sender, EventArgs e)
        {
            CargarFormulario(new FormCalendario());
        }
    }
}
