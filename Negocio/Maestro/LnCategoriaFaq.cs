using System;
using System.Collections.Generic;
using System.Linq;
using Datos.Maestro;
using Entidad.Dto.Maestro;
using Entidad.Entidades.Maestro;
using Entidad.Vo;

namespace Negocio.Maestro
{
    public class LnCategoriaFaq
    {
        private readonly AdCategoriaFaq _adCategoriaFaq = new AdCategoriaFaq();

        public ResultDataTable Obtener(CategoriaFaqFiltroDto filtro)
        {
            ResultDataTable result;
            int totalRegistros = 0;
            List<CategoriaFaqDto> lista = new List<CategoriaFaqDto>();
            string mensajeError = "";

            try
            {
                lista = _adCategoriaFaq.Obtener(filtro);
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

        public List<CategoriaFaq> ObtenerCombo(DropDownItem opcionCombo, Int32 idEstado)
        {
            var lista = _adCategoriaFaq.ObtenerCombo(idEstado);
            switch (opcionCombo)
            {
                case DropDownItem.Ninguno:
                    lista.Insert(0, new CategoriaFaq { IdCategoriaFaq = 0, Nombre = "Ninguno" });
                    break;
                case DropDownItem.Seleccione:
                    lista.Insert(0, new CategoriaFaq { IdCategoriaFaq = 0, Nombre = "Seleccione" });
                    break;
                case DropDownItem.Todos:
                    lista.Insert(0, new CategoriaFaq { IdCategoriaFaq = 0, Nombre = "Todos" });
                    break;
            }
            return lista;
        }

        public CategoriaFaq ObtenerPorId(int id)
        {
            return _adCategoriaFaq.ObtenerPorId(id);
        }

        public Int32 Registrar(CategoriaFaq entidad)
        {
            return _adCategoriaFaq.Registrar(entidad);
        }

        public Int32 Modificar(CategoriaFaq entidad)
        {
            return _adCategoriaFaq.Modificar(entidad);
        }

        public Int32 Eliminar(Int32 id)
        {
            return _adCategoriaFaq.Eliminar(id);
        }
    }
}
