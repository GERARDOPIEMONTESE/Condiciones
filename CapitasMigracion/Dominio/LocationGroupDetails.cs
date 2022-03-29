using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace CapitasMigracion.Dominio
{
    public class LocationGroupDetails : ObjetoPersistido
    {
        private const string NOMBRE = "ACLocationGroupDetails";

        #region Atributos

        private int _IdLocationGroup;

        private int _CountryCode;

        #endregion

        #region Propiedades

        public int IdLocationGroup
        {
            get
            {
                return _IdLocationGroup;
            }
            set
            {
                _IdLocationGroup = value;
            }
        }

        public int CountryCode
        {
            get
            {
                return _CountryCode;
            }
            set
            {
                _CountryCode = value;
            }
        }

        #endregion

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
