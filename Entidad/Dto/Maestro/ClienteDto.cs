using System;

namespace Entidad.Dto.Maestro
{
    public class ClienteDto
    {

        public String IdCliente { get; set; }
        public String NumeroDocumento { get; set; }
        public String RazonSocial { get; set; }
        public String Direccion { get; set; }
        public int IdEstado { get; set; }
        public String Estado { get; set; }
        public Int32 TotalItems { get; set; }

    }
}
