using System;
using System.Collections.Generic;
using System.Web.Http;
using Entidad.Dto.Maestro;
using Entidad.Entidades.Maestro;
using Entidad.Vo;
using Negocio.Maestro;

namespace Api.Controllers.Maestro
{
    [RoutePrefix("api/Motivo")]
    public class MotivoController : ApiController
    {
        private readonly LnMotivo _lnMotivo = new LnMotivo();

        // GET: api/Motivo
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Get")]
        public IHttpActionResult Get([FromBody]MotivoFiltroDto filtro)
        {
            return Json(_lnMotivo.Obtener(filtro));
        }

        // GET: api/Motivo/5
        public Motivo Get(int idMotivo)
        {
            return _lnMotivo.ObtenerPorId(idMotivo);
        }

        [Route("GetCombo")]
        public List<Motivo> GetCombo(DropDownItem opcionCombo, Int32 idEstado)
        {
            return _lnMotivo.ObtenerCombo(opcionCombo, idEstado);
        }

        // POST: api/Motivo
        public Int32 Post([FromBody]Motivo cliente)
        {
            return _lnMotivo.Registrar(cliente);
        }

        // PUT: api/Motivo/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Put")]
        public Int32 Put([FromBody]Motivo cliente)
        {
            return _lnMotivo.Modificar(cliente);
        }

        // DELETE: api/Motivo/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Delete")]
        public Int32 Delete([FromBody]Motivo cliente)
        {
            return _lnMotivo.Eliminar(cliente.IdMotivo);
        }
    }
}
