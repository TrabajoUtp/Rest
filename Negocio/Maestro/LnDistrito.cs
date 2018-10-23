﻿using System;
using System.Collections.Generic;
using Datos.Maestro;
using Entidad.Entidades.Maestro;
using Entidad.Vo;

namespace Negocio.Maestro
{
    public class LnDistrito
    {
        private readonly AdDistrito _adDistrito = new AdDistrito();

        public List<Distrito> ObtenerCombo(Int32 idProvincia, DropDownItem opcionCombo)
        {
            var lista = _adDistrito.ObtenerCombo(idProvincia);
            switch (opcionCombo)
            {
                case DropDownItem.Ninguno:
                    lista.Insert(0, new Distrito { IdDistrito = 0, Nombre = "Ninguno" });
                    break;
                case DropDownItem.Seleccione:
                    lista.Insert(0, new Distrito { IdDistrito = 0, Nombre = "Seleccione" });
                    break;
                case DropDownItem.Todos:
                    lista.Insert(0, new Distrito { IdDistrito = 0, Nombre = "Todos" });
                    break;
            }
            return lista;
        }
    }
}