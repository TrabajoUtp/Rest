using Entidad.Dto.Maestro;
using Entidad.Entidades.Maestro;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Datos.Helper;
using Entidad.Vo;

namespace Datos.Maestro
{
    public class AdMotivo
    {
        public List<MotivoDto> Obtener(MotivoFiltroDto filtro)
        {

            List<MotivoDto> lista;

            try
            {
                const string query = StoreProcedure.Maestro_usp_Motivo_Obtener;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    lista = cn.Query<MotivoDto>(query, new
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

        public List<Motivo> ObtenerCombo(Int32 idEstado)
        {
            List<Motivo> lista;
            const string query = StoreProcedure.Maestro_usp_Motivo_Combo;

            using (var cn = HelperClass.ObtenerConeccion())
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                lista = cn.Query<Motivo>(query, new
                {
                    IdEstado = idEstado
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            return lista;
        }

        public Motivo ObtenerPorId(int id)
        {

            Motivo entidad;

            try
            {
                const string query = StoreProcedure.Maestro_usp_Motivo_ObtenerPorId;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    entidad = cn.Query<Motivo>(query, new
                        {
                            IdMotivo = id
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

        public Int32 Registrar(Motivo entidad)
        {
            Int32 respuesta;
            try
            {
                const string query = StoreProcedure.Maestro_usp_Motivo_Registrar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
                            entidad.Abreviatura,
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

        public Int32 Modificar(Motivo entidad)
        {
            Int32 respuesta;
            try
            {
                const string query = StoreProcedure.Maestro_usp_Motivo_Modificar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
                            entidad.IdMotivo,
                            entidad.Abreviatura,
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
                const string query = StoreProcedure.Maestro_usp_Motivo_Eliminar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
                            IdMotivo = id
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
