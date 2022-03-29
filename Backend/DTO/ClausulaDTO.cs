using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;

namespace Backend.DTO
{
    public class ClausulaDTO
    {
        public const string ROOT = "ROOT";

        #region Atributos

        private int _Id;

        private int _Orden;

        private IList<string> _TextosIdentificatorioPadre = new List<string>();

        private IList<ContenidoRangoDTO> _Contenidos = new List<ContenidoRangoDTO>();

        private string _TextoIdentificatorio;

        private string _NombreClausula;

        private int _IdClausula;

        private int _IdTipoClausula;

        private int _IdTipoImpresionClausula;

        private int _IdTipoContenidoImpresion;

        private bool _EvaluableEnAsistencia;

        private bool _VisibleEnAsistencia;

        private TipoCobertura _TipoCobertura;

        private ContenidoClausula _ContenidoClausula;

        private decimal? _Tasa;

        #endregion

        #region Propiedades

        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }

        public int Orden
        {
            get
            {
                return _Orden;
            }
            set
            {
                _Orden = value;
            }
        }

        public IList<string> TextosIdentificatorioPadre
        {
            get
            {
                return _TextosIdentificatorioPadre;
            }
            set
            {
                _TextosIdentificatorioPadre = value;
            }
        }

        public string TextoIdentificatorio
        {
            get
            {
                return _TextoIdentificatorio;
            }
            set
            {
                _TextoIdentificatorio = value;
            }
        }

        public string NombreClausula
        {
            get
            {
                return _NombreClausula;
            }
            set
            {
                _NombreClausula = value;
            }
        }

        public int IdClausula
        {
            get
            {
                return _IdClausula;
            }
            set
            {
                _IdClausula = value;
            }
        }

        public int IdTipoClausula
        {
            get
            {
                return _IdTipoClausula;
            }
            set
            {
                _IdTipoClausula = value;
            }
        }

        public IList<ContenidoRangoDTO> Contenidos
        {
            get
            {
                return _Contenidos;
            }
            set
            {
                _Contenidos = value;
            }
        }

        public int IdTipoImpresionClausula
        {
            get
            {
                return _IdTipoImpresionClausula;
            }
            set
            {
                _IdTipoImpresionClausula = value;
            }
        }

        public int IdTipoContenidoImpresion
        {
            get
            {
                return _IdTipoContenidoImpresion;
            }
            set
            {
                _IdTipoContenidoImpresion = value;
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

        public TipoCobertura TipoCobertura
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

        public ContenidoClausula ContenidoClausula
        {
            get
            {
                return _ContenidoClausula;
            }
            set
            {
                _ContenidoClausula = value;
            }
        }

        public decimal? Tasa
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

        #endregion
    }

   
}
