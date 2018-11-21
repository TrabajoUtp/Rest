using System;
using Entidad.Vo;

namespace Entidad.Dto.Asignacion
{
    public class RolUsuarioFiltroDto : DataTableNet
    {
        public Int32 IdRolUsuario { get; set; }
        public String Buscar { get; set; }
        public Int32 IdEstado { get; set; }
        public Int32 IdRol { get; set; }
        public Int32 IdUsuario { get; set; }
        public String ListaIdUsuarios { get; set; }

        public RolUsuarioFiltroDto()
        {
            ListaIdUsuarios = String.Empty;
        }
    }
}