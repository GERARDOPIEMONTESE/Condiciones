using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace CapitasMigracion.Dominio
{
    public class Plan : ObjetoCodificado
    {
        private const string NOMBRE = "ACMembershipPlan";

        #region Atributos

        private string _CodigoBusiness;

        private int _CodigoPais;

        private string _Sufijo;

        private int _IdTipoGrupoClausula = 3;

        #endregion

        #region Propiedades

        public string CodigoBusiness
        {
            get
            {
                return _CodigoBusiness;
            }
            set
            {
                _CodigoBusiness = value;
            }
        }

        public int CodigoPais
        {
            get
            {
                return _CodigoPais;
            }
            set
            {
                _CodigoPais = value;
            }
        }

        public string Sufijo
        {
            get
            {
                return _Sufijo;
            }
            set
            {
                _Sufijo = value;
            }
        }

        public int IdTipoGrupoClausula
        {
            get
            {
                return _IdTipoGrupoClausula;
            }
            set
            {
                _IdTipoGrupoClausula = value;
            }
        }

        #endregion

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
