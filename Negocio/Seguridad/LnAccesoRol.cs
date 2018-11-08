using System.Collections.Generic;
using Datos.Seguridad;
using Entidad.Dto.Seguridad;

namespace Negocio.Seguridad
{
    public class LnAccesoRol
    {
        private readonly AdAccesoRol _adAccesoRol = new AdAccesoRol();
        public List<AccesoDto> ObtenerPorIdUsuario(int idUsuario)
        {
            return _adAccesoRol.ObtenerPorIdUsuario(idUsuario);
        }
    }
}
