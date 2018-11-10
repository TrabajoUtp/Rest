using System;
using System.Collections.Generic;
using System.Web.Http;
using Entidad.Dto.Maestro;
using Entidad.Entidades.Maestro;
using Entidad.Vo;
using Negocio.Maestro;

namespace Api.Controllers.Maestro
{
    [RoutePrefix("api/Contacto")]
    public class ContactoController : ApiController
    {
        private readonly LnContacto _lnContacto = new LnContacto();

        // GET: api/Contacto
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Get")]
        public IHttpActionResult Get([FromBody]ContactoFiltroDto filtro)
        {
            return Json(_lnContacto.Obtener(filtro));
        }

        // GET: api/Contacto/5
        public Contacto Get(int idContacto)
        {
            return _lnContacto.ObtenerPorId(idContacto);
        }

        [Route("GetCombo")]
        public List<Contacto> GetCombo(DropDownItem opcionCombo, Int32 idEstado)
        {
            return _lnContacto.ObtenerCombo(opcionCombo, idEstado);
        }

        // POST: api/Contacto
        public Int32 Post([FromBody]Contacto cliente)
        {
            return _lnContacto.Registrar(cliente);
        }

        // PUT: api/Contacto/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Put")]
        public Int32 Put([FromBody]Contacto cliente)
        {
            return _lnContacto.Modificar(cliente);
        }

        // DELETE: api/Contacto/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Delete")]
        public Int32 Delete([FromBody]Contacto cliente)
        {
            return _lnContacto.Eliminar(cliente.IdContacto);
        }
    }
}
