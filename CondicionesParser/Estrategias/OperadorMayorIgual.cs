using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondicionesParser.Estrategias
{
    public class OperadorMayorIgual<T> : IEstrategiaOperador<T>
        where T : IComparable
    {
        protected override bool RealizarEvaluacion(IList<T> Operandos)
        {
            T OperandoIzquierdo = Operandos[0];
            T OperandoDerecho = Operandos[1];

            return OperandoIzquierdo.CompareTo(OperandoDerecho) >= 0;
        }
    }
}
