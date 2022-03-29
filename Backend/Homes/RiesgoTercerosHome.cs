using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Datos;
using Backend.Dominio;

namespace Backend.Homes
{
    public class RiesgoTercerosHome
    {
        public static IList<RiesgoTerceros> Buscar(int Idpais, string TipoNegocio, int? IdCompaniaSeguro)
        {
            return DAORiesgoTerceros.Instancia().Buscar(Idpais, TipoNegocio, IdCompaniaSeguro);
        }
        public static RiesgoTerceros Obtener(int Id)
        {
            return DAORiesgoTerceros.Instancia().Obtener(Id);
        }
        public static RiesgoTerceros SearchByIdCompania(int Id)
        {
            return DAORiesgoTerceros.Instancia().SearchByIdCompania(Id);
        }

    }
}
