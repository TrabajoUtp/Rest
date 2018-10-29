﻿using System;
using System.Linq;
using System.Web.Http;
using Entidad.Dto.Gestion;
using Entidad.Entidades.Gestion;
using Negocio.Gestion;

namespace Api.Controllers.Gestion
{
    [RoutePrefix("api/Faq")]
    public class FaqController : ApiController
    {
        private readonly LnFaq _lnFaq = new LnFaq();

        // GET: api/Faq
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Get")]
        public IHttpActionResult Get([FromBody]FaqFiltro filtro)
        {
            var data = _lnFaq.Obtener(filtro);
            int totalRegistros = 0;

            if (data.Any())
            {
                totalRegistros = data.First().TotalItems;
            }

            return Json(new
            {
                draw = filtro.Draw,
                recordsTotal = totalRegistros,
                recordsFiltered = totalRegistros,
                data
            });
        }

        // GET: api/Faq/5
        public Faq Get(int idFaq)
        {
            return _lnFaq.ObtenerPorId(idFaq);
        }

        // POST: api/Faq
        public Int32 Post([FromBody]Faq faq)
        {
            return _lnFaq.Registrar(faq);
        }

        // PUT: api/Faq/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Put")]
        public Int32 Put([FromBody]Faq faq)
        {
            return _lnFaq.Modificar(faq);
        }

        // DELETE: api/Faq/5
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("Delete")]
        public Int32 Delete([FromBody]Faq faq)
        {
            return _lnFaq.Eliminar(faq.IdFaq);
        }
    }
}
