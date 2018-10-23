using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Datos.Helper;
using Entidad.Entidades.Maestro;
using Entidad.Vo;

namespace Datos.Maestro
{
    public class AdPais
    {
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
    }
}
