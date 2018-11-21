using System;
using System.Collections.Generic;
using System.Linq;
using Datos.Asignacion;
using Entidad.Dto.Asignacion;
using Entidad.Entidades.Asignacion;
using Entidad.Vo;

namespace Negocio.Asignacion
{
    public class LnRolUsuario
    {
        private readonly AdRolUsuario _adRolUsuario = new AdRolUsuario();

        public ResultDataTable Obtener(RolUsuarioFiltroDto filtro)
        {
            ResultDataTable result;
            int totalRegistros = 0;
            List<RolUsuarioDto> lista = new List<RolUsuarioDto>();
            string mensajeError = "";

            try
            {
                lista = _adRolUsuario.Obtener(filtro);
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

        public RolUsuario ObtenerPorId(int id)
        {
            return _adRolUsuario.ObtenerPorId(id);
        }

        public Int32 Registrar(RolUsuarioFiltroDto entidad)
        {
            Int32 resultado = 0;
            //parametro de idsCliente: 12,15,
            List<Int32> listaIdUsuario =
                entidad.ListaIdUsuarios.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            foreach (int i in listaIdUsuario)
            {
                RolUsuario rolUsu = new RolUsuario
                {
                    IdRol = entidad.IdRol,
                    IdUsuario = i,
                    IdEstado = entidad.IdEstado
                };
                Int32 resultIndivisual = _adRolUsuario.Registrar(rolUsu);
                if (resultIndivisual > 0)
                {
                    resultado++;
                }
            }

            return resultado;

        }

        public Int32 Eliminar(Int32 id)
        {
            return _adRolUsuario.Eliminar(id);
        }
    }
}
