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
        }

        private void FormGestionUsuarios_Load(object sender, EventArgs e)
        {
            disenoBotones();
            disenoGrid();
            rellenarUsuarios();
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

                dataGridViewUsuarios.AutoGenerateColumns = true;
                bindingSourceUsuarios.DataSource = usuariosMusicos.ToList();
                dataGridViewUsuarios.DataSource = bindingSourceUsuarios;

                // Desactivar generación automática para personalizar
                dataGridViewUsuarios.AutoGenerateColumns = false;

                // Limpiar columnas existentes
                dataGridViewUsuarios.Columns.Clear();

                // Crear y configurar columnas manualmente
                dataGridViewUsuarios.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Nombre",
                    HeaderText = "Nombre",
                    DataPropertyName = "Nombre"
                });

                dataGridViewUsuarios.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Correo",
                    HeaderText = "Correo",
                    DataPropertyName = "Correo"
                });

                dataGridViewUsuarios.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Rol",
                    HeaderText = "Rol",
                    DataPropertyName = "Rol"
                });

                dataGridViewUsuarios.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Codigo_Postal",
                    HeaderText = "Código Postal",
                    DataPropertyName = "Codigo_Postal"
                });

                // Configuración visual
                dataGridViewUsuarios.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridViewUsuarios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            else if (_rol.Nombre_Rol == "Local")
            {
                // Cargar datos
                var usuariosLocales = UsuariosCSharpOrm.SelectLocales();

                // Configurar DataSource con generación automática inicial
                dataGridViewUsuarios.AutoGenerateColumns = true;
                bindingSourceUsuarios.DataSource = usuariosLocales.ToList();
                dataGridViewUsuarios.DataSource = bindingSourceUsuarios;

                // Desactivar generación automática para personalizar
                dataGridViewUsuarios.AutoGenerateColumns = false;

                // Limpiar columnas existentes
                dataGridViewUsuarios.Columns.Clear();

                // Crear y configurar columnas manualmente
                dataGridViewUsuarios.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "NombreLocal",
                    HeaderText = "Nombre",
                    DataPropertyName = "NombreLocal"  // Usamos el alias del query
                });

                dataGridViewUsuarios.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "CorreoLocal",
                    HeaderText = "Correo",
                    DataPropertyName = "CorreoLocal"  // Usamos el alias del query
                });

                dataGridViewUsuarios.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Rol",
                    HeaderText = "Rol",
                    DataPropertyName = "Rol"
                });

                dataGridViewUsuarios.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "ValoracionMedia",
                    HeaderText = "Valoración",
                    DataPropertyName = "ValoracionMedia"
                });

                dataGridViewUsuarios.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Ubicacion",
                    HeaderText = "Ubicación",
                    DataPropertyName = "Ubicacion"
                });

                // Configuración visual
                dataGridViewUsuarios.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridViewUsuarios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // Reasignar el DataSource para aplicar los cambios
                bindingSourceUsuarios.DataSource = usuariosLocales.ToList();
                dataGridViewUsuarios.DataSource = bindingSourceUsuarios;
            }
            else if (_rol.Nombre_Rol == "Superadministrador")
            {
                // Cargar datos
                var superAdmins = UsuariosCSharpOrm.SelectSuperadministradores();

                // Configurar DataSource con generación automática inicial
                dataGridViewUsuarios.AutoGenerateColumns = true;
                bindingSourceUsuarios.DataSource = superAdmins.ToList();
                dataGridViewUsuarios.DataSource = bindingSourceUsuarios;

                // Desactivar generación automática para personalizar
                dataGridViewUsuarios.AutoGenerateColumns = false;

                // Limpiar columnas existentes
                dataGridViewUsuarios.Columns.Clear();

                // Crear y configurar columnas manualmente
                dataGridViewUsuarios.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Nombre",
                    HeaderText = "Nombre",
                    DataPropertyName = "Nombre"
                });

                dataGridViewUsuarios.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Correo",
                    HeaderText = "Correo",
                    DataPropertyName = "Correo"
                });

                dataGridViewUsuarios.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Contrasena",
                    HeaderText = "Contrasena",
                    DataPropertyName = "Contrasena"
                });

                dataGridViewUsuarios.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Rol",
                    HeaderText = "Rol",
                    DataPropertyName = "Rol"
                });

                // Configuración visual
                dataGridViewUsuarios.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridViewUsuarios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // Reasignar el DataSource para aplicar los cambios
                bindingSourceUsuarios.DataSource = superAdmins.ToList();
                dataGridViewUsuarios.DataSource = bindingSourceUsuarios;
            }
            else if (_rol.Nombre_Rol == "Administrador")
            {
                // Cargar datos
                var administradores = UsuariosCSharpOrm.SelectAdministradores();

                // Configurar DataSource con generación automática inicial
                dataGridViewUsuarios.AutoGenerateColumns = true;
                bindingSourceUsuarios.DataSource = administradores.ToList();
                dataGridViewUsuarios.DataSource = bindingSourceUsuarios;

                // Desactivar generación automática para personalizar
                dataGridViewUsuarios.AutoGenerateColumns = false;

                // Limpiar columnas existentes
                dataGridViewUsuarios.Columns.Clear();

                // Crear y configurar columnas manualmente
                dataGridViewUsuarios.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Nombre",
                    HeaderText = "Nombre",
                    DataPropertyName = "Nombre"
                });

                dataGridViewUsuarios.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Correo",
                    HeaderText = "Correo",
                    DataPropertyName = "Correo"
                });

                dataGridViewUsuarios.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Contrasena",
                    HeaderText = "Contrasena",
                    DataPropertyName = "Contrasena"
                });

                dataGridViewUsuarios.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Rol",
                    HeaderText = "Rol",
                    DataPropertyName = "Rol"
                });

                // Configuración visual
                dataGridViewUsuarios.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridViewUsuarios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // Reasignar el DataSource para aplicar los cambios
                bindingSourceUsuarios.DataSource = administradores.ToList();
                dataGridViewUsuarios.DataSource = bindingSourceUsuarios;
            }
            else if (_rol.Nombre_Rol == "Mantenimiento")
            {
                // Cargar datos
                var mantenimiento = UsuariosCSharpOrm.SelectMantenimiento();

                // Configurar DataSource con generación automática inicial
                dataGridViewUsuarios.AutoGenerateColumns = true;
                bindingSourceUsuarios.DataSource = mantenimiento.ToList();
                dataGridViewUsuarios.DataSource = bindingSourceUsuarios;

                // Desactivar generación automática para personalizar
                dataGridViewUsuarios.AutoGenerateColumns = false;

                // Limpiar columnas existentes
                dataGridViewUsuarios.Columns.Clear();

                // Crear y configurar columnas manualmente
                dataGridViewUsuarios.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Nombre",
                    HeaderText = "Nombre",
                    DataPropertyName = "Nombre"
                });

                dataGridViewUsuarios.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Correo",
                    HeaderText = "Correo",
                    DataPropertyName = "Correo"
                });

                dataGridViewUsuarios.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Contrasena",
                    HeaderText = "Contrasena",
                    DataPropertyName = "Contrasena"
                });

                dataGridViewUsuarios.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Rol",
                    HeaderText = "Rol",
                    DataPropertyName = "Rol"
                });

                // Configuración visual
                dataGridViewUsuarios.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridViewUsuarios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // Reasignar el DataSource para aplicar los cambios
                bindingSourceUsuarios.DataSource = mantenimiento.ToList();
                dataGridViewUsuarios.DataSource = bindingSourceUsuarios;
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

        private void labelRol_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
