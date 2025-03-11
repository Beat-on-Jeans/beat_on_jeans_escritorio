using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using beat_on_jeans_escritorio.Models;

namespace beat_on_jeans_escritorio
{
    public partial class FormGestionUsuarios : Form
    {
        public FormGestionUsuarios()
        {
            InitializeComponent();
           
        }

        private void FormGestionUsuarios_Load(object sender, EventArgs e)
        {
            disenoBotones();
            disenoGrid();

            bindingSourceRoles.DataSource = RolesOrm.Select();
            rellenarUsuariosRoles();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            rellenarUsuariosRoles();
        }

        private void rellenarUsuariosRoles()
        {
            Roles _roles = comboBoxUsuarios.SelectedItem as Roles;
            if (_roles != null)
            {
                bindingSourceUsuariosCSharp.DataSource = _roles.UsuariosCSharp.ToList();
            }
            else
            {
                // Handle the case where _roles is null
                bindingSourceUsuariosCSharp.DataSource = null;
            }
        }
        private void disenoGrid()
        {
            DataGridViewHome.ApplyDesign(dataGridView2);
        }
        private void disenoBotones()
        {
            // BOTON MODIFICAR
            buttonModificar.BackColor = Color.FromArgb(255, 243, 226);

            buttonModificar.FlatAppearance.MouseOverBackColor = buttonModificar.BackColor;
            buttonModificar.FlatAppearance.MouseDownBackColor = buttonModificar.BackColor;
            buttonModificar.FlatAppearance.MouseDownBackColor = buttonModificar.BackColor;

            // BOTON ELIMINAR
            buttonEliminar.BackColor = Color.FromArgb(46, 196, 182);

            buttonEliminar.FlatAppearance.MouseOverBackColor = buttonEliminar.BackColor;
            buttonEliminar.FlatAppearance.MouseDownBackColor = buttonEliminar.BackColor;
            buttonEliminar.FlatAppearance.MouseDownBackColor = buttonEliminar.BackColor;

            // BOTON NUEVO USUARIO
            buttonNuevoUsuario.BackColor = Color.FromArgb(242, 104, 27);

            buttonNuevoUsuario.FlatAppearance.MouseOverBackColor = buttonNuevoUsuario.BackColor;
            buttonNuevoUsuario.FlatAppearance.MouseDownBackColor = buttonNuevoUsuario.BackColor;
            buttonNuevoUsuario.FlatAppearance.MouseDownBackColor = buttonNuevoUsuario.BackColor;
        }
    }
}
