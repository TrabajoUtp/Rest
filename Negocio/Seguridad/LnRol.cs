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

        public ResultDataTable Obtener(RolFiltroDto filtro)
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

        public List<Rol> ObtenerCombo(DropDownItem opcionCombo, Int32 idEstado)
        {
            var lista = _adRol.ObtenerCombo(idEstado);
            switch (opcionCombo)
            {
                case DropDownItem.Ninguno:
                    lista.Insert(0, new Rol { IdRol = 0, Nombre = "Ninguno" });
                    break;
                case DropDownItem.Seleccione:
                    lista.Insert(0, new Rol { IdRol = 0, Nombre = "Seleccione" });
                    break;
                case DropDownItem.Todos:
                    lista.Insert(0, new Rol { IdRol = 0, Nombre = "Todos" });
                    break;
            }
            return lista;
        }

        public Rol ObtenerPorId(int id)
        {
            return _adRol.ObtenerPorId(id);
        }

        public Int32 Registrar(Rol entidad)
        {
            return _adRol.Registrar(entidad);
        }

        public Int32 Modificar(Rol entidad)
        {
            return _adRol.Modificar(entidad);
        }

        public Int32 Eliminar(Int32 id)
        {
            return _adRol.Eliminar(id);
        }

    }
}
