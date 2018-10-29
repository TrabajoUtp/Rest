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
    public class AdCategoriaFaq
    {
        public List<CategoriaFaqDto> Obtener(CategoriaFaqFiltro filtro)
        {

            List<CategoriaFaqDto> lista;

            try
            {
                const string query = StoreProcedure.Maestro_usp_CategoriaFaq_Obtener;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    lista = cn.Query<CategoriaFaqDto>(query, new
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

        public List<CategoriaFaq> ObtenerCombo(Int32 idEstado)
        {
            List<CategoriaFaq> lista;
            const string query = StoreProcedure.Maestro_usp_CategoriaFaq_Combo;

            using (var cn = HelperClass.ObtenerConeccion())
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                lista = cn.Query<CategoriaFaq>(query, new
                    {
                        IdEstado = idEstado
                    },
                    commandType: CommandType.StoredProcedure).ToList();

            }
            return lista;
        }

        public CategoriaFaq ObtenerPorId(int idCategoriaFaq)
        {

            CategoriaFaq entidad;

            try
            {
                const string query = StoreProcedure.Maestro_usp_CategoriaFaq_ObtenerPorId;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    entidad = cn.Query<CategoriaFaq>(query, new
                        {
                            IdCategoriaFaq = idCategoriaFaq
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

        public Int32 Registrar(CategoriaFaq categoriaFaq)
        {
            Int32 respuesta;
            try
            {
                const string query = StoreProcedure.Maestro_usp_CategoriaFaq_Registrar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
                            categoriaFaq.Nombre,
                            categoriaFaq.Observacion,
                            categoriaFaq.IdUsuario,
                            categoriaFaq.IdEstado
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

        public Int32 Modificar(CategoriaFaq categoriaFaq)
        {
            Int32 respuesta;
            try
            {
                const string query = StoreProcedure.Maestro_usp_CategoriaFaq_Modificar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
                            categoriaFaq.IdCategoriaFaq,
                            categoriaFaq.Nombre,
                            categoriaFaq.Observacion,
                            categoriaFaq.IdUsuario,
                            categoriaFaq.IdEstado
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

        public Int32 Eliminar(Int32 idCategoriaFaq)
        {
            Int32 respuesta;
            try
            {
                const string query = StoreProcedure.Maestro_usp_CategoriaFaq_Eliminar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
                            IdCategoriaFaq = idCategoriaFaq
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
