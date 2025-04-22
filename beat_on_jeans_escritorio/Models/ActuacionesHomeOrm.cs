using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace beat_on_jeans_escritorio.Models
{
    public class ActuacionesHomeOrm
    {
        public static List<dynamic> GetActuacionesConNombres()
        {
            using (var db = new dam05Entities1())
            {
                try
                {
                    return db.Actuacion
                           .Include(a => a.UsuarioMobil.Usuarios)
                           .Include(a => a.UsuarioMobil1.Usuarios)
                           .Select(a => new
                           {
                               Fecha = a.Fecha,
                               Local = a.UsuarioMobil.Usuarios.Nombre,
                               Musico = a.UsuarioMobil1.Usuarios.Nombre
                           })
                           .ToList<dynamic>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return new List<dynamic>();
                }
            }
        }
    }
}