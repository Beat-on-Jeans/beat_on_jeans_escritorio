using System;

namespace beat_on_jeans_escritorio.Clases
{
    public class Soporte
    {
        public int ID { get; set; }
        public int Usuario_ID { get; set; }
        public int Tecnico_ID { get; set; }
        public string Tipo_Incidencia { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public DateTime? Fecha_Cierre { get; set; } 
    }
}