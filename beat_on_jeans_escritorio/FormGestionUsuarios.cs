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
    public partial class FormGestionUsuarios : Form
    {
        public FormGestionUsuarios()
        {
            InitializeComponent();
            hoverBotones();
        }

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

      
    }
}
