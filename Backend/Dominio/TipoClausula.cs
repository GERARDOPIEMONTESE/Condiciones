using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;
using Backend.Datos;

namespace Backend.Dominio
{
    public class TipoClausula : ObjetoCodificado
    {
        #region Constantes

        private const string NOMBRE = "TipoClausula";

        public const string SERVICIO = "SERV";

        public const string SEGURO = "SEGU";

        public const string GENERAL = "GRAL";

        public const string GENERAL_EKIT = "EKIT";

        public const string GENERAL_NO_EKIT = "NOEKIT";

        #endregion

        #region Metodos Redefinidos

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }

        #endregion

    }
}
