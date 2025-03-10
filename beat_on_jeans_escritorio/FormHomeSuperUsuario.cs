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
    public partial class FormHomeSuperUsuario : Form
    {
        public FormHomeSuperUsuario()
        {
            InitializeComponent();
        }

        private void FormHomeSuperUsuario_Load(object sender, EventArgs e)
        {
            DataGridViewBordeRedondo.RedondearBordes(dataGridViewNumUsuarios, 20);
            DataGridViewBordeRedondo.RedondearBordes(dataGridViewUltimosRegistros, 20);
            DataGridViewBordeRedondo.RedondearBordes(dataGridViewGestionUsuarios, 20);
            DataGridViewBordeRedondo.RedondearBordes(dataGridViewNotificaciones, 20);
        }
    }
}
