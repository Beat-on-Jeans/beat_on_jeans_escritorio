using System;
using System.Drawing;
using System.Windows.Forms;
using beat_on_jeans_escritorio.Models;

namespace beat_on_jeans_escritorio
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            textBoxContrasena.UseSystemPasswordChar = true;
        }

        private void buttonIniciarSesion_Click(object sender, EventArgs e)
        {
            String correo = textBoxCorreo.Text;
            String contrasena = textBoxContrasena.Text;
            String mensaje;
            Boolean ValidarCredenciales = true;

            ValidarCredenciales = validarCorreoContrasena(correo, contrasena, ValidarCredenciales);

            if (ValidarCredenciales == true)
            {
                UsuariosCSharp usuarioActual = UsuarioCSharpOrm.validarUsuario(correo, contrasena, out mensaje);

                if (usuarioActual == null)
                {

                    MessageBox.Show(mensaje, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    // Pasarle el usuario actual
                    FormHome formulario2 = new FormHome(usuarioActual);
                    MessageBox.Show(mensaje, "Validación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formulario2.ShowDialog();
                }
            }
        }

        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Desactivar efectos de hover o clic
            buttonRegistrar.FlatAppearance.MouseOverBackColor = buttonRegistrar.BackColor;  
            buttonRegistrar.FlatAppearance.MouseDownBackColor = buttonRegistrar.BackColor;  

            // También desactivar el cambio visual cuando se hace clic en el botón
            buttonRegistrar.FlatAppearance.MouseDownBackColor = buttonRegistrar.BackColor;

            // Desactivar efectos de hover o clic
            buttonIniciarSesion.FlatAppearance.MouseOverBackColor = buttonIniciarSesion.BackColor;
            buttonIniciarSesion.FlatAppearance.MouseDownBackColor = buttonIniciarSesion.BackColor;

            // También desactivar el cambio visual cuando se hace clic en el botón
            buttonIniciarSesion.FlatAppearance.MouseDownBackColor = buttonIniciarSesion.BackColor;


        }

        private static Boolean validarCorreoContrasena(String correu, String contrasenya, Boolean validar)
        {

            if (string.IsNullOrEmpty(correu))
            {
                MessageBox.Show("Por favor, introduce tu correo electrónico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validar = false;
            }

            if (string.IsNullOrEmpty(contrasenya))
            {
                MessageBox.Show("Por favor, introduce tu contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validar = false;
            }

            return validar;
        }


    }
}
