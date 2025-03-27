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
                using (var db = new dam05Entities()) 
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

        // En la clase TicketsOrm, añade este nuevo método
        public static (string nombreUsuario, string nombreTecnico) GetNombresUsuarioYTecnico(int usuarioId, int tecnicoId)
        {
            try
            {
                using (var db = new dam05Entities())
                {
                    // Obtener nombre del usuario
                    var usuario = db.Usuarios.FirstOrDefault(u => u.ID == usuarioId);
                    string nombreUsuario = usuario?.Nombre ?? "Desconocido";

                    // Obtener nombre del técnico
                    var tecnico = db.Usuarios.FirstOrDefault(u => u.ID == tecnicoId);
                    string nombreTecnico = tecnico?.Nombre ?? "Desconocido";

                    return (nombreUsuario, nombreTecnico);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener nombres: " + ex.Message);
            }
        }
    }
}