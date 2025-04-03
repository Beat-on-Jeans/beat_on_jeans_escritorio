using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using beat_on_jeans_escritorio.Clases;
using beat_on_jeans_escritorio.Models;
using Microsoft.CSharp.RuntimeBinder;

namespace beat_on_jeans_escritorio
{
    public partial class FormGestionUsuarios : Form

    {
        private string hintText = "Busca al usuario...";
        private BindingSource bindingSourceBuscarUsuarios = new BindingSource();
        private int rolId;

        public FormGestionUsuarios(int rolId)
        {
            InitializeComponent();
            this.rolId = rolId;

            // Configurar los ComboBox según el rol
            configurarComboBoxRol();

            dataGridViewUsuarios.SelectionChanged += DataGridViewUsuarios_SelectionChanged;
            textBoxContrasena.UseSystemPasswordChar = true;

            comboBoxBuscarUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBuscarUsuario.SelectedIndex = -1;
            this.rolId = rolId;

            // Cargar los roles en comboBoxRol
            var roles = RolesOrm.Select();
            comboBoxRol.DataSource = roles;
            comboBoxRol.DisplayMember = "Nombre_Rol"; // Ajusta esto según el nombre de la propiedad que quieres mostrar
            comboBoxRol.ValueMember = "ID";
            comboBoxRol.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBoxAccionUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void configurarComboBoxRol()
        {
            // Cargar los roles disponibles
            bindingSourceRoles.DataSource = RolesOrm.Select();

            if (rolId == 4 || rolId == 5) // Si es administrador o gestor
            {
                // Filtrar roles para Músicos (1) y Locales (2)
                var rolesFiltrados = bindingSourceRoles.List.Cast<Roles>()
                    .Where(r => r.ID == 1 || r.ID == 2)
                    .ToList();

                bindingSourceCorreos.DataSource = rolesFiltrados;

                // Configurar el ComboBox
                comboBoxBuscarUsuario.DataSource = bindingSourceCorreos;
                comboBoxBuscarUsuario.DisplayMember = "Correo";
                comboBoxBuscarUsuario.ValueMember = "ROL_ID";
                comboBoxBuscarUsuario.SelectedIndex = -1;

                // Configurar comboBoxRolFiltro
                comboBoxRolFiltro.DataSource = rolesFiltrados;
                comboBoxRolFiltro.DisplayMember = "Nombre_Rol";
                comboBoxRolFiltro.ValueMember = "ID";

                // Configurar comboBoxRol
                comboBoxRol.DataSource = rolesFiltrados;
                comboBoxRol.DisplayMember = "Nombre_Rol";
                comboBoxRol.ValueMember = "ID";

                // Filtrar solo los usuarios con rol de Músico o Local
                var usuariosFiltrados = UsuariosCSharpOrm.SelectMusicosYLocales();

                // Asignar los usuarios filtrados al ComboBox
                bindingSourceBuscarUsuarios.DataSource = usuariosFiltrados;
                comboBoxBuscarUsuario.DataSource = bindingSourceBuscarUsuarios;
                comboBoxBuscarUsuario.DisplayMember = "Correo";  // Mostrar solo el correo
                comboBoxBuscarUsuario.ValueMember = "ID";        // Valor asociado al ID

                // Configuraciones específicas para gestor (rolId == 5)
                if (rolId == 5)
                {
                    comboBoxAccionUsuario.Items.Clear();
                    comboBoxAccionUsuario.Items.Add("Modificar");
                    comboBoxAccionUsuario.SelectedIndex = 0;

                    buttonCrearUsuario.Visible = false;
                    buttonCrearUsuario.Enabled = false;
                    pictureBox4.Visible = false;
                    buttonEliminarUsuario.Visible = false;
                    buttonEliminarUsuario.Enabled = false;
                    pictureBox3.Visible = false;

                    comboBoxAccionUsuario.Enabled = false;
                }
            }
            else
            {
                // Para otros roles, cargar todos los roles sin filtrar
                comboBoxRolFiltro.DataSource = bindingSourceRoles;
                comboBoxRolFiltro.DisplayMember = "Nombre_Rol";
                comboBoxRolFiltro.ValueMember = "ID";

                comboBoxRol.DataSource = bindingSourceRoles;
                comboBoxRol.DisplayMember = "Nombre_Rol";
                comboBoxRol.ValueMember = "ID";

                // Cargar todos los usuarios
                var usuarios = UsuariosORM.Select();
                bindingSourceBuscarUsuarios.DataSource = usuarios;
                comboBoxBuscarUsuario.DataSource = bindingSourceBuscarUsuarios;
            }
        }

        

        private void FormGestionUsuarios_Load(object sender, EventArgs e)
        {
            disenoBotones();
            disenoGrid();
            rellenarUsuarios();
            dataGridViewUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cargarContenidosUsuarios();

            // Añadir valores a comboBoxAccionUsuario
            comboBoxAccionUsuario.Items.Add("Crear");
            comboBoxAccionUsuario.Items.Add("Modificar");
            comboBoxAccionUsuario.Items.Add("Eliminar");

            if (comboBoxAccionUsuario.Items.Count > 0)
            {
                comboBoxAccionUsuario.SelectedIndex = 0;
            }

            

        }

        private void DataGridViewUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            cargarContenidosUsuarios();
        }

        private void cargarContenidosUsuarios()
        {
            // Configurar el manejador de errores del DataGridView
            dataGridViewUsuarios.DataError += (s, e) => { e.ThrowException = false; };

            // Verificación robusta de fila seleccionada
            if (dataGridViewUsuarios.CurrentRow == null ||
                dataGridViewUsuarios.CurrentRow.IsNewRow ||
                !(dataGridViewUsuarios.CurrentRow.DataBoundItem is object selectedUser))
            {
                return;
            }

            try
            {
                // Usar dynamic para acceso más flexible a propiedades
                dynamic user = dataGridViewUsuarios.CurrentRow.DataBoundItem;

                // Asignación segura de valores con comprobación de existencia
                textBoxNombre.Text = TryGetProperty(user, "Nombre", "NombreLocal");
                textBoxCorreo.Text = TryGetProperty(user, "Correo", "CorreoLocal");
                textBoxContrasena.Text = TryGetProperty(user, "Contrasena");
                textBoxUbicacion.Text = TryGetProperty(user, "Codigo_Postal", "CodigoPostal");

                // Configuración segura del combo de roles
                var rolValue = TryGetProperty(user, "Rol", "Role", "TipoUsuario");
                if (!string.IsNullOrEmpty(rolValue))
                {
                    var selectedRole = comboBoxRolFiltro.Items.Cast<Roles>()
                        .FirstOrDefault(r => r.Nombre_Rol.Equals(rolValue, StringComparison.OrdinalIgnoreCase));
                    comboBoxRolFiltro.SelectedItem = selectedRole;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al cargar usuario: {ex.Message}");
                // No mostrar mensaje al usuario para evitar interrupciones
            }
        }


        private string TryGetProperty(dynamic obj, params string[] propertyNames)
        {
            try
            {
                foreach (var name in propertyNames)
                {
                    try
                    {
                        var value = obj.GetType().GetProperty(name)?.GetValue(obj);
                        if (value != null) return value.ToString();
                    }
                    catch (RuntimeBinderException)
                    {
                        // Continuar con el siguiente nombre si la propiedad no existe
                        continue;
                    }
                }
            }
            catch
            {
                // Manejar cualquier otro error silenciosamente
            }
            return string.Empty;
        }

        private void comboBoxUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Asegurarnos de que el índice seleccionado no sea -1
            if (comboBoxBuscarUsuario.SelectedIndex != -1)
            {
                // Obtener el correo del usuario seleccionado en el ComboBox
                string correoSeleccionado = (string)comboBoxBuscarUsuario.SelectedItem;

                // Buscar el usuario en el DataGridView por correo
                foreach (DataGridViewRow row in dataGridViewUsuarios.Rows)
                {
                    // Verificamos que la fila no sea una fila nueva (row.IsNewRow) y que el valor en la columna "Correo" coincida con el correo seleccionado
                    if (row.Cells["Correo"].Value != null && row.Cells["Correo"].Value.ToString() == correoSeleccionado)
                    {
                        // Seleccionamos la fila en el DataGridView
                        dataGridViewUsuarios.ClearSelection();
                        row.Selected = true;

                        // Cargar los detalles del usuario seleccionado en los controles correspondientes
                        cargarContenidosUsuarios();

                        break; // Salimos del bucle una vez que encontramos la fila correspondiente
                    }
                }
            }
        }


        private void rellenarUsuarios()
        {
            // Obtener el rol seleccionado del comboBoxRoles
            Roles rolSeleccionado = (Roles)comboBoxRolFiltro.SelectedItem;

            // Verificar que se haya seleccionado un rol
            if (rolSeleccionado != null)
            {
                // Configurar el dataGridViewUsuarios según el rol seleccionado
                CargarGridRoles.ConfigurarGridSegunRol(rolSeleccionado, dataGridViewUsuarios, bindingSourceUsuarios);
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
            buttonModificarUsuario.BackColor = Color.FromArgb(255, 243, 226);

            buttonModificarUsuario.FlatAppearance.MouseOverBackColor = buttonModificarUsuario.BackColor;
            buttonModificarUsuario.FlatAppearance.MouseDownBackColor = buttonModificarUsuario.BackColor;
            buttonModificarUsuario.FlatAppearance.MouseDownBackColor = buttonModificarUsuario.BackColor;

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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // ------------------ Logica de Creación, Modificación y Eliminación de Usuarios ------------------

        private void buttonCrearUsuario_Click(object sender, EventArgs e)
        {
            String nombreUsuario = textBoxNombre.Text;
            String correoUsuario = textBoxCorreo.Text;
            String contrasenaUsuario = textBoxContrasena.Text;
            String ubicacionUsuario = textBoxUbicacion.Text;
            Roles rolUsuario = (Roles)comboBoxRolFiltro.SelectedItem;

            // Validación de datos
            if (!ValidarDatosUsuario(nombreUsuario, correoUsuario, contrasenaUsuario, rolUsuario))
            {
                return;
            }

            // Verificar si el correo ya existe
            if (UsuariosORM.CorreoExiste(correoUsuario))
            {
                MessageBox.Show("El correo ya está en uso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear nuevo usuario
            Usuarios nuevoUsuario = CrearNuevoUsuario(nombreUsuario, correoUsuario, contrasenaUsuario, rolUsuario.ID);

            // Insertar usuario en la base de datos
            UsuariosORM.Insert(nuevoUsuario);

            // Crear usuario específico según el rol
            if (rolUsuario.ID == 1 || rolUsuario.ID == 2) // Músico o Local
            {
                UsuarioMovilOrm.Insert(new UsuarioMobil
                {
                    Usuario_ID = nuevoUsuario.ID,
                    ROL_ID = rolUsuario.ID,
                    Ubicacion = ubicacionUsuario
                });
            }
            else if (rolUsuario.ID >= 3 && rolUsuario.ID <= 5) // Administrador, Superadministrador o Mantenimiento
            {
                UsuariosCSharpOrm.CrearUsuarioCSharp(nuevoUsuario.ID, rolUsuario.ID);
            }

            // Actualizar la lista de usuarios
            bindingSourceBuscarUsuarios.DataSource = UsuariosCSharpOrm.Select();

            MessageBox.Show("Usuario creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool ValidarDatosUsuario(string nombre, string correo, string contrasena, Roles rol)
        {
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(contrasena) || rol == null)
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios y seleccione un rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!correo.Contains("@"))
            {
                MessageBox.Show("Por favor, ingrese un correo electrónico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private Usuarios CrearNuevoUsuario(string nombre, string correo, string contrasena, int rolId)
        {
            return new Usuarios
            {
                Nombre = nombre,
                Correo = correo,
                Contrasena = contrasena,
                ROL_ID = rolId
            };
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
            buttonModificarUsuario.Visible = false;
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
                    buttonModificarUsuario.Visible = true;
                    pictureBox2.Visible = true;
                    break;
                case "Eliminar":
                    buttonEliminarUsuario.Visible = true;
                    pictureBox3.Visible = true;
                    break;
            }
        }

        private void comboBoxRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonLimipiar_Click(object sender, EventArgs e)
        {
            textBoxNombre.Text = string.Empty;
            textBoxCorreo.Text = string.Empty;
            textBoxContrasena.Text = string.Empty;
            textBoxUbicacion.Text = string.Empty;
        }

        private void labelUbicacion_Click(object sender, EventArgs e)
        {

        }

        private void textBoxContrasena_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
