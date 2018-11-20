using System;
using System.Collections.Generic;
using System.Web.Http;
using Entidad.Dto.Maestro;
using Entidad.Entidades.Maestro;
using Entidad.Vo;
using Negocio.Maestro;

namespace Api.Controllers.Maestro
{
    [RoutePrefix("api/Cliente")]
    public class ClienteController : ApiController
    {
        private readonly LnCliente _lnCliente = new LnCliente();

        // POST: api/Cliente/Get => {"Buscar": "","IdEstado":1,"NumberPage":1,"Length":20,"ColumnOrder":"IdCliente","OrderDirection":"asc"}
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Get")]
        public IHttpActionResult Get([FromBody]ClienteFiltroDto filtro)
        {
            return Json(_lnCliente.Obtener(filtro));
        }

        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("ObtenerPendientesPorUsuario")]
        public IHttpActionResult GetPendientesPorUsuario([FromBody]ClienteFiltroDto filtro)
        {
            return Json(_lnCliente.ObtenerPendientesPorUsuario(filtro));
        }

        // GET: api/Cliente/5
        public Cliente Get(int idCliente)
        {
            return _lnCliente.ObtenerPorId(idCliente);
        }

        // GET: api/Cliente/GetCombo?opcionCombo=1&idEstado=1
        [Route("GetCombo")]
        public List<Cliente> GetCombo(DropDownItem opcionCombo, Int32 idEstado)
        {
            return _lnCliente.ObtenerCombo(opcionCombo, idEstado);
        }

        // GET: api/Cliente/GetComboPorIdUsuario?opcionCombo=1&idEstado=1
        [Route("GetComboPorIdUsuario")]
        public List<Cliente> GetComboPorIdUsuario(DropDownItem opcionCombo, Int32 idEstado, Int32 idUsuario)
        {
            return _lnCliente.ObtenerComboPorIdUsuario(opcionCombo, idEstado, idUsuario);
        }

        // POST: api/Cliente
        public Int32 Post([FromBody]Cliente cliente)
        {
            return _lnCliente.Registrar(cliente);
        }

        // PUT: api/Cliente/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Put")]
        public Int32 Put([FromBody]Cliente cliente)
        {
            return _lnCliente.Modificar(cliente);
        }

        // DELETE: api/Cliente/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Delete")]
        public Int32 Delete([FromBody]Cliente cliente)
        {
            return _lnCliente.Eliminar(cliente.IdCliente);
        }
    }
}
