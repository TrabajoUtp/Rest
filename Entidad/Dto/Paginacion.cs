using System;

namespace Entidad.Dto
{
    public class Paginacion
    {
        public Int32 NumeroPagina { get; set; }
        public Int32 CantidadRegistros { get; set; }
        public String ColumnaOrden { get; set; }
        public String DireccionOrden { get; set; }
    }
}
