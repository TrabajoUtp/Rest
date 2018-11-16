using System;
using System.Collections.Generic;
using System.Web.Http;
using Entidad.Dto.Maestro;
using Entidad.Entidades.Maestro;
using Entidad.Vo;
using Negocio.Maestro;

namespace Api.Controllers.Maestro
{
    [RoutePrefix("api/Estado")]
    public class EstadoController : ApiController
    {
        private readonly LnEstado _lnEstado = new LnEstado();
        // GET: api/Estado
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Get")]
        public IHttpActionResult Get([FromBody]EstadoFiltroDto filtro)
        {
            return Json(_lnEstado.Obtener(filtro));
        }

        // GET: api/Estado/5
        public Estado Get(int idEstado)
        {
            return _lnEstado.ObtenerPorId(idEstado);
        }

        [Route("GetCombo")]
        public List<EstadoComboDto> GetCombo(DropDownItem opcionCombo, int idTipoEstado)
        {
            return _lnEstado.ObtenerCombo(idTipoEstado, opcionCombo);
        }

        // POST: api/Estado
        public Int32 Post([FromBody]Estado cliente)
        {
            return _lnEstado.Registrar(cliente);
        }

        // PUT: api/Estado/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Put")]
        public Int32 Put([FromBody]Estado cliente)
        {
            return _lnEstado.Modificar(cliente);
        }

        // DELETE: api/Estado/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Delete")]
        public Int32 Delete([FromBody]Estado cliente)
        {
            return _lnEstado.Eliminar(cliente.IdEstado);
        }

        [Route("GetComboConExcepcion")]
        public List<EstadoComboDto> GetComboConExcepcion(DropDownItem opcionCombo, int idTipoEstado, String idsaExcluir)
        {
            return _lnEstado.ObtenerComboConExcepcion(idTipoEstado, opcionCombo, idsaExcluir);
        }

        [Route("GetComboPorId")]
        public List<EstadoComboDto> GetComboPorId(DropDownItem opcionCombo, int idTipoEstado, String idsaIncluir)
        {
            return _lnEstado.ObtenerComboPorId(idTipoEstado, opcionCombo, idsaIncluir);
        }
    }
}
