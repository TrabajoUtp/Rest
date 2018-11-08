using System;
using Entidad.Vo;

namespace Entidad.Dto.Maestro
{
    public class EstadoFiltroDto : DataTableNet
    {
        public String Nombre { get; set; }
        public Int32 IdTipoEstado { get; set; }
    }
}
