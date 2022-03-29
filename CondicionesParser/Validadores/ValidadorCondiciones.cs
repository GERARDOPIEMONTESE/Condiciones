using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CondicionesParser.Parser;
using System.Text.RegularExpressions;
using System.Xml;

namespace CondicionesParser.Validadores
{
    public class ValidadorCondiciones
    {
        #region Singleton

        private static ValidadorCondiciones _Instancia;

        private string Ubicacion;

        private IDictionary<string, IValidadorParametro> _Validadores = 
            new Dictionary<string, IValidadorParametro>();

        private ValidadorCondiciones(string pUbicacion)
        {
            Ubicacion = pUbicacion;
            Inicializar();
        }

        public static ValidadorCondiciones Instancia(string pUbicacion)
        {
            if (_Instancia == null)
            {
                _Instancia = new ValidadorCondiciones(pUbicacion);
            }
            return _Instancia;
        }

        private void Inicializar() 
        {
            XmlDocument XmlDocument = new XmlDocument();
            XmlDocument.Load(Ubicacion + "Parametros.config");

            XmlNodeList Configuraciones = XmlDocument.GetElementsByTagName("tipoParametro");

            foreach (XmlNode Nodo in Configuraciones)
            {
                string Codigo = Nodo.Attributes["codigo"].InnerText;
                string ClaseValidador = Nodo.Attributes["validador"].InnerText;

                _Validadores.Add(Codigo, Instanciar(ClaseValidador));
            }
        }

        private IValidadorParametro Instanciar(string Clase)
        {
            Type InstanciaValidador = Type.GetType(Clase);

            return (IValidadorParametro)Activator.CreateInstance(InstanciaValidador);
        }

        #endregion

        private IValidadorParametro ObtenerValidador(string Clave)
        {
            if (!_Validadores.Keys.Contains(Clave))
            {
                throw new Excepciones.ParserException(
                    "Parametro inexistente: " + Clave);
            }
            return _Validadores[Clave];
        }
        
        public void ValidarCondicion(string CondicionCompleta) 
        {
            if (CondicionCompleta == null || CondicionCompleta.Length == 0)
            {
                return;
            }

            string[] GruposCondiciones = Regex.Split(
                CondicionCompleta,
                "\\|\\|");

            foreach (string GrupoCondiciones in GruposCondiciones)
            {
                string[] CondicionesIndividuales = Regex.Split(
                    GrupoCondiciones, ContenedorOperadores.AND);

                foreach (string CondicionIndividual in CondicionesIndividuales)
                {
                    string[] Condiciones = Regex.Split(CondicionIndividual,
                        ContenedorOperadores.SEPARADOR_TIPO_PARAMETRO);

                    if (Condiciones == null || Condiciones.Length == 0)
                    {
                        throw new Excepciones.ParserException(
                            "Formato Invalido: " + CondicionIndividual);
                    }

                    string Parametro = Condiciones[0];

                    ObtenerValidador(Parametro).ValidarFormato(CondicionIndividual, Ubicacion);
                }
            }
        }
    }
}
