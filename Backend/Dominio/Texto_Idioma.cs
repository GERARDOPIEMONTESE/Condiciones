using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;
using Backend.Datos;

namespace Backend.Dominio
{
    public class Texto_Idioma : ObjetoNegocio
    {
        #region Constantes

        private const string NOMBRE = "Texto_R_Idioma";

        #endregion

        #region Propiedades

        public int IdTexto {get; set;}
        public int IdIdioma {get; set;}
        public string Texto { get; set; }
        
        #endregion

        #region Metodos Redefinidos

        public override FrameworkDAC.Dato.IDAOObjetoNegocio ObtenerDAO()
        {
            return DAOTexto_Idioma.Instancia();
        }

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }

        #endregion

    }
}
