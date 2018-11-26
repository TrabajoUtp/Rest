using System;
using System.Collections.Generic;
using System.Linq;
using Datos.Asignacion;
using Entidad.Dto.Asignacion;
using Entidad.Entidades.Asignacion;
using Entidad.Vo;

namespace Negocio.Asignacion
{
    public class LnAreaUsuario
    {
        private readonly AdAreaUsuario _adAreaUsuario = new AdAreaUsuario();

        public ResultDataTable Obtener(AreaUsuarioFiltroDto filtro)
        {
            ResultDataTable result;
            int totalRegistros = 0;
            List<AreaUsuarioDto> lista = new List<AreaUsuarioDto>();
            string mensajeError = "";

            try
            {
                lista = _adAreaUsuario.Obtener(filtro);
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

        public AreaUsuario ObtenerPorId(int id)
        {
            return _adAreaUsuario.ObtenerPorId(id);
        }

        public Int32 Registrar(AreaUsuarioFiltroDto entidad)
        {
            Int32 resultado = 0;
            //parametro de idsCliente: 12,15,
            List<Int32> listaIdUsuario =
                entidad.ListaIdUsuarios.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            foreach (int i in listaIdUsuario)
            {
                AreaUsuario rolUsu = new AreaUsuario
                {
                    IdArea = entidad.IdArea,
                    IdUsuario = i,
                    IdEstado = entidad.IdEstado
                };
                Int32 resultIndivisual = _adAreaUsuario.Registrar(rolUsu);
                if (resultIndivisual > 0)
                {
                    resultado++;
                }
            }

            return resultado;

        }

        public Int32 Eliminar(Int32 id)
        {
            return _adAreaUsuario.Eliminar(id);
        }
    }
}
