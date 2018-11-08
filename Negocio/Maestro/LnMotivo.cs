using System;
using System.Collections.Generic;
using System.Linq;
using Datos.Maestro;
using Entidad.Dto.Maestro;
using Entidad.Entidades.Maestro;
using Entidad.Vo;

namespace Negocio.Maestro
{
    public class LnMotivo
    {
        private readonly AdMotivo _adMotivo = new AdMotivo();

        public ResultDataTable Obtener(MotivoFiltroDto filtro)
        {
            ResultDataTable result;
            int totalRegistros = 0;
            List<MotivoDto> lista = new List<MotivoDto>();
            string mensajeError = "";

            try
            {
                lista = _adMotivo.Obtener(filtro);
                if (lista.Any())
                {
                    totalRegistros = lista.First().TotalItems;
                }
            }
            catch (Exception ex)
            {
                mensajeError = ex.Message;
            }
            finally
            {
                result = new ResultDataTable
                {
                    draw = filtro.Draw,
                    recordsTotal = totalRegistros,
                    recordsFiltered = totalRegistros,
                    data = lista,
                    error = mensajeError
                };

            }

            return result;

        }

        public List<Motivo> ObtenerCombo(DropDownItem opcionCombo, Int32 idEstado)
        {
            var lista = _adMotivo.ObtenerCombo(idEstado);
            switch (opcionCombo)
            {
                case DropDownItem.Ninguno:
                    lista.Insert(0, new Motivo { IdMotivo = 0, Nombre = "Ninguno" });
                    break;
                case DropDownItem.Seleccione:
                    lista.Insert(0, new Motivo { IdMotivo = 0, Nombre = "Seleccione" });
                    break;
                case DropDownItem.Todos:
                    lista.Insert(0, new Motivo { IdMotivo = 0, Nombre = "Todos" });
                    break;
            }
            return lista;
        }

        public Motivo ObtenerPorId(int id)
        {
            return _adMotivo.ObtenerPorId(id);
        }

        public Int32 Registrar(Motivo entidad)
        {
            return _adMotivo.Registrar(entidad);
        }

        public Int32 Modificar(Motivo entidad)
        {
            return _adMotivo.Modificar(entidad);
        }

        public Int32 Eliminar(Int32 id)
        {
            return _adMotivo.Eliminar(id);
        }
    }
}
