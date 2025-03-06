using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace beat_on_jeans_escritorio.Models
{
    internal class Bd
    {
        // Cambiar nombre de usuario y contraseña
        public static SqlConnection connexion = new SqlConnection("Server=localhost;Database=dbJeans;User Id=facu;Password=1234;");
        public static String MensageError(SqlException sqlException)
        {
            String missatge = "";
            switch (sqlException.Number)
            {
                case 2:
                    missatge = "El servidor no esta operativo";
                    break;
                case 547:
                    missatge = "El registro tiene datos relacionados";
                    break;
                case 2601:
                    missatge = "Registro duplicado";
                    break;
                case 2627:
                    missatge = "Registro duplicado";
                    break;
                case 4060:
                    missatge = "No se puede abrir la base de datos";
                    break;
                case 18456:
                    missatge = "Error al iniciar sesion";
                    break;
                default:
                    missatge = sqlException.Number + " - " + sqlException.Message;
                    break;
            }
            return missatge;
        }
    }
}
