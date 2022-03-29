using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.DTO
{
    public class TipoEntidadDTO
    {
      
        #region Propiedades

        public string Codigo {get;set;}
        public string Clase {get;set;}
       
        #endregion

        public TipoEntidadDTO()
        {
        }

        public TipoEntidadDTO(string pCodigo, string pClase)
        {
            this.Codigo = pCodigo;
            this.Clase = pClase;
        }
    }
}
