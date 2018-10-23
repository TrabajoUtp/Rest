using System.Collections.Generic;
using System.Threading.Tasks;
using Datos.Maestro;
using Entidad.Entidades.Maestro;

namespace Negocio.Maestro
{
    public class LnContacto
    {
        private readonly AdContacto _adContacto = new AdContacto();

        public Task<List<Contacto>> ObtenerContactos()
        {
            return Task.Factory.StartNew(() => _adContacto.Obtener());
            //return Task.Run(() => _adContacto.ObtenerContactos());

        } 
    }
}
