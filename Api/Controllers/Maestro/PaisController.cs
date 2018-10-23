using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entidad.Entidades.Maestro;
using Negocio.Maestro;
using Entidad.Vo;

namespace Api.Controllers.Maestro
{
    [RoutePrefix("api/Pais")]
    public class PaisController : ApiController
    {
        private readonly LnPais _lnPais = new LnPais();
        // GET: api/Pais
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Pais/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("GetCombo")]
        public List<Pais> GetCombo(DropDownItem opcionCombo)
        {
            return _lnPais.ObtenerCombo(opcionCombo);
        }

        // POST: api/Pais
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Pais/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Pais/5
        public void Delete(int id)
        {
        }
    }
}
