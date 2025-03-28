using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace beat_on_jeans_escritorio.Models
{
    class LocalesMapsOrm
    {
        /// <summary>
        /// Select para seleccionar las ubicaciones de los locales
        /// </summary>
        /// <returns></returns>
        public static List<string> SelectUbicacionesLocales()
        {
            try
            {
                using (var context = new dam05Entities())
                {
                    return (from u in context.Usuarios
                            join um in context.UsuarioMobil on u.ID equals um.Usuario_ID
                            where u.ROL_ID == 2 &&
                                  um.Ubicacion != null &&
                                  um.Ubicacion != string.Empty
                            select um.Ubicacion)
                           .Distinct()
                           .OrderBy(u => u)
                           .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener ubicaciones de locales: " + ex.Message);
                throw;
            }
        }

        // Método para obtener la información de un local por su ubicación
        public static dynamic SelectLocalPorUbicacion(string ubicacion)
        {
            try
            {
                using (var context = new dam05Entities())
                {
                    var query = from u in context.Usuarios
                                join um in context.UsuarioMobil on u.ID equals um.Usuario_ID
                                where u.ROL_ID == 2 &&
                                      um.Ubicacion == ubicacion
                                select new
                                {
                                    NombreLocal = u.Nombre,
                                    Valoracion = um.ValoracionTotal,
                                    Ubicacion = um.Ubicacion
                                };

                    return query.FirstOrDefault(); // Devolver solo el primer local que coincida
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener local para {ubicacion}: " + ex.Message);
                throw;
            }
        }
    }
}
