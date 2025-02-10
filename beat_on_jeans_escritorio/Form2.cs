using System;
using System.Windows.Forms;

namespace beat_on_jeans_escritorio
{
    public partial class Form2 : Form
    {
        bool sidebarExpand;
        private UsuariosCSharp usuarioActual; // Variable para almacenar el usuario

        // Constructor modificado para recibir el usuario como parámetro
        public Form2(UsuariosCSharp usuario)
        {
            InitializeComponent();
            this.usuarioActual = usuario; // Asignamos el usuario recibido
            configurarInterfaz();
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

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {


                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else 
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width) 
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }

        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }
    }
}
