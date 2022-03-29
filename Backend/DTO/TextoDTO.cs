using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;
using FrameworkDAC.Dato;
using Backend.Dominio;

namespace Backend.DTO
{
    public class TextoDTO : ObjetoPersistido
    {
        private const string NOMBRE = "Texto";

        #region Atributos

        private int _IdIdioma;

        private string _Nombre;

        private string _Texto;

        #endregion

        #region Propiedades

        public int IdIdioma {get; set;}
        public string Nombre {get; set;}
        public string Texto{get; set;}
        
        #endregion

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }

    

}
