using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondicionesParser.Estrategias
{
    public class OperadorLogicoAnd : IOperadorLogico
    {
        private const string CODIGO = "Y";

        #region IOperadorLogico Members

        public string Codigo()
        {
            return CODIGO; ;
        }

        public bool Ejecutar(IList<bool> Operandos)
        {
            bool Resultado = true;

            foreach(bool Valor in Operandos)
            {
                Resultado = Resultado && Valor;
            }

            return Resultado;
        }

        #endregion
    }
}
