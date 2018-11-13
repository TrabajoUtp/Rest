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
    public class AdFaq
    {
        public List<FaqDto> Obtener(FaqFiltroDto filtro)
        {

            List<FaqDto> lista;

            try
            {
                const string query = StoreProcedure.Gestion_usp_Faq_Obtener;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    lista = cn.Query<FaqDto>(query, new
                        {
                            filtro.Buscar,
                            filtro.IdCategoriaFaq,
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

        public List<Faq> ObtenerCombo()
        {
            List<Faq> lista;
            const string query = StoreProcedure.Gestion_usp_Faq_Combo;

            using (var cn = HelperClass.ObtenerConeccion())
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                lista = cn.Query<Faq>(query, commandType: CommandType.StoredProcedure).ToList();

            }
            return lista;
        }

        public Faq ObtenerPorId(int id)
        {

            Faq rol;

            try
            {
                const string query = StoreProcedure.Gestion_usp_Faq_ObtenerPorId;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    rol = cn.Query<Faq>(query, new
                        {
                            IdFaq = id
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

        public Int32 Registrar(Faq entidad)
        {
            Int32 respuesta;
            try
            {
                const string query = StoreProcedure.Gestion_usp_Faq_Registrar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
                            entidad.Titulo,
                            entidad.Descripcion,
                            entidad.IdCategoriaFaq,
                            IdUsuario = entidad.IdUsuarioRegistra
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

        public Int32 Modificar(Faq entidad)
        {
            Int32 respuesta;
            try
            {
                const string query = StoreProcedure.Gestion_usp_Faq_Modificar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
                            entidad.IdFaq,
                            entidad.Titulo,
                            entidad.Descripcion,
                            entidad.IdCategoriaFaq,
                            IdUsuario = entidad.IdUsuarioActualiza
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
                const string query = StoreProcedure.Gestion_usp_Faq_Eliminar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
                            IdFaq = id
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
