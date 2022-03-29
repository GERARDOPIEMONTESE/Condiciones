using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace Backend.Dominio
{
    public class ValidezTerritorialClausula : ObjetoCodificado
    {
        private const string NOMBRE = "ValidezTerritorialClausula";

        public const string NACIONAL = "NA";

        public const string INTERNACIONAL = "IN";
        
        public const string INTERNACIONAL_RECEPTIVO = "RE";

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
