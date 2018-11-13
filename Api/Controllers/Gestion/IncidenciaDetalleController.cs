using System.Web.Http;
using Entidad.Dto.Gestion;
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

    }
}
