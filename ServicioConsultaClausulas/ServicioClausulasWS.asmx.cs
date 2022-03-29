using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Threading;

namespace ServicioConsultaClausulas
{
    /// <summary>
    /// Summary description for ServicioClausulasWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicioClausulasWS : System.Web.Services.WebService
    {

        [WebMethod]
        public string ObtenerCondicionesXml(string XmlConsulta, string Usuario, string Clave)
        {
            ServicioClausulas Servicio = new ServicioClausulas();
            DateTime b = DateTime.Now;

            return Servicio.ObtenerCondicionesXml(XmlConsulta, Usuario, Clave);
        }

        [WebMethod]
        public int Test(int milliSeconds)
        {
            Thread.Sleep(milliSeconds);
            return milliSeconds;
        }
    }
}
