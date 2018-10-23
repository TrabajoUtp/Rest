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
    public class AdProvincia
    {
        public List<Provincia> ObtenerCombo(Int32 idDepartamento)
        {
            List<Provincia> lista;
            const string query = StoreProcedure.Maestro_usp_Provincia_Combo;

            using (var cn = HelperClass.ObtenerConeccion())
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                lista = cn.Query<Provincia>(query, new
                {
                    IdDepartamento = idDepartamento
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            return lista;
        }
    }
}
