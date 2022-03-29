using System.Collections.Generic;
using Backend.Datos;
using Backend.Interfaces;
using FrameworkDAC.Negocio;

namespace Backend.Dominio
{
    public class ContenidoClausulaRango : ObjetoNegocio, ICopiable<ContenidoClausulaRango>
    {
        private const string NOMBRE = "ContenidoClausulaRango";

        #region Atributos

        private int _IdContenidoClausula;

        private int _EdadMinima;

        private int _EdadMaxima;

        private TipoPlan _TipoPlan;

        private TipoModalidad _TipoModalidad;

        private int _Categoria;

        private string _Contenido = "";

        private ValidezTerritorialClausula _ValidezTerritorialClausula;

        private ValidezTerritorial _ValidezTerritorial;

        private IList<Leyenda> _Leyendas = new List<Leyenda>();

        private decimal? _Peso;

        #endregion

        #region Propiedades

        public int IdContenidoClausula
        {
            get
            {
                return _IdContenidoClausula;
            }
            set
            {
                _IdContenidoClausula = value;
            }
        }

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

        public TipoPlan TipoPlan
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

        public TipoModalidad TipoModalidad
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

        public ValidezTerritorialClausula ValidezTerritorialClausula
        {
            get
            {
                return _ValidezTerritorialClausula;
            }
            set
            {
                _ValidezTerritorialClausula = value;
            }
        }

        public ValidezTerritorial ValidezTerritorial
        {
            get
            {
                return _ValidezTerritorial;
            }
            set
            {
                _ValidezTerritorial = value;
            }
        }

        public IList<Leyenda> Leyendas
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

        public decimal? Peso
        {
            get { return _Peso; }
            set { _Peso = value; }
        }

        #endregion

        public override FrameworkDAC.Dato.IDAOObjetoNegocio ObtenerDAO()
        {
            return DAOContenidoClausulaRango.Instancia();
        }

        public override string ObtenerNombre()
        {
            return NOMBRE;
        }

        #region ICopiable<ContenidoClausulaRango> Members

        public ContenidoClausulaRango Copiar()
        {
            ContenidoClausulaRango Copia = new ContenidoClausulaRango();

            Copia.EdadMinima = EdadMinima;
            Copia.EdadMaxima = EdadMaxima;
            Copia.Categoria = Categoria;
            Copia.TipoPlan = TipoPlan;
            Copia.TipoModalidad = TipoModalidad;
            Copia.Contenido = Contenido;
            Copia.ValidezTerritorialClausula = ValidezTerritorialClausula;
            Copia.ValidezTerritorial = ValidezTerritorial;
            Copia.Peso = Peso;

            foreach (Leyenda Leyenda in Leyendas)
            {
                Copia.Leyendas.Add(Leyenda.Copiar());
            }

            return Copia;
        }

        #endregion
    }
}
