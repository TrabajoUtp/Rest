using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad.Dto.Gestion
{
    public class IncidenciaEstadoDto
    {
        public Int32 IdIncidencia { get; set; }
        public Int32 IdEstado { get; set; }
        public Int32 IdUsuario { get; set; }
        public Boolean Finalizado { get; set; }
        public Int32 IdArea { get; set; }
        public String Descripcion { get; set; }
    }
}
