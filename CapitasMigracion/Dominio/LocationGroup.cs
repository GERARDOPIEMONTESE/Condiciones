using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace CapitasMigracion.Dominio
{
    public class LocationGroup : ObjetoCodificado
    {
        private const string NOMBRE = "ACLocationGroup";

        #region Atributos

        private bool _IncludeNational;

        private IList<LocationGroupDetails> _Details = new List<LocationGroupDetails>();

        #endregion

        #region Propiedades

        public bool IncludeNational
        {
            get
            {
                return _IncludeNational;
            }
            set
            {
                _IncludeNational = value;
            }
        }

        public IList<LocationGroupDetails> Details
        {
            get
            {
                return _Details;
            }
            set
            {
                _Details = value;
            }
        }

        #endregion

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
