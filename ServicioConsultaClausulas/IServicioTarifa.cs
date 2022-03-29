using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioConsultaClausulas
{
    // NOTE: If you change the interface name "IServicioTarifa" here, you must also update the reference to "IServicioTarifa" in Web.config.
    [ServiceContract]
    public interface IServicioTarifa
    {
        [OperationContract]
        void AgregarTarifa(TarifaWS TarifaWS);
    }

    [DataContract]
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

        #endregion

        #region Propiedades

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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

        #endregion
    }

    [DataContract]
    public class ProductoWS
    {
        #region Atributos

        private string _CodigoProducto;

        private string _Nombre;

        #endregion

        #region Propiedades

        [DataMember]
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

        [DataMember]
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
