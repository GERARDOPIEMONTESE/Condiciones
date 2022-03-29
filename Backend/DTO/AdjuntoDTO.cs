using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.DTO
{
    public class AdjuntoDTO
    {
      
        #region Constructores

        public AdjuntoDTO()
        {
        }

        public AdjuntoDTO(int pIdTipoDocumento, int pIdDocumento)
        {
            IdTipoDocumento = pIdTipoDocumento;
            IdDocumento = pIdDocumento;
        }

        #endregion

        #region Propiedades

        public int IdTipoDocumento {get; set;}
        
        public int IdDocumento{get; set;}
        

        #endregion

    }
}
