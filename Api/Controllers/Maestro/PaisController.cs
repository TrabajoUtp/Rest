using System;
using System.Collections.Generic;
using System.Web.Http;
using Entidad.Dto.Maestro;
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
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Get")]
        public IHttpActionResult Get([FromBody]PaisFiltroDto filtro)
        {
            return Json(_lnPais.Obtener(filtro));
        }

        // GET: api/Pais/5
        public Pais Get(int idPais)
        {
            return _lnPais.ObtenerPorId(idPais);
        }
        
        [Route("GetCombo")]
        public List<Pais> GetCombo(DropDownItem opcionCombo)
        {
            return _lnPais.ObtenerCombo(opcionCombo);
        }

        // POST: api/Pais
        public Int32 Post([FromBody]Pais cliente)
        {
            return _lnPais.Registrar(cliente);
        }

        // PUT: api/Pais/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Put")]
        public Int32 Put([FromBody]Pais cliente)
        {
            return _lnPais.Modificar(cliente);
        }

        // DELETE: api/Pais/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Delete")]
        public Int32 Delete([FromBody]Pais cliente)
        {
            return _lnPais.Eliminar(cliente.IdPais);
        }
    }
}
