using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beat_on_jeans_escritorio.Models
{
    class MusicosOrm
    {
        public static List<dynamic> SelectMusicosInfo()
        {
            List<dynamic> musicosInfo = new List<dynamic>();

            try
            {
                using (var context = new dam05Entities())
                {
                    var query = (from musicos in context.Musicos
                                 join usuario in context.Usuarios on musicos.Usuario_ID equals usuario.ID
                                 select new
                                 {
                                     NombreMusico = usuario.Nombre,
                                     CodigoPostal = musicos.Codigo_Postal
                                 }).ToList();

                    musicosInfo = query.ToList<dynamic>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener información de locales: " + ex.Message);
            }

            return musicosInfo;
        }
    }
}
