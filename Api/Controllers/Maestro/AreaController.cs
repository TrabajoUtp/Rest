using System;
using System.Collections.Generic;
using System.Web.Http;
using Entidad.Dto.Maestro;
using Entidad.Entidades.Maestro;
using Entidad.Vo;
using Negocio.Maestro;

namespace Api.Controllers.Maestro
{
    [RoutePrefix("api/Area")]
    public class AreaController : ApiController
    {
        private readonly LnArea _lnArea = new LnArea();

        // GET: api/Area
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Get")]
        public IHttpActionResult Get([FromBody] AreaFiltroDto filtro)
        {
            return Json(_lnArea.Obtener(filtro));
        }

        // GET: api/Area/5
        public Area Get(int idArea)
        {
            return _lnArea.ObtenerPorId(idArea);
        }

        [Route("GetCombo")]
        public List<Area> GetCombo(DropDownItem opcionCombo, Int32 idEstado)
        {
            return _lnArea.ObtenerCombo(opcionCombo, idEstado);
        }

        // POST: api/Area
        public Int32 Post([FromBody] Area area)
        {
            return _lnArea.Registrar(area);
        }

        // PUT: api/Area/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Put")]
        public Int32 Put([FromBody] Area area)
        {
            return _lnArea.Modificar(area);
        }

        // DELETE: api/Area/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Delete")]
        public Int32 Delete([FromBody] Area area)
        {
            return _lnArea.Eliminar(area.IdArea);
        }
    }
}
