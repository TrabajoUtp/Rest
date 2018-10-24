using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entidad.Dto.Maestro;
using Entidad.Vo;
using Negocio.Maestro;

namespace Api.Controllers.Maestro
{
    [RoutePrefix("api/Ubigeo")]
    public class UbigeoController : ApiController
    {
        private readonly LnUbigeo _lnUbigeo = new LnUbigeo();
        // GET: api/Ubigeo
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Ubigeo/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("GetCombo")]
        public List<DepartamentoDto> GetCombo(int idPais, DropDownItem opcionCombo)
        {
            return _lnUbigeo.ObtenerCombo(idPais, opcionCombo);
        }

        // POST: api/Ubigeo
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Ubigeo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Ubigeo/5
        public void Delete(int id)
        {
        }
    }
}
