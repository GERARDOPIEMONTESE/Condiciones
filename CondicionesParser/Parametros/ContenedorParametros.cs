using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CondicionesParser.Parametros;
using CondicionesParser.Estrategias;
using System.Xml;

namespace CondicionesParser.Parametros
{
    public class ContenedorParametros
    {
        #region Simbolos Parametros

        public const string MMG = "MMG";

        public const string EDAD = "EDAD";

        public const string LUGAR = "LUGAR";

        public const string GENERAL = "GENERAL";

        public const string TEXTO = "TEXTO";

        public const string COSTO_VIAJE = "COSTO_VIAJE";

        #endregion

        #region Singleton

        private string Ubicacion = "./";

        private IDictionary<string, ITipoParametro> _Parametros =
            new Dictionary<string, ITipoParametro>();

        private static ContenedorParametros _Instancia;

        private ContenedorParametros(string pUbicacion)
        {
            Ubicacion = pUbicacion;
            Iniciar();
        }

        public static ContenedorParametros Instancia(string pUbicacion)
        {
            if (_Instancia == null)
            {
                _Instancia = new ContenedorParametros(pUbicacion);
            }
            return _Instancia;
        }

        private ITipoParametro Instanciar(string TipoDato)
        {
            Type TipoParametro = Type.GetType("CondicionesParser.Parametros.TipoParametro`1");

            Type[] Argumentos = { Type.GetType(TipoDato) };

            Type TipoParametroGenerico = TipoParametro.MakeGenericType(Argumentos);

            return (ITipoParametro)Activator.CreateInstance(TipoParametroGenerico);
        }

        private void Iniciar()
        {
            XmlDocument XmlDocument = new XmlDocument();
            XmlDocument.Load(Ubicacion + "Parametros.config");

            XmlNodeList Configuraciones = XmlDocument.GetElementsByTagName("tipoParametro");

            foreach (XmlNode Nodo in Configuraciones)
            {
                string Codigo = Nodo.Attributes["codigo"].InnerText;
                string TipoDato = Nodo.Attributes["tipoDato"].InnerText;

                ITipoParametro TipoParametro = Instanciar(TipoDato);
                TipoParametro.SetearCodigo(Codigo);
                _Parametros.Add(Codigo, TipoParametro);
            }
        }

        #endregion

        public ITipoParametro Obtener(string Codigo)
        {
            if (_Parametros.Keys.Contains(Codigo))
            {
                return _Parametros[Codigo];
            }
            return null;
        }

        public IList<string> Todos()
        {
            return (IList<string>)_Parametros.Keys.ToList<string>();
        }
    }
}
