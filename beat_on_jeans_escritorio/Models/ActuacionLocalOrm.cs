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
                           .Include(a => a.UsuarioMobil)     // Relación con el Local (UsuarioMobil_L)
                           .Include(a => a.UsuarioMobil1)    // Relación con el Músico (UsuarioMobil_M)
                           .Include(a => a.UsuarioMobil.Usuarios)  // Datos del Local
                           .Include(a => a.UsuarioMobil1.Usuarios) // Datos del Músico
                           .Where(a => DbFunctions.TruncateTime(a.Fecha) == fecha.Date)
                           .Select(a => new
                           {
                               FechaActuacion = a.Fecha,
                               UbicacionLocal = a.UsuarioMobil.Ubicacion,
                               NombreLocal = a.UsuarioMobil.Usuarios.Nombre,
                               NombreMusico = a.UsuarioMobil1.Usuarios.Nombre,
                               // Campos adicionales que podrían ser útiles:
                               ImagenLocal = a.UsuarioMobil.Url_Imagen,
                               ImagenMusico = a.UsuarioMobil1.Url_Imagen,
                               ValoracionLocal = a.UsuarioMobil.ValoracionTotal,
                               ValoracionMusico = a.UsuarioMobil1.ValoracionTotal
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