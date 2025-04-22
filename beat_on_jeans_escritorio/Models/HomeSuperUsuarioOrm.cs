using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beat_on_jeans_escritorio.Models
{
    class HomeSuperUsuarioOrm
    {

        public static List<dynamic> SelectLocales()
        {
            using (var context = new dam05Entities1())
            {
                var query = from u in context.Usuarios
                            join um in context.UsuarioMobil on u.ID equals um.Usuario_ID
                            where u.ROL_ID == 2  // Filtro para solo locales
                            select new
                            {
                                NombreLocal = u.Nombre,
                                CorreoLocal = u.Correo,
                                Ubicacion = um.Ubicacion,
                                ValoracionMedia = um.ValoracionTotal,
                                ID = u.ID  // Mantenemos el ID por si es necesario
                            };

                return query.ToList<dynamic>();
            }
        }

    }
}
