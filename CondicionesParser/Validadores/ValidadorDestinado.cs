using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondicionesParser.Validadores
{
    public class ValidadorDestinado : AbstractValidator
    {
        private string _Destinado = "|ACCIDENTES|ENFERMEDAD|ENFERMEDADES|REPATRIACIONES";

        protected override void ValidarTipoDato(string Dato, string Ubicacion)
        {
            if (!_Destinado.ToUpper().Contains(Dato.ToUpper()))
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
