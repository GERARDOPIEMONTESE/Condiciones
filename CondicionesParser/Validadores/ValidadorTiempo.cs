using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondicionesParser.Validadores
{
    public class ValidadorTiempo : AbstractValidator
    {
        private string _Unidades = "|HS|DIAS|";

        protected override void ValidarTipoDato(string Dato, string Ubicacion)
        {
            ValidarEntero(Dato);
        }

        protected override string Unidades()
        {
            return _Unidades;
        }
    }
}
