using System;
using System.Collections.Generic;
using System.Linq;
using Datos.Maestro;
using Entidad.Dto.Maestro;
using Entidad.Entidades.Maestro;
using Entidad.Vo;

namespace Negocio.Maestro
{
    public class LnTipoCorreo
    {
        private readonly AdTipoCorreo _adTipoCorreo = new AdTipoCorreo();

        public ResultDataTable Obtener(TipoCorreoFiltroDto filtro)
        {
            ResultDataTable result;
            int totalRegistros = 0;
            List<TipoCorreoDto> lista = new List<TipoCorreoDto>();
            string mensajeError = "";

            try
            {
                lista = _adTipoCorreo.Obtener(filtro);
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

        public List<TipoCorreo> ObtenerCombo(DropDownItem opcionCombo, Int32 idEstado)
        {
            var lista = _adTipoCorreo.ObtenerCombo(idEstado);
            switch (opcionCombo)
            {
                case DropDownItem.Ninguno:
                    lista.Insert(0, new TipoCorreo { IdTipoCorreo = 0, Nombre = "Ninguno" });
                    break;
                case DropDownItem.Seleccione:
                    lista.Insert(0, new TipoCorreo { IdTipoCorreo = 0, Nombre = "Seleccione" });
                    break;
                case DropDownItem.Todos:
                    lista.Insert(0, new TipoCorreo { IdTipoCorreo = 0, Nombre = "Todos" });
                    break;
            }
            return lista;
        }

        public TipoCorreo ObtenerPorId(int id)
        {
            return _adTipoCorreo.ObtenerPorId(id);
        }

        public Int32 Registrar(TipoCorreo entidad)
        {
            return _adTipoCorreo.Registrar(entidad);
        }

        public Int32 Modificar(TipoCorreo entidad)
        {
            return _adTipoCorreo.Modificar(entidad);
        }

        public Int32 Eliminar(Int32 id)
        {
            return _adTipoCorreo.Eliminar(id);
        }
    }
}
