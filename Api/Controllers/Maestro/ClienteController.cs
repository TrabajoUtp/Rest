using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entidad.Dto.Maestro;
using Entidad.Dto.Seguridad;
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
        public IHttpActionResult Get([FromBody]ClienteFiltro filtro)
        {
            var data = _lnCliente.Obtener(filtro);
            int totalRegistros = 0;

            if (data.Any())
            {
                totalRegistros = data.First().TotalItems;
            }

            return Json(new
            {
                draw = filtro.Draw,
                recordsTotal = totalRegistros,
                recordsFiltered = totalRegistros,
                data
            });
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
