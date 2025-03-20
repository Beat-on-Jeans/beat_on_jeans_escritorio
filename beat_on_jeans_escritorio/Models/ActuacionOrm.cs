using System;
using System.Collections.Generic;
using System.Linq;

namespace beat_on_jeans_escritorio.Models
{
    public static class ActuacionOrm
    {
        public static List<Actuacion> Select()
        {
            List<Actuacion> _Actuacion = (
            from a in Orm.db.Actuacion
            select a
        ).ToList();
            return _Actuacion;
        }
    }
}