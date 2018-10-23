using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Datos.Helper;
using Entidad.Entidades.Maestro;
using Entidad.Vo;

namespace Datos.Maestro
{
    public class AdEstado
    {
        public List<Estado> ObtenerPorTipoEstado(int idTipoEstado)
        {
            List<Estado> lista;
            const string query = StoreProcedure.Maestro_usp_Estado_Combo;

            using (var cn = HelperClass.ObtenerConeccion())
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                lista = cn.Query<Estado>(query, new
                {
                    IdTipoEstado = idTipoEstado
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            return lista;
        }
    }
}
