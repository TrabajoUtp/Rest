using System;

namespace Entidad.Dto.Gestion
{
    public class FaqDto
    {
        public Int32 Item { get; set; }
        public Int32 IdFaq { get; set; }
        public String Titulo { get; set; }
        public String NombreCategoriaFaq { get; set; }
        public Int32 TotalItems { get; set; }
    }
}
