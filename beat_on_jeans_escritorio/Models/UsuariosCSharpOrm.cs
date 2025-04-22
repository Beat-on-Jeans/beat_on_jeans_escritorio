using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
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

        public static List<dynamic> SelectMusicos()
        {
            using (var context = new dam05Entities1())
            {
                var query = from u in context.Usuarios
                            join r in context.Roles on u.ROL_ID equals r.ID
                            join um in context.UsuarioMobil on u.ID equals um.Usuario_ID
                            where u.ROL_ID == 1 // Cambiado a 2 o el ID correcto para músicos
                            select new
                            {
                                u.ID,
                                u.Nombre,
                                u.Correo,
                                u.Contrasena,
                                Ubicacion = um.Ubicacion,
                                Valoracion = um.ValoracionTotal,
                                Imagen = um.Url_Imagen,
                                Rol = r.Nombre_Rol,
                                ROL_ID = r.ID
                            };

                return query.ToList<dynamic>();
            }
        }

        public static List<dynamic> SelectLocales()
        {
            using (var context = new dam05Entities1())
            {
                var query = from u in context.Usuarios
                            join r in context.Roles on u.ROL_ID equals r.ID  // Join con la tabla Roles
                            join um in context.UsuarioMobil on u.ID equals um.Usuario_ID
                            where u.ROL_ID == 2  // Filtro para solo locales
                            select new
                            {
                                NombreLocal = u.Nombre,
                                CorreoLocal = u.Correo,
                                u.Contrasena,
                                Ubicacion = um.Ubicacion,
                                ValoracionMedia = um.ValoracionTotal,
                                Rol = r.Nombre_Rol,  // Añadimos el nombre del rol
                                ID = u.ID,
                                ROL_ID = u.ROL_ID  // Mantenemos el ID del rol por si es necesario
                            };

                return query.ToList<dynamic>();
            }
        }

        public static List<dynamic> SelectSuperadministradores()
        {
            using (var context = new dam05Entities1())
            {
                var query = from u in context.Usuarios
                            join r in context.Roles on u.ROL_ID equals r.ID
                            where u.ROL_ID == 3 
                            select new
                            {
                                u.ID,
                                u.Nombre,
                                u.Correo,
                                u.Contrasena,
                                Rol = r.Nombre_Rol,
                                ROL_ID = u.ROL_ID
                            };

                return query.ToList<dynamic>();
            }
        }

        public static List<dynamic> SelectAdministradores()
        {
            using (var context = new dam05Entities1())
            {
                return (from u in context.Usuarios
                        join r in context.Roles on u.ROL_ID equals r.ID
                        where u.ROL_ID == 4 
                        select new
                        {
                            u.ID,
                            u.Nombre,
                            u.Correo,
                            Rol = r.Nombre_Rol,
                            ROL_ID = u.ROL_ID,
                            u.Contrasena 
                        }).ToList<dynamic>();
            }
        }

        public static List<dynamic> SelectMantenimiento()
        {
            using (var context = new dam05Entities1())
            {
                return (from u in context.Usuarios
                        join r in context.Roles on u.ROL_ID equals r.ID
                        where u.ROL_ID == 5  
                        select new
                        {
                            u.ID,
                            u.Nombre,
                            u.Correo,
                            Rol = r.Nombre_Rol,
                            ROL_ID = u.ROL_ID,
                            u.Contrasena  
                        }).ToList<dynamic>();
            }
        }

        public static List<dynamic> SelectMusicosYLocales()
        {
            using (var context = new dam05Entities1())
            {
                var query = from u in context.Usuarios
                            join r in context.Roles on u.ROL_ID equals r.ID
                            where u.ROL_ID == 1 || u.ROL_ID == 2
                            select new
                            {
                                u.ID,
                                u.Correo,
                                NombreRol = r.Nombre_Rol,
                                ROL_ID = u.ROL_ID
                            };

                return query.ToList<dynamic>();
            }
        }

        public static bool DeleteUser(int userId)
        {
            using (var context = new dam05Entities1())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // 1. Obtener el usuario con TODAS sus relaciones posibles
                        var usuario = context.Usuarios
                            .Include(u => u.UsuarioMobil)
                            // Relaciones de UsuarioMobil
                            .Include(u => u.UsuarioMobil.Select(um => um.Actuacion)) // Actuaciones como Local
                            .Include(u => u.UsuarioMobil.Select(um => um.Actuacion1)) // Actuaciones como Músico
                            .Include(u => u.UsuarioMobil.Select(um => um.Chats)) // Chats como Local
                            .Include(u => u.UsuarioMobil.Select(um => um.Chats1)) // Chats como Músico
                            .Include(u => u.UsuarioMobil.Select(um => um.Chats.Select(c => c.Mensajes))) // Mensajes como Local
                            .Include(u => u.UsuarioMobil.Select(um => um.Chats1.Select(c => c.Mensajes))) // Mensajes como Músico
                            .Include(u => u.UsuarioMobil.Select(um => um.Generos_Usuarios)) // Géneros musicales
                            .Include(u => u.UsuarioMobil.Select(um => um.Matches)) // Matches como Local
                            .Include(u => u.UsuarioMobil.Select(um => um.Matches1)) // Matches como Músico
                            .Include(u => u.UsuarioMobil.Select(um => um.Notificaciones)) // Notificaciones
                            .Include(u => u.UsuarioMobil.Select(um => um.Valoracion)) // Valoraciones recibidas
                            .Include(u => u.UsuarioMobil.Select(um => um.Valoracion1)) // Valoraciones dadas
                            .Include(u => u.UsuarioMobil.Select(um => um.Soporte)) // Tickets de soporte creados
                            .Include(u => u.UsuarioMobil.Select(um => um.Soporte1)) // Tickets de soporte asignados
                                                                                    // Relaciones de UsuariosCSharp
                            .Include(u => u.UsuariosCSharp)
                            .Include(u => u.UsuariosCSharp.Select(uc => uc.Soporte)) // Tickets de soporte creados
                            .Include(u => u.UsuariosCSharp.Select(uc => uc.Soporte1)) // Tickets de soporte asignados
                            .FirstOrDefault(u => u.ID == userId);

                        if (usuario == null) return false;

                        // 2. Eliminar en orden inverso de dependencia
                        if (usuario.UsuarioMobil != null && usuario.UsuarioMobil.Any())
                        {
                            var usuarioMobil = usuario.UsuarioMobil.First();

                            // 2.1. Eliminar Mensajes de Chats donde es Local
                            if (usuarioMobil.Chats != null)
                            {
                                foreach (var chat in usuarioMobil.Chats.ToList())
                                {
                                    if (chat.Mensajes != null)
                                    {
                                        context.Mensajes.RemoveRange(chat.Mensajes.ToList());
                                    }
                                }
                            }

                            // 2.2. Eliminar Mensajes de Chats donde es Músico
                            if (usuarioMobil.Chats1 != null)
                            {
                                foreach (var chat in usuarioMobil.Chats1.ToList())
                                {
                                    if (chat.Mensajes != null)
                                    {
                                        context.Mensajes.RemoveRange(chat.Mensajes.ToList());
                                    }
                                }
                            }

                            // 2.3. Eliminar Chats donde es Local
                            if (usuarioMobil.Chats != null)
                            {
                                context.Chats.RemoveRange(usuarioMobil.Chats.ToList());
                            }

                            // 2.4. Eliminar Chats donde es Músico
                            if (usuarioMobil.Chats1 != null)
                            {
                                context.Chats.RemoveRange(usuarioMobil.Chats1.ToList());
                            }

                            // 2.5. Eliminar Actuaciones donde es Músico
                            if (usuarioMobil.Actuacion1 != null)
                            {
                                context.Actuacion.RemoveRange(usuarioMobil.Actuacion1.ToList());
                            }

                            // 2.6. Eliminar Actuaciones donde es Local
                            if (usuarioMobil.Actuacion != null)
                            {
                                context.Actuacion.RemoveRange(usuarioMobil.Actuacion.ToList());
                            }

                            // 2.7. Eliminar Matches donde es Local
                            if (usuarioMobil.Matches != null)
                            {
                                context.Matches.RemoveRange(usuarioMobil.Matches.ToList());
                            }

                            // 2.8. Eliminar Matches donde es Músico
                            // 2.8. Eliminar Matches donde es Músico
                            if (usuarioMobil.Matches1 != null)
                            {
                                context.Matches.RemoveRange(usuarioMobil.Matches1.ToList());
                            }

                            // 2.9. Eliminar relaciones con Géneros musicales
                            if (usuarioMobil.Generos_Usuarios != null)
                            {
                                context.Generos_Usuarios.RemoveRange(usuarioMobil.Generos_Usuarios.ToList());
                            }

                            // 2.10. Eliminar Notificaciones
                            if (usuarioMobil.Notificaciones != null)
                            {
                                context.Notificaciones.RemoveRange((IEnumerable<Notificaciones>)usuarioMobil.Notificaciones);
                            }

                            // 2.11. Eliminar Valoraciones recibidas (donde el usuario fue valorado)
                            if (usuarioMobil.Valoracion != null)
                            {
                                context.Valoracion.RemoveRange(usuarioMobil.Valoracion.ToList());
                            }

                            // 2.12. Eliminar Valoraciones dadas (donde el usuario valoró a otros)
                            if (usuarioMobil.Valoracion1 != null)
                            {
                                context.Valoracion.RemoveRange(usuarioMobil.Valoracion1.ToList());
                            }

                            // 2.13. Eliminar Tickets de soporte donde es usuario solicitante
                            if (usuarioMobil.Soporte != null)
                            {
                                context.Soporte.RemoveRange(usuarioMobil.Soporte.ToList());
                            }

                            // 2.14. Eliminar Tickets de soporte donde es técnico asignado
                            if (usuarioMobil.Soporte1 != null)
                            {
                                context.Soporte.RemoveRange(usuarioMobil.Soporte1.ToList());
                            }

                            // 2.15. Eliminar UsuarioMobil
                            context.UsuarioMobil.Remove(usuarioMobil);
                        }

                        // 3. Eliminar datos relacionados con UsuariosCSharp
                        if (usuario.UsuariosCSharp != null && usuario.UsuariosCSharp.Any())
                        {
                            var usuarioCSharp = usuario.UsuariosCSharp.First();

                            // 3.1. Eliminar tickets de soporte creados
                            if (usuarioCSharp.Soporte != null)
                            {
                                context.Soporte.RemoveRange(usuarioCSharp.Soporte.ToList());
                            }

                            // 3.2. Eliminar tickets de soporte asignados
                            if (usuarioCSharp.Soporte1 != null)
                            {
                                context.Soporte.RemoveRange(usuarioCSharp.Soporte1.ToList());
                            }

                            // 3.3. Eliminar UsuarioCSharp
                            context.UsuariosCSharp.Remove(usuarioCSharp);
                        }

                        // 4. Eliminar Usuario principal
                        context.Usuarios.Remove(usuario);

                        // 5. Guardar todos los cambios
                        context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error completo al eliminar usuario: " +
                                             ex.Message + " | " +
                                             (ex.InnerException?.Message ?? "No hay información adicional") + " | " +
                                             (ex.InnerException?.InnerException?.Message ?? "No hay información adicional"));
                    }
                }
            }
        }

        public static UsuariosCSharp Insert(UsuariosCSharp _usuario)
        {
            Orm.db.UsuariosCSharp.Add(_usuario);
            Orm.db.SaveChanges();
            return _usuario;
        }

        // Nueva función para crear un usuario de tipo UsuariosCSharp
        public static UsuariosCSharp CrearUsuarioCSharp(int usuarioId, int rolId)
        {
            UsuariosCSharp nuevoUsuarioCSharp = new UsuariosCSharp
            {
                Usuario_Id = usuarioId,
                RoleId = rolId
            };

            return Insert(nuevoUsuarioCSharp);
        }
    }
}
