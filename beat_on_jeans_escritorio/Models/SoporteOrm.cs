using System;
using System.Collections.Generic;
using System.Linq;

namespace beat_on_jeans_escritorio.Models
{
    public static class SoporteOrm
    {
        public static List<Soporte> Select()
        {
            List<Soporte> _Soporte = (
                from s in Orm.db.Soporte
                select s
            ).ToList();
            return _Soporte;
        }
    }
}