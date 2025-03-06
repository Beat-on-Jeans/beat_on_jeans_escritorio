using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using beat_on_jeans_escritorio.Models;

namespace beat_on_jeans_escritorio
{
    public class UsuariosCSharp
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string contrasena { get; set; }
        public string correo { get; set; }
        public int rol { get; set; }

        public static UsuariosCSharp recogerUsuario(string correo, string contrasena)
        {
            string mensajeError = "";
            SqlCommand sentencia = new SqlCommand();
            SqlDataReader datos;
            UsuariosCSharp usuario = null;

            try
            {
                sentencia.Connection = Bd.connexion;
                sentencia.CommandText = "SELECT * FROM usuarios WHERE correo = @correo AND contrasena = @contrasena";
                sentencia.Parameters.AddWithValue("@correo", correo);
                sentencia.Parameters.AddWithValue("@contrasena", contrasena);

                Bd.connexion.Open();

                datos = sentencia.ExecuteReader();
                if (datos.Read())
                {
                    usuario = new UsuariosCSharp
                    {
                        id = Convert.ToInt32(datos["id"]),
                        nombre = datos["nombre"].ToString(),
                        contrasena = datos["contrasena"].ToString(),
                        correo = datos["correo"].ToString(),
                        rol = Convert.ToInt32(datos["rol"])
                    };
                }
            }
            catch (SqlException ex)
            {
                mensajeError = Bd.MensageError(ex);
                MessageBox.Show($"No se pudo recoger los datos: {mensajeError}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (Bd.connexion.State == ConnectionState.Open)
                {
                    Bd.connexion.Close();
                }
            }

            return usuario;
        }
    }
}
