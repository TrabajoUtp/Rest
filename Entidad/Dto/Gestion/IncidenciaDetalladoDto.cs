using System;

namespace Entidad.Dto.Gestion
{
    public class IncidenciaDetalladoDto
    {
        public Int32 IdIncidencia { get; set; }
        public String Asunto { get; set; }
        public String NumeroDocumento { get; set; }
        public String RazonSocial { get; set; }
        public String NombreTipoIncidencia { get; set; }
        public String NombrePrioridad { get; set; }
        public Int32 IdEstado { get; set; }
        public String NombreEstado { get; set; }

    }
}
