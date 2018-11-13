using System;

namespace Entidad.Entidades.Seguridad
{
    public class Usuario
    {
        public Int32 IdUsuario { get; set; }
        public String UserName { get; set; }
        public String Contrasenia { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public Int32 IdEstado { get; set; }
    }
}
