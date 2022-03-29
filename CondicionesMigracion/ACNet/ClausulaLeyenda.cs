using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace CondicionesMigracion.ACNet
{
    public class ClausulaLeyenda : ObjetoPersistido
    {
        private const string NOMBRE = "ICARD.CLAUSULA_LEYENDA";

        #region Atributos

        private int _IdGrupo;

        private int _Posicion;

        private string _Leyenda;

        #endregion

        #region Propiedades

        public int IdGrupo
        {
            get
            {
                return _IdGrupo;
            }
            set
            {
                _IdGrupo = value;
            }
        }

        public int Posicion
        {
            get
            {
                return _Posicion;
            }
            set
            {
                _Posicion = value;
            }
        }

        public string Leyenda
        {
            get
            {
                return _Leyenda;
            }
            set
            {
                _Leyenda = value;
            }
        }

        #endregion

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
