using System;
using System.Drawing;
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

            Superusuario superusuario = new Superusuario(1, correoPorDefecto, contrasenaPorDefecto, 1);

            // Verificar si las credenciales ingresadas son correctas
            if (textBoxCorreo.Text.Equals(correoPorDefecto) && textBoxContrasena.Text.Equals(contrasenaPorDefecto))
            {
                // Crear el usuario actual (esto se debe obtener de tu lógica de login)
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

        
    }
}
