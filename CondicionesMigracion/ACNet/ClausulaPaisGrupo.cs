using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace CondicionesMigracion.ACNet
{
    public class ClausulaPaisGrupo : ObjetoCodificado
    {
        private const string NOMBRE = "ICARD.CLAUSULA_PAIS_GRUPO";

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
