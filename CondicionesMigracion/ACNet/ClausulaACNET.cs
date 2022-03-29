using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace CondicionesMigracion.ACNet
{
    public class ClausulaACNET : ObjetoPersistido
    {
        private const string NOMBRE = "ICARD.CLAUSULAS";

        #region Atributos

        private string _IdClausula;

        private int _IdIdioma;

        private string _Titulo;

        #endregion

        #region Propiedades

        public string IdClausula
        {
            get
            {
                return _IdClausula;
            }
            set
            {
                _IdClausula = value;
            }
        }

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

        public string Titulo
        {
            get
            {
                return _Titulo;
            }
            set
            {
                _Titulo = value;
            }
        }

        #endregion

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
