using System.Collections.Generic;

namespace Entidad.Dto.Seguridad
{
    public class LoginUsuario
    {
        public int IdUsuario { get; set; }
        public string UserName { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }

        public List<RolUsuario> ListaRolUsuario { get; set; } 
    }
}
