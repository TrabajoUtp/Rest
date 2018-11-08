using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entidad.Dto.Seguridad;
using Entidad.Entidades.Seguridad;
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

        // POST: api/Rol
        public IHttpActionResult Post([FromBody]Rol rol)
        {
            if (ModelState.IsValid)
            {
                var result = _lnRol.Registrar(rol);
                if (result > 0)
                {
                    return Ok(result);
                }
            }
            return BadRequest();
        }

        // PUT: api/Rol/5
        public IHttpActionResult Put([FromBody]Rol rol)
        {
            if (ModelState.IsValid)
            {
                var result = _lnRol.Modificar(rol);
                if (result > 0)
                {
                    return Ok(result);
                }
            }
            return BadRequest();
        }

    }
}
