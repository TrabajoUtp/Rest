using System;
using System.Collections.Generic;
using System.Linq;
using Datos.Maestro;
using Entidad.Dto.Maestro;
using Entidad.Entidades.Maestro;
using Entidad.Vo;

namespace Negocio.Maestro
{
    public class LnTipoEstado
    {
        private readonly AdTipoEstado _adTipoEstado = new AdTipoEstado();

        public ResultDataTable Obtener(TipoEstadoFiltroDto filtro)
        {
            ResultDataTable result;
            int totalRegistros = 0;
            List<TipoEstadoDto> lista = new List<TipoEstadoDto>();
            string mensajeError = "";

            try
            {
                lista = _adTipoEstado.Obtener(filtro);
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

        public List<TipoEstado> ObtenerCombo(DropDownItem opcionCombo)
        {
            var lista = _adTipoEstado.ObtenerCombo();
            switch (opcionCombo)
            {
                case DropDownItem.Ninguno:
                    lista.Insert(0, new TipoEstado { IdTipoEstado = 0, Nombre = "Ninguno" });
                    break;
                case DropDownItem.Seleccione:
                    lista.Insert(0, new TipoEstado { IdTipoEstado = 0, Nombre = "Seleccione" });
                    break;
                case DropDownItem.Todos:
                    lista.Insert(0, new TipoEstado { IdTipoEstado = 0, Nombre = "Todos" });
                    break;
            }
            return lista;
        }

        public TipoEstado ObtenerPorId(int id)
        {
            return _adTipoEstado.ObtenerPorId(id);
        }

        public Int32 Registrar(TipoEstado entidad)
        {
            return _adTipoEstado.Registrar(entidad);
        }

        public Int32 Modificar(TipoEstado entidad)
        {
            return _adTipoEstado.Modificar(entidad);
        }

        public Int32 Eliminar(Int32 id)
        {
            return _adTipoEstado.Eliminar(id);
        }
    }
}
