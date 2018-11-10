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
    public class AdTipoIncidencia
    {
        public List<TipoIncidenciaDto> Obtener(TipoIncidenciaFiltroDto filtro)
        {

            List<TipoIncidenciaDto> lista;

            try
            {
                const string query = StoreProcedure.Maestro_usp_TipoIncidencia_Obtener;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    lista = cn.Query<TipoIncidenciaDto>(query, new
                        {
                            filtro.Nombre,
                            filtro.Observacion,
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

        public List<TipoIncidencia> ObtenerCombo(Int32 idEstado)
        {
            List<TipoIncidencia> lista;
            const string query = StoreProcedure.Maestro_usp_TipoIncidencia_Combo;

            using (var cn = HelperClass.ObtenerConeccion())
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                lista = cn.Query<TipoIncidencia>(query, new
                {
                    IdEstado = idEstado
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            return lista;
        }

        public TipoIncidencia ObtenerPorId(int id)
        {

            TipoIncidencia entidad;

            try
            {
                const string query = StoreProcedure.Maestro_usp_TipoIncidencia_ObtenerPorId;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    entidad = cn.Query<TipoIncidencia>(query, new
                        {
                            IdTipoIncidencia = id
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

        public Int32 Registrar(TipoIncidencia entidad)
        {
            Int32 respuesta;
            try
            {
                const string query = StoreProcedure.Maestro_usp_TipoIncidencia_Registrar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
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

        public Int32 Modificar(TipoIncidencia entidad)
        {
            Int32 respuesta;
            try
            {
                const string query = StoreProcedure.Maestro_usp_TipoIncidencia_Modificar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
                            entidad.IdTipoIncidencia,
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
                const string query = StoreProcedure.Maestro_usp_TipoIncidencia_Eliminar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
                            IdTipoIncidencia = id
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
