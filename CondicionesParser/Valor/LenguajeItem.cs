using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondicionesParser.Valor
{
    public class LenguajeItem <T>
    {
        #region Atributos
        
        private string _TipoValor;

        private T _Valor;

        #endregion

        #region Propiedades

        public string TipoValor
        {
            get
            {
                return _TipoValor;
            }
            set
            {
                _TipoValor = value;
            }
        }

        public T Valor
        {
            get
            {
                return _Valor;
            }
            set
            {
                _Valor = value;
            }
        }

        #endregion
    }
}
