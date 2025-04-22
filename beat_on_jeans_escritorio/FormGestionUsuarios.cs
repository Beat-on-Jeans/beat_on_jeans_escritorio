using beat_on_jeans_escritorio.Clases;
using beat_on_jeans_escritorio.Models;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace beat_on_jeans_escritorio
{
    public partial class FormGestionUsuarios : Form
    {
        private BindingSource bindingSourceBuscarUsuarios = new BindingSource();
        private int rolId;

        public FormGestionUsuarios(int rolId)
        {
            InitializeComponent();
            this.rolId = rolId;

            // Configurar los ComboBox según el rol
            configurarComboBoxRol();

            dataGridViewUsuarios.SelectionChanged += DataGridViewUsuarios_SelectionChanged;
            comboBoxBuscarUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBuscarUsuario.SelectedIndex = -1;

            // Agregar el manejador de eventos para el cambio de rol
            comboBoxRolFiltro.SelectedIndexChanged += ComboBoxRolFiltro_SelectedIndexChanged;
        }

        /// <summary>
        /// Actualiza la interfaz según el rol seleccionado, mostrando u ocultando campos y ajustando la visualización de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxRolFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar que se haya seleccionado un ítem
            if (comboBoxRolFiltro.SelectedIndex != -1)
            {
                // Obtener el rol seleccionado
                Roles rolSeleccionado = (Roles)comboBoxRolFiltro.SelectedItem;

                // Actualizar el grid según el rol seleccionado
                CargarGridRoles.ConfigurarGridSegunRol(rolSeleccionado, dataGridViewUsuarios, bindingSourceUsuarios);

                // También puedes actualizar el ComboBox de búsqueda si es necesario
                ActualizarComboBoxBusqueda(rolSeleccionado);
            }

            if (comboBoxRolFiltro.SelectedIndex == 1)
            {
                labelCodigoUbicacion.Visible = true;
                textBoxUbicacion.Visible = true;
            }
            if (comboBoxRolFiltro.SelectedIndex == 2)
            {
                labelCodigoUbicacion.Visible = true;
                textBoxUbicacion.Visible = true;
            }
            if (comboBoxRolFiltro.SelectedIndex == 2)
            {
                labelCodigoUbicacion.Visible = false;
                textBoxUbicacion.Visible = false;
            }
            if (comboBoxRolFiltro.SelectedIndex == 3)
            {
                labelCodigoUbicacion.Visible = false;
                textBoxUbicacion.Visible = false;
            }
            if (comboBoxRolFiltro.SelectedIndex == 4)
            {
                labelCodigoUbicacion.Visible = false;
                textBoxUbicacion.Visible = false;
            }
        }

        /// <summary>
        /// Muestra todos los correos en la comboBox.
        /// </summary>
        /// <param name="rolSeleccionado"></param>
        private void ActualizarComboBoxBusqueda(Roles rolSeleccionado)
        {
            bindingSourceBuscarUsuarios.DataSource = UsuariosORM.Select(); // Todos los usuarios

            comboBoxBuscarUsuario.DataSource = bindingSourceBuscarUsuarios;
            comboBoxBuscarUsuario.DisplayMember = "Correo";
            comboBoxBuscarUsuario.ValueMember = "ID";
            comboBoxBuscarUsuario.SelectedIndex = -1;
        }

        /// <summary>
        /// Configurar comboBox y que en dependiendo el usuario enseñe unos datos o otros.
        /// </summary>
        private void configurarComboBoxRol()
        {
            // Cargar los roles disponibles
            bindingSourceRoles.DataSource = RolesOrm.Select();

            if (rolId == 3) // Si es superusuario
            {
                // Cargar todos los usuarios sin filtro
                var todosLosUsuarios = UsuariosORM.Select(); // Obtener todos los usuarios
                bindingSourceBuscarUsuarios.DataSource = todosLosUsuarios;
                comboBoxBuscarUsuario.DataSource = bindingSourceBuscarUsuarios;
                comboBoxBuscarUsuario.DisplayMember = "Correo";  // Mostrar el correo
                comboBoxBuscarUsuario.ValueMember = "ID";       // Valor asociado al ID

                // Configurar comboBoxRolFiltro y comboBoxRol (sin cambios)
                comboBoxRolFiltro.DataSource = bindingSourceRoles;
                comboBoxRolFiltro.DisplayMember = "Nombre_Rol";
                comboBoxRolFiltro.ValueMember = "ID";

                comboBoxRol.DataSource = bindingSourceRoles;
                comboBoxRol.DisplayMember = "Nombre_Rol";
                comboBoxRol.ValueMember = "ID";
            }
            else if (rolId == 4 || rolId == 5) // Si es administrador o mantenimiento
            {
                // Filtrar roles para Músicos (1) y Locales (2)
                var rolesFiltrados = bindingSourceRoles.List.Cast<Roles>()
                    .Where(r => r.ID == 1 || r.ID == 2) // Músicos y Locales
                    .ToList();

                bindingSourceGmails.DataSource = rolesFiltrados;

                // Configurar comboBoxRolFiltro y comboBoxRol (sin cambios)
                comboBoxRolFiltro.DataSource = rolesFiltrados;
                comboBoxRolFiltro.DisplayMember = "Nombre_Rol";
                comboBoxRolFiltro.ValueMember = "ID";

                comboBoxRol.DataSource = rolesFiltrados;
                comboBoxRol.DisplayMember = "Nombre_Rol";
                comboBoxRol.ValueMember = "ID";

                // --- Solo mostrar los usuarios Músicos (ID == 1) y Locales (ID == 2) en comboBoxBuscarUsuario ---
                var usuariosFiltrados = UsuariosORM.Select()
                    .Where(u => u.ROL_ID == 1 || u.ROL_ID == 2) // Filtrar por Músicos y Locales
                    .ToList();

                bindingSourceBuscarUsuarios.DataSource = usuariosFiltrados;
                comboBoxBuscarUsuario.DataSource = bindingSourceBuscarUsuarios;
                comboBoxBuscarUsuario.DisplayMember = "Correo";  // Mostrar el correo
                comboBoxBuscarUsuario.ValueMember = "ID";       // Valor asociado al ID

                // Configuraciones específicas para mantenimiento (rolId == 5)
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
                // Para otros roles (no superusuario, admin o mantenimiento), cargar todos los roles sin filtrar
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
                comboBoxBuscarUsuario.DisplayMember = "Correo";  // Mostrar el correo
                comboBoxBuscarUsuario.ValueMember = "ID";       // Valor asociado al ID
            }
        }

        /// <summary>
        /// Se ejecuta la primera vez que se ejecuta el form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormGestionUsuarios_Load(object sender, EventArgs e)
        {
            disenoBotones();
            disenoGrid();
            rellenarUsuarios();
            dataGridViewUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cargarContenidosUsuarios();
            textBoxContrasena.UseSystemPasswordChar = true;

            // Añadir valores a comboBoxAccionUsuario
            comboBoxAccionUsuario.Items.Add("Crear");
            comboBoxAccionUsuario.Items.Add("Modificar");
            comboBoxAccionUsuario.Items.Add("Eliminar");

            if (comboBoxAccionUsuario.Items.Count > 0)
            {
                comboBoxAccionUsuario.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Llama a otro metodo para que ejecute la acción.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            cargarContenidosUsuarios();
        }

        /// <summary>
        /// Carga de manera segura los datos del usuario seleccionado en el dataGridViewUsuarios a varios controles de la interfaz
        /// </summary>
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
                textBoxUbicacion.Text = TryGetProperty(user, "Ubicacion", "Ubicacion");

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

        /// <summary>
        /// Intenta obtener el valor de una propiedad de un objeto dinámico, probando varios nombres de propiedad en orden
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyNames"></param>
        /// <returns>Si una propiedad existe y tiene un valor, lo devuelve. Si no, sigue intentando con los siguientes nombres.</returns>
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

        /// <summary>
        /// Rellenar la dataGridView con los usuarios dentro de esos roles.
        /// </summary>
        private void rellenarUsuarios()
        {
            // Obtener el rol seleccionado del comboBoxRoles
            if (comboBoxRolFiltro.SelectedItem is Roles rolSeleccionado)
            {
                // Configurar el dataGridViewUsuarios según el rol seleccionado
                CargarGridRoles.ConfigurarGridSegunRol(rolSeleccionado, dataGridViewUsuarios, bindingSourceUsuarios);

                // Asegurarse de que la columna de ubicación sea visible para músicos
                if (rolSeleccionado.ID == 1 && dataGridViewUsuarios.Columns["Ubicacion"] != null)
                {
                    dataGridViewUsuarios.Columns["Ubicacion"].Visible = true;
                }
            }
        }

        /// <summary>
        /// Cuando le de al boton de buscar verifica que hay seleccionado un correo y cuando lo verifica lo muestra en el dataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            // Verificar si hay un ítem seleccionado
            if (comboBoxBuscarUsuario.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un correo para buscar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener el usuario seleccionado directamente
            var usuarioSeleccionado = comboBoxBuscarUsuario.SelectedItem as Usuarios;
            if (usuarioSeleccionado == null)
            {
                MessageBox.Show("El correo seleccionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cargar los datos del usuario en el formulario
            CargarUsuarioEnFormulario(usuarioSeleccionado);
        }

        /// <summary>
        /// Carga el usuario con ese correo en el formulario.
        /// </summary>
        /// <param name="usuario"></param>
        private void CargarUsuarioEnFormulario(Usuarios usuario)
        {
            // Vaciar el ComboBox de búsqueda
            comboBoxBuscarUsuario.SelectedIndex = -1;

            // Actualizamos los controles del formulario con los datos del usuario
            textBoxNombre.Text = usuario.Nombre;
            textBoxCorreo.Text = usuario.Correo;
            textBoxContrasena.Text = usuario.Contrasena;

            // Asumimos que el rol ya está correctamente configurado en el combo
            var rolSeleccionado = comboBoxRolFiltro.Items.Cast<Roles>()
                .FirstOrDefault(r => r.ID == usuario.ROL_ID);
            if (rolSeleccionado != null)
            {
                comboBoxRolFiltro.SelectedItem = rolSeleccionado;
            }
        }

        /// <summary>
        /// Diseño del grid con bordes redondos.
        /// </summary>
        private void disenoGrid()
        {
            DataGridViewBordeRedondo.RedondearBordes(dataGridViewUsuarios, 20);
        }

        /// <summary>
        /// Diseño de botones con estilo.
        /// </summary>
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

        // ------------------ Logica de Creación, Modificación y Eliminación de Usuarios ------------------

        /// <summary>
        /// Crea un usuario y lo manda la BBDD con sus campos correspondientes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCrearUsuario_Click(object sender, EventArgs e)
        {
            String nombreUsuario = textBoxNombre.Text;
            String correoUsuario = textBoxCorreo.Text;
            String contrasenaUsuario = textBoxContrasena.Text;
            String ubicacionUsuario = textBoxUbicacion.Text;
            Roles rolUsuario = (Roles)comboBoxRolFiltro.SelectedItem;

            // Validación de datos
            if (ValidarDatosUsuario(nombreUsuario, correoUsuario, contrasenaUsuario, rolUsuario))
            {
                if (UsuariosORM.CorreoExiste(correoUsuario))
                {
                    MessageBox.Show("El correo ya está en uso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    Usuarios nuevoUsuario = CrearNuevoUsuario(nombreUsuario, correoUsuario, contrasenaUsuario, rolUsuario.ID);
                    UsuariosORM.Insert(nuevoUsuario);

                    bindingSourceBuscarUsuarios.DataSource = UsuariosCSharpOrm.Select();
                    MessageBox.Show("Usuario creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

                    // Actualizar el DataGridView
                    rellenarUsuarios();
                }
                return;
            }
        }

        /// <summary>
        /// Valida los datos del propio usuario antes de crearlo.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="correo"></param>
        /// <param name="contrasena"></param>
        /// <param name="rol"></param>
        /// <returns>Devuelve un boolean</returns>
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

        /// <summary>
        /// Crea y construye una nueva instacia de clase usuario.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="correo"></param>
        /// <param name="contrasena"></param>
        /// <param name="rolId"></param>
        /// <returns>Devuelve un usuario.</returns>
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
        
        /// <summary>
        /// Elimina al usuario que haya seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario primero");
                return;
            }

            // Obtenemos el ID del usuario seleccionado
            var selectedRow = dataGridViewUsuarios.SelectedRows[0];
            dynamic usuario = selectedRow.DataBoundItem;
            int userId = usuario.ID; // Asegúrate que esta propiedad coincide con tu DataGridView

            DialogResult confirm = MessageBox.Show(
                "¿Está seguro de eliminar este usuario y todos sus datos relacionados?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    bool eliminado = UsuariosCSharpOrm.DeleteUser(userId);

                    if (eliminado)
                    {
                        MessageBox.Show("Usuario eliminado correctamente");
                        rellenarUsuarios(); // Método para actualizar el DataGridView
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el usuario");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Modifica al usuario que tenga seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonModificar_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedRow = dataGridViewUsuarios.SelectedRows[0];
            int usuarioId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
            Roles rol = (Roles)comboBoxRolFiltro.SelectedItem;

            // Validar datos primero
            if (!ValidarDatosUsuario(textBoxNombre.Text, textBoxCorreo.Text, textBoxContrasena.Text, rol))
            {
                return;
            }

            // Crear objeto actualizado
            Usuarios usuarioActualizado = new Usuarios
            {
                ID = usuarioId,
                Nombre = textBoxNombre.Text,
                Correo = textBoxCorreo.Text,
                Contrasena = textBoxContrasena.Text,
                ROL_ID = rol.ID, // Esto está bien aunque ROL_ID sea nullable
                Ubicacion = (rol.ID == 1 || rol.ID == 2) ? textBoxUbicacion.Text : null
            };

            // Actualizar en base de datos
            bool actualizado = UsuariosORM.UpdateUser(usuarioActualizado);

            if (actualizado)
            {
                MessageBox.Show("Usuario modificado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rellenarUsuarios(); // Refrescar DataGridView
            }
            else
            {
                MessageBox.Show("No se pudo modificar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Depende lo que elija enseña un boton u otro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Que limpie los campos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLimipiar_Click(object sender, EventArgs e)
        {
            textBoxNombre.Text = string.Empty;
            textBoxCorreo.Text = string.Empty;
            textBoxContrasena.Text = string.Empty;
            textBoxUbicacion.Text = string.Empty;
        }
    }
}
