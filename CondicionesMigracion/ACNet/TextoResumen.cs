using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace CondicionesMigracion.ACNet
{
    public class TextoResumen : ObjetoCodificado
    {
        private const string NOMBRE = "CLAUSULA_TEXTO_VOUCHER";

        #region Atributos

        private string _Texto;

        #endregion

        #region Propiedades

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

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
