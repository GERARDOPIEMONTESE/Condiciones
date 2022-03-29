using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServicioCondiciones
{
    /// <summary>
    /// Summary description for ServicioTarifaWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicioTarifaWS : System.Web.Services.WebService
    {
        [WebMethod]
        public string AgregarTarifa(string Xml, string Usuario, string Clave)
        {
            try
            {
                TarifaWS TarifaWS = (TarifaWS)ServicioConversionXml.Instancia().
                    DeserializeObject(Xml, Type.GetType("ServicioCondiciones.TarifaWS"));

                string Mensaje = ServicioTarifa.Instancia().AgregarTarifa(TarifaWS);

                return Mensaje;
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
    }
}
