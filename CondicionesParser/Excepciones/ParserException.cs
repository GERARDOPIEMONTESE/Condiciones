using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondicionesParser.Excepciones
{
    public class ParserException : Exception
    {
        public ParserException()
            : base()
        {
        }

        public ParserException(string Mensaje)
            : base(Mensaje)
        {
        }

        public ParserException(string Mensaje, Exception Excepcion)
            : base(Mensaje, Excepcion)
        {
        }
    }
}
