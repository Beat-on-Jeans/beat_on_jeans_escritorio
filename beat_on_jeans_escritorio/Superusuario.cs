using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beat_on_jeans_escritorio
{
    public class Superusuario : UsuariosCSharp
    {
        public Superusuario(int id, string correo, string contrasena, int rol)
        {
            this.id = id;
            this.contrasena = contrasena;
            this.correo = correo;
            this.rol = rol;
        }

    }
}
