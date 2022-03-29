using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace Backend.Dominio
{
    public class TipoContenidoImpresion : ObjetoCodificado
    {
        private const string NOMBRE = "TipoContenidoImpresion";

        public const string COMPLETO = "FULL";

        public const string DESC_CONT = "DESCONT";

        public const string CONTENIDO = "CONT";

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
