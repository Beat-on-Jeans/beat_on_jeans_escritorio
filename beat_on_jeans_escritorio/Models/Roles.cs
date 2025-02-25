using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace beat_on_jeans_escritorio.Models
{
    internal class Roles
    {
        public static DataTable recogerRoles()
        {
            string mensajeError = "";
            SqlCommand sentencia = new SqlCommand();
            SqlDataReader dades;
            DataTable taula = new DataTable();

            try
            {
                sentencia.Connection = Bd.connexion;
                sentencia.CommandText = "select * from roles";

                Bd.connexion.Open();

                dades = sentencia.ExecuteReader();
                taula.Load(dades);

            }
            catch (SqlException ex)
            {
                mensajeError = Bd.MensageError(ex);
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
    }
}
