using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beat_on_jeans_escritorio.Models
{
    public static class RolesOrm
    {
        public static List<Roles> Select()
        {
            List<Roles> _roles = (
                    from r in Orm.db.Roles
                    select r
                    ).ToList();
            return _roles;
        }
    }
}
