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
        private BindingSource bindingSourceBuscarUsuarios = new BindingSource();
        public FormGestionUsuarios()
        {
            InitializeComponent();

            // Ecoger los roles en la ComboBox
            bindingSourceRoles.DataSource = RolesOrm.Select();

            // Hacer que comboBoxRoles sea de solo lectura
            comboBoxRoles.DropDownStyle = ComboBoxStyle.DropDownList;

            // Hacer que comboBoxAccionUsuario sea de solo lectura
            comboBoxAccionUsuario.DropDownStyle = ComboBoxStyle.DropDownList;

            var usuarios = UsuariosORM.Select();
            bindingSourceBuscarUsuarios.DataSource = usuarios; // Corrected line
            comboBoxBuscarUsuario.DataSource = bindingSourceBuscarUsuarios;
            comboBoxBuscarUsuario.DisplayMember = "Correo"; // Ajusta esto según el nombre de la propiedad que deseas mostrar
            comboBoxBuscarUsuario.ValueMember = "ID"; // Ajusta esto según el nombre de la propiedad del ID del usuario
            comboBoxBuscarUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBuscarUsuario.SelectedIndex = -1;

            comboBoxBuscarUsuario.TextChanged += ComboBoxBuscarUsuario_TextChanged;
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
