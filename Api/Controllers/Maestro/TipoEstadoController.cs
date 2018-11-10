using System;
using System.Collections.Generic;
using System.Web.Http;
using Entidad.Dto.Maestro;
using Entidad.Entidades.Maestro;
using Entidad.Vo;
using Negocio.Maestro;

namespace Api.Controllers.Maestro
{
    [RoutePrefix("api/TipoEstado")]
    public class TipoEstadoController : ApiController
    {
        private readonly LnTipoEstado _lnTipoEstado = new LnTipoEstado();

        // GET: api/TipoEstado
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Get")]
        public IHttpActionResult Get([FromBody]TipoEstadoFiltroDto filtro)
        {
            return Json(_lnTipoEstado.Obtener(filtro));
        }

        // GET: api/TipoEstado/5
        public TipoEstado Get(int idTipoEstado)
        {
            return _lnTipoEstado.ObtenerPorId(idTipoEstado);
        }

        [Route("GetCombo")]
        public List<TipoEstado> GetCombo(DropDownItem opcionCombo)
        {
            return _lnTipoEstado.ObtenerCombo(opcionCombo);
        }

        // POST: api/TipoEstado
        public Int32 Post([FromBody]TipoEstado cliente)
        {
            return _lnTipoEstado.Registrar(cliente);
        }

        // PUT: api/TipoEstado/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Put")]
        public Int32 Put([FromBody]TipoEstado cliente)
        {
            return _lnTipoEstado.Modificar(cliente);
        }

        // DELETE: api/TipoEstado/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Delete")]
        public Int32 Delete([FromBody]TipoEstado cliente)
        {
            return _lnTipoEstado.Eliminar(cliente.IdTipoEstado);
        }
    }
}
