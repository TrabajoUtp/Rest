using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Datos.Helper;
using Entidad.Dto.Gestion;
using Entidad.Entidades.Gestion;
using Entidad.Vo;

namespace Datos.Gestion
{
    public class AdIncidenciaDetalle
    {
        public List<IncidenciaDetalleDto> Obtener(IncidenciaDetalleFiltroDto filtro)
        {

            List<IncidenciaDetalleDto> lista;

            try
            {
                const string query = StoreProcedure.Gestion_usp_IncidenciaDetalle_Obtener;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    lista = cn.Query<IncidenciaDetalleDto>(query, new
                        {
                            filtro.IdIncidencia,
                            filtro.Descripcion,
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

        public IncidenciaDetalle ObtenerPorId(int id)
        {

            IncidenciaDetalle entidad;

            try
            {
                const string query = StoreProcedure.Gestion_usp_IncidenciaDetalle_ObtenerPorId;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    entidad = cn.Query<IncidenciaDetalle>(query, new
                        {
                            IdIncidenciaDetalle = id
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

        public Int32 Registrar(IncidenciaDetalle entidad)
        {
            Int32 respuesta;
            try
            {
                const string query = StoreProcedure.Gestion_usp_IncidenciaDetalle_Registrar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
                            entidad.IdIncidencia,
                            entidad.IdArea,
                            entidad.Descripcion,
                            entidad.IdUsuario
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

        public Int32 Modificar(IncidenciaDetalle entidad)
        {
            Int32 respuesta;
            try
            {
                const string query = StoreProcedure.Gestion_usp_IncidenciaDetalle_Modificar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
                            entidad.IdIncidenciaDetalle,
                            entidad.IdIncidencia,
                            entidad.IdArea,
                            entidad.Descripcion,
                            entidad.IdUsuario
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
                const string query = StoreProcedure.Gestion_usp_IncidenciaDetalle_Eliminar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
                            IdIncidenciaDetalle = id
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
