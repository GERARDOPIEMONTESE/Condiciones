using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace ServicioCondiciones
{
    public class ConditionsReport
    {
        public static IEnumerable<ConditionsReportObject> GetConditionsReportObject(
            int codigoPais, string producto, string tarifa, int edad, int idLanguage, bool anual, int idTipoPlan)
        {
            var result = new List<ConditionsReportObject>();
            var grupoClausulaDTO = ServicioClausulas.Instancia().ObtenerCondiciones(codigoPais, producto, tarifa, edad, anual, idTipoPlan);

            foreach (ContenidoClausulaDTO contenidoClausulaDto in grupoClausulaDTO.Clausulas)
            {
                if (contenidoClausulaDto.ShowClause())
                {
                    string text = primeraLetraenMayuscula(contenidoClausulaDto.GetTitleClause(idLanguage).ToLower());
                    string leyend = contenidoClausulaDto.GetContentClause(idLanguage);
                    if (text.Count() == 0) {
                        text = primeraLetraenMayuscula(leyend.ToLower());
                        leyend = "";
                    }
                    if (leyend.Count() > 45) {
                        text = text + " " + primeraLetraenMayuscula(leyend.ToLower());
                        leyend = "";
                    }
                    result.Add(new ConditionsReportObject(contenidoClausulaDto.CodigoTipoContenidoImpresion,
                                    contenidoClausulaDto.GetIdClause(idLanguage),
                                    text,
                                    leyend,
                                    GetReportTitle(idLanguage)));
                }
            }
            return result;
        }

        private static string primeraLetraenMayuscula(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        private static string GetReportTitle(int idLanguage)
        {
            switch (idLanguage)
            {
                case 1: return CultureInfo.CurrentCulture.TextInfo.ToTitleCase("CONDICIONES PARTICULARES - LÍMITES Y TOPES".ToLower());
                case 2: return CultureInfo.CurrentCulture.TextInfo.ToTitleCase("SPECIFIC TERMS & CONDITIONS".ToLower());
                case 3: return CultureInfo.CurrentCulture.TextInfo.ToTitleCase("CONDICOES PARTICULARES - LIMITES E TOPES".ToLower());
            }
            return string.Empty;
        }
    }
}
