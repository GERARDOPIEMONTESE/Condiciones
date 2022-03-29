using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace CondicionesMigracion.ACNet
{
    public class GrupoPais : ObjetoPersistido
    {
        private const string NOMBRE = "ICARD.CLAUSULA_PAIS_GRUPO";

        #region Atributos

        private string _CodigoClausula;

        private int _IdGrupoClausula;

        private int _PosicionClausula;

        private string _Nombre;

        #endregion

        #region Propiedades

        public string CodigoClausula
        {
            get
            {
                return _CodigoClausula;
            }
            set
            {
                _CodigoClausula = value;
            }
        }

        public int IdGrupoClausula
        {
            get
            {
                return _IdGrupoClausula;
            }
            set
            {
                _IdGrupoClausula = value;
            }
        }

        public int PosicionClausula
        {
            get
            {
                return _PosicionClausula;
            }
            set
            {
                _PosicionClausula = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _Nombre;
            }
            set
            {
                _Nombre = value;
            }
        }

        #endregion

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
