using System;
using System.Collections.Generic;
using System.Web.Http;
using Entidad.Dto.Maestro;
using Entidad.Entidades.Maestro;
using Entidad.Vo;
using Negocio.Maestro;

namespace Api.Controllers.Maestro
{
    [RoutePrefix("api/TipoCorreo")]
    public class TipoCorreoController : ApiController
    {
        private readonly LnTipoCorreo _lnTipoCorreo = new LnTipoCorreo();

        // GET: api/TipoCorreo
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Get")]
        public IHttpActionResult Get([FromBody] TipoCorreoFiltroDto filtro)
        {
            return Json(_lnTipoCorreo.Obtener(filtro));
        }

        // GET: api/TipoCorreo/5
        public TipoCorreo Get(int idTipoCorreo)
        {
            return _lnTipoCorreo.ObtenerPorId(idTipoCorreo);
        }

        [Route("GetCombo")]
        public List<TipoCorreo> GetCombo(DropDownItem opcionCombo, Int32 idEstado)
        {
            return _lnTipoCorreo.ObtenerCombo(opcionCombo, idEstado);
        }

        // POST: api/TipoCorreo
        public Int32 Post([FromBody] TipoCorreo cliente)
        {
            return _lnTipoCorreo.Registrar(cliente);
        }

        // PUT: api/TipoCorreo/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Put")]
        public Int32 Put([FromBody] TipoCorreo cliente)
        {
            return _lnTipoCorreo.Modificar(cliente);
        }

        // DELETE: api/TipoCorreo/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Delete")]
        public Int32 Delete([FromBody] TipoCorreo cliente)
        {
            return _lnTipoCorreo.Eliminar(cliente.IdTipoCorreo);
        }
    }
}
