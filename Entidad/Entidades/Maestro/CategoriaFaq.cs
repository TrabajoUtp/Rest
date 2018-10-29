using System;

namespace Entidad.Entidades.Maestro
{
    public class CategoriaFaq
    {
        public Int32 IdCategoriaFaq { get; set; }
        public String Nombre { get; set; }
        public String Observacion { get; set; }
        public Int32 IdEstado { get; set; }
        public Int32 IdUsuario { get; set; }
    }
}
