using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.DTO
{
    public class ClausulaIdiomaDTO
    {

        #region Atributos
        private int _Id;
        private string _TipoClausula;
        private string _Codigo;
        private int _OrdenPredefinido;
        private string _Nombre;
        private string _Idioma;

        #endregion

        #region Propiedades
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string TipoClausula
        {
            get { return _TipoClausula; }
            set { _TipoClausula = value; }
        }

        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public int OrdenPredefinido
        {
            get
            {
                return _OrdenPredefinido;
            }
            set
            {
                _OrdenPredefinido = value;
            }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string Idioma
        {
            get { return _Idioma; }
            set { _Idioma = value; }
        }
        #endregion

    }
}
