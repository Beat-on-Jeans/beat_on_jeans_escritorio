using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace beat_on_jeans_escritorio
{
    public class PictureBoxHandler
    {
        public static void AttachHoverBehavior(PictureBox pictureBox, Button button)
        {
            // Inicializar el PictureBox como oculto
            pictureBox.Hide();

            // Agregar los eventos de MouseEnter y MouseLeave
            button.MouseEnter += (sender, e) => pictureBox.Show();
            button.MouseLeave += (sender, e) => pictureBox.Hide();
        }
    }



}
