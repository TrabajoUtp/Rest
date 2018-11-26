using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Datos.Helper;
using Entidad.Dto.Seguridad;
using Entidad.Entidades.Seguridad;
using Entidad.Vo;

namespace Datos.Seguridad
{
    public class AdUsuario
    {
        public List<UsuarioDto> Obtener(UsuarioFiltroDto filtro)
        {

            List<UsuarioDto> lista;

            try
            {
                const string query = StoreProcedure.Seguridad_usp_Usuario_Obtener;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    lista = cn.Query<UsuarioDto>(query, new
                        {
                            filtro.Buscar,
                            filtro.IdEstado,
                            NumeroPagina = filtro.NumberPage,
                            CantidadRegistros = filtro.Length,
                            ColumnaOrden = filtro.ColumnOrder,
                            DireccionOrden = filtro.OrderDirection
                        },
                        commandType: CommandType.StoredProcedure).ToList();

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lista;
        }

        public List<UsuarioDto> ObtenerPendientesPorRol(UsuarioFiltroDto filtro)
        {

            List<UsuarioDto> lista;

            try
            {
                const string query = StoreProcedure.Seguridad_usp_Usuario_ObtenerPendientesPorRol;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    lista = cn.Query<UsuarioDto>(query, new
                        {
                            filtro.Buscar,
                            filtro.IdEstado,
                            filtro.IdRol,
                            ColumnaOrden = filtro.ColumnOrder,
                            DireccionOrden = filtro.OrderDirection
                        },
                        commandType: CommandType.StoredProcedure).ToList();

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lista;
        }

        public List<UsuarioDto> ObtenerPendientesPorArea(UsuarioFiltroDto filtro)
        {

            List<UsuarioDto> lista;

            try
            {
                const string query = StoreProcedure.Seguridad_usp_Usuario_ObtenerPendientesPorArea;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    lista = cn.Query<UsuarioDto>(query, new
                        {
                            filtro.Buscar,
                            filtro.IdEstado,
                            filtro.IdArea,
                            ColumnaOrden = filtro.ColumnOrder,
                            DireccionOrden = filtro.OrderDirection
                        },
                        commandType: CommandType.StoredProcedure).ToList();

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lista;
        }

        public List<Usuario> ObtenerCombo(Int32 idEstado)
        {
            List<Usuario> lista;
            const string query = StoreProcedure.Seguridad_usp_Usuario_Combo;

            using (var cn = HelperClass.ObtenerConeccion())
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                lista = cn.Query<Usuario>(query, new
                {
                    IdEstado = idEstado
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            return lista;
        }

        public Usuario ObtenerPorId(int id)
        {

            Usuario entidad;

            try
            {
                const string query = StoreProcedure.Seguridad_usp_Usuario_ObtenerPorId;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    entidad = cn.Query<Usuario>(query, new
                        {
                            IdUsuario = id
                        },
                        commandType: CommandType.StoredProcedure).FirstOrDefault();

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return entidad;
        }

        public Int32 Registrar(Usuario entidad)
        {
            Int32 respuesta;
            try
            {
                const string query = StoreProcedure.Seguridad_usp_Usuario_Registrar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
                            entidad.UserName,
                            entidad.Contrasenia,
                            entidad.Nombre,
                            entidad.ApellidoPaterno,
                            entidad.ApellidoMaterno,
                            entidad.IdEstado
                        },
                        commandType: CommandType.StoredProcedure);

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }

        public Int32 Modificar(Usuario entidad)
        {
            Int32 respuesta;
            try
            {
                const string query = StoreProcedure.Seguridad_usp_Usuario_Modificar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
                            entidad.IdUsuario,
                            entidad.UserName,
                            entidad.Contrasenia,
                            entidad.Nombre,
                            entidad.ApellidoPaterno,
                            entidad.ApellidoMaterno,
                            entidad.IdEstado
                    },
                        commandType: CommandType.StoredProcedure);

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }

        public Int32 Eliminar(Int32 id)
        {
            Int32 respuesta;
            try
            {
                const string query = StoreProcedure.Seguridad_usp_Usuario_Eliminar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
                            IdUsuario = id
                        },
                        commandType: CommandType.StoredProcedure);

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }

        public UsuarioLoginDto Login(string usuario, string contrasenia)
        {

            UsuarioLoginDto entidad;

            try
            {
                const string query = StoreProcedure.Seguridad_usp_Usuario_Login;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    var headerDictionary = new Dictionary<int, UsuarioLoginDto>();

                    entidad = cn.Query<UsuarioLoginDto, RolUsuarioDto, UsuarioLoginDto>(
                            query,
                            (header, detail) =>
                            {
                                UsuarioLoginDto headerEntry;

                                if (!headerDictionary.TryGetValue(header.IdUsuario, out headerEntry))
                                {
                                    headerEntry = header;
                                    headerEntry.ListaRolUsuario = new List<RolUsuarioDto>();
                                    headerDictionary.Add(headerEntry.IdUsuario, headerEntry);
                                }

                                headerEntry.ListaRolUsuario.Add(detail);
                                return headerEntry;
                            },
                            splitOn: "IdRolUsuario",
                            param: new
                            {
                                UserName = usuario,
                                Contrasenia = contrasenia
                            },
                            commandType: CommandType.StoredProcedure)
                        .Distinct()
                        .FirstOrDefault();

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return entidad;
        }
    }
}
