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

        public LoginUsuario()
        {
            ListaRolUsuario = new List<RolUsuario>();
            UserName = string.Empty;
            Nombre = string.Empty;
            ApellidoPaterno = string.Empty;
            ApellidoMaterno = string.Empty;
        }

    }
}
