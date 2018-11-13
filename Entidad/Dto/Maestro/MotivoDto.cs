using System;

namespace Entidad.Dto.Maestro
{
    public  class MotivoDto
    {
        public Int32 Item { get; set; }
        public Int32 IdMotivo { get; set; }
        public String Abreviatura { get; set; }
        public String Nombre { get; set; }
        public String Observacion { get; set; }
        public Int32 IdEstado { get; set; }
        public Int32 TotalItems { get; set; }
    }
}
