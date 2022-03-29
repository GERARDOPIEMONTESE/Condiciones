using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace Backend.Dominio
{
    public class TipoAsociacionDocumento : ObjetoCodificado
    {
        #region Constantes
        
        private const string NOMBRE = "TipoAsociacionDocumento";

        public const string PAIS = "PAIS";

        public const string PRODUCTO = "PROD";

        public const string GRUPO = "GRUP";

        #endregion

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
