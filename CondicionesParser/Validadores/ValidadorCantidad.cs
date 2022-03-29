using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondicionesParser.Validadores
{
    public class ValidadorCantidad : AbstractValidator
    {
        protected override void ValidarTipoDato(string Dato, string Ubicacion)
        {
            ValidarEntero(Dato);
        }

        protected override string Unidades()
        {
            return null;
        }
    }
}
