using System;
using System.Collections.Generic;
using System.Linq;
using Datos.Seguridad;
using Entidad.Dto.Seguridad;
using Entidad.Entidades.Seguridad;
using Entidad.Vo;

namespace Negocio.Seguridad
{
    public class LnAcceso
    {
        private readonly AdAcceso _adAcceso = new AdAcceso();

        public ResultDataTable Obtener(AccesoFiltroDto filtro)
        {
            ResultDataTable result;
            int totalRegistros = 0;
            List<AccesoDto> lista = new List<AccesoDto>();
            string mensajeError = "";

            try
            {
                lista = _adAcceso.Obtener(filtro);
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

        public List<Acceso> ObtenerCombo(DropDownItem opcionCombo, Int32 idEstado)
        {
            var lista = _adAcceso.ObtenerCombo(idEstado);
            switch (opcionCombo)
            {
                case DropDownItem.Ninguno:
                    lista.Insert(0, new Acceso { IdAcceso = 0, Nombre = "Ninguno" });
                    break;
                case DropDownItem.Seleccione:
                    lista.Insert(0, new Acceso { IdAcceso = 0, Nombre = "Seleccione" });
                    break;
                case DropDownItem.Todos:
                    lista.Insert(0, new Acceso { IdAcceso = 0, Nombre = "Todos" });
                    break;
            }
            return lista;
        }

        public Acceso ObtenerPorId(Int64 id)
        {
            return _adAcceso.ObtenerPorId(id);
        }

        public Int32 Registrar(Acceso entidad)
        {
            return _adAcceso.Registrar(entidad);
        }

        public Int32 Modificar(Acceso entidad)
        {
            return _adAcceso.Modificar(entidad);
        }

        public Int32 Eliminar(Int64 id)
        {
            return _adAcceso.Eliminar(id);
        }
    }
}
