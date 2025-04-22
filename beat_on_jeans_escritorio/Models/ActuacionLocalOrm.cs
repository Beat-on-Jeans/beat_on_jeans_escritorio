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
            using (var db = new dam05Entities1())
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
            using (var db = new dam05Entities1())
            {
                try
                {
                    return db.Actuacion
                           .Include(a => a.UsuarioMobil)     // Relación con el Local (UsuarioMobil_Local_ID)
                           .Include(a => a.UsuarioMobil.Usuarios)  // Datos del usuario Local
                           .Include(a => a.UsuarioMobil1)    // Relación con el Músico (UsuarioMobil_Musico_ID)
                           .Include(a => a.UsuarioMobil1.Usuarios) // Datos del usuario Músico
                           .Where(a => DbFunctions.TruncateTime(a.Fecha) == fecha.Date)
                           .Select(a => new
                           {
                               FechaActuacion = a.Fecha,
                               // Asegurando que obtenemos la ubicación del LOCAL (ROL_ID=2)
                               UbicacionLocal = a.UsuarioMobil.Usuarios.ROL_ID == 2 ?
                                              a.UsuarioMobil.Ubicacion :
                                              a.UsuarioMobil1.Ubicacion,
                               NombreLocal = a.UsuarioMobil.Usuarios.Nombre,
                               NombreMusico = a.UsuarioMobil1.Usuarios.Nombre
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