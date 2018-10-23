using System;

namespace Entidad.Entidades.Maestro
{
    public class Cliente
    {

        public Int32 IdCliente { get; set; }
        public String NumeroDocumento { get; set; }
        public String RazonSocial { get; set; }
        public String Direccion { get; set; }
        public Int32 IdPais { get; set; }
        public Int32 IdDepartamento { get; set; }
        public Int32 IdProvincia { get; set; }
        public Int32 IdDistrito { get; set; }
        public DateTime FechaRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public Int32 IdEstado { get; set; }

    }
}
