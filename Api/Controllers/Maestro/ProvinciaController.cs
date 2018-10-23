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
    [RoutePrefix("api/Provincia")]
    public class ProvinciaController : ApiController
    {
        private readonly LnProvincia _lnProvincia = new LnProvincia();
        // GET: api/Provincia
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Provincia/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("GetCombo")]
        public List<Provincia> GetCombo(Int32 idDepartamento, DropDownItem opcionCombo)
        {
            return _lnProvincia.ObtenerCombo(idDepartamento, opcionCombo);
        }

        // POST: api/Provincia
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Provincia/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Provincia/5
        public void Delete(int id)
        {
        }
    }
}
