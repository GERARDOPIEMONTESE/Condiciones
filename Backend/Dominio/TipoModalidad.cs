using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace Backend.Dominio
{
    public class TipoModalidad : ObjetoCodificado
    {
        private const string NOMBRE = "TipoModalidad";

        public const string NO_APLICA = "NA";

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
