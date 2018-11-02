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

        public ResultDataTable Obtener(ClienteFiltro filtro)
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

        public List<Cliente> ObtenerCombo(DropDownItem opcionCombo, Int32 idEstado)
        {
            var lista = _adCliente.ObtenerCombo(idEstado);
            switch (opcionCombo)
            {
                case DropDownItem.Ninguno:
                    lista.Insert(0, new Cliente { IdCliente = 0, RazonSocial = "Ninguno" });
                    break;
                case DropDownItem.Seleccione:
                    lista.Insert(0, new Cliente { IdCliente = 0, RazonSocial = "Seleccione" });
                    break;
                case DropDownItem.Todos:
                    lista.Insert(0, new Cliente { IdCliente = 0, RazonSocial = "Todos" });
                    break;
            }
            return lista;
        }

        public Cliente ObtenerPorId(int idCliente)
        {
            return _adCliente.ObtenerPorId(idCliente);
        }

        public Int32 Registrar(Cliente cliente)
        {
            return _adCliente.Registrar(cliente);
        }

        public Int32 Modificar(Cliente cliente)
        {
            return _adCliente.Modificar(cliente);
        }

        public Int32 Eliminar(Int32 idCliente)
        {
            return _adCliente.Eliminar(idCliente);
        }
    }
}