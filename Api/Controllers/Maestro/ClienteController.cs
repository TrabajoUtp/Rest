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

        // GET: api/Cliente
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Get")]
        public IHttpActionResult Get([FromBody]ClienteFiltroDto filtro)
        {
            return Json(_lnCliente.Obtener(filtro));
        }

        // GET: api/Cliente/5
        public Cliente Get(int idCliente)
        {
            return _lnCliente.ObtenerPorId(idCliente);
        }

        [Route("GetCombo")]
        public List<Cliente> GetCombo(DropDownItem opcionCombo, Int32 idEstado)
        {
            return _lnCliente.ObtenerCombo(opcionCombo, idEstado);
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
