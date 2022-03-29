using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace CapitasMigracion.Dominio
{
    public class Business : ObjetoCodificado
    {
        private const string NOMBRE = "ACMembershipBusiness";

        #region Atributos

        private int _CodigoPais;

        private int _IdTipoGrupoClausula = 3;

        #endregion

        #region Propiedades

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
