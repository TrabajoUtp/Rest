using System;

namespace Entidad.Dto.Maestro
{
    public class CategoriaFaqDto
    {
        public Int32 IdCategoriaFaq { get; set; }
        public String Nombre { get; set; }
        public String Observacion { get; set; }
        public String Estado { get; set; }
        public Int32 TotalItems { get; set; }
    }
}
