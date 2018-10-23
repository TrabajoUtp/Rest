using System;
using System.Collections.Generic;

namespace Entidad.Dto.Maestro
{
    public class DepartamentoDto
    {
        public String CodigoDepartamento { get; set; }
        public String NombreDepartamento { get; set; }
        public List<UbigeoDto> ListaUbigeo { get; set; }
    }
}
