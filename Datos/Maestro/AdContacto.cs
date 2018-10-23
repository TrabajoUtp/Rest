using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Datos.Helper;
using Entidad.Entidades.Maestro;

namespace Datos.Maestro
{
    public class AdContacto
    {
        public List<Contacto> Obtener()
        {
            try
            {
                using (var cn = HelperClass.ObtenerConeccion())
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    return cn.Query<Contacto>("SELECT * FROM Contacto").ToList();
                }
            }
            catch
            {
                
                throw;
            }
        } 
    }
}
