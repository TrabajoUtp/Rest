using System;
using Entidad.Vo;

namespace Entidad.Dto.Seguridad
{
    public class AccesoFiltroDto : DataTableNet
    {
        public String Buscar { get; set; }
        public Int32 IdEstado { get; set; }
    }
}
