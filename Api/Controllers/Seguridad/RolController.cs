using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entidad.Dto.Seguridad;
using Entidad.Entidades.Seguridad;
using Entidad.Vo;
using Negocio.Seguridad;

namespace Api.Controllers.Seguridad
{
    [RoutePrefix("api/Rol")]
    public class RolController : ApiController
    {
        private readonly LnRol _lnRol = new LnRol();

        // GET: api/Rol
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Get")]
        public IHttpActionResult Get([FromBody]RolFiltroDto filtro)
        {
            return Json(_lnRol.Obtener(filtro));
        }

        // GET: api/Rol/5
        //[Authorize(Roles = "Administrador Sistema2")]
        [HttpGet]
        public RolDto Get(int idRol)
        {
            return _lnRol.ObtenerPorId(idRol);
        }

        [Route("GetCombo")]
        public List<Rol> GetCombo(DropDownItem opcionCombo, Int32 idEstado)
        {
            return _lnRol.ObtenerCombo(opcionCombo, idEstado);
        }

        // POST: api/Rol
        public Int32 Post([FromBody]Rol entidad)
        {
            if (ModelState.IsValid)
            {
                return _lnRol.Registrar(entidad);
            }
            return 0;
        }

        // PUT: api/Rol/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Put")]
        public Int32 Put([FromBody]Rol rol)
        {
            if (ModelState.IsValid)
            {
                return _lnRol.Modificar(rol);
            }
            return 0;
        }

        // DELETE: api/Cliente/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Delete")]
        public Int32 Delete([FromBody]Rol entidad)
        {
            return _lnRol.Eliminar(entidad.IdRol);
        }

    }
}
