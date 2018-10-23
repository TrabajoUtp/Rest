using System;

namespace Entidad.Dto.Seguridad
{
    public class RolFiltro: Paginacion
    {
        public Int32 IdRol { get; set; }
        public String Nombre { get; set; }
        public String Observacion { get; set; }
        public Int32 IdEstado { get; set; }
    }
}
