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
    [RoutePrefix("api/Distrito")]
    public class DistritoController : ApiController
    {
        private readonly LnDistrito _lnDistrito = new LnDistrito();
        // GET: api/Distrito
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Distrito/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("GetCombo")]
        public List<Distrito> GetCombo(Int32 idProvincia, DropDownItem opcionCombo)
        {
            return _lnDistrito.ObtenerCombo(idProvincia, opcionCombo);
        }

        // POST: api/Distrito
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Distrito/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Distrito/5
        public void Delete(int id)
        {
        }
    }
}
