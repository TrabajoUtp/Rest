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
    public class AdRol
    {
        public List<RolDto> Obtener(RolFiltroDto filtro)
        {

            List<RolDto> lista;

            try
            {
                const string query = StoreProcedure.Seguridad_usp_Rol_Obtener;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    lista = cn.Query<RolDto>(query, new
                    {
                        filtro.Nombre,
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

        public List<Rol> ObtenerCombo(Int32 idEstado)
        {
            List<Rol> lista;
            const string query = StoreProcedure.Seguridad_usp_Rol_Combo;

            using (var cn = HelperClass.ObtenerConeccion())
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                lista = cn.Query<Rol>(query, new
                {
                    IdEstado = idEstado
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            return lista;
        }

        public RolDto ObtenerPorId(int id)
        {

            RolDto rol;

            try
            {
                const string query = StoreProcedure.Seguridad_usp_Rol_ObtenerPorId;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    rol = cn.Query<RolDto>(query, new
                    {
                        IdRol = id
                    },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return rol;
        }

        public Int32 Registrar(Rol entidad)
        {
            Int32 respuesta;
            try
            {
                const string query = StoreProcedure.Seguridad_usp_Rol_Registrar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                    {
                        entidad.IdRol,
                        entidad.Nombre,
                        entidad.Observacion,
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

        public Int32 Modificar(Rol entidad)
        {
            Int32 respuesta;
            try
            {
                const string query = StoreProcedure.Seguridad_usp_Rol_Modificar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                    {
                        entidad.IdRol,
                        entidad.Nombre,
                        entidad.Observacion,
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
                const string query = StoreProcedure.Seguridad_usp_Rol_Eliminar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
                            IdRol = id
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

    }
}
