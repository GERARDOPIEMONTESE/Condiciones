using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace Backend.Interfaces
{
    public interface ICopiable<T> where T : ObjetoPersistido
    {
        T Copiar();
    }
}
