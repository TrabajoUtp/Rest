using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Datos.Helper;
using Entidad.Dto.Maestro;
using Entidad.Vo;

namespace Datos.Maestro
{
    public class AdUbigeo
    {
        public List<DepartamentoDto> ObtenerCombo(Int32 idPais)
        {

            List<DepartamentoDto> lista;
            const string query = StoreProcedure.Maestro_usp_Ubigeo_Combo;

            using (var cn = HelperClass.ObtenerConeccion())
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                DynamicParameters paramet = new DynamicParameters();
                paramet.Add("@IdPais", idPais);

                var dictionary = new Dictionary<string, DepartamentoDto>();

                

                lista = cn.Query<DepartamentoDto, UbigeoDto, DepartamentoDto>(
                        query,

                        (cabecera, detalle) =>
                        {
                            DepartamentoDto registroCabecera;

                            if (!dictionary.TryGetValue(cabecera.CodigoDepartamento, out registroCabecera))
                            {
                                registroCabecera = cabecera;
                                registroCabecera.ListaUbigeo = new List<UbigeoDto>();
                                dictionary.Add(registroCabecera.CodigoDepartamento, registroCabecera);
                            }

                            registroCabecera.ListaUbigeo.Add(detalle);
                            return registroCabecera;
                        },
                        splitOn: "IdUbigeo",
                        commandType: CommandType.StoredProcedure,
                        param: paramet
                        )
                    .Distinct()
                    .ToList();

            }
            return lista;
        }
    }
}
