using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondicionesParser.Validadores
{
    public class ValidadorGeneral : AbstractValidator
    {
        private string _Unidades = "|USD|$|R$|Euro|Won|Bolívares|Guaraníes|Offset|%|Por Evento|Kg|KG|Percent|Days from Membership's Valid to|";

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
