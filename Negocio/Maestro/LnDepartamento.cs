using System;
using System.Collections.Generic;
using Datos.Maestro;
using Entidad.Entidades.Maestro;
using Entidad.Vo;

namespace Negocio.Maestro
{
    public class LnDepartamento
    {
        private readonly AdDepartamento _adDepartamento = new AdDepartamento();

        public List<Departamento> ObtenerCombo(Int32 idPais, DropDownItem opcionCombo)
        {
            var lista = _adDepartamento.ObtenerCombo(idPais);
            //switch (opcionCombo)
            //{
            //    case DropDownItem.Ninguno:
            //        lista.Insert(0, new Departamento { IdDepartamento = 0, Nombre = "Ninguno" });
            //        break;
            //    case DropDownItem.Seleccione:
            //        lista.Insert(0, new Departamento { IdDepartamento = 0, Nombre = "Seleccione" });
            //        break;
            //    case DropDownItem.Todos:
            //        lista.Insert(0, new Departamento { IdDepartamento = 0, Nombre = "Todos" });
            //        break;
            //}
            return lista;

        }
    }
}
