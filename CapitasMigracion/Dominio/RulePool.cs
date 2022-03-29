using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace CapitasMigracion.Dominio
{
    public class RulePool : ObjetoPersistido
    {
        private const string NOMBRE = "ACCGGRulePool";

        #region Atributos

        private int _IdPool;

        private string _RuleType;

        private decimal _Value;

        private string _Unit;

        private string _Rate;

        private int _IdTerritorialValidity;

        private string _TerritorialValidity;

        private bool _IncludeNational;

        private bool _Evaluate;

        #endregion

        #region Propiedades

        public int IdPool
        {
            get
            {
                return _IdPool;
            }
            set
            {
                _IdPool = value;
            }
        }

        public string RuleType
        {
            get
            {
                return _RuleType;
            }
            set
            {
                _RuleType = value;
            }
        }

        public decimal Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
            }
        }

        public string Unit
        {
            get
            {
                return _Unit;
            }
            set
            {
                _Unit = value;
            }
        }

        public string Rate
        {
            get
            {
                return _Rate;
            }
            set
            {
                _Rate = value;
            }
        }

        public int IdTerritorialValidity
        {
            get
            {
                return _IdTerritorialValidity;
            }
            set
            {
                _IdTerritorialValidity = value;
            }
        }

        public string TerritorialValidity
        {
            get
            {
                return _TerritorialValidity;
            }
            set
            {
                _TerritorialValidity = value;
            }
        }

        public bool Evaluate
        {
            get
            {
                return _Evaluate;
            }
            set
            {
                _Evaluate = value;
            }
        }

        public bool IncludeNational
        {
            get
            {
                return _IncludeNational;
            }
            set
            {
                _IncludeNational = value;
            }
        }

        #endregion

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
