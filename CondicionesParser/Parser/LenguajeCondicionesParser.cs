using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CondicionesParser.Parametros;
using System.Text.RegularExpressions;
using System.Xml;

namespace CondicionesParser.Parser
{
    public class LenguajeCondicionesParser
    {
        #region Atributos

        private IDictionary<string, string> _ParametrosPredefinidos = new Dictionary<string, string>();

        #endregion

        #region Singleton

        private static string Ubicacion = "./";

        private static LenguajeCondicionesParser _Instancia;

        private void Iniciar()
        {
            XmlDocument XmlDocument = new XmlDocument();
            XmlDocument.Load(Ubicacion + "Parametros.config");

            XmlNodeList Configuraciones = XmlDocument.GetElementsByTagName("tipoParametro");

            foreach (XmlNode Nodo in Configuraciones)
            {
                string Codigo = Nodo.Attributes["codigo"].InnerText;
                string TipoDato = Nodo.Attributes["tipoDato"].InnerText;

                _ParametrosPredefinidos.Add(Codigo, TipoDato);
            }
        }

        private LenguajeCondicionesParser(string pUbicacion)
        {
            Ubicacion = pUbicacion;
            Iniciar();
        }

        public static LenguajeCondicionesParser Instancia(string pUbicacion)
        {
            if (_Instancia == null)
            {
                _Instancia = new LenguajeCondicionesParser(pUbicacion);
            }

            return _Instancia;
        }

        #endregion

        private string[] SetearPorcentajes(IDictionary<string, object> Imputaciones, string[] Parametros)
        {
            string[] ParametrosProcesados = new string[Parametros.Length];

            for (int I = 0; I < Parametros.Length; I++)
            {
                string Parametro = Parametros[I];
                if (Parametro.Contains(ContenedorOperadores.PORCENTAJE_COSTO_VIAJE))
                {
                    float CostoViaje = (float)Convert.ToDouble(
                        Imputaciones[ContenedorParametros.COSTO_VIAJE]);

                    Parametro = Parametro.Replace(ContenedorOperadores.PORCENTAJE_COSTO_VIAJE, "");

                    Parametro = (CostoViaje * Convert.ToDouble(Parametro) / 100).ToString();
                }
                ParametrosProcesados[I] = Parametro;
            }
            
            return ParametrosProcesados;
        }

        /**
         * Ejemplo lenguaje:
         * MMG: MENOR 100 USD Y EDAD: MENOR 70 ANIOS Y EDAD: MAYOR 20 ANIOS Y LUGAR: IGUAL EUROPA O MMG: MENOR 20000 USD Y LUGAR: IGUAL RESTO_MUNDO
         * MMG: MENOR 40 %
         */
        private bool EvaluarCondicion(IDictionary<string, object> Imputaciones,
            string Condicion)
        {
            string[] PartesCondicion = Regex.Split(Condicion, 
                ContenedorOperadores.SEPARADOR_TIPO_PARAMETRO);

            string TipoParametro = PartesCondicion[0].Trim();

            string[] Parametros = Regex.Split(PartesCondicion[1].Trim(),
                ContenedorOperadores.SEPARADOR_PARAMETRO);

            Parametros = SetearPorcentajes(Imputaciones, Parametros);
            try
            {
                return ContenedorParametros.Instancia(Ubicacion).Obtener(TipoParametro).
                    Resolver(Parametros[0].ToString().Trim(),
                    Imputaciones[TipoParametro].ToString().ToUpper(),
                    Parametros[1].Trim());
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Evaluar(IDictionary<string, object> Imputaciones, 
            string CondicionesCompletas)
        {
            CondicionesCompletas = CondicionesCompletas.ToUpper().Replace(
                ContenedorOperadores.SEPARADOR_PARAMETRO + ContenedorOperadores.PORCENTAJE_COSTO_VIAJE, 
                ContenedorOperadores.PORCENTAJE_COSTO_VIAJE);

            string[] Bloques = Regex.Split(
                CondicionesCompletas, "\\|\\|");
            bool Evaluacion = false;

            foreach (string Bloque in Bloques)
            {
                string[] Condiciones = Regex.Split(Bloque, ContenedorOperadores.AND);

                bool EvaluacionCondicion = true;

                foreach(string Condicion in Condiciones) 
                {
                    EvaluacionCondicion &= EvaluarCondicion(Imputaciones, Condicion);

                    if (!EvaluacionCondicion)
                    {
                        break;
                    }
                }

                Evaluacion |= EvaluacionCondicion;
            }

            return Evaluacion;
        }

        public IList<string> ObtenerCondicionesInvalidas(IDictionary<string, object> Imputaciones,
            string CondicionesCompletas)
        {
            IList<string> CondicionesInvalidas = new List<string>();
            CondicionesCompletas = CondicionesCompletas.ToUpper().Replace(
                ContenedorOperadores.SEPARADOR_PARAMETRO + ContenedorOperadores.PORCENTAJE_COSTO_VIAJE,
                ContenedorOperadores.PORCENTAJE_COSTO_VIAJE);

            string[] Bloques = Regex.Split(
                CondicionesCompletas, "\\|\\|");

            foreach (string Bloque in Bloques)
            {
                string[] Condiciones = Regex.Split(Bloque, ContenedorOperadores.AND);

                foreach (string Condicion in Condiciones)
                {
                    if (!Evaluar(Imputaciones, Condicion))
                    {
                        CondicionesInvalidas.Add(Condicion);
                    }
                }
            }

            return CondicionesInvalidas;
        }

        private IDictionary<string, string> ObtenerParametros(string CondicionCompleta)
        {
            IDictionary<string, string> Parametros = new Dictionary<string, string>();

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

                    for (int I = 0; I < Condiciones.Length; I++)
                    {
                        string Clave = Condiciones[I].Trim();
                        if (((I % 2) == 0) &&
                            (_ParametrosPredefinidos.Keys.Contains(Clave)))
                        {
                            Parametros.Add(Clave, _ParametrosPredefinidos[Clave]);
                        }
                    }
                }
            }
            
            return Parametros;
        }

        public IDictionary<string, string> ObtenerValoresContenido(string CondicionCompleta)
        {
            IDictionary<string, string> Parametros = new Dictionary<string, string>();

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
                    
                    string Clave = Condiciones[0].Trim();

                    string[] ParametrosCondicion = Regex.Split(Condiciones[1].Trim(),
                        ContenedorOperadores.SEPARADOR_PARAMETRO);

                    string ValorParametro = ParametrosCondicion[1];

                    for (int I = 2; I < ParametrosCondicion.Length; I++)
                    {
                        ValorParametro += ContenedorOperadores.SEPARADOR_PARAMETRO + 
                            ParametrosCondicion[I];
                    }

                    Parametros.Add(Clave, ValorParametro);
                }
            }

            return Parametros;
        }

        public IDictionary<string, string> ObtenerParametros(IList<string> CondicionesCompletas)
        {
            IDictionary<string, string> Parametros = new Dictionary<string, string>();

            foreach (string CondicionCompleta in CondicionesCompletas)
            {
                IDictionary<string, string> ParametrosIndividual = ObtenerParametros(CondicionCompleta);

                foreach (string Key in ParametrosIndividual.Keys)
                {
                    if (!Parametros.Keys.Contains(Key))
                    {
                        Parametros.Add(Key, ParametrosIndividual[Key]);
                    }
                }
            }

            return Parametros;
        }

        public IList<string> ObtenerParametrosLista(IList<string> CondicionesCompletas)
        {
            IDictionary<string, string> Parametros = new Dictionary<string, string>();

            foreach (string CondicionCompleta in CondicionesCompletas)
            {
                IDictionary<string, string> ParametrosIndividual = ObtenerParametros(CondicionCompleta);

                foreach (string Key in ParametrosIndividual.Keys)
                {
                    if (!Parametros.Keys.Contains(Key))
                    {
                        Parametros.Add(Key, ParametrosIndividual[Key]);
                    }
                }
            }

            IList<string> ParametrosLista = new List<string>();

            foreach (string Key in Parametros.Keys)
            {
                ParametrosLista.Add(Key + " - " + Parametros[Key]);
            }

            return ParametrosLista;
        }
    }
}
