using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beat_on_jeans_escritorio.Models
{
    public static class UsuarioCSharpOrm
    {
        // Recogemos todos los usuarios de la aplicación de C#
        public static List<UsuariosCSharp> Select()
        {
            List<UsuariosCSharp> _usuarioCSSharp = (
                    from u in Orm.db.UsuariosCSharp
                    select u
                    ).ToList();
            return _usuarioCSSharp;
        }

        // Validamos el usuario que inserta el usuario
        public static UsuariosCSharp validarUsuario(string correo, string contrasena, out string mensaje)
        {
            mensaje = string.Empty;
            UsuariosCSharp usuario = null;

            var usuarioEncontrado = (from u in Orm.db.UsuariosCSharp
                                     where u.Correo == correo
                                     select u).FirstOrDefault();


            if (usuarioEncontrado == null)
            {
                mensaje = "El correo no existe.";
            }

            else if (usuarioEncontrado.Contrasena != contrasena)
            {
                mensaje = "La contraseña es incorrecta.";
            }
            else
            {
                mensaje = "Usuario validado correctamente.";
                usuario = usuarioEncontrado;
            }

            // Devolvemos el usuario validado o null
            return usuario;
        }
    }
}
