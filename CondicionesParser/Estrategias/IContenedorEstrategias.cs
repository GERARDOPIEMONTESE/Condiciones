using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondicionesParser.Estrategias
{
    public interface IContenedorEstrategias
    {
        bool Evaluar<T>(string Operador, IList<T> Operandos);
    }
}
