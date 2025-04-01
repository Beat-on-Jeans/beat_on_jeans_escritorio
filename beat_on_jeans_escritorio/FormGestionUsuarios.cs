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
            configurarComboBoxRol();  // Configura los roles del combo
            dataGridViewUsuarios.SelectionChanged += DataGridViewUsuarios_SelectionChanged;

            // Cargar los roles en el combo (todos)
            bindingSourceRoles.DataSource = RolesOrm.Select();

            // Hacer que comboBoxRoles sea de solo lectura
            comboBoxRolFiltro.DropDownStyle = ComboBoxStyle.DropDownList;

            // Cargar los usuarios dependiendo del rol
            cargarUsuariosSegunRol();

            comboBoxBuscarUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBuscarUsuario.SelectedIndex = -1;
            this.rolId = rolId;
        }

        private void configurarComboBoxRol()
        {
            // Cargar los roles disponibles
            bindingSourceRoles.DataSource = RolesOrm.Select();

            if (rolId == 4) // Si es administrador
            {
                cargarComboBoxRolesSoloMusicosYLocales();
            }
            else
            {
                // Para otros roles, cargar todos los roles sin filtrar
                comboBoxRolFiltro.DataSource = bindingSourceRoles;
                comboBoxRolFiltro.DisplayMember = "Nombre_Rol";
                comboBoxRolFiltro.ValueMember = "ID";
            }
        }

        private void cargarUsuariosSegunRol()
        {
            try
            {
                // Si el rol es Administrador (ID == 4), solo mostrar Músicos y Locales
                if (rolId == 4) // Administrador
                {
                    // Filtrar solo los usuarios con rol de Músico o Local
                    var usuariosFiltrados = UsuariosCSharpOrm.SelectMusicosYLocales();

                    // Asignar los usuarios filtrados al ComboBox
                    bindingSourceBuscarUsuarios.DataSource = usuariosFiltrados;
                    comboBoxBuscarUsuario.DataSource = bindingSourceBuscarUsuarios;
                    comboBoxBuscarUsuario.DisplayMember = "Correo";  // Mostrar solo el correo
                    comboBoxBuscarUsuario.ValueMember = "ID";        // Valor asociado al ID
                }
                else
                {
                    // Si no es administrador, cargar todos los usuarios
                    var usuarios = UsuariosORM.Select();

                    bindingSourceBuscarUsuarios.DataSource = usuarios; // Todos los usuarios
                    comboBoxBuscarUsuario.DataSource = bindingSourceBuscarUsuarios;
                    comboBoxBuscarUsuario.DisplayMember = "Correo";  // Mostrar solo el correo
                    comboBoxBuscarUsuario.ValueMember = "ID";        // Valor asociado al ID
                }

                // Configurar el estilo del ComboBox
                comboBoxBuscarUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBoxBuscarUsuario.SelectedIndex = -1; // No seleccionar ninguno inicialmente

                // Verificar que haya usuarios cargados
                if (bindingSourceBuscarUsuarios.Count == 0)
                {
                    MessageBox.Show("No se encontraron usuarios.",
                                    "Información",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void cargarComboBoxRolesSoloMusicosYLocales()
        {
            try
            {
                // Filtrar los roles de Músico (ID=1) y Local (ID=2) solo para administradores
                var rolesFiltrados = RolesOrm.Select()
                                             .Where(r => r.ID == 1 || r.ID == 2)
                                             .ToList();

                if (!rolesFiltrados.Any())
                {
                    MessageBox.Show("No se encontraron los roles de Músico o Local.",
                                     "Advertencia",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Warning);
                    return;
                }

                // Configurar el ComboBox de roles con solo Músicos y Locales
                comboBoxRolFiltro.DataSource = new BindingSource(rolesFiltrados, null);
                comboBoxRolFiltro.DisplayMember = "Nombre_Rol";
                comboBoxRolFiltro.ValueMember = "ID";

                comboBoxRol.DataSource = new BindingSource(rolesFiltrados, null);
                comboBoxRol.DisplayMember = "Nombre_Rol";
                comboBoxRol.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar roles: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
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
                dynamic user = selectedUser;

                // Asignación segura de valores con comprobación de existencia
                textBoxNombre.Text = TryGetProperty(user, "Nombre", "NombreLocal");
                textBoxCorreo.Text = TryGetProperty(user, "Correo", "CorreoLocal");
                textBoxContrasena.Text = TryGetProperty(user, "Contrasena");
                textBoxCodigoPostal.Text = TryGetProperty(user, "Codigo_Postal", "CodigoPostal");
                textBoxUbicacion.Text = TryGetProperty(user, "Ubicacion", "Location", "Direccion");

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
            rellenarUsuarios();
      
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

        // ------------------ Logica de Creación, Modificación y Eliminación de Usuarios ------------------


        private void buttonCrearUsuario_Click(object sender, EventArgs e)
        {

            String nombreUsuario = textBoxNombre.Text;
            String correoUsuario = textBoxCorreo.Text;
            String contrasenaUsuario = textBoxContrasena.Text;
            String codigoPostalUsuario = textBoxCodigoPostal.Text;
            String ubicacionUsuario = textBoxUbicacion.Text;
            Roles rolUsuario = (Roles)comboBoxRolFiltro.SelectedItem;

            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(correoUsuario) || string.IsNullOrWhiteSpace(contrasenaUsuario))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Usuarios nuevoUsuario = new Usuarios
            {
                Nombre = nombreUsuario,
                Correo = correoUsuario,
                Contrasena = contrasenaUsuario,
                ROL_ID = rolUsuario.ID
            };

            UsuariosORM.Insert(nuevoUsuario);
            bindingSourceBuscarUsuarios.DataSource = UsuariosCSharpOrm.Select();
            MessageBox.Show("Usuario creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
       
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

        private void comboBoxRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
