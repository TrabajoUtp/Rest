using System;
using System.Web.Http;
using Entidad.Dto.Gestion;
using Entidad.Entidades.Gestion;
using Negocio.Gestion;

namespace Api.Controllers.Gestion
{
    [RoutePrefix("api/IncidenciaDetalle")]
    public class IncidenciaDetalleController : ApiController
    {
        private readonly LnIncidenciaDetalle _lnIncidenciaDetalle = new LnIncidenciaDetalle();

        // GET: api/IncidenciaDetalle
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Get")]
        public IHttpActionResult Get([FromBody]IncidenciaDetalleFiltroDto filtro)
        {
            return Json(_lnIncidenciaDetalle.Obtener(filtro));
        }

        // GET: api/Incidencia/5
        public IncidenciaDetalle Get(int idIncidenciaDetalle)
        {
            return _lnIncidenciaDetalle.ObtenerPorId(idIncidenciaDetalle);
        }

        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("RegistrarHistorial")]
        public Int32 RegistrarHistorial(IncidenciaEstadoDto entidad)
        {
            if (entidad == null)
            {
                return 0;
            }
            return _lnIncidenciaDetalle.RegistrarHistorial(entidad);
        }

    }
}
