using System.ComponentModel.DataAnnotations;

namespace Entidad.Entidades.Seguridad
{
    public class Rol
    {
        [Required]
        public int IdRol { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Observacion { get; set; }
        [Required]
        public int IdEstado { get; set; }
    }
}
