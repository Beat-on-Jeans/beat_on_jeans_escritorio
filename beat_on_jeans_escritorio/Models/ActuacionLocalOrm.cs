using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace beat_on_jeans_escritorio.Models
{
    class ActuacionLocalOrm
    {
        public static bool TieneActuacion(string fecha)
        {
            using (var db = new dbJeanEntities())
            {
                try
                {
                    DateTime fechaDate = DateTime.Parse(fecha);
                    return db.Actuacion
                           .Any(a => DbFunctions.TruncateTime(a.Fecha) == DbFunctions.TruncateTime(fechaDate));
                }
                catch
                {
                    return false;
                }
            }
        }

        public static List<dynamic> GetActuacionesPorFecha(string fecha)
        {
            using (var db = new dbJeanEntities())
            {
                try
                {
                    DateTime fechaDate = DateTime.Parse(fecha);

                    return db.Actuacion
                           .Where(a => DbFunctions.TruncateTime(a.Fecha) == DbFunctions.TruncateTime(fechaDate))
                           .Select(a => new
                           {
                               FechaActuacion = a.Fecha,
                               NombreLocal = a.Locales.Ubicacion
                           })
                           .ToList<dynamic>();
                }
                catch
                {
                    return new List<dynamic>();
                }
            }
        }
    }
}