using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;
using Backend.Datos;

namespace Backend.Dominio
{
    public class Texto : ObjetoNegocio
    {
        #region Constantes

        private const string NOMBRE = "Texto";

        public const int RESUMEN = 1;

        public const int CLAUSULA = 2;

        #endregion

        #region Atributos

        private string _Nombre;
        private TipoTexto _TipoTexto;
        private TipoTextoResumen _TipoTextoResumen;
        private IList<Texto_Idioma> _Texto_Idioma;
        private int _Idioma;

        #endregion

        #region Propiedades

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public int Idioma
        {
            get { return _Idioma; }
            set { _Idioma = value; }
        }

        public TipoTexto TipoTexto
        {
            get
            {
                return _TipoTexto;
            }
            set
            {
                _TipoTexto = value;
            }
        }

        public TipoTextoResumen TipoTextoResumen
        {
            get
            {
                return _TipoTextoResumen;
            }
            set
            {
                _TipoTextoResumen = value;
            }
        }

        public IList<Texto_Idioma> Texto_Idioma
        {
            get { return _Texto_Idioma; }
            set { _Texto_Idioma = value; }
        }

        public string ContenidoTexto
        {
            get
            {
                return _Texto_Idioma != null
                    ? _Texto_Idioma[_Idioma - 1 < 0 ? 0 : _Idioma - 1].Texto : "-";
            }
        }

        #endregion

        #region Metodos Redefinidos

        public override FrameworkDAC.Dato.IDAOObjetoNegocio ObtenerDAO()
        {
            return DAOTexto.Instancia();
        }

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }

        #endregion
    }

   

}
