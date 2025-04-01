using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beat_on_jeans_escritorio.Models
{
    public static class UsuariosORM
    {
        public static List<Usuarios> Select()
        {
            List<Usuarios> _usuarios = (
                    from u in Orm.db.Usuarios
                    select u
                    ).ToList();
            return _usuarios;
        }
    }
}
