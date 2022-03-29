using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace Backend.Dominio
{
    public class TipoTextoResumen : ObjetoCodificado
    {
        private const string NOMBRE = "TipoTextoResumen";

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
