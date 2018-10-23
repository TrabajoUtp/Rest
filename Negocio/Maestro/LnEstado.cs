using System;
using System.Collections.Generic;
using Datos.Maestro;
using Entidad.Entidades.Maestro;
using Entidad.Vo;

namespace Negocio.Maestro
{
    public class LnEstado
    {
        private readonly AdEstado _adEstado = new AdEstado();

        public List<Estado> GetCombo(Int32 idTipoEstado, DropDownItem opcionCombo)
        {
            var lista = _adEstado.ObtenerPorTipoEstado(idTipoEstado);
            switch (opcionCombo)
            {
                case DropDownItem.Ninguno:
                    lista.Insert(0, new Estado { IdEstado = 0, Nombre = "Ninguno" });
                    break;
                case DropDownItem.Seleccione:
                    lista.Insert(0, new Estado { IdEstado = 0, Nombre = "Seleccione" });
                    break;
                case DropDownItem.Todos:
                    lista.Insert(0, new Estado { IdEstado = 0, Nombre = "Todos" });
                    break;
            }
            return lista;

        }
    }
}
