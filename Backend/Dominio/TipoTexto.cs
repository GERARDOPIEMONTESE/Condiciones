using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace Backend.Dominio
{
    public class TipoTexto : ObjetoCodificado
    {
        private const string NOMBRE = "TipoTexto";

        public const string RESUMEN_BENEFICIOS = "Resumen Beneficios";

        public const string CLAUSULAS = "Clausulas";

        public const string CODIGO_RESUMEN_BENEFICIOS = "RESUMEN";

        public const string CODIGO_CLAUSULAS = "CLAUSULAS";

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
