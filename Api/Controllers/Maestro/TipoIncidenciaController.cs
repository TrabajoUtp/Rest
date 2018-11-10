using System;
using System.Collections.Generic;
using System.Web.Http;
using Entidad.Dto.Maestro;
using Entidad.Entidades.Maestro;
using Entidad.Vo;
using Negocio.Maestro;

namespace Api.Controllers.Maestro
{
    [RoutePrefix("api/TipoIncidencia")]
    public class TipoIncidenciaController : ApiController
    {
        private readonly LnTipoIncidencia _lnTipoIncidencia = new LnTipoIncidencia();

        // GET: api/TipoIncidencia
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Get")]
        public IHttpActionResult Get([FromBody]TipoIncidenciaFiltroDto filtro)
        {
            return Json(_lnTipoIncidencia.Obtener(filtro));
        }

        // GET: api/TipoIncidencia/5
        public TipoIncidencia Get(int idTipoIncidencia)
        {
            return _lnTipoIncidencia.ObtenerPorId(idTipoIncidencia);
        }

        [Route("GetCombo")]
        public List<TipoIncidencia> GetCombo(DropDownItem opcionCombo, Int32 idEstado)
        {
            return _lnTipoIncidencia.ObtenerCombo(opcionCombo, idEstado);
        }

        // POST: api/TipoIncidencia
        public Int32 Post([FromBody]TipoIncidencia cliente)
        {
            return _lnTipoIncidencia.Registrar(cliente);
        }

        // PUT: api/TipoIncidencia/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Put")]
        public Int32 Put([FromBody]TipoIncidencia cliente)
        {
            return _lnTipoIncidencia.Modificar(cliente);
        }

        // DELETE: api/TipoIncidencia/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Delete")]
        public Int32 Delete([FromBody]TipoIncidencia cliente)
        {
            return _lnTipoIncidencia.Eliminar(cliente.IdTipoIncidencia);
        }
    }
}
