using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Backend.Homes;
using Backend.Dominio;
using System.Collections;

namespace Condiciones.Servicios
{
    /// <summary>
    /// Summary description for ServicioAutocompletarTarifa
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ServicioAutocompletarTarifa : System.Web.Services.WebService
    {
        private static IList<string> Sugerencias = new List<string>();

        private static DateTime UltimaActualizacion = new DateTime(1900, 1, 1);


        [WebMethod]
        public string[] GetSuggestions(string prefixText, int count, string contextKey)
        {
            //bool HoraDeActualizar = (new DateTime()).Subtract(UltimaActualizacion).Hours >= 5;
            //Sugerencias.Clear();
            //var su = Sugerencias.Where(p => p.Substring(0, prefixText.Length) == prefixText);
            //var su = Sugerencias.Where(p => p == prefixText);

            //if (su.Count() == 0 || su.Count() == 1 || HoraDeActualizar)
            //{
                //Limpio todas las sugerencias
            //    if (HoraDeActualizar)
            //    {
            //        Sugerencias.Clear();
            //    }
            //    UltimaActualizacion = new DateTime();
                IList<Tarifa> Tarifas = TarifaHome.Buscar(prefixText, null, count, (contextKey == "" ? 0 : Convert.ToInt32(contextKey)));

                var tar = Tarifas
                                .OrderBy(s => s.Codigo.PadLeft(10, '0'))
                                .GroupBy(g => g.Codigo).Where((w,i) => i < count );


            //    for (int I = 0; I < count && I < tar.Count(); I++ )
            //    {
            //        if (!Sugerencias.Contains(tar.ElementAt(I).Key))
            //        {
            //            Sugerencias.Add(tar.ElementAt(I).Key );
            //        }
            //    }
            //}

            ////return Sugerencias.ToArray();
            ////su = Sugerencias.Where(p => p.Substring(0, prefixText.Length) == "'" + prefixText).OrderBy(s => s.Insert(s.IndexOf("'") + 1, new string('0', 10 - s.Length)));

            //su = Sugerencias.Select(s => new { orden = s.PadLeft(10, '0'), valor = "\'" + s + "\'" , key = s})
            //                .OrderBy(o => o.orden)
            //                .Where(w=> w.key.PadRight(prefixText.Length,' ').Substring(0,prefixText.Length) == prefixText)
            //                .Select(s => s.valor);

            return tar.Select(p=> new {valor = "\'" + p.Key + "\'"}.valor).ToArray();

            //return su.ToArray();
            //return su.Where((p,i) => i < count).ToArray();
            //return new string[] { " 01", " 02", " 03" };
            
        }
    }
}
