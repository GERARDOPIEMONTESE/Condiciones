using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondicionesParser.Estrategias
{
    public interface IOperadorLogico
    {
        string Codigo();

        bool Ejecutar(IList<bool> Operandos);
    }
}
