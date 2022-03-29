using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace CondicionesMigracion.ACNet
{
    public class UnidadMedicion : ObjetoCodificado
    {
        private const string NOMBRE = "ICARD.UNIDAD_MEDICION";

        #region Atributos

        private string _Nomenclatura;

        #endregion

        #region Propiedades

        public string Nomenclatura
        {
            get
            {
                return _Nomenclatura;
            }
            set
            {
                _Nomenclatura = value;
            }
        }

        #endregion

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
