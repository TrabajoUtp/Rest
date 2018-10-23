using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Entidad.Entidades.Maestro;
using Dapper;
using Datos.Helper;
using Entidad.Vo;

namespace Datos.Maestro
{
    public class AdDepartamento
    {
        public List<Departamento> ObtenerCombo(Int32 idPais)
        {
            List<Departamento> lista;
            const string query = StoreProcedure.Maestro_usp_Departamento_Combo;

            using (var cn = HelperClass.ObtenerConeccion())
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                lista = cn.Query<Departamento>(query, new
                {
                    IdPais = idPais
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            return lista;
        }
    }
}
