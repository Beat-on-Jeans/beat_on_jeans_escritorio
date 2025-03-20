using beat_on_jeans_escritorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class LocalOrm
{
    public static List<Locales> Select()
    {
        List<Locales> _Locales = (
            from l in Orm.db.Locales
            select l
        ).ToList();
        return _Locales;
    }
}
