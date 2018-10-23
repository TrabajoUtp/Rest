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
    public class AdCliente
    {
        public List<ClienteDto> Obtener(ClienteFiltro filtro)
        {

            List<ClienteDto> listaRol;

            try
            {
                const string query = StoreProcedure.Maestro_usp_Cliente_Obtener;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    listaRol = cn.Query<ClienteDto>(query, new
                    {
                        filtro.NumeroDocumento,
                        filtro.RazonSocial,
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
            return listaRol;
        }

        public Cliente ObtenerPorId(int idCliente)
        {

            Cliente rol;

            try
            {
                const string query = StoreProcedure.Maestro_usp_Cliente_ObtenerPorId;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    rol = cn.Query<Cliente>(query, new
                    {
                        IdCliente = idCliente
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

        public Int32 Registrar(Cliente cliente)
        {
            Int32 respuesta;
            try
            {
                const string query = StoreProcedure.Maestro_usp_Cliente_Registrar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                    {
                        cliente.NumeroDocumento,
                        cliente.RazonSocial,
                        cliente.Direccion,
                        cliente.IdPais,
                        cliente.IdDepartamento,
                        cliente.IdProvincia,
                        cliente.IdDistrito,
                        cliente.IdUsuario,
                        cliente.IdEstado
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

        public Int32 Modificar(Cliente cliente)
        {
            Int32 respuesta;
            try
            {
                const string query = StoreProcedure.Maestro_usp_Cliente_Modificar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                    {
                        cliente.IdCliente,
                        cliente.NumeroDocumento,
                        cliente.RazonSocial,
                        cliente.Direccion,
                        cliente.IdPais,
                        cliente.IdDepartamento,
                        cliente.IdProvincia,
                        cliente.IdDistrito,
                        cliente.IdUsuario,
                        cliente.IdEstado
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

        public Int32 Eliminar(Int32 idCliente)
        {
            Int32 respuesta;
            try
            {
                const string query = StoreProcedure.Maestro_usp_Cliente_Eliminar;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    respuesta = cn.Execute(query, new
                        {
                            IdCliente = idCliente
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
