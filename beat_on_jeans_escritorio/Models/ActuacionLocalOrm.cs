using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace beat_on_jeans_escritorio.Models
{
    public class ActuacionLocalOrm
    {
        public static bool TieneActuacion(DateTime fecha)
        {
            using (var db = new dam05Entities())
            {
                try
                {
                    return db.Actuacion
                           .Any(a => DbFunctions.TruncateTime(a.Fecha) == fecha.Date);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en TieneActuacion: {ex.Message}");
                    return false;
                }
            }
        }

        public static List<dynamic> GetActuacionesPorFecha(DateTime fecha)
        {
            using (var db = new dam05Entities())
            {
                try
                {
                    return db.Actuacion
                           .Include(a => a.Locales)
                           .Include(a => a.Musicos)
                           .Include(a => a.Musicos.UsuarioMobil)
                           .Include(a => a.Musicos.UsuarioMobil.Usuarios)
                           .Where(a => DbFunctions.TruncateTime(a.Fecha) == fecha.Date)
                           .Select(a => new
                           {
                               FechaActuacion = a.Fecha,
                               NombreMusico = a.Musicos.UsuarioMobil.Usuarios.Nombre,
                               NombreLocal = a.Locales.UsuarioMobil.Usuarios.Nombre, // Nombre del local
                               DireccionLocal = a.Locales.Ubicacion // Dirección del local
                           })
                           .ToList<dynamic>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al obtener actuaciones: {ex.Message}");
                    return new List<dynamic>();
                }
            }
        }
    }
}