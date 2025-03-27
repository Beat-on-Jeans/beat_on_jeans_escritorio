using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace beat_on_jeans_escritorio.Models
{
    class LocalesOrm
    {
        public static List<dynamic> SelectLocalesInfo()
        {
            List<dynamic> localesInfo = new List<dynamic>();

            try
            {
                using (var context = new dam05Entities())
                {
                    var query = (from local in context.Locales
                                 join usuario in context.Usuarios on local.Usuario_ID equals usuario.ID
                                 select new
                                 {
                                     NombreLocal = usuario.Nombre,
                                     ValoracionMedia = local.Valoracion_Media,
                                     Ubicacion = local.Ubicacion
                                 }).ToList();

                    localesInfo = query.ToList<dynamic>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener información de locales: " + ex.Message);
            }

            return localesInfo;
        }
    }
}