using System;

namespace Entidad.Dto.Seguridad
{
    public class AccesoRolHijoDto
    {
        public Int64 IdAccesoLlave { get; set; }
        public String NombreAccesoHijo { get; set; }
        public String DescripcionHijo { get; set; }
        public String UrlHijo { get; set; }
        public String IconoHijo { get; set; }
        public Int32 OrdenHijo { get; set; }
        public String TipoHijo { get; set; }
    }
}
