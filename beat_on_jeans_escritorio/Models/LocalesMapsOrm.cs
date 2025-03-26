using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace beat_on_jeans_escritorio.Models
{
    class LocalesMapsOrm
    {
        // Método para obtener ubicaciones únicas
        public static List<string> SelectUbicacionesLocales()
        {
            try
            {
                using (var context = new dam05Entities())
                {
                    return context.Locales
                                 .Where(l => l.Ubicacion != null && l.Ubicacion != "")
                                 .Select(l => l.Ubicacion)
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
                    // Retorna solo el primer local que coincide con la ubicación
                    return context.Locales
                                 .Where(l => l.Ubicacion == ubicacion)
                                 .Join(context.Usuarios,
                                       local => local.Usuario_ID,
                                       usuario => usuario.ID,
                                       (local, usuario) => new
                                       {
                                           NombreLocal = usuario.Nombre,
                                           Valoracion = local.Valoracion_Media,
                                           Ubicacion = local.Ubicacion
                                       })
                                 .FirstOrDefault(); // Devolver solo el primer local
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
