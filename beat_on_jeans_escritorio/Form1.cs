using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            
            String correoPorDefecto = "example@gmail.com";
            String contrasenaPorDefecto = "123";

            Superusuario superusuario = new Superusuario(1, correoPorDefecto, contrasenaPorDefecto, 1);


            if (textBoxCorreo.Text.Equals(correoPorDefecto) && textBoxContrasena.Text.Equals(contrasenaPorDefecto))
            {
                // Que se dirija al siguiente formulario
                this.Hide();
                
                Form2 formulario2 = new Form2();
                formulario2.ShowDialog();
            }
        }
    }
}
