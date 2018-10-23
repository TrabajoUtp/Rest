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
    [RoutePrefix("api/Departamento")]
    public class DepartamentoController : ApiController
    {
        private readonly LnDepartamento _lnDepartamento = new LnDepartamento();
        // GET: api/Departamento
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Departamento/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("GetCombo")]
        public List<Departamento> GetCombo(Int32 idPais, DropDownItem opcionCombo)
        {
            return _lnDepartamento.ObtenerCombo(idPais, opcionCombo);
        }

        // POST: api/Departamento
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Departamento/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Departamento/5
        public void Delete(int id)
        {
        }
    }
}
