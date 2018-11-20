using System;
using System.Web.Http;
using Entidad.Dto.Asignacion;
using Entidad.Entidades.Asignacion;
using Negocio.Asignacion;

namespace Api.Controllers.Asignacion
{
    [RoutePrefix("api/UsuarioCliente")]
    public class UsuarioClienteController : ApiController
    {
        private readonly LnUsuarioCliente _lnUsuarioCliente = new LnUsuarioCliente();

        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Get")]
        public IHttpActionResult Get([FromBody]UsuarioClienteFiltroDto filtro)
        {
            return Json(_lnUsuarioCliente.Obtener(filtro));
        }

        // GET: api/Faq/5
        public UsuarioCliente Get(int idUsuarioCliente)
        {
            return _lnUsuarioCliente.ObtenerPorId(idUsuarioCliente);
        }

        // POST: api/UsuarioCliente
        public Int32 Post([FromBody]UsuarioClienteFiltroDto entidad)
        {
            return _lnUsuarioCliente.Registrar(entidad);
        }

        // DELETE: api/UsuarioCliente/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Delete")]
        public Int32 Delete([FromBody]UsuarioCliente entidad)
        {
            return _lnUsuarioCliente.Eliminar(entidad.IdUsuarioCliente);
        }

    }
}
