using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CondicionesParser.Parser
{
    public class ContenedorOperadores
    {
        #region Constantes

        public const string SEPARADOR_PARAMETRO = " ";

        public const string SEPARADOR_TIPO_PARAMETRO = ":";

        public const string OR = " || ";

        public const string AND = " && ";

        public const string MENOR = "MENOR";

        public const string MAYOR = "MAYOR";

        public const string IGUAL = "IGUAL";

        public const string DISTINTO = "DISTINTO";

        public const string MENOR_IGUAL = "MENOR-IGUAL";

        public const string MAYOR_IGUAL = "MAYOR-IGUAL";

        public const string TEXTO = "TEXTO";

        public const string PORCENTAJE_COSTO_VIAJE = "%";

        private IList<string> _Operadores = new List<string>();

        #endregion

        #region Singleton

        private static ContenedorOperadores _Instancia;

        public static ContenedorOperadores Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new ContenedorOperadores();
            }
            return _Instancia;
        }

        private ContenedorOperadores()
        {
            Inicializar();
        }

        private void Inicializar()
        {
            foreach (SettingsProperty Property in
                CondicionesParser.Properties.Settings.Default.Properties)
            {
                _Operadores.Add(Property.Name.ToUpper());
            }
        }

        #endregion

        public IList<string> Todos()
        {
            return _Operadores;
        }

    }
}
