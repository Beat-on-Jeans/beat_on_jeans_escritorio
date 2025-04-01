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
using beat_on_jeans_escritorio.Clases;
using beat_on_jeans_escritorio.Models;

namespace beat_on_jeans_escritorio
{
    public partial class FormGestionUsuarios : Form

    {
        private string hintText = "Busca al usuario...";
        public FormGestionUsuarios()
        {
            InitializeComponent();

            // Ecoger los roles en la ComboBox
            bindingSourceRoles.DataSource = RolesOrm.Select();

            // Hacer que comboBoxRoles sea de solo lectura
            comboBoxRoles.DropDownStyle = ComboBoxStyle.DropDownList;

            // Hacer que comboBoxAccionUsuario sea de solo lectura
            comboBoxAccionUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void FormGestionUsuarios_Load(object sender, EventArgs e)
        {
            disenoBotones();
            disenoGrid();
            rellenarUsuarios();
            dataGridViewUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Añadir valores a comboBoxAccionUsuario
            comboBoxAccionUsuario.Items.Add("Crear");
            comboBoxAccionUsuario.Items.Add("Modificar");
            comboBoxAccionUsuario.Items.Add("Eliminar");

            if (comboBoxAccionUsuario.Items.Count > 0)
            {
                comboBoxAccionUsuario.SelectedIndex = 0;
            }
        }

        private void comboBoxUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            rellenarUsuarios();
      
        }

        private void rellenarUsuarios()
        {
            Roles rolSeleccionado = (Roles)comboBoxRoles.SelectedItem;
            CargarGridRoles.ConfigurarGridSegunRol(rolSeleccionado, dataGridViewUsuarios, bindingSourceUsuarios);
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
            DataGridViewBordeRedondo.RedondearBordes(dataGridViewUsuarios, 20);
        }
        private void disenoBotones()
        {
            // BOTON MODIFICAR
            buttonModificar.BackColor = Color.FromArgb(255, 243, 226);

            buttonModificar.FlatAppearance.MouseOverBackColor = buttonModificar.BackColor;
            buttonModificar.FlatAppearance.MouseDownBackColor = buttonModificar.BackColor;
            buttonModificar.FlatAppearance.MouseDownBackColor = buttonModificar.BackColor;

            // BOTON ELIMINAR
            buttonEliminarUsuario.BackColor = Color.FromArgb(46, 196, 182);

            buttonEliminarUsuario.FlatAppearance.MouseOverBackColor = buttonEliminarUsuario.BackColor;
            buttonEliminarUsuario.FlatAppearance.MouseDownBackColor = buttonEliminarUsuario.BackColor;
            buttonEliminarUsuario.FlatAppearance.MouseDownBackColor = buttonEliminarUsuario.BackColor;

            // BOTON NUEVO USUARIO
            buttonCrearUsuario.BackColor = Color.FromArgb(242, 104, 27);

            buttonCrearUsuario.FlatAppearance.MouseOverBackColor = buttonCrearUsuario.BackColor;
            buttonCrearUsuario.FlatAppearance.MouseDownBackColor = buttonCrearUsuario.BackColor;
            buttonCrearUsuario.FlatAppearance.MouseDownBackColor = buttonCrearUsuario.BackColor;
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

        private void buttonCrearUsuario_Click(object sender, EventArgs e)
        {

        }
        private void buttonEliminar_Click(object sender, EventArgs e)
        {

        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {

        }


        private void labelRol_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBoxCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxAccionUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ocultar todos los botones primero
            buttonCrearUsuario.Visible = false;
            buttonModificar.Visible = false;
            buttonEliminarUsuario.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;

            // Mostrar el botón correspondiente según la opción seleccionada
            switch (comboBoxAccionUsuario.SelectedItem.ToString())
            {
                case "Crear":
                    buttonCrearUsuario.Visible = true;
                    pictureBox4.Visible = true;
                    break;
                case "Modificar":
                    buttonModificar.Visible = true;
                    pictureBox2.Visible = true;
                    break;
                case "Eliminar":
                    buttonEliminarUsuario.Visible = true;
                    pictureBox3.Visible = true;
                    break;
            }
        }
    }
}
