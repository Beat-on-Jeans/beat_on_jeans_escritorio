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
        // Recoge los usuarios Adm, SupAdm y Mant para el LogIn
        public static List<Usuarios> Select()
        {
            List<Usuarios> _usuarios = (
                    from u in Orm.db.Usuarios
                    where u.ROL_ID >= 3 && u.ROL_ID <= 5
                    select u
                    ).ToList();
            return _usuarios;
        }

        // Funcion para validar el usuario
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

        /// <summary>
        /// Select a la base de datos de los musicos.
        /// </summary>
        /// <returns></returns>
        public static List<dynamic> SelectMusicos()
        {
            using (var context = new dam05Entities())
            {
                var query = from u in context.Usuarios
                            join r in context.Roles on u.ROL_ID equals r.ID
                            join um in context.UsuarioMobil on u.ID equals um.Usuario_ID
                            where u.ROL_ID == 1 
                            select new
                            {
                                u.ID,
                                u.Nombre,
                                u.Correo,
                                u.Contrasena,
                                Codigo_Postal = um.Ubicacion,
                                Nombre_Rol = r.Nombre_Rol,
                            };

                return query.ToList<dynamic>();
            }
        }

        /// <summary>
        /// Select de los locales a la base de datos.
        /// </summary>
        /// <returns></returns>
        public static List<dynamic> SelectLocales()
        {
            using (var context = new dam05Entities())
            {
                var query = from u in context.Usuarios
                            join um in context.UsuarioMobil on u.ID equals um.Usuario_ID
                            where u.ROL_ID == 2  // Filtro para solo locales
                            select new
                            {
                                NombreLocal = u.Nombre,
                                CorreoLocal = u.Correo,
                                Ubicacion = um.Ubicacion,
                                ValoracionMedia = um.ValoracionTotal,
                                ID = u.ID  // Mantenemos el ID por si es necesario
                            };

                return query.ToList<dynamic>();
            }
        }






    }
}
