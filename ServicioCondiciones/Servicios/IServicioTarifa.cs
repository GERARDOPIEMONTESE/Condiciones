using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ServicioCondiciones
{
    // NOTE: If you change the interface name "IServicioTarifa" here, you must also update the reference to "IServicioTarifa" in Web.config.
    public interface IServicioTarifa
    {
        string AgregarTarifa(TarifaWS TarifaWS);
    }

    public class TarifaWS
    {
        #region Atributos

        private int _IdTipoGrupoClausula;

        private int _CodigoPais;

        private string _CodigoTarifa;

        private string _Nombre;

        private bool _Anual;

        private string _Sufijo;

        private bool _Activa;

        private ProductoWS _Producto;

        private string _ModalidadTarifa;

        #endregion

        #region Propiedades

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

        public ProductoWS Producto
        {
            get
            {
                return _Producto;
            }
            set
            {
                _Producto = value;
            }
        }

        public string ModalidadTarifa
        {
            get
            {
                return _ModalidadTarifa;
            }
            set
            {
                _ModalidadTarifa = value;
            }
        }

        #endregion
    }

    public class ProductoWS
    {
        #region Atributos

        private string _CodigoProducto;

        private string _Nombre;

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
    }

}
