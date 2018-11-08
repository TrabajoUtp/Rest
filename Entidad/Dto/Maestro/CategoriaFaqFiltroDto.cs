using System;
using Entidad.Vo;

namespace Entidad.Dto.Maestro
{
    public class CategoriaFaqFiltroDto : DataTableNet
    {
        public String Nombre { get; set; }
        public String Observacion { get; set; }
        public Int32 IdEstado { get; set; }
    }
}
