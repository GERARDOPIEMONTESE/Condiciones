using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;
using Backend.Datos;
using Backend.Interfaces;

namespace Backend.Dominio
{
    public class ContenidoClausula : ObjetoNegocio, ICopiable<ContenidoClausula>
    {
        private const string NOMBRE = "ContenidoClausula";

        #region Atributos

        private int _IdClausula;

        private int _IdGrupoClausula;

        private IList<ContenidoClausulaRango> _Contenidos =
            new List<ContenidoClausulaRango>();

        private IList<AsociacionContenidoClausula> _Padres = 
            new List<AsociacionContenidoClausula>();

        private TipoImpresionClausula _TipoImpresionClausula;

        private TipoContenidoImpresion _TipoContenidoImpresion;

        private bool _EvaluableEnAsistencia;

        private bool _VisibleEnAsistencia;

        private int _Orden;

        
        private TipoCobertura _TipoCobertura;

        //atributo transiente
        private string _CodigoTipoGrupo = ""; 

        #endregion

        #region Propiedades

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

        public int IdGrupoClausula
        {
            get
            {
                return _IdGrupoClausula;
            }
            set
            {
                _IdGrupoClausula = value;
            }
        }

        public IList<AsociacionContenidoClausula> Padres
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

        public IList<ContenidoClausulaRango> Contenidos
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

        public TipoImpresionClausula TipoImpresionClausula
        {
            get
            {
                return _TipoImpresionClausula;
            }
            set
            {
                _TipoImpresionClausula = value;
            }
        }

        public TipoContenidoImpresion TipoContenidoImpresion
        {
            get
            {
                return _TipoContenidoImpresion;
            }
            set
            {
                _TipoContenidoImpresion = value;
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

        //public IList<Leyenda> Leyendas
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

        public Clausula Clausula
        {
            get
            {
                return DAOClausula.Instancia().Obtener(IdClausula);
            }
            set
            {
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

        public int ObtenerOrden()
        {
            return Orden == 0 ? Clausula.OrdenPredefinido : Orden;
        }

        #endregion

        public override FrameworkDAC.Dato.IDAOObjetoNegocio ObtenerDAO()
        {
            return DAOContenidoClausula.Instancia();
        }

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }

        #region ICopiable<ContenidoClausula> Members

        public ContenidoClausula Copiar()
        {
            ContenidoClausula Copia = new ContenidoClausula();

            Copia.IdClausula = IdClausula;
            Copia.TipoImpresionClausula = TipoImpresionClausula;
            Copia.TipoContenidoImpresion = TipoContenidoImpresion;
            Copia.EvaluableEnAsistencia = EvaluableEnAsistencia;
            Copia.VisibleEnAsistencia = VisibleEnAsistencia;
            Copia.TipoCobertura = TipoCobertura;
            Copia.Orden = Orden;

            foreach (ContenidoClausulaRango Rango in Contenidos)
            {
                Copia.Contenidos.Add(Rango.Copiar());
            }

            return Copia;
        }

        #endregion

      
    }
}
