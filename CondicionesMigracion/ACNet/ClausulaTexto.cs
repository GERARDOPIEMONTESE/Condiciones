using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace CondicionesMigracion.ACNet
{
    public class ClausulaTexto : ObjetoPersistido
    {
        private const string NOMBRE = "ICARD.CLAUSULA_TEXTOS";

        #region Atributos

        private string _Descripcion;

        #endregion

        #region Propiedades

        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }
            set
            {
                _Descripcion = value;
            }
        }

        #endregion

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
