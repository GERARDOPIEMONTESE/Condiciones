using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;
using Backend.Datos;

namespace Backend.Dominio
{
    public class Clausula_Idioma : ObjetoNegocio
    {
        #region Constantes

        private const string NOMBRE = "Clausula_R_Idioma";

        #endregion

        #region Propiedades

        public int IdClausula {get; set;}
        public int IdIdioma {get; set;}
        public string Nombre {get; set;}
        public string Texto
        {
            get
            {
                return Nombre;
            }
        }

        #endregion

        #region Metodos Redefinidos

        public override FrameworkDAC.Dato.IDAOObjetoNegocio ObtenerDAO()
        {
            return DAOClausula_Idioma.Instancia();
        }

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }

        #endregion
    }
}
