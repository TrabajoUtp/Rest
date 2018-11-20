using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Datos.Helper;
using Entidad.Dto.Asignacion;
using Entidad.Entidades.Asignacion;
using Entidad.Vo;

namespace Datos.Asignacion
{
    public class AdUsuarioCliente
    {
        public List<UsuarioClienteDto> Obtener(UsuarioClienteFiltroDto filtro)
        {

            List<UsuarioClienteDto> lista;

            try
            {
                const string query = StoreProcedure.Asignacion_usp_UsuarioCliente_ObtenerPorIdUsuario;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    lista = cn.Query<UsuarioClienteDto>(query, new
                        {
                            filtro.Buscar,
                            filtro.IdEstado,
                            filtro.IdUsuario,
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

        public UsuarioCliente ObtenerPorId(int id)
        {

            UsuarioCliente entidad;

            try
            {
                const string query = StoreProcedure.Asignacion_usp_UsuarioCliente_ObtenerPorId;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    entidad = cn.Query<UsuarioCliente>(query, new
                        {
                            IdUsuarioCliente = id
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

        public Int32 Registrar(UsuarioCliente entidad)
        {
            Int32 respuesta;
            try
            {
                const string query = StoreProcedure.Asignacion_usp_UsuarioCliente_Registrar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
                            entidad.IdUsuario,
                            entidad.IdCliente,
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
                const string query = StoreProcedure.Asignacion_usp_UsuarioCliente_Eliminar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
                            IdUsuarioCliente = id
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
