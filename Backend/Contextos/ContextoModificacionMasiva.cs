using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.DTO;

namespace Backend.Contextos
{
    public class ContextoModificacionMasiva
    {
        #region Atributos

        private IList<int> _IdsClausula;

        private IList<int> _IdsGrupoClausula;

        private IList<ContextoModificacionRango> _Rangos = 
            new List<ContextoModificacionRango>();

        private IList<int> _IdsPadre = new List<int>();

        private int _IdTipoCobertura;

        private int _IdTipoImpresionClausula;

        private int _IdTipoContenidoClausula;

        private bool _EvaluableEnAsistencia = true;

        private bool _VisibleEnAsistencia = true;

        private int _Orden = 100;

        //private int _IdTextoResumen;
        private IList<TextoResumenDTO> _TextosResumen = new List<TextoResumenDTO>();

        private IList<ContextoModificacionDocumento> _Documentos =
            new List<ContextoModificacionDocumento>();

        #endregion

        #region Propiedades

        public IList<int> IdsClausula
        {
            get
            {
                return _IdsClausula;
            }
            set
            {
                _IdsClausula = value;
            }
        }

        public IList<int> IdsGrupoClausula
        {
            get
            {
                return _IdsGrupoClausula;
            }
            set
            {
                _IdsGrupoClausula = value;
            }
        }

        public IList<ContextoModificacionRango> Rangos
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

        public IList<int> IdsPadre
        {
            get
            {
                return _IdsPadre;
            }
            set
            {
                _IdsPadre = value;
            }
        }

        public IList<TextoResumenDTO> TextosResumen
        {
            get
            {
                return _TextosResumen;
            }
            set
            {
                _TextosResumen = value;
            }
        }

        public IList<ContextoModificacionDocumento> Documentos
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

        public int IdTipoCobertura
        {
            get
            {
                return _IdTipoCobertura;
            }
            set
            {
                _IdTipoCobertura = value;
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

        public int IdTipoContenidoClausula
        {
            get
            {
                return _IdTipoContenidoClausula;
            }
            set
            {
                _IdTipoContenidoClausula = value;
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

        #endregion
    }
}
