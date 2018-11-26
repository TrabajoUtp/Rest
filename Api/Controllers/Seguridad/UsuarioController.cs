using System;
using System.Collections.Generic;
using System.Web.Http;
using Entidad.Dto.Seguridad;
using Entidad.Entidades.Seguridad;
using Entidad.Vo;
using Negocio.Seguridad;

namespace Api.Controllers.Seguridad
{
    [RoutePrefix("api/Usuario")]
    public class UsuarioController : ApiController
    {
        private readonly LnUsuario _lnUsuario = new LnUsuario();

        // GET: api/Usuario
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Get")]
        public IHttpActionResult Get([FromBody]UsuarioFiltroDto filtro)
        {
            return Json(_lnUsuario.Obtener(filtro));
        }

        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("ObtenerPendientesPorRol")]
        public IHttpActionResult GetPendientesPorRol([FromBody]UsuarioFiltroDto filtro)
        {
            return Json(_lnUsuario.ObtenerPendientesPorRol(filtro));
        }

        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("ObtenerPendientesPorArea")]
        public IHttpActionResult GetPendientesPorArea([FromBody]UsuarioFiltroDto filtro)
        {
            return Json(_lnUsuario.ObtenerPendientesPorArea(filtro));
        }

        // GET: api/Usuario/5
        public Usuario Get(int idUsuario)
        {
            return _lnUsuario.ObtenerPorId(idUsuario);
        }

        [Route("GetCombo")]
        public List<Usuario> GetCombo(DropDownItem opcionCombo, Int32 idEstado)
        {
            return _lnUsuario.ObtenerCombo(opcionCombo, idEstado);
        }

        // POST: api/Usuario
        public Int32 Post([FromBody]Usuario entidad)
        {
            return _lnUsuario.Registrar(entidad);
        }

        // PUT: api/Usuario/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Put")]
        public Int32 Put([FromBody]Usuario entidad)
        {
            return _lnUsuario.Modificar(entidad);
        }

        // DELETE: api/Usuario/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Delete")]
        public Int32 Delete([FromBody]Usuario entidad)
        {
            return _lnUsuario.Eliminar(entidad.IdUsuario);
        }
    }
}
