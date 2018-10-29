using System;

namespace Entidad.Entidades.Gestion
{
    public class Faq
    {

        public Int32 IdFaq { get; set; }
        public String Titulo { get; set; }
        public String Descripcion { get; set; }
        public Int32 IdCategoriaFaq { get; set; }
        public Int32 IdUsuarioRegistra { get; set; }
        public Int32? IdUsuarioActualiza { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaActualizacion { get; set; }


    }
}
