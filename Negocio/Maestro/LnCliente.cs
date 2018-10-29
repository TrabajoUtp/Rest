using System;
using System.Collections.Generic;
using Datos.Maestro;
using Entidad.Dto.Maestro;
using Entidad.Entidades.Maestro;
using Entidad.Vo;

namespace Negocio.Maestro
{
    public class LnCliente
    {
        private readonly AdCliente _adCliente = new AdCliente();

        public List<ClienteDto> Obtener(ClienteFiltro filtro)
        {
            return _adCliente.Obtener(filtro);
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