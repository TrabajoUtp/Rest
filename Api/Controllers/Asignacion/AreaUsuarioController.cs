using System;
using System.Web.Http;
using Entidad.Dto.Asignacion;
using Entidad.Entidades.Asignacion;
using Negocio.Asignacion;

namespace Api.Controllers.Asignacion
{
    [RoutePrefix("api/AreaUsuario")]
    public class AreaUsuarioController : ApiController
    {
        private readonly LnAreaUsuario _lnAreaUsuario = new LnAreaUsuario();

        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Get")]
        public IHttpActionResult Get([FromBody]AreaUsuarioFiltroDto filtro)
        {
            return Json(_lnAreaUsuario.Obtener(filtro));
        }

        // GET: api/Faq/5
        public AreaUsuario Get(int idAreaUsuario)
        {
            return _lnAreaUsuario.ObtenerPorId(idAreaUsuario);
        }

        // POST: api/AreaUsuario
        public Int32 Post([FromBody]AreaUsuarioFiltroDto entidad)
        {
            return _lnAreaUsuario.Registrar(entidad);
        }

        // DELETE: api/AreaUsuario/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Delete")]
        public Int32 Delete([FromBody]AreaUsuario entidad)
        {
            return _lnAreaUsuario.Eliminar(entidad.IdAreaUsuario);
        }
    }
}
