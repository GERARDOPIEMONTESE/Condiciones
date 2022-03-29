using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace Backend.Dominio
{
    public class Ayuda : ObjetoCodificado
    {
        private const string NOMBRE = "Ayuda";

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
