using System;
using System.Collections.Generic;
using System.Linq;
using Datos.Gestion;
using Entidad.Dto.Gestion;
using Entidad.Entidades.Gestion;
using Entidad.Vo;

namespace Negocio.Gestion
{
    public class LnIncidenciaDetalle
    {
        private readonly AdIncidenciaDetalle _adIncidenciaDetalle = new AdIncidenciaDetalle();

        public ResultDataTable Obtener(IncidenciaDetalleFiltroDto filtro)
        {
            ResultDataTable result;
            int totalRegistros = 0;
            List<IncidenciaDetalleDto> lista = new List<IncidenciaDetalleDto>();
            string mensajeError = "";

            try
            {
                lista = _adIncidenciaDetalle.Obtener(filtro);
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

        public IncidenciaDetalle ObtenerPorId(int id)
        {
            return _adIncidenciaDetalle.ObtenerPorId(id);
        }

        public Int32 Registrar(IncidenciaDetalle entidad)
        {
            return _adIncidenciaDetalle.Registrar(entidad);
        }

        public Int32 Modificar(IncidenciaDetalle entidad)
        {
            return _adIncidenciaDetalle.Modificar(entidad);
        }

        public Int32 Eliminar(Int32 id)
        {
            return _adIncidenciaDetalle.Eliminar(id);
        }
    }
}
