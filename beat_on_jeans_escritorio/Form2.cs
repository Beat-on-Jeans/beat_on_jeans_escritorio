using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace beat_on_jeans_escritorio
{
    public partial class Form2 : Form
    {
        bool sidebarExpand;
        private UsuariosCSharp usuarioActual; // Variable para almacenar el usuario
        private bool isHovered = false;

        // Constructor modificado para recibir el usuario como parámetro
        public Form2(UsuariosCSharp usuario)
        {
            InitializeComponent();
            this.usuarioActual = usuario; // Asignamos el usuario recibido
            configurarInterfaz();
            configurarImagenRedonda();
            hoverBotones();
           
        
        }

        private void hoverBotones()
        {
            // Inicializar PictureBox como invisible
            pictureBoxHome.Hide();

            // Cuando el cursor entra en el botón
            buttonHome.MouseEnter += (sender, e) =>
            {
                // Mostrar PictureBox cuando el cursor pasa por encima del botón
                pictureBoxHome.Show();
            };

            // Cuando el cursor sale del botón
            buttonHome.MouseLeave += (sender, e) =>
            {
                // Ocultar PictureBox cuando el cursor sale del área del botón
                pictureBoxHome.Hide();
            };
        }


        private void configurarImagenRedonda()
        {
            // Crear un grafico a partir de la imagen actual.
            Bitmap originalBitmap = new Bitmap(pictureBox.Image);
            int diametro = Math.Min(originalBitmap.Width, pictureBox.Image.Height);

            // Crear una nueva imagen con el mismo tamaño que la imagen
            Bitmap roundBitmap = new Bitmap(diametro, diametro);

            // Crear un objeto Graphics para dibujar la nueva imagen
            using (Graphics g = Graphics.FromImage(roundBitmap))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);  // Fondo transparente

                // Crea una ruta de gráficos con una forma circular
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, diametro, diametro);

                // Establece la región del gráfico como la forma circular
                g.SetClip(path);

                // Dibuja la imagen original en la imagen redonda
                g.DrawImage(originalBitmap, new Rectangle(0, 0, diametro, diametro));
            }

            // Asigna la imagen redonda al PictureBox
            pictureBox.Image = roundBitmap;
        }

        private void configurarInterfaz()
        {
            if (usuarioActual == null)
            {
                MessageBox.Show("Error: El usuario no está inicializado.");
                return;
            }

            // Configuramos la interfaz según el rol del usuario
            if (usuarioActual.rol == 1) // Administrador
            {
                buttonGestionSoporte.Enabled = true;
                buttonGestionUsuarios.Enabled = true;
                buttonGestionMusicos.Enabled = true;
                buttonGestionLocales.Enabled = true;
                buttonGestionDatosSistema.Enabled = true;
                buttonMapas.Enabled = true;
            }
            else if (usuarioActual.rol == 2) // Usuario con rol menos privilegios
            {
                buttonGestionSoporte.Enabled = false;
                buttonGestionUsuarios.Enabled = false;
                buttonGestionMusicos.Enabled = true;
                buttonGestionLocales.Enabled = true;
                buttonGestionDatosSistema.Enabled = true;
                buttonMapas.Enabled = true;
            }
            else // Rol básico
            {
                buttonGestionSoporte.Enabled = false;
                buttonGestionUsuarios.Enabled = false;
                buttonGestionMusicos.Enabled = false;
                buttonGestionLocales.Enabled = false;
                buttonGestionDatosSistema.Enabled = true;
                buttonMapas.Enabled = true;
            }
        }

        private void buttonMapas_Click(object sender, EventArgs e)
        {
            this.Hide();

            FormMaps maps = new FormMaps();
            maps.ShowDialog();
        }

        private void buttonGestionUsuarios_Click(object sender, EventArgs e)
        {
            this.Hide();

            FormGestionUsuarios usuarios = new FormGestionUsuarios();
            usuarios.ShowDialog();
        }

        
    }
}
