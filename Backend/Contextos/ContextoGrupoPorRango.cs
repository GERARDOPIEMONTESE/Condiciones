using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Contextos
{
    public class ContextoGrupoPorRango
    {
        #region Atributos

        private int _CodigoPais = 0;

        private string _CodigoProducto;

        private string _CodigoTarifa;

        private bool _Anual = false;

        private int _Edad = -1;

        private int _IdTipoPlan = 0;

        private int _IdTipoModalidad = 0;

        private int _Categoria = -1;

        //SLA
        private string _CodigoAgencia;
        private int _NumeroSucursal = -1;
        private int _IdTipoGrupoClausula = 0;
        //Fin SLA

        #endregion

        #region Propiedades

        public int IdTipoGrupoClausula
        {
            get { return _IdTipoGrupoClausula; }
            set { _IdTipoGrupoClausula = value; }
        }

        public int NumeroSucursal
        {
            get { return _NumeroSucursal; }
            set { _NumeroSucursal = value; }
        }

        public string CodigoAgencia
        {
            get { return _CodigoAgencia; }
            set { _CodigoAgencia = value; }
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

        public string CodigoProducto
        {
            get
            {
                return _CodigoProducto;
            }
            set 
            {
                _CodigoProducto = value;
            }
        }

        public string CodigoTarifa
        {
            get
            {
                return _CodigoTarifa;
            }
            set
            {
                _CodigoTarifa = value;
            }
        }

        public bool Anual
        {
            get
            {
                return _Anual;
            }
            set
            {
                _Anual = value;
            }
        }

        public int Edad
        {
            get
            {
                return _Edad;
            }
            set
            {
                _Edad = value;
            }
        }

        public int IdTipoPlan
        {
            get
            {
                return _IdTipoPlan;
            }
            set
            {
                _IdTipoPlan = value;
            }
        }

        public int IdTipoModalidad
        {
            get
            {
                return _IdTipoModalidad;
            }
            set
            {
                _IdTipoModalidad = value;
            }
        }

        public int Categoria
        {
            get
            {
                return _Categoria;
            }
            set
            {
                _Categoria = value;
            }
        }

        #endregion
    }
}
