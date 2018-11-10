using System;
using System.Collections.Generic;
using System.Linq;
using Datos.Maestro;
using Entidad.Dto.Maestro;
using Entidad.Entidades.Maestro;
using Entidad.Vo;

namespace Negocio.Maestro
{
    public class LnTipoIncidencia
    {
        private readonly AdTipoIncidencia _adTipoIncidencia = new AdTipoIncidencia();

        public ResultDataTable Obtener(TipoIncidenciaFiltroDto filtro)
        {
            ResultDataTable result;
            int totalRegistros = 0;
            List<TipoIncidenciaDto> lista = new List<TipoIncidenciaDto>();
            string mensajeError = "";

            try
            {
                lista = _adTipoIncidencia.Obtener(filtro);
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

        public List<TipoIncidencia> ObtenerCombo(DropDownItem opcionCombo, Int32 idEstado)
        {
            var lista = _adTipoIncidencia.ObtenerCombo(idEstado);
            switch (opcionCombo)
            {
                case DropDownItem.Ninguno:
                    lista.Insert(0, new TipoIncidencia { IdTipoIncidencia = 0, Nombre = "Ninguno" });
                    break;
                case DropDownItem.Seleccione:
                    lista.Insert(0, new TipoIncidencia { IdTipoIncidencia = 0, Nombre = "Seleccione" });
                    break;
                case DropDownItem.Todos:
                    lista.Insert(0, new TipoIncidencia { IdTipoIncidencia = 0, Nombre = "Todos" });
                    break;
            }
            return lista;
        }

        public TipoIncidencia ObtenerPorId(int id)
        {
            return _adTipoIncidencia.ObtenerPorId(id);
        }

        public Int32 Registrar(TipoIncidencia entidad)
        {
            return _adTipoIncidencia.Registrar(entidad);
        }

        public Int32 Modificar(TipoIncidencia entidad)
        {
            return _adTipoIncidencia.Modificar(entidad);
        }

        public Int32 Eliminar(Int32 id)
        {
            return _adTipoIncidencia.Eliminar(id);
        }
    }
}
