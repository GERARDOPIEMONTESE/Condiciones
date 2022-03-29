using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;

namespace Backend.DTO
{
    public class PaisDTO
    {
        #region Atributos

        private Pais _Pais;

        #endregion

        #region Propiedades

        public string Codigo
        {
            get
            {
                return _Pais.Codigo;
            }
        }

        public string Nombre
        {
            get
            {
                return _Pais.Codigo + " - " + _Pais.Nombre;
            }
        }

        #endregion

        public PaisDTO(Pais pPais)
        {
            _Pais = pPais;
        }
    }
}
