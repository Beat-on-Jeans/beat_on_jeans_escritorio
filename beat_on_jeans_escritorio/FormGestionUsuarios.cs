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
            configurarComboBoxRol();
            dataGridViewUsuarios.SelectionChanged += DataGridViewUsuarios_SelectionChanged;

            // Ecoger los roles en la ComboBox
            bindingSourceRoles.DataSource = RolesOrm.Select();

            // Hacer que comboBoxRoles sea de solo lectura
            comboBoxRolFiltro.DropDownStyle = ComboBoxStyle.DropDownList;

            var usuarios = UsuariosORM.Select();
            bindingSourceBuscarUsuarios.DataSource = usuarios; // Corrected line
            comboBoxBuscarUsuario.DataSource = bindingSourceBuscarUsuarios;
            comboBoxBuscarUsuario.DisplayMember = "Correo"; 
            comboBoxBuscarUsuario.ValueMember = "ID";
            comboBoxBuscarUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBuscarUsuario.SelectedIndex = -1;
            this.rolId = rolId;
        }

        private void configurarComboBoxRol()
        {
            // Primero cargar todos los roles
            bindingSourceRoles.DataSource = RolesOrm.Select();

            if (rolId == 4) // Administrador
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

        private void cargarComboBoxRolesSoloMusicosYLocales()
        {
            try
            {
                // Verificar que hay datos
                if (bindingSourceRoles == null || bindingSourceRoles.Count == 0)
                {
                    MessageBox.Show("No hay roles disponibles para cargar.");
                    return;
                }

                // Filtrar usando LINQ para mayor claridad
                var rolesFiltrados = bindingSourceRoles.List.Cast<Roles>()
                    .Where(r => r.ID == 1 || r.ID == 2)  // 1: Músico, 2: Local
                    .ToList();

                // Verificar que encontramos los roles esperados
                if (!rolesFiltrados.Any())
                {
                    MessageBox.Show("No se encontraron los roles de Músico o Local.");
                    return;
                }

                // Configurar el ComboBox
                comboBoxRolFiltro.DataSource = rolesFiltrados;
                comboBoxRolFiltro.DisplayMember = "Nombre_Rol";
                comboBoxRolFiltro.ValueMember = "ID";

                comboBoxRol.DataSource = rolesFiltrados;
                comboBoxRol.DisplayMember = "Nombre_Rol";
                comboBoxRol.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar roles: {ex.Message}");
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
