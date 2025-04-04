using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beat_on_jeans_escritorio.Models
{
    public static class UsuarioMovilOrm
    {
        public static UsuarioMobil Insert(UsuarioMobil usuarioMobil)
        {
            Orm.db.UsuarioMobil.Add(usuarioMobil);
            Orm.db.SaveChanges();
            return usuarioMobil;
        }
    }
}
