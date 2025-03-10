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

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {

            String correo = textBoxCorreo.Text;
            String contrasena = textBoxContrasena.Text;
            String mensaje;
            Boolean ValidarCredenciales = true;

            // Definir usuario predeterminado con rol
            //String correoPorDefecto = "example@gmail.com";
            //String contrasenaPorDefecto = "123";

            //Superusuario superusuario = new Superusuario(1, correoPorDefecto, contrasenaPorDefecto, 1);

            ValidarCredenciales = validarCorreoContrasena(correo, contrasena, ValidarCredenciales);

            if (ValidarCredenciales == true)
            {
                Boolean validado = Usuarios.validarUsuarios(correo, contrasena, out mensaje);

                if (validado == true)
                {
                    // Recoger el rolId del usuario
                    //UsuariosCSharp usuarioActual = new UsuariosCSharp.recogerUsuario(correo, contrasena);
                    // Mostrar la landing page
                    //FormHome Home = new FormHome(usuarioActual);
                    //Home.ShowDialog();


                    MessageBox.Show(mensaje, "Resultado del Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Close();
                    //this.Hide();
                }
                else
                {
                    MessageBox.Show(mensaje, "Resultado del Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }



            // Verificar si las credenciales ingresadas son correctas
            //if (textBoxCorreo.Text.Equals(correoPorDefecto) && textBoxContrasena.Text.Equals(contrasenaPorDefecto))
            //{
                // Crear el usuario actual (esto se debe obtener de tu lógica de login)
                //UsuariosCSharp usuarioActual = new UsuariosCSharp(); // Esto se debe obtener de tu lógica de login

                //usuarioActual.rol = superusuario.rol; // Asignar el rol basado en el superusuario

                // Ocultar Form1 y mostrar Form2, pasando el usuarioActual
               
                
            //}
            else
            {
                MessageBox.Show("Credenciales incorrectas. Inténtalo nuevamente.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Establecer el estilo plano para el botón
            buttonRegistrar.FlatStyle = FlatStyle.Flat;
            buttonRegistrar.FlatAppearance.BorderSize = 0;  // Quitar el borde predeterminado

            // Establecer el color de fondo del botón
            buttonRegistrar.BackColor = Color.FromArgb(242, 104, 27);  // Cambia al color que desees

            // Desactivar efectos de hover o clic
            buttonRegistrar.FlatAppearance.MouseOverBackColor = buttonRegistrar.BackColor;  // No cambia el color cuando el mouse pasa por encima
            buttonRegistrar.FlatAppearance.MouseDownBackColor = buttonRegistrar.BackColor;  // No cambia el color cuando se hace clic

            // También desactivar el cambio visual cuando se hace clic en el botón
            buttonRegistrar.FlatAppearance.MouseDownBackColor = buttonRegistrar.BackColor;  // Asegura que no se resalte al hacer clic

           
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
