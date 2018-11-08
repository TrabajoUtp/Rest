using System;

namespace Entidad.Entidades.Seguridad
{
    public class Acceso
    {
        public Int64 IdAcceso { get; set; }
        public Int64 IdAccesoPadre { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public String Url { get; set; }
        public String Icono { get; set; }
        public Int32 Orden { get; set; }
        public String Tipo { get; set; }
        public Int32 IdEstado { get; set; }
    }
}
