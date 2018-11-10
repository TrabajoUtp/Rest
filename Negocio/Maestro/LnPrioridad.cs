using System;
using System.Collections.Generic;
using System.Linq;
using Datos.Maestro;
using Entidad.Dto.Maestro;
using Entidad.Entidades.Maestro;
using Entidad.Vo;

namespace Negocio.Maestro
{
    public class LnPrioridad
    {
        private readonly AdPrioridad _adPrioridad = new AdPrioridad();

        public ResultDataTable Obtener(PrioridadFiltroDto filtro)
        {
            ResultDataTable result;
            int totalRegistros = 0;
            List<PrioridadDto> lista = new List<PrioridadDto>();
            string mensajeError = "";

            try
            {
                lista = _adPrioridad.Obtener(filtro);
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

        public List<Prioridad> ObtenerCombo(DropDownItem opcionCombo, Int32 idEstado)
        {
            var lista = _adPrioridad.ObtenerCombo(idEstado);
            switch (opcionCombo)
            {
                case DropDownItem.Ninguno:
                    lista.Insert(0, new Prioridad { IdPrioridad = 0, Nombre = "Ninguno" });
                    break;
                case DropDownItem.Seleccione:
                    lista.Insert(0, new Prioridad { IdPrioridad = 0, Nombre = "Seleccione" });
                    break;
                case DropDownItem.Todos:
                    lista.Insert(0, new Prioridad { IdPrioridad = 0, Nombre = "Todos" });
                    break;
            }
            return lista;
        }

        public Prioridad ObtenerPorId(int id)
        {
            return _adPrioridad.ObtenerPorId(id);
        }

        public Int32 Registrar(Prioridad entidad)
        {
            return _adPrioridad.Registrar(entidad);
        }

        public Int32 Modificar(Prioridad entidad)
        {
            return _adPrioridad.Modificar(entidad);
        }

        public Int32 Eliminar(Int32 id)
        {
            return _adPrioridad.Eliminar(id);
        }
    }
}
