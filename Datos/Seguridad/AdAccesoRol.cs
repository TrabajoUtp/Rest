using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Datos.Helper;
using Entidad.Dto.Seguridad;
using Entidad.Vo;

namespace Datos.Seguridad
{
    public class AdAccesoRol
    {
        //public List<AccesoRolPadreDto> ObtenerPorIdUsuario(Int32 idUsuario)
        //{
        //    List<AccesoRolPadreDto> lista;
        //    const string query = StoreProcedure.Seguridad_usp_AccesoRol_ObtenerPorIdUsuario;

        //    using (var cn = HelperClass.ObtenerConeccion())
        //    {
        //        if (cn.State == ConnectionState.Closed)
        //        {
        //            cn.Open();
        //        }

        //        lista = cn.Query<AccesoRolPadreDto>(query, new
        //        {
        //            IdUsuario = idUsuario
        //        }, commandType: CommandType.StoredProcedure).ToList();

        //    }
        //    return lista;
        //}

        public List<AccesoRolPadreDto> ObtenerPorIdUsuario(Int32 idUsuario)
        {

            List<AccesoRolPadreDto> entidad;

            try
            {
                const string query = StoreProcedure.Seguridad_usp_Acceso_ObtenerPorIdUsuario;
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    var headerDictionary = new Dictionary<Int64, AccesoRolPadreDto>();

                    entidad = cn.Query<AccesoRolPadreDto, AccesoRolHijoDto, AccesoRolPadreDto>(
                            query,
                            (header, detail) =>
                            {
                                AccesoRolPadreDto headerEntry;

                                if (!headerDictionary.TryGetValue(header.IdAccesoLlave, out headerEntry))
                                {
                                    headerEntry = header;
                                    headerEntry.ListaEnlaces = new List<AccesoRolHijoDto>();
                                    headerDictionary.Add(headerEntry.IdAccesoLlave, headerEntry);
                                }

                                headerEntry.ListaEnlaces.Add(detail);
                                return headerEntry;
                            },
                            splitOn: "IdAccesoLLave",
                            param: new
                            {
                                IdUsuario = idUsuario
                            },
                            commandType: CommandType.StoredProcedure)
                        .Distinct().ToList();

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return entidad;
        }
    }
}
