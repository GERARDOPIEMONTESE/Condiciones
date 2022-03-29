using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondicionesParser.Validadores
{
    public class ValidadorRubro : AbstractValidator
    {
        private string _Unidades = "|Internacional|Nacional|";

        protected override void ValidarTipoDato(string Dato, string Ubicacion)
        {
            if (!_Unidades.ToUpper().Contains(Dato.ToUpper()))
            {
                throw new Excepciones.ParserException(
                    "Valor " + Dato + " indefinido para parametro Rubro");
            }
        }

        protected override string Unidades()
        {
            return null;
        }
    }
}
