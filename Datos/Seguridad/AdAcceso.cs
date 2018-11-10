using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Datos.Helper;
using Entidad.Dto.Seguridad;
using Entidad.Entidades.Seguridad;
using Entidad.Vo;

namespace Datos.Seguridad
{
    public class AdAcceso
    {
        public List<AccesoDto> Obtener(AccesoFiltroDto filtro)
        {

            List<AccesoDto> lista;

            try
            {
                const string query = StoreProcedure.Seguridad_usp_Acceso_Obtener;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    lista = cn.Query<AccesoDto>(query, new
                        {
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

        public List<Acceso> ObtenerCombo(Int32 idEstado)
        {
            List<Acceso> lista;
            const string query = StoreProcedure.Seguridad_usp_Acceso_Combo;

            using (var cn = HelperClass.ObtenerConeccion())
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                lista = cn.Query<Acceso>(query, new
                {
                    IdEstado = idEstado
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            return lista;
        }

        public Acceso ObtenerPorId(Int64 id)
        {

            Acceso entidad;

            try
            {
                const string query = StoreProcedure.Seguridad_usp_Acceso_ObtenerPorId;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    entidad = cn.Query<Acceso>(query, new
                        {
                            IdAcceso = id
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

        public Int32 Registrar(Acceso entidad)
        {
            Int32 respuesta;
            try
            {
                const string query = StoreProcedure.Seguridad_usp_Acceso_Registrar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    

                    respuesta = cn.Execute(query, new
                        {
                            entidad.IdAcceso,
                            entidad.Nombre,
                            entidad.Descripcion,
                            entidad.Url,
                            entidad.Icono,
                            entidad.Orden,
                            entidad.Tipo,
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

        public Int32 Modificar(Acceso entidad)
        {
            Int32 respuesta;
            try
            {
                const string query = StoreProcedure.Seguridad_usp_Acceso_Modificar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
                            entidad.IdAcceso,
                            entidad.IdAccesoPadre,
                            entidad.Nombre,
                            entidad.Descripcion,
                            entidad.Url,
                            entidad.Icono,
                            entidad.Orden,
                            entidad.Tipo,
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

        public Int32 Eliminar(Int64 id)
        {
            Int32 respuesta;
            try
            {
                const string query = StoreProcedure.Seguridad_usp_Acceso_Eliminar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
                            IdAcceso = id
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
