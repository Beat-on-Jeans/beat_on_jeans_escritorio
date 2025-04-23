using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity; 

namespace beat_on_jeans_escritorio.Models
{
    class TicketsOrm
    {
        public static List<dynamic> SelectTicketsWithIncidentType()
        {
            try
            {
                using (var db = new dam05Entities1()) 
                {
                    var query = db.Soporte
                        .Include(s => s.TipoIncidencia) 
                        .Select(s => new
                        {
                            s.ID,
                            s.Usuario_ID,
                            s.Tecnico_ID,
                            TipoIncidencia = s.TipoIncidencia.Nombre_Incidencia,
                            s.Fecha_Creacion,
                            s.Fecha_Cierre
                        })
                        .ToList<dynamic>();

                    return query;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener tickets: " + ex.Message);
            }
        }

        public static (string nombreUsuario, string nombreTecnico) GetNombresUsuarioYTecnico(int usuarioId, int tecnicoId)
        {
            try
            {
                using (var db = new dam05Entities1())
                {
                    // 1. Obtener nombre del usuario principal
                    var usuario = db.Usuarios
                                  .Where(u => u.ID == usuarioId)
                                  .Select(u => new { u.Nombre })
                                  .FirstOrDefault();

                    string nombreUsuario = usuario?.Nombre ?? "Usuario no encontrado";

                    // 2. Obtener nombre del técnico (a través de UsuariosCSharp)
                    var tecnico = db.UsuariosCSharp
                                 .Where(uc => uc.ID == tecnicoId)
                                 .Join(db.Usuarios,
                                       uc => uc.Usuario_Id,
                                       u => u.ID,
                                       (uc, u) => new { u.Nombre })
                                 .FirstOrDefault();

                    string nombreTecnico = tecnico?.Nombre ?? "Técnico no encontrado";

                    return (nombreUsuario, nombreTecnico);
                }
            }
            catch (Exception ex)
            {
                return ("Error al obtener usuario", "Error al obtener técnico");
            }
        }

        public static void DeleteTicket(int ticketId)
        {
            try
            {
                using (var db = new dam05Entities1())
                {
                    // Buscar el ticket a eliminar
                    var ticket = db.Soporte.FirstOrDefault(s => s.ID == ticketId);

                    if (ticket != null)
                    {
                        db.Soporte.Remove(ticket);
                        db.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("No se encontró el ticket con ID: " + ticketId);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar ticket: " + ex.Message);
            }
        }
    }
}