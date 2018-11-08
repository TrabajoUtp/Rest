using System.Collections.Generic;
using System.Web.Http;
using Entidad.Dto.Seguridad;
using Negocio.Seguridad;

namespace Api.Controllers.Seguridad
{
    [RoutePrefix("api/AccesoRol")]
    public class AccesoRolController : ApiController
    {
        private readonly LnAccesoRol _lnAccesoRol = new LnAccesoRol();

        [HttpGet]
        [Route("ObtenerPorIdUsuario")]
        public List<AccesoDto> ObtenerPorIdUsuario(int idUsuario)
        {
            return _lnAccesoRol.ObtenerPorIdUsuario(idUsuario);
        }
    }
}
