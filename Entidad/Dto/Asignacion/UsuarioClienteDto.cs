using System;

namespace Entidad.Dto.Asignacion
{
    public class UsuarioClienteDto
    {
        public Int32 Item { get; set; }
        public Int32 IdUsuarioCliente { get; set; }
        public String IdCliente { get; set; }
        public String NumeroDocumento { get; set; }
        public String RazonSocial { get; set; }
        public int IdEstado { get; set; }
        public Int32 TotalItems { get; set; }
    }
}
