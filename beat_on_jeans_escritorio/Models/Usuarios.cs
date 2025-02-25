using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;


namespace beat_on_jeans_escritorio.Models
{
    internal class Usuarios
    {
        public static DataTable recogerUsuarios()
        {

            SqlCommand sentencia = new SqlCommand();
            SqlDataReader dades;
            DataTable taula = new DataTable();

            try
            {
                sentencia.Connection = Bd.connexion;
                sentencia.CommandText = "select * from usuaris";

                Bd.connexion.Open();

                dades = sentencia.ExecuteReader();
                taula.Load(dades);
            }
            catch (SqlException ex)
            {
                String mensajeError = Bd.MensageError(ex);
                MessageBox.Show($"No se puedo recoger los datos: {mensajeError}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (Bd.connexion.State == ConnectionState.Open)
                {
                    Bd.connexion.Close();
                }
            }

            return taula;

        }
        public static Boolean validarUsuaris(String correu, String contrasenya, out String missatge)
        {
            SqlCommand sentencia = new SqlCommand();
            SqlDataReader dades;
            DataTable taula = new DataTable();
            Boolean validar = false;
            missatge = null;

            try
            {
                sentencia.Connection = Bd.connexion;
                sentencia.CommandText = "select contrasenya from usuaris where correu = @correu";
                sentencia.Parameters.Clear();
                sentencia.Parameters.AddWithValue("@correu", correu);

                Bd.connexion.Open();

                dades = sentencia.ExecuteReader();
                taula.Load(dades);

                if (taula.Rows.Count > 0)
                {
                    // Obtener el hash almacenado en la base de datos
                    string hashAlmacenado = taula.Rows[0]["contrasenya"].ToString();
                    Boolean constrasenyaEncryptada = BCrypt.Net.BCrypt.EnhancedVerify(contrasenya, hashAlmacenado, HashType.SHA512);

                    if (constrasenyaEncryptada == true)
                    {
                        validar = true;
                        missatge = validar ? "Inicio de sesión exitoso." : "Contraseña incorrecta.";
                    }
                }
                else
                {
                    missatge = "El correo ingresado no existe en la base de datos.";
                }
            }
            catch (SqlException ex)
            {
                missatge = $"Error al validar el usuario: {Bd.MensageError(ex)}";
            }
            finally
            {
                if (Bd.connexion.State == ConnectionState.Open)
                {
                    Bd.connexion.Close();
                }
            }

            return validar;
        }
    }

}
