﻿using System;

namespace Entidad.Entidades.Maestro
{
    public class Contacto
    {
        public Int32 IdContacto { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Correo { get; set; }
        public String Telefono { get; set; }
        public Int32 IdCliente { get; set; }
        public Int32 IdEstado { get; set; }

    }
}
