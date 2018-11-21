using System;
using System.Web.Http;
using Entidad.Dto.Asignacion;
using Entidad.Entidades.Asignacion;
using Negocio.Asignacion;

namespace Api.Controllers.Asignacion
{
    [RoutePrefix("api/RolUsuario")]
    public class RolUsuarioController : ApiController
    {
        private readonly LnRolUsuario _lnRolUsuario = new LnRolUsuario();

        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Get")]
        public IHttpActionResult Get([FromBody]RolUsuarioFiltroDto filtro)
        {
            return Json(_lnRolUsuario.Obtener(filtro));
        }

        // GET: api/Faq/5
        public RolUsuario Get(int idRolUsuario)
        {
            return _lnRolUsuario.ObtenerPorId(idRolUsuario);
        }

        // POST: api/RolUsuario
        public Int32 Post([FromBody]RolUsuarioFiltroDto entidad)
        {
            return _lnRolUsuario.Registrar(entidad);
        }

        // DELETE: api/RolUsuario/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Delete")]
        public Int32 Delete([FromBody]RolUsuario entidad)
        {
            return _lnRolUsuario.Eliminar(entidad.IdRolUsuario);
        }
    }
}
