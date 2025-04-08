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

        public static Usuarios Insert(Usuarios _usuario)
        {
            Orm.db.Usuarios.Add(_usuario);
            Orm.db.SaveChanges();
            return _usuario;
        }

        // Verificar si el correo ya existe
        public static bool CorreoExiste(string correo)
        {
            return Orm.db.Usuarios.Any(u => u.Correo == correo);
        }
        public static bool UpdateUser(Usuarios usuarioActualizado)
        {
            // Buscar el usuario existente en la base de datos
            var usuarioExistente = Orm.db.Usuarios.FirstOrDefault(u => u.ID == usuarioActualizado.ID);

            if (usuarioExistente != null)
            {
                // Actualizar los campos del usuario existente con los valores del usuario actualizado
                usuarioExistente.Nombre = usuarioActualizado.Nombre;
                usuarioExistente.Correo = usuarioActualizado.Correo;
                usuarioExistente.Contrasena = usuarioActualizado.Contrasena;
                usuarioExistente.ROL_ID = usuarioActualizado.ROL_ID;

                // Guardar los cambios en la base de datos
                Orm.db.SaveChanges();
                return true;
            }

            return false; // Retornar false si el usuario no fue encontrado
        }



    }
}
