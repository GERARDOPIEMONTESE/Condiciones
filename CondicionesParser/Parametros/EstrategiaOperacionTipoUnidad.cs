using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CondicionesParser.Estrategias;

namespace CondicionesParser.TipoUnidad
{
    public class EstrategiaOperacionTipoUnidad
    {
        #region Singleton y atributos

        private IDictionary<string, IContenedorEstrategias> _Estrategias = null;

        private static EstrategiaOperacionTipoUnidad _Instancia;

        private EstrategiaOperacionTipoUnidad()
        {
            Iniciar();
        }

        public static EstrategiaOperacionTipoUnidad Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new EstrategiaOperacionTipoUnidad();
            }

            return _Instancia;
        }

        private void Iniciar()
        {
            _Estrategias.Add(TipoParametro.TIPO_DATO_ENTERO, new ContenedorEstrategias<int>());
            _Estrategias.Add(TipoParametro.TIPO_DATO_CADENA, new ContenedorEstrategias<string>());
            _Estrategias.Add(TipoParametro.TIPO_DATO_PUNTO_FLOTANTE, new ContenedorEstrategias<float>());
        }

        #endregion

        public IContenedorEstrategias Estrategia(string Tipo)
        {
            return _Estrategias[Tipo];
        }

        public IContenedorEstrategias Estrategia(TipoParametro TipoUnidad)
        {
            return Estrategia(TipoUnidad.TipoDato);
        }
    
    }
}
