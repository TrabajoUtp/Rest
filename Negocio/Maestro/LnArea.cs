using System;
using System.Collections.Generic;
using System.Linq;
using Datos.Maestro;
using Entidad.Dto.Maestro;
using Entidad.Entidades.Maestro;
using Entidad.Vo;

namespace Negocio.Maestro
{
    public class LnArea
    {
        private readonly AdArea _adArea = new AdArea();

        public ResultDataTable Obtener(AreaFiltroDto filtro)
        {
            ResultDataTable result;
            int totalRegistros = 0;
            List<AreaDto> lista = new List<AreaDto>();
            string mensajeError = "";

            try
            {
                lista = _adArea.Obtener(filtro);
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

        public List<Area> ObtenerCombo(DropDownItem opcionCombo, Int32 idEstado)
        {
            var lista = _adArea.ObtenerCombo(idEstado);
            switch (opcionCombo)
            {
                case DropDownItem.Ninguno:
                    lista.Insert(0, new Area { IdArea = 0, Nombre = "Ninguno" });
                    break;
                case DropDownItem.Seleccione:
                    lista.Insert(0, new Area { IdArea = 0, Nombre = "Seleccione" });
                    break;
                case DropDownItem.Todos:
                    lista.Insert(0, new Area { IdArea = 0, Nombre = "Todos" });
                    break;
            }
            return lista;
        }

        public Area ObtenerPorId(int id)
        {
            return _adArea.ObtenerPorId(id);
        }

        public Int32 Registrar(Area entidad)
        {
            return _adArea.Registrar(entidad);
        }

        public Int32 Modificar(Area entidad)
        {
            return _adArea.Modificar(entidad);
        }

        public Int32 Eliminar(Int32 id)
        {
            return _adArea.Eliminar(id);
        }
    }
}
