using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Datos.Helper;
using Entidad.Dto.Asignacion;
using Entidad.Entidades.Asignacion;
using Entidad.Vo;

namespace Datos.Asignacion
{
    public class AdRolUsuario
    {
        public List<RolUsuarioDto> Obtener(RolUsuarioFiltroDto filtro)
        {

            List<RolUsuarioDto> lista;

            try
            {
                const string query = StoreProcedure.Asignacion_usp_RolUsuario_ObtenerPorIdRol;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    lista = cn.Query<RolUsuarioDto>(query, new
                    {
                        filtro.Buscar,
                        filtro.IdEstado,
                        filtro.IdRol,
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

        public RolUsuario ObtenerPorId(int id)
        {

            RolUsuario entidad;

            try
            {
                const string query = StoreProcedure.Asignacion_usp_RolUsuario_ObtenerPorId;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    entidad = cn.Query<RolUsuario>(query, new
                    {
                        IdRolUsuario = id
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

        public Int32 Registrar(RolUsuario entidad)
        {
            Int32 respuesta;
            try
            {
                const string query = StoreProcedure.Asignacion_usp_RolUsuario_Registrar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                    {
                        entidad.IdRol,
                        entidad.IdUsuario,
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
                const string query = StoreProcedure.Asignacion_usp_RolUsuario_Eliminar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                    {
                        IdRolUsuario = id
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
