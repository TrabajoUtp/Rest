using System;
using System.Collections.Generic;
using Datos.Seguridad;
using Entidad.Dto.Seguridad;
using Entidad.Entidades.Seguridad;
using Entidad.Vo;

namespace Negocio.Seguridad
{
    public class LnRol
    {
        private readonly AdRol _adRol = new AdRol();

        public List<RolDto> Obtener(RolFiltro filtro)
        {
            return _adRol.Obtener(filtro);
        }

        public RolDto ObtenerPorId(int idRol)
        {
            return _adRol.ObtenerPorId(idRol);
        }

        public Int32 Registrar(Rol rol)
        {
            var result = new Result();
            return _adRol.Registrar(rol);
        }

        public Int32 Modificar(Rol rol)
        {
            return _adRol.Modificar(rol);
        }

    }
}
