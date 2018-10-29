using System;
using System.Collections.Generic;
using Datos.Gestion;
using Entidad.Dto.Gestion;
using Entidad.Entidades.Gestion;

namespace Negocio.Gestion
{
    public class LnFaq
    {
        private readonly AdFaq _adFaq = new AdFaq();

        public List<FaqDto> Obtener(FaqFiltro filtro)
        {
            return _adFaq.Obtener(filtro);
        }

        public Faq ObtenerPorId(int idCliente)
        {
            return _adFaq.ObtenerPorId(idCliente);
        }

        public Int32 Registrar(Faq cliente)
        {
            return _adFaq.Registrar(cliente);
        }

        public Int32 Modificar(Faq cliente)
        {
            return _adFaq.Modificar(cliente);
        }

        public Int32 Eliminar(Int32 idCliente)
        {
            return _adFaq.Eliminar(idCliente);
        }
    }
}
