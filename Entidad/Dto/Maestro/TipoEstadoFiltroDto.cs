using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad.Vo;

namespace Entidad.Dto.Maestro
{
    public class TipoEstadoFiltroDto: DataTableNet
    {
        public String Nombre { get; set; }
        public String Observacion { get; set; }
    }
}
