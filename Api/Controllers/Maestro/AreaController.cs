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
        public Int32 Post([FromBody] Area cliente)
        {
            return _lnArea.Registrar(cliente);
        }

        // PUT: api/Area/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Put")]
        public Int32 Put([FromBody] Area cliente)
        {
            return _lnArea.Modificar(cliente);
        }

        // DELETE: api/Area/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Delete")]
        public Int32 Delete([FromBody] Area cliente)
        {
            return _lnArea.Eliminar(cliente.IdArea);
        }
    }
}
