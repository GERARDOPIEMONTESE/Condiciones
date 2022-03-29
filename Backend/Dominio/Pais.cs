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
    public class Pais : ObjetoPersistido
    {
        #region Constantes

        private const string NOMBRE = "Idioma";

        #endregion

        #region Propiedades

        public int IdLocacion {get; set;}
        public string Nombre {get; set;}
        public string Codigo {get; set;}
        public string CodigoISOA2 {get; set;}
        public string CodigoISOA3 {get; set;}
        
          
        #endregion

        #region Metodos Redefinidos

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }

        #endregion
    }
}
