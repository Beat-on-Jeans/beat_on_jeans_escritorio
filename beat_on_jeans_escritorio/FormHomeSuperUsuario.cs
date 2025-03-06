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
            DataGridViewStyler.RedondearBordes(dataGridViewNumUsuarios, 20);
            DataGridViewStyler.RedondearBordes(dataGridViewUltimosRegistros, 20);
            DataGridViewStyler.RedondearBordes(dataGridViewGestionUsuarios, 20);
            DataGridViewStyler.RedondearBordes(dataGridViewNotificaciones, 20);
        }
    }
}
