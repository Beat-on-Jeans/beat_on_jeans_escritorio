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
    public partial class FormHomeAdmistrador : Form
    {
        public FormHomeAdmistrador()
        {
            InitializeComponent();
        }

        private void FormHomeAdmistrador_Load(object sender, EventArgs e)
        {
            DataGridViewBordeRedondo.RedondearBordes(dataGridViewEventosProgramados, 20);
            DataGridViewBordeRedondo.RedondearBordes(dataGridViewListaMusicosLocales, 20);
            DataGridViewBordeRedondo.RedondearBordes(dataGridViewCambiosMusicosLocales, 20);
        }
    }
}
