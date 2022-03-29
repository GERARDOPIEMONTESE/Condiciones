using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondicionesParser.Validadores
{
    public class ValidadorPorcentaje : AbstractValidator
    {
        protected override void ValidarTipoDato(string Dato, string Ubicacion)
        {
            ValidarFloat(Dato);

            double Valor = Convert.ToDouble(Dato);
            if (Valor < 0 || Valor > 100)
            {
                throw new Excepciones.ParserException("Porcentaje Invalido: " + Dato);
            }
        }

        protected override string Unidades()
        {
            return null;
        }
    }
}