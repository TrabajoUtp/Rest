using Datos.Seguridad;
using Entidad.Dto.Seguridad;

namespace Negocio.Seguridad
{
    public class LnLogin
    {
        private readonly AdLogin _adLogin = new AdLogin();

        public LoginUsuario Login(string usuario, string contrasenia)
        {
            return _adLogin.Login(usuario, contrasenia);
        }
    }
}
