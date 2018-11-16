using System;
using System.Collections.Generic;
using System.Linq;
using Datos.Maestro;
using Entidad.Dto.Maestro;
using Entidad.Entidades.Maestro;
using Entidad.Vo;

namespace Negocio.Maestro
{
    public class LnEstado
    {
        private readonly AdEstado _adEstado = new AdEstado();

        public ResultDataTable Obtener(EstadoFiltroDto filtro)
        {
            ResultDataTable result;
            int totalRegistros = 0;
            List<EstadoDto> lista = new List<EstadoDto>();
            string mensajeError = "";

            try
            {
                lista = _adEstado.Obtener(filtro);
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

        public List<EstadoComboDto> ObtenerCombo(Int32 idTipoEstado, DropDownItem opcionCombo)
        {
            var lista = _adEstado.ObtenerCombo(idTipoEstado);
            switch (opcionCombo)
            {
                case DropDownItem.Ninguno:
                    lista.Insert(0, new EstadoComboDto { IdEstado = 0, Nombre = "Ninguno" });
                    break;
                case DropDownItem.Seleccione:
                    lista.Insert(0, new EstadoComboDto { IdEstado = 0, Nombre = "Seleccione" });
                    break;
                case DropDownItem.Todos:
                    lista.Insert(0, new EstadoComboDto { IdEstado = 0, Nombre = "Todos" });
                    break;
            }
            return lista;

        }

        public List<EstadoComboDto> ObtenerComboConExcepcion(Int32 idTipoEstado, DropDownItem opcionCombo, String idsaExcluir)
        {
            var lista = _adEstado.ObtenerCombo(idTipoEstado);

            try
            {
                if (lista.Any())
                {
                    if (!String.IsNullOrEmpty(idsaExcluir))
                    {
                        //Remover los registros de la variable idsaExcluir
                        List<int> listaIdEstadoExcluir = idsaExcluir.Split(',').Select(int.Parse).ToList();
                        if (listaIdEstadoExcluir.Any())
                        {
                            foreach (int idaBuscar in listaIdEstadoExcluir)
                            {
                                for (int i = lista.Count - 1; i >= 0; i--)
                                {
                                    if (lista[i].IdEstado == idaBuscar)
                                    {
                                        lista.RemoveAt(i);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch { }


            switch (opcionCombo)
            {
                case DropDownItem.Ninguno:
                    lista.Insert(0, new EstadoComboDto { IdEstado = 0, Nombre = "Ninguno" });
                    break;
                case DropDownItem.Seleccione:
                    lista.Insert(0, new EstadoComboDto { IdEstado = 0, Nombre = "Seleccione" });
                    break;
                case DropDownItem.Todos:
                    lista.Insert(0, new EstadoComboDto { IdEstado = 0, Nombre = "Todos" });
                    break;
            }
            return lista;

        }

        public List<EstadoComboDto> ObtenerComboPorId(Int32 idTipoEstado, DropDownItem opcionCombo, String idsaIncluir)
        {
            var lista = new List<EstadoComboDto>();

            if (!String.IsNullOrEmpty(idsaIncluir))
            {
                lista = _adEstado.ObtenerCombo(idTipoEstado);
            }
            

            try
            {
                if (lista.Any())
                {
                    if (!String.IsNullOrEmpty(idsaIncluir))
                    {
                        //Solo considerar los registros de la variable idsaIncluir
                        List<int> listaIdEstadoIncluir = idsaIncluir.Split(',').Select(int.Parse).ToList();
                        if (listaIdEstadoIncluir.Any())
                        {

                            for (int i = lista.Count - 1; i >= 0; i--)
                            {
                                Boolean existeRegistro = false;
                                foreach (int idaBuscar in listaIdEstadoIncluir)
                                {
                                    if (idaBuscar == lista[i].IdEstado)
                                    {
                                        //Si lo encontro
                                        existeRegistro = true;
                                        break;
                                    }
                                }

                                if (!existeRegistro)
                                {
                                    lista.RemoveAt(i);
                                }

                            }

                        }
                    }
                }
            }
            catch { }


            switch (opcionCombo)
            {
                case DropDownItem.Ninguno:
                    lista.Insert(0, new EstadoComboDto { IdEstado = 0, Nombre = "Ninguno" });
                    break;
                case DropDownItem.Seleccione:
                    lista.Insert(0, new EstadoComboDto { IdEstado = 0, Nombre = "Seleccione" });
                    break;
                case DropDownItem.Todos:
                    lista.Insert(0, new EstadoComboDto { IdEstado = 0, Nombre = "Todos" });
                    break;
            }
            return lista;

        }

        public Estado ObtenerPorId(int id)
        {
            return _adEstado.ObtenerPorId(id);
        }

        public Int32 Registrar(Estado entidad)
        {
            return _adEstado.Registrar(entidad);
        }

        public Int32 Modificar(Estado entidad)
        {
            return _adEstado.Modificar(entidad);
        }

        public Int32 Eliminar(Int32 id)
        {
            return _adEstado.Eliminar(id);
        }
    }
}
