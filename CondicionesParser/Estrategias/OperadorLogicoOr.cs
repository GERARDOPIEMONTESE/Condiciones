using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondicionesParser.Estrategias
{
    public class OperadorLogicoOr : IOperadorLogico
    {
        private const string CODIGO = "O";

        #region IOperadorLogico Members

        public string Codigo()
        {
            return CODIGO;
        }

        public bool Ejecutar(IList<bool> Operandos)
        {
            bool Resultado = false;

            foreach (bool Valor in Operandos)
            {
                Resultado = Resultado || Valor;
            }

            return Resultado;
        }

        #endregion
    }
}
