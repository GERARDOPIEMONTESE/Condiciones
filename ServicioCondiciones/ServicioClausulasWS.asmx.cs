using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServicioCondiciones
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
            return ServicioClausulas.Instancia().
                ObtenerCondicionesXml(XmlConsulta, Usuario, Clave);
        }
        
        [WebMethod]
        public string GetMainBenefits(string country, string productCode, string rateCode, string user, string password)
        {
            return ServicioClausulas.Instancia().
                ObtenerCondicionesXml(country, productCode, rateCode, user, password);
        }

        [WebMethod]
        public string GetPrintedBenefits(string xml, string Usuario, string Clave)
        {
            return ServicioClausulas.Instancia().GetPrintedBenefits(xml, Usuario, Clave);
        }

        [WebMethod]
        public string ObtenerDocumentosProductoXml(int CodigoPais, string Codigo, string Usuario, string Clave)
        {
            return ServicioClausulas.Instancia().
                ObtenerDocumentosXml(CodigoPais, Codigo, Usuario, Clave);
        }

        [WebMethod]
        public string ObtenerDocumentosPaisXml(int CodigoPais, string Usuario, string Clave)
        {
            return ServicioClausulas.Instancia().
                ObtenerDocumentosXml(CodigoPais, Usuario, Clave);
        }

        [WebMethod]
        public string ObtenerComparacionesXml(string XmlConsulta, string Usuario, string Clave)
        {
            return ServicioClausulas.Instancia().
                ObtenerComparacionesXml(XmlConsulta, Usuario, Clave);
        }

        [WebMethod]
        public string ObtenerClausulasCoincidentesXml(string XmlConsulta, string Usuario, string Clave)
        {
            return ServicioClausulas.Instancia().
                ObtenerClausulasCoincidentesXml(XmlConsulta, Usuario, Clave);
        }
    }
}