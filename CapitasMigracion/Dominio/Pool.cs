using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace CapitasMigracion.Dominio
{
    public class Pool : ObjetoPersistido
    {
        private const string NOMBRE = "ACCGGPool";

        #region Atributos

        private int _IdTreePool;

        private string _CodigoClausula;

        private string _ParentsIds;

        private bool _Visible;

        private IList<RulePool> _Rules = new List<RulePool>();

        #endregion

        #region Propiedades

        public int IdTreePool
        {
            get
            {
                return _IdTreePool;
            }
            set
            {
                _IdTreePool = value;
            }
        }

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

        public string ParentsIds
        {
            get
            {
                return _ParentsIds;
            }
            set
            {
                _ParentsIds = value;
            }
        }

        public bool Visible
        {
            get
            {
                return _Visible;
            }
            set
            {
                _Visible = value;
            }
        }

        public IList<RulePool> Rules
        {
            get
            {
                return _Rules;
            }
            set
            {
                _Rules = value;
            }
        }

        #endregion

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
