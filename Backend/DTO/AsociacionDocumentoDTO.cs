using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.DTO
{
    public class AsociacionDocumentoDTO
    {
     

        #region Propiedades

        public int Id {get;set;}
        public string TipoAsociacionDocumento {get;set;}
        public string NombreDocumento {get;set;}
        public string NombreObjeto{get;set;}
    
        #endregion
    }
}
