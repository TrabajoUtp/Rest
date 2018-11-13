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
    public class AdIncidencia
    {
        public List<IncidenciaDto> Obtener(IncidenciaFiltroDto filtro)
        {

            List<IncidenciaDto> lista;

            try
            {
                const string query = StoreProcedure.Gestion_usp_Incidencia_Obtener;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    lista = cn.Query<IncidenciaDto>(query, new
                        {
                            filtro.IdCliente,
                            filtro.Asunto,
                            filtro.IdTipoIncidencia,
                            filtro.IdMotivo,
                            filtro.IdPrioridad,
                            filtro.IdEstado,
                            filtro.FechaInicio,
                            filtro.FechaFin,
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

        public List<Incidencia> ObtenerCombo(Int32 idEstado)
        {
            List<Incidencia> lista;
            const string query = StoreProcedure.Gestion_usp_Incidencia_Combo;

            using (var cn = HelperClass.ObtenerConeccion())
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                lista = cn.Query<Incidencia>(query, new
                {
                    IdEstado = idEstado
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            return lista;
        }

        public Incidencia ObtenerPorId(int id)
        {

            Incidencia entidad;

            try
            {
                const string query = StoreProcedure.Gestion_usp_Incidencia_ObtenerPorId;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    entidad = cn.Query<Incidencia>(query, new
                        {
                            IdIncidencia = id
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

        public Int32 Registrar(Incidencia entidad, ref Int32 idIncidenciaNuevo)
        {
            Int32 respuesta;
            try
            {
                const string query = StoreProcedure.Gestion_usp_Incidencia_Registrar;
                var p = new DynamicParameters();
                p.Add("IdIncidencia", 0, DbType.Int32, ParameterDirection.Output);
                p.Add("IdCliente", entidad.IdCliente);
                p.Add("Asunto", entidad.Asunto);
                p.Add("IdTipoIncidencia", entidad.IdTipoIncidencia);
                p.Add("IdMotivo", entidad.IdMotivo);
                p.Add("IdPrioridad", entidad.IdPrioridad);
                p.Add("IdEstado", entidad.IdEstado);
                p.Add("IdUsuarioRegistra", entidad.IdUsuarioRegistra);

                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, param: p, commandType: CommandType.StoredProcedure);
                    idIncidenciaNuevo = p.Get<Int32>("IdIncidencia");

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }

        public Int32 Modificar(Incidencia entidad)
        {
            Int32 respuesta;
            try
            {
                const string query = StoreProcedure.Gestion_usp_Incidencia_Modificar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
                            entidad.IdIncidencia,
                            entidad.IdCliente,
                            entidad.Asunto,
                            entidad.IdTipoIncidencia,
                            entidad.IdMotivo,
                            entidad.IdPrioridad,
                            entidad.IdEstado,
                            entidad.IdUsuarioRegistra
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
                const string query = StoreProcedure.Gestion_usp_Incidencia_Eliminar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
                            IdIncidencia = id
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
