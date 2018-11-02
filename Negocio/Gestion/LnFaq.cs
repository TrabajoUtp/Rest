using System;
using System.Collections.Generic;
using System.Linq;
using Datos.Gestion;
using Entidad.Dto.Gestion;
using Entidad.Entidades.Gestion;
using Entidad.Vo;

namespace Negocio.Gestion
{
    public class LnFaq
    {
        private readonly AdFaq _adFaq = new AdFaq();

        public ResultDataTable Obtener(FaqFiltro filtro)
        {
            ResultDataTable result;
            int totalRegistros = 0;
            List<FaqDto> lista = new List<FaqDto>();
            string mensajeError = "";

            try
            {
                lista = _adFaq.Obtener(filtro);
                if (lista.Any())
                {
                    totalRegistros = lista.First().TotalItems;
                }
            }
            catch (Exception ex)
            {
                mensajeError = ex.Message;
            }
            finally
            {
                result = new ResultDataTable
                {
                    draw = filtro.Draw,
                    recordsTotal = totalRegistros,
                    recordsFiltered = totalRegistros,
                    data = lista,
                    error = mensajeError
                };

            }

            return result;

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
