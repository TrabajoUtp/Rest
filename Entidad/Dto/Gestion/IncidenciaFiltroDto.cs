using System;
using Entidad.Vo;

namespace Entidad.Dto.Gestion
{
    public class IncidenciaFiltroDto : DataTableNet
    {
        public Int32 IdCliente { get; set; }
        public String Asunto { get; set; }
        public Int32 IdTipoIncidencia { get; set; }
        public Int32 IdMotivo { get; set; }
        public Int32 IdPrioridad { get; set; }
        public Int32 IdEstado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
