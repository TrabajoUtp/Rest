using System.Collections.Generic;

namespace Entidad.Dto.Seguridad
{
    public class UsuarioLoginDto
    {
        public int IdUsuario { get; set; }
        public string UserName { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }

        public List<RolUsuarioDto> ListaRolUsuario { get; set; }

        public UsuarioLoginDto()
        {
            ListaRolUsuario = new List<RolUsuarioDto>();
            UserName = string.Empty;
            Nombre = string.Empty;
            ApellidoPaterno = string.Empty;
            ApellidoMaterno = string.Empty;
        }

    }
}
