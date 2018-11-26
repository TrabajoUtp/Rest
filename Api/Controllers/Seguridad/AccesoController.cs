using System;
using System.Collections.Generic;
using System.Web.Http;
using Entidad.Dto.Seguridad;
using Entidad.Entidades.Seguridad;
using Entidad.Vo;
using Negocio.Seguridad;

namespace Api.Controllers.Seguridad
{
    [RoutePrefix("api/Acceso")]
    public class AccesoController : ApiController
    {
        private readonly LnAcceso _lnAcceso = new LnAcceso();

        // GET: api/Acceso
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Get")]
        public IHttpActionResult Get([FromBody]AccesoFiltroDto filtro)
        {
            return Json(_lnAcceso.Obtener(filtro));
        }

        // GET: api/Acceso/5
        public Acceso Get(Int64 idAcceso)
        {
            return _lnAcceso.ObtenerPorId(idAcceso);
        }

        [Route("GetCombo")]
        public List<Acceso> GetCombo(DropDownItem opcionCombo, Int32 idEstado)
        {
            return _lnAcceso.ObtenerCombo(opcionCombo, idEstado);
        }

        // POST: api/Acceso
        public Int32 Post([FromBody]Acceso acceso)
        {
            return _lnAcceso.Registrar(acceso);
        }

        // PUT: api/Acceso/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Put")]
        public Int32 Put([FromBody]Acceso acceso)
        {
            return _lnAcceso.Modificar(acceso);
        }

        // DELETE: api/Acceso/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Delete")]
        public Int32 Delete([FromBody]Acceso acceso)
        {
            return _lnAcceso.Eliminar(acceso.IdAcceso);
        }
    }
}
