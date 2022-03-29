using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondicionesParser.Parametros
{
    public interface ITipoParametro
    {
        bool Resolver(string Operador, 
            object OperandoIzquierdo, object OperandoDerecho);

        void SetearCodigo(string Codigo);
    }
}
