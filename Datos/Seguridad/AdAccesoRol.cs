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
        public List<AccesoDto> ObtenerPorIdUsuario(Int32 idUsuario)
        {
            List<AccesoDto> lista;
            const string query = StoreProcedure.Seguridad_usp_AccesoRol_ObtenerPorIdUsuario;

            using (var cn = HelperClass.ObtenerConeccion())
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                lista = cn.Query<AccesoDto>(query, new
                {
                    IdUsuario = idUsuario
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            return lista;
        }
    }
}
