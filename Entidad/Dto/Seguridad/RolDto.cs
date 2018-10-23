using System.ComponentModel.DataAnnotations;

namespace Entidad.Dto.Seguridad
{
    public class RolDto
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public string Observacion { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
    }
}
