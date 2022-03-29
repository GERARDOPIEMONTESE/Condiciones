using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondicionesParser.Validadores
{
    public class ValidadorPeso : AbstractValidator
    {
        private string _Unidades = "|KG|";

        protected override void ValidarTipoDato(string Dato, string Ubicacion)
        {
            ValidarFloat(Dato);
        }

        protected override string Unidades()
        {
            return _Unidades;
        }
    }
}
