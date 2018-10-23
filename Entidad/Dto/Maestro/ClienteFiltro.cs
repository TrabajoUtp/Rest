using System;
using Entidad.Vo;

namespace Entidad.Dto.Maestro
{
    public class ClienteFiltro : DataTableNet
    {
        public Int32 IdCliente { get; set; }
        public String NumeroDocumento { get; set; }
        public String RazonSocial { get; set; }
        public String Direccion { get; set; }
        public Int32 IdEstado { get; set; }
        
    }
}
