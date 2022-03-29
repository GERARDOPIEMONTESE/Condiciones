using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.DTO
{
    public class GrupoCondicionesDTO
    {
        #region Atributos

        private string _CodigoClausula;

        //Depende del idioma del usuario logueado.
        private string _TituloClausula;

        private IList<GrupoCondicionesRangoDTO> _Rangos = 
            new List<GrupoCondicionesRangoDTO>();

        #endregion

        #region Propiedades

        public string CodigoClausula
        {
            get
            {
                return _CodigoClausula;
            }
            set
            {
                _CodigoClausula = value;
            }
        }

        public string TituloClausula
        {
            get
            {
                return _TituloClausula;
            }
            set
            {
                _TituloClausula = value;
            }
        }

        public IList<GrupoCondicionesRangoDTO> Rangos
        {
            get
            {
                return _Rangos;
            }
            set
            {
                _Rangos = value;
            }
        }

        #endregion
    }
}
