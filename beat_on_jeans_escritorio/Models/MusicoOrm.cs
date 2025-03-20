using System;
using System.Collections.Generic;
using System.Linq;
using beat_on_jeans_escritorio.Models;

namespace beat_on_jeans_escritorio.Models
{
    public static class MusicoOrm
    {
        public static List<Musicos> Select()
        {
            List<Musicos> _Musicos = (
                    from u in Orm.db.Musicos
                    select u
                    ).ToList();
            return _Musicos;

        }
    }
}