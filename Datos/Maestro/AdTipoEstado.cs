using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Datos.Helper;
using Entidad.Dto.Maestro;
using Entidad.Entidades.Maestro;
using Entidad.Vo;

namespace Datos.Maestro
{
    public class AdTipoEstado
    {
        public List<TipoEstadoDto> Obtener(TipoEstadoFiltroDto filtro)
        {

            List<TipoEstadoDto> lista;

            try
            {
                const string query = StoreProcedure.Maestro_usp_TipoEstado_Obtener;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    lista = cn.Query<TipoEstadoDto>(query, new
                        {
                            filtro.Buscar,
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

        public List<TipoEstado> ObtenerCombo()
        {
            List<TipoEstado> lista;
            const string query = StoreProcedure.Maestro_usp_TipoEstado_Combo;

            using (var cn = HelperClass.ObtenerConeccion())
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                lista = cn.Query<TipoEstado>(query, commandType: CommandType.StoredProcedure).ToList();

            }
            return lista;
        }

        public TipoEstado ObtenerPorId(int id)
        {

            TipoEstado entidad;

            try
            {
                const string query = StoreProcedure.Maestro_usp_TipoEstado_ObtenerPorId;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    entidad = cn.Query<TipoEstado>(query, new
                        {
                            IdTipoEstado = id
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

        public Int32 Registrar(TipoEstado entidad)
        {
            Int32 respuesta;
            try
            {
                const string query = StoreProcedure.Maestro_usp_TipoEstado_Registrar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
                            entidad.Nombre,
                            entidad.Observacion
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

        public Int32 Modificar(TipoEstado entidad)
        {
            Int32 respuesta;
            try
            {
                const string query = StoreProcedure.Maestro_usp_TipoEstado_Modificar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
                            entidad.IdTipoEstado,
                            entidad.Nombre,
                            entidad.Observacion
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
                const string query = StoreProcedure.Maestro_usp_TipoEstado_Eliminar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
                            IdTipoEstado = id
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
