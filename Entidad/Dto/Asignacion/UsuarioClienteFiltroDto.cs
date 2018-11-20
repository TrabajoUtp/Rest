using System;
using Entidad.Vo;

namespace Entidad.Dto.Asignacion
{
    public class UsuarioClienteFiltroDto : DataTableNet
    {
        public Int32 IdUsuarioCliente { get; set; }
        public String Buscar { get; set; }
        public Int32 IdEstado { get; set; }
        public Int32 IdUsuario { get; set; }
        public Int32 IdCliente { get; set; }
        public String ListaIdClientes { get; set; }

        public UsuarioClienteFiltroDto()
        {
            ListaIdClientes = String.Empty;
        }
    }
}
