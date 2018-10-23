using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Datos.Helper
{
    internal class HelperClass
    {
        public static IDbConnection ObtenerConeccion()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            //"Server=.;Database=Demo;Integrated Security=false;Uid=sa;Pwd=d3sarrollo;");
        }
    }
}
