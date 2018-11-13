using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Datos.Helper;
using Entidad.Entidades.Maestro;
using Entidad.Vo;
using System;
using Entidad.Dto.Maestro;

namespace Datos.Maestro
{
    public class AdPais
    {
        public List<PaisDto> Obtener(PaisFiltroDto filtro)
        {
            List<PaisDto> lista;

            try
            {
                const string query = StoreProcedure.Maestro_usp_Pais_Obtener;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    lista = cn.Query<PaisDto>(query, new
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

        public List<Pais> ObtenerCombo()
        {
            List<Pais> lista;
            const string query = StoreProcedure.Maestro_usp_Pais_Combo;

            using (var cn = HelperClass.ObtenerConeccion())
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                lista = cn.Query<Pais>(query, commandType: CommandType.StoredProcedure).ToList();

            }
            return lista;
        }

        public Pais ObtenerPorId(int id)
        {

            Pais entidad;

            try
            {
                const string query = StoreProcedure.Maestro_usp_Pais_ObtenerPorId;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    entidad = cn.Query<Pais>(query, new
                        {
                            IdPais = id
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

        public Int32 Registrar(Pais entidad)
        {
            Int32 respuesta;
            try
            {
                const string query = StoreProcedure.Maestro_usp_Pais_Registrar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
                            entidad.Nombre,
                            entidad.Codigo
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

        public Int32 Modificar(Pais entidad)
        {
            Int32 respuesta;
            try
            {
                const string query = StoreProcedure.Maestro_usp_Pais_Modificar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
                            entidad.IdPais,
                            entidad.Nombre,
                            entidad.Codigo
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
                const string query = StoreProcedure.Maestro_usp_Pais_Eliminar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
                            IdPais = id
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
