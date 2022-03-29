using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;

namespace Backend.Contextos
{
    public class ContextoModificacionRango
    {
        #region Atributos

        private int _EdadMinima = -1;

        private int _EdadMaxima = -1;

        private int _IdTipoPlan = -1;

        private int _IdTipoModalidad = -1;

        private int _Categoria = -1;

        private string _Contenido;

        private IList<Leyenda> _Leyendas = new List<Leyenda>();

        private int _IdTipoDestino = 0;

        private int _IdValidezTerritorialClausula;

        private int _IdValidezTerritorial;

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

        public int IdTipoDestino
        {
            get
            {
                return _IdTipoDestino;
            }
            set
            {
                _IdTipoDestino = value;
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

        #endregion
    }
}
