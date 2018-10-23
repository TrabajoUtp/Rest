using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using Dapper;
using Datos.Helper;
using Entidad.Dto.Seguridad;

namespace Datos.Seguridad
{
    public class AdLogin
    {
        //public LoginUsuario Login(string usuario, string contrasenia)
        //{

        //    LoginUsuario entidad;

        //    try
        //    {
        //        const string query = "Seguridad.usp_Usuario_Login";
        //        using (var cn = HelperClass.ObtenerConeccion())
        //        {
        //            if (cn.State == ConnectionState.Closed)
        //            {
        //                cn.Open();
        //            }

        //            using (var multi = cn.QueryMultiple(query, new
        //            {
        //                UserName = usuario,
        //                Contrasenia = contrasenia
        //            }, 
        //            commandType: CommandType.StoredProcedure))
        //            {
        //                entidad = multi.Read<LoginUsuario>().First();
        //                if (entidad != null)
        //                {
        //                    entidad.ListaRolUsuario = multi.Read<RolUsuario>().ToList();
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return entidad;
        //}

        public LoginUsuario Login(string usuario, string contrasenia)
        {

            LoginUsuario entidad;

            try
            {
                const string query = "Seguridad.usp_Usuario_Login";
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    var headerDictionary = new Dictionary<int, LoginUsuario>();

                    entidad = cn.Query<LoginUsuario, RolUsuario, LoginUsuario>(
                        query,
                        (header, detail) =>
                        {
                            LoginUsuario headerEntry;

                            if (!headerDictionary.TryGetValue(header.IdUsuario, out headerEntry))
                            {
                                headerEntry = header;
                                headerEntry.ListaRolUsuario = new List<RolUsuario>();
                                headerDictionary.Add(headerEntry.IdUsuario, headerEntry);
                            }

                            headerEntry.ListaRolUsuario.Add(detail);
                            return headerEntry;
                        },
                        splitOn: "IdRolUsuario",
                        param: new
                        {
                            UserName = usuario,
                            Contrasenia = contrasenia
                        },
                        commandType: CommandType.StoredProcedure)
                        .Distinct()
                        .FirstOrDefault();
                    
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
