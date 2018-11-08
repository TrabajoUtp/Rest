using System;
using System.Collections.Generic;
using System.Linq;
using Datos.Maestro;
using Entidad.Dto.Maestro;
using Entidad.Entidades.Maestro;
using Entidad.Vo;

namespace Negocio.Maestro
{
    public class LnPais
    {
        private readonly AdPais _adPais = new AdPais();

        public ResultDataTable Obtener(PaisFiltroDto filtro)
        {
            ResultDataTable result;
            int totalRegistros = 0;
            List<PaisDto> lista = new List<PaisDto>();
            string mensajeError = "";

            try
            {
                lista = _adPais.Obtener(filtro);
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

        public List<Pais> ObtenerCombo(DropDownItem opcionCombo)
        {
            var lista = _adPais.ObtenerCombo();
            switch (opcionCombo)
            {
                case DropDownItem.Ninguno:
                    lista.Insert(0, new Pais { IdPais = 0, Nombre = "Ninguno" });
                    break;
                case DropDownItem.Seleccione:
                    lista.Insert(0, new Pais { IdPais = 0, Nombre = "Seleccione" });
                    break;
                case DropDownItem.Todos:
                    lista.Insert(0, new Pais { IdPais = 0, Nombre = "Todos" });
                    break;
            }
            return lista;
        }

        public Pais ObtenerPorId(int id)
        {
            return _adPais.ObtenerPorId(id);
        }

        public Int32 Registrar(Pais entidad)
        {
            return _adPais.Registrar(entidad);
        }

        public Int32 Modificar(Pais entidad)
        {
            return _adPais.Modificar(entidad);
        }

        public Int32 Eliminar(Int32 id)
        {
            return _adPais.Eliminar(id);
        }
    }
}
