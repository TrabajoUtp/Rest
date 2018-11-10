using System;
using Entidad.Vo;

namespace Entidad.Dto.Maestro
{
    public class PrioridadFiltroDto: DataTableNet
    {
        public String Nombre { get; set; }
        public Int32 IdEstado { get; set; }
    }
}
