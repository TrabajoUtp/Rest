using System;
using System.Collections.Generic;
using System.Linq;
using Datos.Asignacion;
using Entidad.Dto.Asignacion;
using Entidad.Entidades.Asignacion;
using Entidad.Vo;

namespace Negocio.Asignacion
{
    public class LnUsuarioCliente
    {
        private readonly AdUsuarioCliente _adUsuarioCliente = new AdUsuarioCliente();

        public ResultDataTable Obtener(UsuarioClienteFiltroDto filtro)
        {
            ResultDataTable result;
            int totalRegistros = 0;
            List<UsuarioClienteDto> lista = new List<UsuarioClienteDto>();
            string mensajeError = "";

            try
            {
                lista = _adUsuarioCliente.Obtener(filtro);
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

        public UsuarioCliente ObtenerPorId(int id)
        {
            return _adUsuarioCliente.ObtenerPorId(id);
        }

        public Int32 Registrar(UsuarioClienteFiltroDto entidad)
        {
            Int32 resultado = 0;
            //parametro de idsCliente: 12,15,
            List<Int32> listaIdCliente =
                entidad.ListaIdClientes.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            foreach (int i in listaIdCliente)
            {
                UsuarioCliente usuCli = new UsuarioCliente
                {
                    IdUsuario = entidad.IdUsuario,
                    IdCliente = i,
                    IdEstado = entidad.IdEstado
                };
                Int32 resultIndivisual = _adUsuarioCliente.Registrar(usuCli);
                if (resultIndivisual > 0)
                {
                    resultado++;
                }
            }

            return resultado;

        }

        public Int32 Eliminar(Int32 id)
        {
            return _adUsuarioCliente.Eliminar(id);
        }

    }
}
