using System;

namespace Entidad.Dto.Seguridad
{
    public class RolDto
    {
        public Int32 Item { get; set; }
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public string Observacion { get; set; }
        public int IdEstado { get; set; }
        public Int32 TotalItems { get; set; }
    }
}
