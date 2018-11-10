using System;
using System.Collections.Generic;

namespace Entidad.Dto.Seguridad
{
    public class AccesoRolPadreDto
    {
        public Int64 IdAccesoLlave { get; set; }
        public String NombreAccesoPadre { get; set; }
        public String DescripcionPadre { get; set; }
        public String IconoPadre { get; set; }
        public Int32 OrdenPadre { get; set; }
        public String TipoPadre { get; set; }

        public List<AccesoRolHijoDto> ListaEnlaces { get; set; }

    }
}
