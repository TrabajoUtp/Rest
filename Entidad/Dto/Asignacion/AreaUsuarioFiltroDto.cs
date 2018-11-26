using System;
using Entidad.Vo;

namespace Entidad.Dto.Asignacion
{
    public class AreaUsuarioFiltroDto : DataTableNet
    {
        public Int32 IdAreaUsuario { get; set; }
        public String Buscar { get; set; }
        public Int32 IdEstado { get; set; }
        public Int32 IdArea { get; set; }
        public Int32 IdUsuario { get; set; }
        public String ListaIdUsuarios { get; set; }

        public AreaUsuarioFiltroDto()
        {
            ListaIdUsuarios = String.Empty;
        }
    }
}
