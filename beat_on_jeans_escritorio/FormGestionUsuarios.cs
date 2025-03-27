using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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
        private string hintText = "Busca al usuario...";
        public FormGestionUsuarios()
        {
            InitializeComponent();

            //Ecoger los roles en la ComboBox
            bindingSourceRoles.DataSource = RolesOrm.Select();

            comboBoxBuscarUsuario = new ComboBox();
            comboBoxBuscarUsuario.Location = new Point(50, 50);
            comboBoxBuscarUsuario.Width = 200;
            comboBoxBuscarUsuario.ForeColor = Color.Gray;
            comboBoxBuscarUsuario.Text = hintText;
            comboBoxBuscarUsuario.GotFocus += RemoveHint;
            comboBoxBuscarUsuario.LostFocus += ShowHint;

            Controls.Add(comboBoxBuscarUsuario);

        }

        private void FormGestionUsuarios_Load(object sender, EventArgs e)
        {
            disenoBotones();
            disenoGrid();
            rellenarUsuarios();
            // Ajusta el tamaño de las columnas al ancho del DataGridView
            dataGridViewUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void comboBoxUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            rellenarUsuarios();
      
        }

        private void rellenarUsuarios()
        {
            Roles _rol = (Roles)comboBoxRoles.SelectedItem;
            if (_rol == null)
            {
                return;
            }

            dataGridViewUsuarios.DataSource = _rol.Usuarios.ToList();

            if (_rol.Nombre_Rol == "Musico")
            {
                var usuariosMusicos = UsuariosCSharpOrm.SelectMusicos();
                dataGridViewUsuarios.DataSource = usuariosMusicos.ToList();

                if (!dataGridViewUsuarios.Columns.Contains("Codigo_Postal"))
                {
                    dataGridViewUsuarios.Columns.Add("Codigo_Postal", "Código Postal");
                }
            }
            else if (_rol.Nombre_Rol == "Local")
            {
                //var usuariosLocales = UsuariosCSharpOrm.SelectLocales();
                //dataGridViewUsuarios.DataSource = usuariosLocales.ToList();

                if (!dataGridViewUsuarios.Columns.Contains("Ubicación"))
                {
                    dataGridViewUsuarios.Columns.Add("Ubicacion", "Ubicación");
                }
            }

            else
            {
                if (dataGridViewUsuarios.Columns.Contains("Codigo_Postal"))
                {
                    dataGridViewUsuarios.Columns.Remove("Codigo_Postal");
                }
            }
        }

        private void dataGridViewUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dataBoundItem = dataGridViewUsuarios.Rows[e.RowIndex].DataBoundItem;

            // Mostramos el codigo postal de Musicos
            if (dataGridViewUsuarios.Columns[e.ColumnIndex].Name == "Codigo_Postal")
            {
                dynamic _usuario = dataBoundItem;
                e.Value = _usuario.Codigo_Postal;
            }
        }

        private void disenoGrid()
        {
            DataGridViewHome.ApplyDesign(dataGridViewUsuarios);
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

        private void label3_Click(object sender, EventArgs e)
        {
            
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RemoveHint(object sender, EventArgs e)
        {
            if (comboBoxBuscarUsuario.ForeColor == Color.Gray)
            {
                comboBoxBuscarUsuario.Text = "";
                comboBoxBuscarUsuario.ForeColor = Color.Black;
            }
        }

        private void ShowHint(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxBuscarUsuario.Text))
            {
                comboBoxBuscarUsuario.ForeColor = Color.Gray;
                comboBoxBuscarUsuario.Text = hintText;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {

        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
