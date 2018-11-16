using System;
using System.Web.Http;
using Entidad.Dto.Gestion;
using Entidad.Entidades.Gestion;
using Negocio.Gestion;

namespace Api.Controllers.Gestion
{
    [RoutePrefix("api/Incidencia")]
    public class IncidenciaController : ApiController
    {
        private readonly LnIncidencia _lnIncidencia = new LnIncidencia();

        // GET: api/Incidencia
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Get")]
        public IHttpActionResult Get([FromBody]IncidenciaFiltroDto filtro)
        {
            return Json(_lnIncidencia.Obtener(filtro));
        }

        // GET: api/Incidencia/5
        public Incidencia Get(int idIncidencia)
        {
            return _lnIncidencia.ObtenerPorId(idIncidencia);
        }

        // POST: api/Incidencia
        public Int32 Post([FromBody]Incidencia faq)
        {
            return _lnIncidencia.Registrar(faq);
        }

        // PUT: api/Incidencia/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Put")]
        public Int32 Put([FromBody]Incidencia faq)
        {
            return _lnIncidencia.Modificar(faq);
        }

        // DELETE: api/Incidencia/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Delete")]
        public Int32 Delete([FromBody]Incidencia faq)
        {
            return _lnIncidencia.Eliminar(faq.IdIncidencia);
        }

        [HttpGet]
        [Route("ObtenerHistorial")]
        public IHttpActionResult ObtenerHistorial(int idIncidencia, int idIncidenciaDetalle)
        {
            return Json(_lnIncidencia.ObtenerHistorial(idIncidencia, idIncidenciaDetalle));
        }

        [HttpGet]
        [Route("ObtenerPorIdDetallado")]
        public IncidenciaDetalladoDto ObtenerPorIdDetallado(int idIncidencia)
        {
            return _lnIncidencia.ObtenerPorIdDetallado(idIncidencia);
        }

    }
}
