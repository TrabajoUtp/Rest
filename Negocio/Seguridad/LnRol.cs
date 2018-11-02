using System;
using System.Collections.Generic;
using System.Linq;
using Datos.Seguridad;
using Entidad.Dto.Seguridad;
using Entidad.Entidades.Seguridad;
using Entidad.Vo;

namespace Negocio.Seguridad
{
    public class LnRol
    {
        private readonly AdRol _adRol = new AdRol();

        public ResultDataTable Obtener(RolFiltro filtro)
        {
            ResultDataTable result;
            int totalRegistros = 0;
            List<RolDto> lista = new List<RolDto>();
            string mensajeError = "";

            try
            {
                lista = _adRol.Obtener(filtro);
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

        public RolDto ObtenerPorId(int idRol)
        {
            return _adRol.ObtenerPorId(idRol);
        }

        public Int32 Registrar(Rol rol)
        {
            return _adRol.Registrar(rol);
        }

        public Int32 Modificar(Rol rol)
        {
            return _adRol.Modificar(rol);
        }

    }
}
