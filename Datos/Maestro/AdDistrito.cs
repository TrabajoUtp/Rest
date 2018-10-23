using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Datos.Helper;
using Entidad.Entidades.Maestro;
using Entidad.Vo;

namespace Datos.Maestro
{
    public class AdDistrito
    {
        public List<Distrito> ObtenerCombo(Int32 idProvincia)
        {
            List<Distrito> lista;
            const string query = StoreProcedure.Maestro_usp_Distrito_Combo;

            using (var cn = HelperClass.ObtenerConeccion())
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                lista = cn.Query<Distrito>(query, new
                {
                    IdProvincia = idProvincia
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            return lista;
        }
    }
}
