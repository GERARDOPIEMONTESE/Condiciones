using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CondicionesParser.Estrategias;

namespace CondicionesParser.Parametros
{
    public class TipoParametro<T> : ITipoParametro
        where T : IComparable
    {
        #region Atributos

        private T _Referencia;// = System.Activator.CreateInstance(T);

        private string _Codigo;

        private ContenedorEstrategias<T> _Estrategias;

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

        public ContenedorEstrategias<T> Estrategias
        {
            get
            {
                return _Estrategias;
            }
            set
            {
                _Estrategias = value;
            }
        }

        #endregion

        public TipoParametro()
        {
            Estrategias = new ContenedorEstrategias<T>();
        }

        public TipoParametro(string pCodigo)
        {
            Codigo = pCodigo;
            Estrategias = new ContenedorEstrategias<T>();
        }

        public TipoParametro(string pCodigo, ContenedorEstrategias<T> pEstrategias)
        {
            Codigo = pCodigo;
            Estrategias = pEstrategias;
        }

        #region ITipoParametro Members

        /**
         * HORRIBLEEEE!!!! No encontre la forma de tomar del Type el tipo
         * del generico ... MEJORAR ESTOOOOO
         **/
        private T Convertir(object Operando)
        {
            if (_Referencia != null && _Referencia.GetType() == typeof(int))
            {
                int Resultado = 0;
                try
                {
                    Resultado = Convert.ToInt32(Operando);
                }
                catch (Exception)
                {
                }

                return (T) ((object) Resultado);
            }

            if (_Referencia != null && _Referencia.GetType() == typeof(float))
            {
                float Resultado = 0;
                try
                {
                    Resultado = (float) Convert.ToDouble(Operando);
                }
                catch (Exception)
                {
                }

                return (T)((object)Resultado);
            }

            if (_Referencia != null && _Referencia.GetType() == typeof(bool))
            {
                bool Resultado = false;
                try
                {
                    Resultado = (bool)Convert.ToBoolean(Operando);
                }
                catch (Exception)
                {
                }

                return (T)((object)Resultado);
            }

            return (T)Operando;
        }

        public bool Resolver(string Operador, 
            object OperandoIzquierdo, object OperandoDerecho)
        {
            IList<T> Operandos = new List<T>();
            Operandos.Add(Convertir(OperandoIzquierdo));
            Operandos.Add(Convertir(OperandoDerecho));

            return Estrategias.Evaluar(Operador, Operandos);
        }

        #endregion

        #region ITipoParametro Members


        public void SetearCodigo(string Codigo)
        {
            this.Codigo = Codigo;
        }

        #endregion
    }
}
