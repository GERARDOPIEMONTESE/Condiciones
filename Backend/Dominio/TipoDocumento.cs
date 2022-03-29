using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Backend.Datos;
using FrameworkDAC.Negocio;
using Backend.Interfaces;

namespace Backend.Dominio
{
    public class TipoDocumento : ObjetoCodificado
    {
        #region Constantes

        private const string NOMBRE = "TipoDocumento";

        public const int CONDICIONES_GENERALES = 1;

        public const int CONDICIONES_PARTICULARES = 2;

        #endregion

        #region Metodos Redefinidos

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }

        #endregion
    }
}
