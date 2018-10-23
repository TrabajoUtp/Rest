using System.Collections.Generic;
using Datos.Maestro;
using Entidad.Entidades.Maestro;
using Entidad.Vo;

namespace Negocio.Maestro
{
    public class LnPais
    {
        private readonly AdPais _adPais = new AdPais();

        public List<Pais> ObtenerCombo(DropDownItem opcionCombo)
        {
            var lista = _adPais.ObtenerCombo();
            switch (opcionCombo)
            {
                case DropDownItem.Ninguno:
                    lista.Insert(0, new Pais { IdPais = 0, Nombre = "Ninguno" });
                    break;
                case DropDownItem.Seleccione:
                    lista.Insert(0, new Pais {IdPais = 0, Nombre = "Seleccione"});
                    break;
                case DropDownItem.Todos:
                    lista.Insert(0, new Pais {IdPais = 0, Nombre = "Todos"});
                    break;
            }
            return lista;
        }
    }
}
