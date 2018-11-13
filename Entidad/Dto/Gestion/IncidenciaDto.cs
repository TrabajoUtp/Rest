using System;

namespace Entidad.Dto.Gestion
{
    public class IncidenciaDto
    {
        public Int32 Item { get; set; }
        public Int32 IdIncidencia { get; set; }
        public String Asunto { get; set; }
        public String TipoIncidencia { get; set; }
        public String Prioridad { get; set; }
        public String Motivo { get; set; }
        public String Estado { get; set; }
        public Int32 IdEstado { get; set; }
        public String FechaRegistro { get; set; }
        public Int32 TotalItems { get; set; }
    }
}
