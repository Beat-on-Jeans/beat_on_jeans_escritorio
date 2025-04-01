using System.Windows.Forms;
using System.Collections.Generic;
using beat_on_jeans_escritorio.Models;

namespace beat_on_jeans_escritorio.Clases
{
    public static class CargarGridRoles
    {
        public static void ConfigurarGridSegunRol(Roles rol, DataGridView dataGridView, BindingSource bindingSource)
        {
            if (rol == null) return;

            // Configuración común para todos los roles
            dataGridView.AutoGenerateColumns = true;
            bindingSource.DataSource = rol.Usuarios;
            dataGridView.DataSource = bindingSource;

            // Desactivar generación automática para personalizar
            dataGridView.AutoGenerateColumns = false;
            dataGridView.Columns.Clear();

            // Configuración específica por rol
            switch (rol.Nombre_Rol)
            {
                case "Musico":
                    ConfigurarGridMusico(dataGridView, bindingSource);
                    break;
                case "Local":
                    ConfigurarGridLocal(dataGridView, bindingSource);
                    break;
                case "Superadministrador":
                    ConfigurarGridSuperadministrador(dataGridView, bindingSource);
                    break;
                case "Administrador":
                    ConfigurarGridAdministrador(dataGridView, bindingSource);
                    break;
                case "Mantenimiento":
                    ConfigurarGridMantenimiento(dataGridView, bindingSource);
                    break;
            }

            // Configuración visual común
            dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private static void ConfigurarGridMusico(DataGridView dataGridView, BindingSource bindingSource)
        {
            var usuariosMusicos = UsuariosCSharpOrm.SelectMusicos();
            bindingSource.DataSource = usuariosMusicos;
            dataGridView.DataSource = bindingSource;

            AgregarColumna(dataGridView, "Nombre", "Nombre", "Nombre");
            AgregarColumna(dataGridView, "Correo", "Correo", "Correo");
            AgregarColumna(dataGridView, "Rol", "Rol", "Rol");
            AgregarColumna(dataGridView, "Codigo_Postal", "Código Postal", "Codigo_Postal");
        }

        private static void ConfigurarGridLocal(DataGridView dataGridView, BindingSource bindingSource)
        {
            var usuariosLocales = UsuariosCSharpOrm.SelectLocales();
            bindingSource.DataSource = usuariosLocales;
            dataGridView.DataSource = bindingSource;

            AgregarColumna(dataGridView, "NombreLocal", "Nombre", "NombreLocal");
            AgregarColumna(dataGridView, "CorreoLocal", "Correo", "CorreoLocal");
            AgregarColumna(dataGridView, "Rol", "Rol", "Rol");
            AgregarColumna(dataGridView, "ValoracionMedia", "Valoración", "ValoracionMedia");
            AgregarColumna(dataGridView, "Ubicacion", "Ubicación", "Ubicacion");
        }

        private static void ConfigurarGridSuperadministrador(DataGridView dataGridView, BindingSource bindingSource)
        {
            var superAdmins = UsuariosCSharpOrm.SelectSuperadministradores();
            bindingSource.DataSource = superAdmins;
            dataGridView.DataSource = bindingSource;

            AgregarColumna(dataGridView, "Nombre", "Nombre", "Nombre");
            AgregarColumna(dataGridView, "Correo", "Correo", "Correo");
            AgregarColumna(dataGridView, "Contrasena", "Contrasena", "Contrasena");
            AgregarColumna(dataGridView, "Rol", "Rol", "Rol");
        }

        private static void ConfigurarGridAdministrador(DataGridView dataGridView, BindingSource bindingSource)
        {
            var administradores = UsuariosCSharpOrm.SelectAdministradores();
            bindingSource.DataSource = administradores;
            dataGridView.DataSource = bindingSource;

            AgregarColumna(dataGridView, "Nombre", "Nombre", "Nombre");
            AgregarColumna(dataGridView, "Correo", "Correo", "Correo");
            AgregarColumna(dataGridView, "Contrasena", "Contrasena", "Contrasena");
            AgregarColumna(dataGridView, "Rol", "Rol", "Rol");
        }

        private static void ConfigurarGridMantenimiento(DataGridView dataGridView, BindingSource bindingSource)
        {
            var mantenimiento = UsuariosCSharpOrm.SelectMantenimiento();
            bindingSource.DataSource = mantenimiento;
            dataGridView.DataSource = bindingSource;

            AgregarColumna(dataGridView, "Nombre", "Nombre", "Nombre");
            AgregarColumna(dataGridView, "Correo", "Correo", "Correo");
            AgregarColumna(dataGridView, "Contrasena", "Contrasena", "Contrasena");
            AgregarColumna(dataGridView, "Rol", "Rol", "Rol");
        }

        private static void AgregarColumna(DataGridView dataGridView, string name, string headerText, string dataPropertyName)
        {
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = headerText,
                DataPropertyName = dataPropertyName
            });
        }
    }
}