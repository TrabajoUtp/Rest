using System;
using System.Collections.Generic;
using System.Linq;
using Datos.Seguridad;
using Entidad.Dto.Seguridad;
using Entidad.Entidades.Seguridad;
using Entidad.Vo;

namespace Negocio.Seguridad
{
    public class LnUsuario
    {
        private readonly AdUsuario _adUsuario = new AdUsuario();

        public ResultDataTable Obtener(UsuarioFiltroDto filtro)
        {
            ResultDataTable result;
            int totalRegistros = 0;
            List<UsuarioDto> lista = new List<UsuarioDto>();
            string mensajeError = "";

            try
            {
                lista = _adUsuario.Obtener(filtro);
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

        public List<Usuario> ObtenerCombo(DropDownItem opcionCombo, Int32 idEstado)
        {
            var lista = _adUsuario.ObtenerCombo(idEstado);
            switch (opcionCombo)
            {
                case DropDownItem.Ninguno:
                    lista.Insert(0, new Usuario { IdUsuario = 0, Nombre = "Ninguno", UserName = "Ninguno" });
                    break;
                case DropDownItem.Seleccione:
                    lista.Insert(0, new Usuario { IdUsuario = 0, Nombre = "Seleccione", UserName = "Seleccione" });
                    break;
                case DropDownItem.Todos:
                    lista.Insert(0, new Usuario { IdUsuario = 0, Nombre = "Todos", UserName = "Todos" });
                    break;
            }
            return lista;
        }

        public Usuario ObtenerPorId(int id)
        {
            return _adUsuario.ObtenerPorId(id);
        }

        public Int32 Registrar(Usuario entidad)
        {
            return _adUsuario.Registrar(entidad);
        }

        public Int32 Modificar(Usuario entidad)
        {
            return _adUsuario.Modificar(entidad);
        }

        public Int32 Eliminar(Int32 id)
        {
            return _adUsuario.Eliminar(id);
        }

        public UsuarioLoginDto Login(string usuario, string contrasenia)
        {
            var result = _adUsuario.Login(usuario, contrasenia);
            if (result == null)
            {
                result = new UsuarioLoginDto();
            }
            return result;
        }
    }
}
