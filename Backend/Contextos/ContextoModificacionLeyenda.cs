using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Contextos
{
    public class ContextoModificacionLeyenda
    {
        #region Atributos

        private int _IdIdioma;

        private string _Texto;

        #endregion

        #region Propiedades

        public int IdIdioma
        {
            get
            {
                return _IdIdioma;
            }
            set
            {
                _IdIdioma = value;
            }
        }

        public string Texto
        {
            get
            {
                return _Texto;
            }
            set
            {
                _Texto = value;
            }
        }

        #endregion

        public ContextoModificacionLeyenda(int pIdIdioma, string pTexto)
        {
            IdIdioma = pIdIdioma;
            Texto = pTexto;
        }
    
    }
}
