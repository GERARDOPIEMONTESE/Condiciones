using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Servicios
{
    public interface IServicioClausulas
    {
        string ObtenerCondicionesXml(string XmlConsulta, string Usuario, string Clave);

        string ObtenerDocumentosProductoXml(int CodigoPais, string Codigo, string Usuario, string Clave);

        string ObtenerDocumentosPaisXml(int CodigoPais, string Usuario, string Clave);

        string ObtenerComparacionesXml(string XmlConsulta, string Usuario, string Clave);

        string ObtenerClausulasCoincidentesXml(string XmlConsulta, string Usuario, string Clave);
    }

    public class ConsultaCondicionesUpgradeDTO
    {
        #region Atributos

        private string _CodigoUpgrade;

        private string _CodigoTarifa;

        private int _Categoria;

        #endregion

        #region Propiedades

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

    public class ConsultasCondicionesDTO
    {
        #region Atributos

        private ConsultaCondicionesDTO[] _Consultas;

        #endregion

        #region Propiedades

        public ConsultaCondicionesDTO[] Consultas
        {
            get
            {
                return _Consultas;
            }
            set
            {
                _Consultas = value;
            }
        }

        #endregion

    }

    /***
     * Invocacion servicio
     * **/
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
    public class ClausulaIdiomaDTO
    {
        #region Atributos

        private int _IdIdioma;

        private string _Texto;

        #endregion

        #region Propiedades

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

    public class ClausulaDTO
    {
        #region Atributos
        private string _CodigoTipoClausula;

        private string _NombreTipoClausula;

        private string _Codigo;

        private ClausulaIdiomaDTO[] _ClausulaIdioma;

        #endregion

        #region Propiedades

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

        private decimal _Tasa = Convert.ToDecimal(0.3);

        private decimal _Valor = Convert.ToDecimal(0.3);

        private int _IdMoneda = 1;

        #endregion

        #region Propiedades

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

        public decimal Tasa
        {
            get
            {
                return _Tasa;
            }
            set
            {
                _Tasa = value;
            }
        }

        public decimal Valor
        {
            get
            {
                return _Valor;
            }
            set
            {
                _Valor = value;
            }
        }

        public int IdMoneda
        {
            get
            {
                return _IdMoneda;
            }
            set
            {
                _IdMoneda = value;
            }
        }
        
        #endregion
    }

    public class CondicionEvaluacion
    {
        #region Atributos

        private string _Codigo;

        private string _TipoDato;

        #endregion

        #region Propiedades

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

    public class LeyendaDTO
    {
        #region Atributos

        private int _IdIdioma;

        private string _Texto;

        #endregion

        #region Propiedades

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
            //Texto = "<![CDATA[" + pTexto + "]]>";
            Texto = pTexto;
        }
    }

    public class ContenidoClausulaDTO
    {
        #region Atributos

        private ClausulaDTO _Clausula;

        private ContenidoClausulaRangoDTO[] _Rangos;

        private ContenidoClausulaDTO[] _Padres;

        private CondicionEvaluacion[] _CondicionesEvaluacion;

        private string _CodigoTipoImpresionClausula;

        private string _CodigoTipoContenidoImpresion;

        private bool _EvaluableEnAsistencia;

        private bool _VisibleEnAsistencia;

        //private LeyendaDTO[] _Leyendas;

        private string _TipoCobertura;

        private string _CodigoTipoGrupo;

        #endregion

        #region Propiedades

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

        public string CodigoTipoContenidoImpresion
        {
            get
            {
                return _CodigoTipoContenidoImpresion;
            }
            set
            {
                _CodigoTipoContenidoImpresion = value;
            }
        }

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

        public string CodigoTipoGrupo
        {
            get
            {
                return _CodigoTipoGrupo;
            }
            set
            {
                _CodigoTipoGrupo = value;
            }
        }

        #endregion
    }

    public class TarifaDTO
    {
        #region Atributos

        private int _CodigoPais;

        private string _CodigoProducto;

        private string _CodigoTarifa;

        private string _Sufijo;

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

    public class DocumentoDTO
    {
        #region Atributos

        private int _IdDocumento;

        private string _CodigoValidacion;

        private int _IdTipoDocumento;

        private string _Nombre;

        private string _Observaciones;

        //private byte[] _DocumentoContenido;

        private Int64 _DocumentoDimension;

        private string _DocumentoTipoContenido;

        private int _IdIdioma;

        #endregion

        #region Propiedades

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

        public string Observaciones
        {
            get
            {
                return _Observaciones;
            }
            set
            {
                _Observaciones = value;
            }
        }

        public Int64 DocumentoDimension
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

    public class GrupoClausulaDTO
    {
        #region Atributos

        private int _IdLocacion;

        private string _TipoGrupoClausula;

        private string _Texto;

        private string _TipoTextoResumen;

        private bool _Anual;

        private int _DiasConsecutivos;

        private ContenidoClausulaDTO[] _Clausulas;

        private TarifaDTO[] _Tarifas;

        private DocumentoDTO[] _Documentos;

        #endregion

        #region Propiedades

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

        public string TipoTextoResumen
        {
            get
            {
                return _TipoTextoResumen;
            }
            set
            {
                _TipoTextoResumen = value;
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

    public class ConjuntoGruposClausulaDTO
    {
        #region Atributos

        private GrupoClausulaDTO[] _Grupos;

        #endregion

        #region Propiedades

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

        #endregion
    }

    public class GruposClausulaDTO
    {
        private GrupoClausulaDTO[] _Grupos;

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

    public class DocumentosDTO
    {
        private DocumentoDTO[] _Documentos;

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
    }
}
