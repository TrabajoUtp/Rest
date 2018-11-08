using System;

namespace Entidad.Entidades.Maestro
{
    public class Motivo
    {
        public Int32 IdMotivo { get; set; }
        public String Abreviatura { get; set; }
        public String Nombre { get; set; }
        public String Observacion { get; set; }
        public Int32 IdEstado { get; set; }
    }
}
