using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Negocio;

namespace Backend.Homes
{
    public abstract class TipoObjetoCodificadoHome<T> : IObjetoCodificadoHome where T : ObjetoCodificado
    {
        public abstract ObjetoCodificado ObtenerObjetoCodificado(int Id);

        protected abstract IList<T> BuscarObjetos();

        public IList<ObjetoCodificado> BuscarObjetosCodificados()
        {
            IList<ObjetoCodificado> ObjetosCodificados = new List<ObjetoCodificado>();

            IList<T> Objetos = BuscarObjetos();

            foreach (T Objeto in Objetos)
            {
                ObjetosCodificados.Add(Objeto);
            }

            return ObjetosCodificados;
        }

        public abstract string InsertQuery(ObjetoCodificado Objeto);

        public abstract string UpdateQuery(ObjetoCodificado Objeto);

        public abstract string DeleteQuery(ObjetoCodificado Objeto);
    }

    public interface IObjetoCodificadoHome
    {
        ObjetoCodificado ObtenerObjetoCodificado(int Id);

        IList<ObjetoCodificado> BuscarObjetosCodificados();

        string InsertQuery(ObjetoCodificado Objeto);

        string UpdateQuery(ObjetoCodificado Objeto);

        string DeleteQuery(ObjetoCodificado Objeto);
    }
}
