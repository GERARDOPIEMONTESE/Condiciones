using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace Backend.Dominio
{
    public class ValidezTerritorial : ObjetoCodificado
    {
        private const string NOMBRE = "Locacion";

        public const string TIPO_LOCACION = "Validez Territorial";
        
        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
