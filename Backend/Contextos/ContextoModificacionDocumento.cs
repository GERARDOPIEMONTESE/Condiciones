using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Contextos
{
    public class ContextoModificacionDocumento
    {
        #region Atributos

        private int _IdTipoDocumento;

        private int _IdDocumento;

        #endregion

        #region Propiedades

        public int IdTipoDocumento
        {
            get
            {
                return _IdTipoDocumento;
            }
            set
            {
                _IdTipoDocumento = value;
            }
        }

        public int IdDocumento
        {
            get
            {
                return _IdDocumento;
            }
            set
            {
                _IdDocumento = value;
            }
        }

        #endregion

        public ContextoModificacionDocumento(int pIdTipoDocumento, int pIdDocumento)
        {
            IdTipoDocumento = pIdTipoDocumento;
            IdDocumento = pIdDocumento;
        }
    }
}
