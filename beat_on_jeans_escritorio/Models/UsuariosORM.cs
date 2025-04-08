using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            try
            {
                var usuarioExistente = Orm.db.Usuarios.FirstOrDefault(u => u.ID == usuarioActualizado.ID);

                if (usuarioExistente != null)
                {
                    // Actualizar propiedades básicas
                    usuarioExistente.Nombre = usuarioActualizado.Nombre;
                    usuarioExistente.Correo = usuarioActualizado.Correo;
                    usuarioExistente.Contrasena = usuarioActualizado.Contrasena;
                    usuarioExistente.ROL_ID = usuarioActualizado.ROL_ID; // Esto debería funcionar aunque ROL_ID sea nullable

                    // Manejo de ubicación - versión mejorada
                    if (usuarioActualizado.ROL_ID.HasValue &&
                       (usuarioActualizado.ROL_ID.Value == 1 || usuarioActualizado.ROL_ID.Value == 2))
                    {
                        usuarioExistente.Ubicacion = usuarioActualizado.Ubicacion;
                    }
                    else
                    {
                        usuarioExistente.Ubicacion = null;
                    }

                    // Forzar la verificación de cambios
                    Orm.db.Entry(usuarioExistente).State = EntityState.Modified;
                    int cambios = Orm.db.SaveChanges();

                    return cambios > 0; // Retorna true si se guardaron cambios
                }
                return false;
            }
            catch (Exception ex)
            {
                // Mejor manejo del error
                System.Diagnostics.Debug.WriteLine($"Error al actualizar usuario: {ex.Message}");
                if (ex.InnerException != null)
                {
                    System.Diagnostics.Debug.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
                return false;
            }
        }



    }
}
