using System;

namespace Entidad.Dto.Asignacion
{
    public class AreaUsuarioDto
    {
        public Int32 Item { get; set; }
        public Int32 IdAreaUsuario { get; set; }
        public Int32 IdUsuario { get; set; }
        public String UserName { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String Nombre { get; set; }
        public int IdEstado { get; set; }
        public Int32 TotalItems { get; set; }
    }
}
