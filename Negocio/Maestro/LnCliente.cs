using System;
using System.Collections.Generic;
using System.Linq;
using Datos.Maestro;
using Entidad.Dto.Maestro;
using Entidad.Entidades.Maestro;
using Entidad.Vo;

namespace Negocio.Maestro
{
    public class LnCliente
    {
        private readonly AdCliente _adCliente = new AdCliente();

        public ResultDataTable Obtener(ClienteFiltroDto filtro)
        {
            ResultDataTable result;
            int totalRegistros = 0;
            List<ClienteDto> lista = new List<ClienteDto>();
            string mensajeError = "";

            try
            {
                lista = _adCliente.Obtener(filtro);
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

        public ResultDataTable ObtenerPendientesPorUsuario(ClienteFiltroDto filtro)
        {
            ResultDataTable result;
            int totalRegistros = 0;
            List<ClienteDto> lista = new List<ClienteDto>();
            string mensajeError = "";

            try
            {
                if (filtro.IdUsuario == 0)
                {
                    lista = new List<ClienteDto>();
                }
                else
                {
                    lista = _adCliente.ObtenerPendientesPorUsuario(filtro);
                }
                
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

        public List<Cliente> ObtenerCombo(DropDownItem opcionCombo, Int32 idEstado)
        {
            var lista = _adCliente.ObtenerCombo(idEstado);
            switch (opcionCombo)
            {
                case DropDownItem.Ninguno:
                    lista.Insert(0, new Cliente { IdCliente = 0, NumeroDocumento = "", RazonSocial = "Ninguno" });
                    break;
                case DropDownItem.Seleccione:
                    lista.Insert(0, new Cliente { IdCliente = 0, NumeroDocumento = "", RazonSocial = "Seleccione" });
                    break;
                case DropDownItem.Todos:
                    lista.Insert(0, new Cliente { IdCliente = 0, NumeroDocumento = "", RazonSocial = "Todos" });
                    break;
            }
            return lista;
        }

        public List<Cliente> ObtenerComboPorIdUsuario(DropDownItem opcionCombo, Int32 idEstado, Int32 idUsuario)
        {
            var lista = _adCliente.ObtenerComboPorIdUsuario(idEstado, idUsuario);
            switch (opcionCombo)
            {
                case DropDownItem.Ninguno:
                    lista.Insert(0, new Cliente { IdCliente = 0, NumeroDocumento = "", RazonSocial = "Ninguno" });
                    break;
                case DropDownItem.Seleccione:
                    lista.Insert(0, new Cliente { IdCliente = 0, NumeroDocumento = "", RazonSocial = "Seleccione" });
                    break;
                case DropDownItem.Todos:
                    lista.Insert(0, new Cliente { IdCliente = 0, NumeroDocumento = "", RazonSocial = "Todos" });
                    break;
            }
            return lista;
        }

        public Cliente ObtenerPorId(int id)
        {
            return _adCliente.ObtenerPorId(id);
        }

        public Int32 Registrar(Cliente entidad)
        {
            return _adCliente.Registrar(entidad);
        }

        public Int32 Modificar(Cliente entidad)
        {
            return _adCliente.Modificar(entidad);
        }

        public Int32 Eliminar(Int32 id)
        {
            return _adCliente.Eliminar(id);
        }
    }
}