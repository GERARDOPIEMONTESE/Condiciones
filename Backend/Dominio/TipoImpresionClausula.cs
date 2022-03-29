using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace Backend.Dominio
{
    public class TipoImpresionClausula : ObjetoCodificado
    {
        private const string NOMBRE = "TipoImpresionClausula";

        public const string COMPLETO = "IC";
        
        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
