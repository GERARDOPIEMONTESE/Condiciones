using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace Backend.Dominio
{
    public class TipoDestino : ObjetoCodificado
    {
        private const string NOMBRE = "TipoDestino";

        public const string NO_APLICA = "No Aplica";

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
