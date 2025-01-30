using System;
using System.Windows.Forms;

namespace beat_on_jeans_escritorio
{
    public partial class Form1 : Form
    {
        public Form1()
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
            // Definir usuario predeterminado con rol
            String correoPorDefecto = "example@gmail.com";
            String contrasenaPorDefecto = "123";

            Superusuario superusuario = new Superusuario(1, correoPorDefecto, contrasenaPorDefecto, 3);

            // Verificar si las credenciales ingresadas son correctas
            if (textBoxCorreo.Text.Equals(correoPorDefecto) && textBoxContrasena.Text.Equals(contrasenaPorDefecto))
            {
                // Crear el usuario actual (esto debería venir de la base de datos o sistema de autenticación real)
                UsuariosCSharp usuarioActual = new UsuariosCSharp(); // Esto se debe obtener de tu lógica de login
                usuarioActual.rol = superusuario.rol; // Asignar el rol basado en el superusuario

                // Ocultar Form1 y mostrar Form2, pasando el usuarioActual
                this.Hide();
                Form2 formulario2 = new Form2(usuarioActual);
                formulario2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas. Inténtalo nuevamente.");
            }
        }
    }
}
