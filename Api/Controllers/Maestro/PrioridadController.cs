using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entidad.Dto.Maestro;
using Entidad.Entidades.Maestro;
using Entidad.Vo;
using Negocio.Maestro;

namespace Api.Controllers.Maestro
{
    [RoutePrefix("api/Prioridad")]
    public class PrioridadController : ApiController
    {
        private readonly LnPrioridad _lnPrioridad = new LnPrioridad();

        // GET: api/Prioridad
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Get")]
        public IHttpActionResult Get([FromBody]PrioridadFiltroDto filtro)
        {
            return Json(_lnPrioridad.Obtener(filtro));
        }

        // GET: api/Prioridad/5
        public Prioridad Get(int idPrioridad)
        {
            return _lnPrioridad.ObtenerPorId(idPrioridad);
        }

        [Route("GetCombo")]
        public List<Prioridad> GetCombo(DropDownItem opcionCombo, Int32 idEstado)
        {
            return _lnPrioridad.ObtenerCombo(opcionCombo, idEstado);
        }

        // POST: api/Prioridad
        public Int32 Post([FromBody]Prioridad cliente)
        {
            return _lnPrioridad.Registrar(cliente);
        }

        // PUT: api/Prioridad/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Put")]
        public Int32 Put([FromBody]Prioridad cliente)
        {
            return _lnPrioridad.Modificar(cliente);
        }

        // DELETE: api/Prioridad/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Delete")]
        public Int32 Delete([FromBody]Prioridad cliente)
        {
            return _lnPrioridad.Eliminar(cliente.IdPrioridad);
        }
    }
}
