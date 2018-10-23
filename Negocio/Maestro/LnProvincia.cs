using System;
using System.Collections.Generic;
using Datos.Maestro;
using Entidad.Entidades.Maestro;
using Entidad.Vo;

namespace Negocio.Maestro
{
    public class LnProvincia
    {
        private readonly AdProvincia _adProvincia = new AdProvincia();

        public List<Provincia> ObtenerCombo(Int32 idDepartamento, DropDownItem opcionCombo)
        {
            var lista = _adProvincia.ObtenerCombo(idDepartamento);
            switch (opcionCombo)
            {
                case DropDownItem.Ninguno:
                    lista.Insert(0, new Provincia { IdProvincia = 0, Nombre = "Ninguno" });
                    break;
                case DropDownItem.Seleccione:
                    lista.Insert(0, new Provincia { IdProvincia = 0, Nombre = "Seleccione" });
                    break;
                case DropDownItem.Todos:
                    lista.Insert(0, new Provincia { IdProvincia = 0, Nombre = "Todos" });
                    break;
            }
            return lista;
        }
    }
}
