using System;

namespace Entidad.Dto.Maestro
{
    public class ContactoDto
    {
        public Int32 Item { get; set; }
        public Int32 IdContacto { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Correo { get; set; }
        public String Telefono { get; set; }
        public Int32 IdCliente { get; set; }
        public Int32 IdEstado { get; set; }
        public Int32 TotalItems { get; set; }

    }
}
