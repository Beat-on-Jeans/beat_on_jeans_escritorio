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
    public partial class FormHomeMantenimiento : Form
    {
        public FormHomeMantenimiento()
        {
            InitializeComponent();
        }

        private void FormHomeMantenimiento_Load(object sender, EventArgs e)
        {
            DataGridViewStyler.RedondearBordes(dataGridViewGestionMusicosLocales, 20);
            DataGridViewStyler.RedondearBordes(dataGridViewListaModificaciones, 20);
            DataGridViewStyler.RedondearBordes(dataGridViewHistorialModificaciones, 20);
        }
    }
}
