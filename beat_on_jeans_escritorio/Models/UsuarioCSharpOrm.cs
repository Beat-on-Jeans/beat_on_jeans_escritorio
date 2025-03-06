using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beat_on_jeans_escritorio.Models
{
    public static class UsuarioCSharpOrm
    {
        // Recogemos todos los usuarios de la apliación de C#
        public static List<UsuariosCSharp> Select()
        {
            List<UsuariosCSharp> _usuarioCSSharp = (
                    from u in Orm.db.UsuariosCSharp
                    select u
                    ).ToList();
            return _usuarioCSSharp;
        }
    }
}
