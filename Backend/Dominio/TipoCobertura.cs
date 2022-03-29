using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace Backend.Dominio
{
    public class TipoCobertura : ObjetoCodificado
    {
        private const string NOMBRE = "TipoCobertura";

        public const string NO_APLICA = "NO";

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
