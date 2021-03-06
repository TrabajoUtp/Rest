﻿using System;
using System.Collections.Generic;
using System.Linq;
using Datos.Maestro;
using Entidad.Dto.Maestro;
using Entidad.Entidades.Maestro;
using Entidad.Vo;

namespace Negocio.Maestro
{
    public class LnContacto
    {
        private readonly AdContacto _adContacto = new AdContacto();

        public ResultDataTable Obtener(ContactoFiltroDto filtro)
        {
            ResultDataTable result;
            int totalRegistros = 0;
            List<ContactoDto> lista = new List<ContactoDto>();
            string mensajeError = "";

            try
            {
                lista = _adContacto.Obtener(filtro);
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

        public List<Contacto> ObtenerCombo(DropDownItem opcionCombo, Int32 idEstado)
        {
            var lista = _adContacto.ObtenerCombo(idEstado);
            switch (opcionCombo)
            {
                case DropDownItem.Ninguno:
                    lista.Insert(0, new Contacto { IdContacto = 0, Nombre = "Ninguno" });
                    break;
                case DropDownItem.Seleccione:
                    lista.Insert(0, new Contacto { IdContacto = 0, Nombre = "Seleccione" });
                    break;
                case DropDownItem.Todos:
                    lista.Insert(0, new Contacto { IdContacto = 0, Nombre = "Todos" });
                    break;
            }
            return lista;
        }

        public Contacto ObtenerPorId(int id)
        {
            return _adContacto.ObtenerPorId(id);
        }

        public Int32 Registrar(Contacto entidad)
        {
            return _adContacto.Registrar(entidad);
        }

        public Int32 Modificar(Contacto entidad)
        {
            return _adContacto.Modificar(entidad);
        }

        public Int32 Eliminar(Int32 id)
        {
            return _adContacto.Eliminar(id);
        }
    }
}
