using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Backend.Homes;
using Backend.Dominio;

namespace Condiciones.Servicios
{
    /// <summary>
    /// Summary description for ServicioAutocompletarSufijo
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ServicioAutocompletarSufijo : System.Web.Services.WebService
    {
        private static IList<string> Sugerencias = new List<string>();

        private static DateTime UltimaActualizacion = new DateTime(1900, 1, 1);

        [WebMethod]
        public string[] GetSuggestions(string prefixText, int count)
        {
            bool HoraDeActualizar = (new DateTime()).Subtract(UltimaActualizacion).Hours >= 5;
            //var s = from x in Sugerencias where x.Substring(0, prefixText.Length) == prefixText select x;
            var s = Sugerencias.Where(p => p.Substring(0, prefixText.Length) == prefixText).OrderBy(x=>x.ToString());
            if (s.Count() == 0 || HoraDeActualizar)
            {
                //Limpia la coleccion
                if (HoraDeActualizar)
                {
                    Sugerencias.Clear();
                }

                IList<Tarifa> Tarifas = TarifaHome.Buscar(null, prefixText, count, 0);

                for (int I = 0; I < count && I < Tarifas.Count; I++)
                {
                    if (!Sugerencias.Contains(Tarifas[I].Sufijo))
                    {
                        Sugerencias.Add(Tarifas[I].Sufijo);
                    }
                }

                

                //s = from x in Sugerencias where x.Substring(0, prefixText.Length) == prefixText select x;
                s = Sugerencias.Where(p => p.Substring(0, prefixText.Length) == prefixText).OrderBy(x => x.ToString());
            }
            
            return s.ToArray();
        }
    }
}
