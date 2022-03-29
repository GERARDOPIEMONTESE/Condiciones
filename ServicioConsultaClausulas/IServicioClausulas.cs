using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioConsultaClausulas
{
    // NOTE: If you change the interface name "IService1" here, you must also update the reference to "IService1" in Web.config.
    [ServiceContract]
    public interface IServicioClausulas
    {
        // TODO: Add your service operations here
        [OperationContract]
        GruposClausulaDTO ObtenerCondiciones(ConsultaCondicionesDTO Consulta, string Usuario, string Clave);

        [OperationContract]
        string ObtenerCondicionesXml(string XmlConsulta, string Usuario, string Clave);

        [OperationContract]
        string ConvertirConsulta(ConsultaCondicionesDTO Consulta);

        [OperationContract]
        string ConvertirGrupos(GruposClausulaDTO Grupos);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    [DataContract]
    public class ConsultaCondicionesUpgradeDTO
    {
        #region Atributos

        private string _CodigoUpgrade;

        private string _CodigoTarifa;

        private int _Categoria;

        #endregion

        #region Propiedades

        [DataMember]
        public string CodigoUpgrade
        {
            get
            {
                return _CodigoUpgrade;
            }
            set
            {
                _CodigoUpgrade = value;
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

    /***
     * Invocacion servicio
     * **/
    [DataContract]
    public class ConsultaCondicionesDTO
    {
        #region Atributos

        private int _CodigoPais = 0;

        private string _CodigoProducto;

        private string _CodigoTarifa;

        private bool _Anual = false;

        private int _Edad = -1;

        private int _IdTipoPlan = 0;

        private int _IdTipoModalidad = 0;

        private ConsultaCondicionesUpgradeDTO[] _Upgrades;

        private ConsultaCondicionesDTO _ConsultaPadre;

        #endregion

        #region Propiedades

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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
        public ConsultaCondicionesUpgradeDTO[] Upgrades
        {
            get
            {
                return _Upgrades;
            }
            set
            {
                _Upgrades = value;
            }
        }

        [DataMember]
        public ConsultaCondicionesDTO ConsultaPadre
        {
            get
            {
                return _ConsultaPadre;
            }
            set
            {
                _ConsultaPadre = value;
            }
        }

        #endregion
    }

    /***
     * Respuesta servicio
     * **/
    [DataContract]
    public class ClausulaIdiomaDTO
    {
        #region Atributos

        private int _IdIdioma;

        private string _Texto;

        #endregion

        #region Propiedades

        [DataMember]
        public int IdIdioma
        {
            get
            {
                return _IdIdioma;
            }
            set
            {
                _IdIdioma = value;
            }
        }

        [DataMember]
        public string Texto
        {
            get
            {
                return _Texto;
            }
            set
            {
                _Texto = value;
            }
        }

        #endregion
    }

    [DataContract]
    public class ClausulaDTO
    {
        #region Atributos
        private string _CodigoTipoClausula;

        private string _NombreTipoClausula;

        private string _Codigo;

        private ClausulaIdiomaDTO[] _ClausulaIdioma;

        #endregion

        #region Propiedades

        [DataMember]
        public string CodigoTipoClausula
        {
            get
            {
                return _CodigoTipoClausula;
            }
            set
            {
                _CodigoTipoClausula = value;
            }
        }

        [DataMember]
        public string NombreTipoClausula
        {
            get
            {
                return _NombreTipoClausula;
            }
            set
            {
                _NombreTipoClausula = value;
            }
        }

        [DataMember]
        public string Codigo
        {
            get
            {
                return _Codigo;
            }
            set
            {
                _Codigo = value;
            }
        }

        [DataMember]
        public ClausulaIdiomaDTO[] ClausulaIdioma
        {
            get
            {
                return _ClausulaIdioma;
            }
            set
            {
                _ClausulaIdioma = value;
            }
        }


        #endregion

    }

    [DataContract]
    public class ContenidoClausulaRangoDTO
    {
        #region  Atributos

        private int _EdadMinima;

        private int _EdadMaxima;

        private string _TipoPlan;

        private string _TipoModalidad;

        private int _Categoria;

        private string _Contenido;

        private int _IdValidezTerritorialClausula;

        private int _IdValidezTerritorial;

        private LeyendaDTO[] _Leyendas;

        #endregion

        #region Propiedades

        [DataMember]
        public int EdadMinima
        {
            get
            {
                return _EdadMinima;
            }
            set
            {
                _EdadMinima = value;
            }
        }

        [DataMember]
        public int EdadMaxima
        {
            get
            {
                return _EdadMaxima;
            }
            set
            {
                _EdadMaxima = value;
            }
        }

        [DataMember]
        public string TipoPlan
        {
            get
            {
                return _TipoPlan;
            }
            set
            {
                _TipoPlan = value;
            }
        }

        [DataMember]
        public string TipoModalidad
        {
            get
            {
                return _TipoModalidad;
            }
            set
            {
                _TipoModalidad = value;
            }
        }

        [DataMember]
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

        [DataMember]
        public string Contenido
        {
            get
            {
                return _Contenido;
            }
            set
            {
                _Contenido = value;
            }
        }

        [DataMember]
        public int IdValidezTerritorial
        {
            get
            {
                return _IdValidezTerritorial;
            }
            set
            {
                _IdValidezTerritorial = value;
            }
        }

        [DataMember]
        public int IdValidezTerritorialClausula
        {
            get
            {
                return _IdValidezTerritorialClausula;
            }
            set
            {
                _IdValidezTerritorialClausula = value;
            }
        }

        [DataMember]
        public LeyendaDTO[] Leyendas
        {
            get
            {
                return _Leyendas;
            }
            set
            {
                _Leyendas = value;
            }
        }

        #endregion
    }

    [DataContract]
    public class CondicionEvaluacion
    {
        #region Atributos

        private string _Codigo;

        private string _TipoDato;

        #endregion

        #region Propiedades

        [DataMember]
        public string Codigo
        {
            get
            {
                return _Codigo;
            }
            set
            {
                _Codigo = value;
            }
        }

        [DataMember]
        public string TipoDato
        {
            get
            {
                return _TipoDato;
            }
            set
            {
                _TipoDato = value;
            }
        }
        #endregion

        public CondicionEvaluacion()
        {
        }

        public CondicionEvaluacion(string pCodigo, string pTipoDato)
        {
            this.Codigo = pCodigo;
            this.TipoDato = pTipoDato;
        }
    }

    [DataContract]
    public class LeyendaDTO
    {
        #region Atributos

        private int _IdIdioma;

        private string _Texto;

        #endregion

        #region Propiedades

        [DataMember]
        public int IdIdioma
        {
            get
            {
                return _IdIdioma;
            }
            set
            {
                _IdIdioma = value;
            }
        }

        [DataMember]
        public string Texto
        {
            get
            {
                return _Texto;
            }
            set
            {
                _Texto = value;
            }
        }

        #endregion

        public LeyendaDTO()
        {
        }

        public LeyendaDTO(int pIdIdioma, string pTexto)
        {
            IdIdioma = pIdIdioma;
            Texto = "<![CDATA[" + pTexto + "]]>";
        }
    }

    [DataContract]
    public class ContenidoClausulaDTO
    {
        #region Atributos

        private ClausulaDTO _Clausula;

        private ContenidoClausulaRangoDTO[] _Rangos;

        private ContenidoClausulaDTO[] _Padres;

        private CondicionEvaluacion[] _CondicionesEvaluacion;

        private string _CodigoTipoImpresionClausula;

        private bool _EvaluableEnAsistencia;

        private bool _VisibleEnAsistencia;

        //private LeyendaDTO[] _Leyendas;

        private string _TipoCobertura;

        #endregion

        #region Propiedades

        [DataMember]
        public ClausulaDTO Clausula
        {
            get
            {
                return _Clausula;
            }
            set
            {
                _Clausula = value;
            }
        }

        [DataMember]
        public string CodigoTipoImpresionClausula
        {
            get
            {
                return _CodigoTipoImpresionClausula;
            }
            set
            {
                _CodigoTipoImpresionClausula = value;
            }
        }

        [DataMember]
        public bool EvaluableEnAsistencia
        {
            get
            {
                return _EvaluableEnAsistencia;
            }
            set
            {
                _EvaluableEnAsistencia = value;
            }
        }

        [DataMember]
        public bool VisibleEnAsistencia
        {
            get
            {
                return _VisibleEnAsistencia;
            }
            set
            {
                _VisibleEnAsistencia = value;
            }
        }

        //[DataMember]
        //public LeyendaDTO[] Leyendas
        //{
        //    get
        //    {
        //        return _Leyendas;
        //    }
        //    set
        //    {
        //        _Leyendas = value;
        //    }
        //}

        [DataMember]
        public string TipoCobertura
        {
            get
            {
                return _TipoCobertura;
            }
            set
            {
                _TipoCobertura = value;
            }
        }

        [DataMember]
        public ContenidoClausulaDTO[] Padres
        {
            get
            {
                return _Padres;
            }
            set
            {
                _Padres = value;
            }
        }

        [DataMember]
        public ContenidoClausulaRangoDTO[] Rangos
        {
            get
            {
                return _Rangos;
            }
            set
            {
                _Rangos = value;
            }
        }

        [DataMember]
        public CondicionEvaluacion[] CondicionesEvaluacion
        {
            get
            {
                return _CondicionesEvaluacion;
            }
            set
            {
                _CondicionesEvaluacion = value;
            }
        }

        #endregion
    }

    [DataContract]
    public class TarifaDTO
    {
        #region Atributos

        private int _CodigoPais;

        private string _CodigoProducto;

        private string _CodigoTarifa;

        private string _Sufijo;

        #endregion

        #region Propiedades

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
        #endregion
    }

    [DataContract]
    public class DocumentoDTO
    {
        #region Atributos

        private int _IdDocumento;

        private string _CodigoValidacion;

        private int _IdTipoDocumento;

        private string _Nombre;

        //private byte[] _DocumentoContenido;

        private int _DocumentoDimension;

        private string _DocumentoTipoContenido;

        private int _IdIdioma;

        #endregion

        #region Propiedades

        [DataMember]
        public int IdDocumento
        {
            get
            {
                return _IdDocumento;
            }
            set
            {
                _IdDocumento = value;
            }
        }

        [DataMember]
        public string CodigoValidacion
        {
            get
            {
                return _CodigoValidacion;
            }
            set
            {
                _CodigoValidacion = value;
            }
        }
        [DataMember]
        public int IdTipoDocumento
        {
            get
            {
                return _IdTipoDocumento;
            }
            set
            {
                _IdTipoDocumento = value;
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

        //[DataMember]
        //public byte[] DocumentoContenido
        //{
        //    get
        //    {
        //        return _DocumentoContenido;
        //    }
        //    set
        //    {
        //        _DocumentoContenido = value;
        //    }
        //}

        [DataMember]
        public int DocumentoDimension
        {
            get
            {
                return _DocumentoDimension;
            }
            set
            {
                _DocumentoDimension = value;
            }
        }

        [DataMember]
        public string DocumentoTipoContenido
        {
            get
            {
                return _DocumentoTipoContenido;
            }
            set
            {
                _DocumentoTipoContenido = value;
            }
        }

        [DataMember]
        public int IdIdioma
        {
            get
            {
                return _IdIdioma;
            }
            set
            {
                _IdIdioma = value;
            }
        }

        #endregion
    }

    [DataContract]
    public class GrupoClausulaDTO
    {
        #region Atributos

        private int _IdLocacion;

        private string _TipoGrupoClausula;

        private string _Texto;

        private bool _Anual;

        private int _DiasConsecutivos;

        private ContenidoClausulaDTO[] _Clausulas;

        private TarifaDTO[] _Tarifas;

        private DocumentoDTO[] _Documentos;

        #endregion

        #region Propiedades

        [DataMember]
        public int IdLocacion
        {
            get
            {
                return _IdLocacion;
            }
            set
            {
                _IdLocacion = value;
            }
        }

        [DataMember]
        public string TipoGrupoClausula
        {
            get
            {
                return _TipoGrupoClausula;
            }
            set
            {
                _TipoGrupoClausula = value;
            }
        }

        [DataMember]
        public string Texto
        {
            get
            {
                return _Texto;
            }
            set
            {
                _Texto = value;
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
        public int DiasConsecutivos
        {
            get
            {
                return _DiasConsecutivos;
            }
            set
            {
                _DiasConsecutivos = value;
            }
        }

        [DataMember]
        public ContenidoClausulaDTO[] Clausulas
        {
            get
            {
                return _Clausulas;
            }
            set
            {
                _Clausulas = value;
            }
        }

        [DataMember]
        public TarifaDTO[] Tarifas
        {
            get
            {
                return _Tarifas;
            }
            set
            {
                _Tarifas = value;
            }
        }

        [DataMember]
        public DocumentoDTO[] Documentos
        {
            get
            {
                return _Documentos;
            }
            set
            {
                _Documentos = value;
            }
        }

        #endregion
    }

    [DataContract]
    public class GruposClausulaDTO
    {
        private GrupoClausulaDTO[] _Grupos;

        [DataMember]
        public GrupoClausulaDTO[] Grupos
        {
            get
            {
                return _Grupos;
            }
            set
            {
                _Grupos = value;
            }
        }
    }

}
