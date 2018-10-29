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
        public List<FaqDto> Obtener(FaqFiltro filtro)
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
                            filtro.Descripcion,
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

        public Faq ObtenerPorId(int idFaq)
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
                            IdFaq = idFaq
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

        public Int32 Registrar(Faq faq)
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
                            faq.Titulo,
                            faq.Descripcion,
                            faq.IdCategoriaFaq,
                            IdUsuario = faq.IdUsuarioRegistra
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

        public Int32 Modificar(Faq faq)
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
                            faq.IdFaq,
                            faq.Titulo,
                            faq.Descripcion,
                            faq.IdCategoriaFaq,
                            IdUsuario = faq.IdUsuarioActualiza
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

        public Int32 Eliminar(Int32 idFaq)
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
                            IdFaq = idFaq
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
