using System;
using System.Collections.Generic;
using Entidad.Dto.Maestro;

namespace Entidad.Entidades.Maestro
{
    public class Departamento
    {
        public String NombreDepartamento { get; set; }
        public String CodigoDepartamento { get; set; }
        public List<UbigeoDto> ListaUbigeo { get; set; }
    }
}
