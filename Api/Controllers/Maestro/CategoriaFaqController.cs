using System;
using System.Collections.Generic;
using System.Web.Http;
using Entidad.Dto.Maestro;
using Entidad.Entidades.Maestro;
using Entidad.Vo;
using Negocio.Maestro;

namespace Api.Controllers.Maestro
{
    [RoutePrefix("api/CategoriaFaq")]
    public class CategoriaFaqController : ApiController
    {
        private readonly LnCategoriaFaq _lnCategoriaFaq = new LnCategoriaFaq();

        // GET: api/CategoriaFaq
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Get")]
        public IHttpActionResult Get([FromBody]CategoriaFaqFiltroDto filtro)
        {
            return Json(_lnCategoriaFaq.Obtener(filtro));
        }

        // GET: api/CategoriaFaq/5
        public CategoriaFaq Get(int idCategoriaFaq)
        {
            return _lnCategoriaFaq.ObtenerPorId(idCategoriaFaq);
        }

        [Route("GetCombo")]
        public List<CategoriaFaq> GetCombo(DropDownItem opcionCombo, Int32 idEstado)
        {
            return _lnCategoriaFaq.ObtenerCombo(opcionCombo, idEstado);
        }

        // POST: api/CategoriaFaq
        public Int32 Post([FromBody]CategoriaFaq categoriaFaq)
        {
            return _lnCategoriaFaq.Registrar(categoriaFaq);
        }

        // PUT: api/CategoriaFaq/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Put")]
        public Int32 Put([FromBody]CategoriaFaq categoriaFaq)
        {
            return _lnCategoriaFaq.Modificar(categoriaFaq);
        }

        // DELETE: api/CategoriaFaq/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Delete")]
        public Int32 Delete([FromBody]CategoriaFaq categoriaFaq)
        {
            return _lnCategoriaFaq.Eliminar(categoriaFaq.IdCategoriaFaq);
        }
    }
}
