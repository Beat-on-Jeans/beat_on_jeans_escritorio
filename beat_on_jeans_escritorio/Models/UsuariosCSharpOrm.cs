using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace beat_on_jeans_escritorio.Models
{
    public static class UsuariosCSharpOrm
    {
        // Recoge los usuarios Adm, SupAdm y Mant
        public static List<Usuarios> Select()
        {
            List<Usuarios> _usuarios = (
                    from u in Orm.db.Usuarios
                    where u.ROL_ID >= 3 && u.ROL_ID <= 5
                    select u
                    ).ToList();
            return _usuarios;
        }



        public static Usuarios validarUsuario(string correo, string contrasena, out string mensaje)
        {
            mensaje = string.Empty;
            Usuarios usuario = null;

            var usuarioEncontrado = (from u in Orm.db.Usuarios
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
            else if (usuarioEncontrado.ROL_ID < 3 || usuarioEncontrado.ROL_ID > 5)
            {
                mensaje = "El usuario no tiene los permisos necesarios.";
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
