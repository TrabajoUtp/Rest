using System;
using Entidad.Vo;

namespace Entidad.Dto.Seguridad
{
    public class RolFiltroDto: DataTableNet
    {
        public String Nombre { get; set; }
        public Int32 IdEstado { get; set; }
    }
}
