using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace CapitasMigracion.Dominio
{
    public class LimitCategories : ObjetoCodificado
    {
        private const string NOMBRE = "ACCaseLimitCategories";

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
