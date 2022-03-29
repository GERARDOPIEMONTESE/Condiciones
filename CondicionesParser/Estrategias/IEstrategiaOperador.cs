using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CondicionesParser.Excepciones;

namespace CondicionesParser.Estrategias
{
    public abstract class IEstrategiaOperador <T> where T : IComparable
    {
        protected abstract bool RealizarEvaluacion(IList<T> Operandos);

        public bool Evaluar(IList<T> Operandos) 
        {
            try
            {
                return RealizarEvaluacion(Operandos);
            }
            catch (Exception e)
            {
                throw new ParserException(e.Message, e);
            }
        }
    }
}
