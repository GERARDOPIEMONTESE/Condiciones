using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace CondicionesMigracion.ACNet
{
    public class TarifaACNET : ObjetoCodificado
    {
        private const string NOMBRE = "ICARD.TARIFAS";

        #region Atributos

        private string _CodigoProducto;

        private int _CodigoPais;

        private bool _Anual;

        private string _Sufijo;

        private bool _Activa;

        private int _Tipo;

        private int _IdTipoModalidad;

        #endregion

        #region Propiedades

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

        public bool Activa
        {
            get
            {
                return _Activa;
            }
            set
            {
                _Activa = value;
            }
        }

        public int Tipo
        {
            get
            {
                return _Tipo;
            }
            set
            {
                _Tipo = value;
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

        #endregion

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }
    }
}
