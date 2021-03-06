﻿using System;
using System.Collections.Generic;
using Datos.Maestro;
using Entidad.Dto.Maestro;
using Entidad.Vo;

namespace Negocio.Maestro
{
    public class LnUbigeo
    {
        private readonly AdUbigeo _adDepartamento = new AdUbigeo();

        public List<DepartamentoDto> ObtenerCombo(Int32 idPais, DropDownItem opcionCombo)
        {
            var lista = _adDepartamento.ObtenerCombo(idPais);
            switch (opcionCombo)
            {
                case DropDownItem.Ninguno:
                    lista.Insert(0, new DepartamentoDto { CodigoDepartamento = "00", NombreDepartamento = "Ninguno", ListaUbigeo = new List<UbigeoDto>() });
                    break;
                case DropDownItem.Seleccione:
                    lista.Insert(0, new DepartamentoDto { CodigoDepartamento = "00", NombreDepartamento = "Seleccione", ListaUbigeo = new List<UbigeoDto>() });
                    break;
                case DropDownItem.Todos:
                    lista.Insert(0, new DepartamentoDto { CodigoDepartamento = "00", NombreDepartamento = "Todos", ListaUbigeo = new List<UbigeoDto>() });
                    break;
            }
            return lista;

        }
    }
}
