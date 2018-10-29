using System;
using System.Collections.Generic;
using Datos.Maestro;
using Entidad.Dto.Maestro;
using Entidad.Entidades.Maestro;
using Entidad.Vo;

namespace Negocio.Maestro
{
    public class LnCategoriaFaq
    {
        private readonly AdCategoriaFaq _adCategoriaFaq = new AdCategoriaFaq();

        public List<CategoriaFaqDto> Obtener(CategoriaFaqFiltro filtro)
        {
            return _adCategoriaFaq.Obtener(filtro);
        }

        public List<CategoriaFaq> ObtenerCombo(DropDownItem opcionCombo, Int32 idEstado)
        {
            var lista = _adCategoriaFaq.ObtenerCombo(idEstado);
            switch (opcionCombo)
            {
                case DropDownItem.Ninguno:
                    lista.Insert(0, new CategoriaFaq { IdCategoriaFaq = 0, Nombre = "Ninguno" });
                    break;
                case DropDownItem.Seleccione:
                    lista.Insert(0, new CategoriaFaq { IdCategoriaFaq = 0, Nombre = "Seleccione" });
                    break;
                case DropDownItem.Todos:
                    lista.Insert(0, new CategoriaFaq { IdCategoriaFaq = 0, Nombre = "Todos" });
                    break;
            }
            return lista;
        }

        public CategoriaFaq ObtenerPorId(int idCategoriaFaq)
        {
            return _adCategoriaFaq.ObtenerPorId(idCategoriaFaq);
        }

        public Int32 Registrar(CategoriaFaq categoriaFaq)
        {
            return _adCategoriaFaq.Registrar(categoriaFaq);
        }

        public Int32 Modificar(CategoriaFaq categoriaFaq)
        {
            return _adCategoriaFaq.Modificar(categoriaFaq);
        }

        public Int32 Eliminar(Int32 idCategoriaFaq)
        {
            return _adCategoriaFaq.Eliminar(idCategoriaFaq);
        }
    }
}
