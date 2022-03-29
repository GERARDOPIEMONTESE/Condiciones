using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Backend.Datos;
using FrameworkDAC.Negocio;

namespace Backend.Dominio
{
    public class Idioma : ObjetoPersistido
    {

        #region Constantes

        private const string NOMBRE = "Idioma";

        public const string ESPANOL = "ES";

        public const string INGLES = "EN";

        public const string PORTUGUES = "PT";

        #endregion

        #region Propiedades

        public string Nombre {get; set;}
        public string Cultura {get; set;}
        
        #endregion

        #region Metodos Redefinidos

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }

        #endregion

        #region Idiomas
        public enum Idiomas
        {
            Español = 1,
            Ingles = 2,
            Portugues = 3
        };

        #endregion

    }
}
