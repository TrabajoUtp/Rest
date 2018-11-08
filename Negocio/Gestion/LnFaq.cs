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

        public ResultDataTable Obtener(FaqFiltroDto filtro)
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

        public List<Faq> ObtenerCombo(DropDownItem opcionCombo)
        {
            var lista = _adFaq.ObtenerCombo();
            switch (opcionCombo)
            {
                case DropDownItem.Ninguno:
                    lista.Insert(0, new Faq { IdFaq = 0, Titulo = "Ninguno" });
                    break;
                case DropDownItem.Seleccione:
                    lista.Insert(0, new Faq { IdFaq = 0, Titulo = "Seleccione" });
                    break;
                case DropDownItem.Todos:
                    lista.Insert(0, new Faq { IdFaq = 0, Titulo = "Todos" });
                    break;
            }
            return lista;
        }

        public Faq ObtenerPorId(int id)
        {
            return _adFaq.ObtenerPorId(id);
        }

        public Int32 Registrar(Faq entidad)
        {
            return _adFaq.Registrar(entidad);
        }

        public Int32 Modificar(Faq entidad)
        {
            return _adFaq.Modificar(entidad);
        }

        public Int32 Eliminar(Int32 id)
        {
            return _adFaq.Eliminar(id);
        }
    }
}
