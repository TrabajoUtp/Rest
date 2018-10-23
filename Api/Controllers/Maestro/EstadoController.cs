using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Estado/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("GetCombo")]
        public List<Estado> GetCombo(int idTipoEstado, DropDownItem opcionCombo)
        {
            return _lnEstado.GetCombo(idTipoEstado, opcionCombo);
        }

        // POST: api/Estado
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Estado/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Estado/5
        public void Delete(int id)
        {
        }
    }
}
