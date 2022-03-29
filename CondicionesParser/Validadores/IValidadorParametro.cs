using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondicionesParser.Validadores
{
    public interface IValidadorParametro
    {
        void ValidarFormato(string Condicion, string Ubicacion);
    }
}
