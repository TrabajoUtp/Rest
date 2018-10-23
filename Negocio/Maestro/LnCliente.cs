using System;
using System.Collections.Generic;
using Datos.Maestro;
using Entidad.Dto.Maestro;
using Entidad.Entidades.Maestro;

namespace Negocio.Maestro
{
    public class LnCliente
    {
        private readonly AdCliente _adCliente = new AdCliente();

        //public Task<List<ClienteDto>> Obtener(ClienteFiltro filtro)
        public List<ClienteDto> Obtener(ClienteFiltro filtro)
        {
            return _adCliente.Obtener(filtro);
            //return Task.Factory.StartNew(() => _adCliente.Obtener(filtro));
            //return Task.Run(() => _adContacto.ObtenerContactos());
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