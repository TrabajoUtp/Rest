using System;
using System.Collections.Generic;
using System.Linq;
using Datos.Gestion;
using Entidad.Dto.Gestion;
using Entidad.Entidades.Gestion;
using Entidad.Vo;

namespace Negocio.Gestion
{
    public class LnIncidencia
    {
        private readonly AdIncidencia _adIncidencia = new AdIncidencia();
        private readonly LnIncidenciaDetalle _lnIncidenciaDetalle = new LnIncidenciaDetalle();

        public ResultDataTable Obtener(IncidenciaFiltroDto filtro)
        {
            ResultDataTable result;
            int totalRegistros = 0;
            List<IncidenciaDto> lista = new List<IncidenciaDto>();
            string mensajeError = "";

            try
            {
                lista = _adIncidencia.Obtener(filtro);
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

        public List<Incidencia> ObtenerCombo(DropDownItem opcionCombo, Int32 idEstado)
        {
            var lista = _adIncidencia.ObtenerCombo(idEstado);
            switch (opcionCombo)
            {
                case DropDownItem.Ninguno:
                    lista.Insert(0, new Incidencia { IdIncidencia = 0, Asunto = "Ninguno" });
                    break;
                case DropDownItem.Seleccione:
                    lista.Insert(0, new Incidencia { IdIncidencia = 0, Asunto = "Seleccione" });
                    break;
                case DropDownItem.Todos:
                    lista.Insert(0, new Incidencia { IdIncidencia = 0, Asunto = "Todos" });
                    break;
            }
            return lista;
        }

        public Incidencia ObtenerPorId(int id)
        {
            return _adIncidencia.ObtenerPorId(id);
        }

        public Int32 Registrar(Incidencia entidad)
        {
            Int32 idIncidenciaDetalleResultado = 0;
            Int32 idIncidenciaNuevo = 0;
            Int32 idIncidenciaResultado = _adIncidencia.Registrar(entidad, ref idIncidenciaNuevo);
            if (idIncidenciaResultado > 0 && idIncidenciaNuevo > 0 && entidad.ListaDetalle.Any())
            {
                foreach (IncidenciaDetalle detalle in entidad.ListaDetalle)
                {
                    detalle.IdIncidencia = idIncidenciaNuevo;
                    idIncidenciaDetalleResultado = _lnIncidenciaDetalle.Registrar(detalle);
                }
            }
            return idIncidenciaDetalleResultado;

        }

        public Int32 Modificar(Incidencia entidad)
        {
            return _adIncidencia.Modificar(entidad);
        }

        public Int32 Eliminar(Int32 id)
        {
            return _adIncidencia.Eliminar(id);
        }
    }
}
