using System;
using Entidad.Vo;

namespace Entidad.Dto.Gestion
{
    public class IncidenciaDetalleFiltroDto : DataTableNet
    {
        public Int32 IdIncidencia { get; set; }
        public String Descripcion { get; set; }
        public Boolean RecortarDescripcion { get; set; }

        public IncidenciaDetalleFiltroDto()
        {
            RecortarDescripcion = false;
        }
    }
}
