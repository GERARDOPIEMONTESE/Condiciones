using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;

namespace Backend.DTO
{
    public class TarifaDTO
    {
   

        #region Propiedades

        public Tarifa Tarifa {get; set;}
        public string Codigo {get; set;}
        public string Nombre {get; set;}
        public string Sufijo {get; set;}

        #endregion

        public TarifaDTO(Tarifa pTarifa)
        {
            Tarifa = pTarifa;
            Codigo = pTarifa.Codigo;
            Nombre = pTarifa.Nombre;
            Sufijo = pTarifa.Sufijo;
        }

        public TarifaDTO(string pCodigo, string pNombre, string pSufijo)
        {
            Codigo = pCodigo;
            Nombre = pNombre;
            Sufijo = pSufijo;
        }
    }
}
