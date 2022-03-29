using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CondicionesParser.Properties;
using System.Configuration;
using CondicionesParser.Parser;

namespace CondicionesParser.Estrategias
{
    public class ContenedorEstrategias<T> //: IContenedorEstrategias
        where T : IComparable
    {
        #region Atributos

        private IDictionary<string, IEstrategiaOperador<T>> _Estrategias = 
            new Dictionary<string, IEstrategiaOperador<T>>();

        #endregion

        private IEstrategiaOperador<T> Instanciar(string Clase)
        {
            Type TipoEstrategia = Type.GetType(Clase + "`1");

            Type[] Argumentos = { typeof(T) };

            Type TipoEstrategiaGenerica = TipoEstrategia.MakeGenericType(Argumentos);

            return (IEstrategiaOperador<T>) Activator.CreateInstance(TipoEstrategiaGenerica);
        }

        private void Inicializar()
        {
            foreach (SettingsProperty Property in
                CondicionesParser.Properties.Settings.Default.Properties)
            {
                _Estrategias.Add(Property.Name.ToUpper(), Instanciar(
                    Property.DefaultValue.ToString()));
            }
        }

        public ContenedorEstrategias()
        {
            Inicializar();
        }
        
        #region IContenedorEstrategias Members

        public bool Evaluar(string Operador, IList<T> Operandos)
        {
            return _Estrategias[Operador.ToUpper().Replace("-", "")].Evaluar(Operandos);
        }

        #endregion
    }
}
