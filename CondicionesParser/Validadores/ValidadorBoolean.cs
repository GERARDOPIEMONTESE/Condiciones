using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondicionesParser.Validadores
{
    public class ValidadorBoolean : AbstractValidator
    {
        protected override void ValidarTipoDato(string Dato, string Ubicacion)
        {
            ValidarBoolean(Dato);
        }

        protected override string Unidades()
        {
            return null;
        }
    }
}
