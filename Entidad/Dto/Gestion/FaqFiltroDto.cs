using System;
using Entidad.Vo;

namespace Entidad.Dto.Gestion
{
    public class FaqFiltroDto : DataTableNet
    {
        public String Descripcion { get; set; }
        public Int32 IdCategoriaFaq { get; set; }
        public Int32 IdEstado { get; set; }
    }
}
