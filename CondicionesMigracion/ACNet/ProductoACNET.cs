using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace CondicionesMigracion.ACNet
{
    public class ProductoACNET : ObjetoCodificado
    {
        private const string NOMBRE = "ICARD.PRODUCTOS";

        #region Atributos

        private int _Pais;

        private int _Tipo;

        #endregion

        #region Propiedades

        public int Pais
        {
            get
            {
                return _Pais;
            }
            set
            {
                _Pais = value;
            }
        }

        public int Tipo
        {
            get
            {
                return _Tipo;
            }
            set
            {
                _Tipo = value;
            }
        }

        #endregion

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
