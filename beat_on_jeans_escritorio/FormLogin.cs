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
            UsuariosCSharpOrm.Select();
        }

        /// <summary>
        /// Cuando le da al boton de iniciar sesión hace las verificaciones necesarias para dejarte entrar a la aplicación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonIniciarSesion_Click(object sender, EventArgs e)
        {
            String correo = textBoxCorreo.Text;
            String contrasena = textBoxContrasena.Text;
            String mensaje;
            Boolean ValidarCredenciales = true;

            ValidarCredenciales = validarCorreoContrasena(correo, contrasena, ValidarCredenciales);


            if (ValidarCredenciales == true)
            {
                  
                Usuarios usuarioActual = UsuariosCSharpOrm.validarUsuario(correo, contrasena, out mensaje);

                if (usuarioActual == null)
                {

                    MessageBox.Show(mensaje, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    //Pasarle el usuario actual
                    FormHome formulario2 = new FormHome(usuarioActual);
                    formulario2.Show();
                    this.Hide(); // Ocultar el formulario actual
                    formulario2.FormClosed += (s, args) => this.Close(); // Cerrar el formulario actual cuando se cierre el nuevo formulario
                }
            }
        }

        /// <summary>
        /// Se ejecuta la primera vez que ejecutas el formulario, desactiva el hover de los botones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Desactivar efectos de hover o clic
            buttonIniciarSesion.FlatAppearance.MouseOverBackColor = buttonIniciarSesion.BackColor;
            buttonIniciarSesion.FlatAppearance.MouseDownBackColor = buttonIniciarSesion.BackColor;

            // También desactivar el cambio visual cuando se hace clic en el botón
            buttonIniciarSesion.FlatAppearance.MouseDownBackColor = buttonIniciarSesion.BackColor;
        }

        /// <summary>
        /// Valida el correo y contraseña del usuario.
        /// </summary>
        /// <param name="correu"></param>
        /// <param name="contrasenya"></param>
        /// <param name="validar"></param>
        /// <returns>Devuelve si esta validado o no</returns>
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

        /// <summary>
        /// Cuando se cierre que la aplicación se cierre.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
