using System;
using Entidad.Vo;

namespace Entidad.Dto.Maestro
{
    public class ClienteFiltroDto : DataTableNet
    {
        public String Buscar { get; set; }
        public Int32 IdEstado { get; set; }
        public Int32 IdUsuario { get; set; }
        
    }
}
