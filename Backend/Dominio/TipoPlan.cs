using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace Backend.Dominio
{
    public class TipoPlan : ObjetoCodificado
    {
        private const string NOMBRE = "TipoPlan";

        public const string CODIGO_TODOS = "ALL";

        public const string PLAN_FAMILIAR = "PF";

        public const string PLAN_INDIVIDUAL = "PI";

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
