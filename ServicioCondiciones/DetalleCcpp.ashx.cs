using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using CrystalDecisions.CrystalReports.Engine;
//using EMailAdmin.BackEnd.Reports.Objects;

namespace ServicioCondiciones
{
    /// <summary>
    /// Summary description for DetalleCcpp
    /// </summary>
    public class DetalleCcpp : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string producto = "", tarifa = "";
            int codigoPais = 0, edad = 0, idLanguage = 0;
            bool anual = false;
            int idTipoPlan = 1; //Default 1

            try
            {
                codigoPais = Convert.ToInt32(context.Request.QueryString["codigoPais"]);
                producto = context.Request.QueryString["producto"];
                tarifa = context.Request.QueryString["tarifa"];
                edad = Convert.ToInt32(context.Request.QueryString["edad"]);
                idLanguage = Convert.ToInt32(context.Request.QueryString["idLanguage"]);
                anual = Convert.ToBoolean(context.Request.QueryString["anual"]);
                    if (context.Request.QueryString["idTipoPlan"] != null)
                    {
                        idTipoPlan = Convert.ToInt32(context.Request.QueryString["idTipoPlan"]);
                    }
            }
            catch(Exception ex)
            {
                context.Response.ContentType = "text/html";
                context.Response.Write("Error procesando los parametros de la URL.");
                context.Response.Write("Error:" + ex.Message);
                return;
            }

            if (codigoPais == 0 || producto == "" || tarifa == "" || edad == 0 || idLanguage == 0)
            {
                context.Response.ContentType = "text/html";
                context.Response.Write("Parametros incorrectos.");
                return;
            }
            
            context.Response.ContentType = "application/pdf";
            context.Response.BinaryWrite(GenerateReport(ConditionsReport.GetConditionsReportObject(codigoPais, producto, tarifa, edad, idLanguage, anual, idTipoPlan)));
        }
        
        private byte[] GenerateReport(IEnumerable<ConditionsReportObject> conditions)
        {
            try
            {
                ReportDocument rptDoc = new ReportDocument();
                rptDoc.Load(HttpContext.Current.Server.MapPath("~/Reportes/DetalleCcpp.rpt"));
                rptDoc.SetDataSource(conditions);
                string url = CapaNegocioDatos.CapaHome.CodigoActivadorHome.ObtenerImagenURLHeader();
                rptDoc.SetParameterValue("UrlImageHeader", url);
                var crv =
                    new CrystalDecisions.Web.CrystalReportPartsViewer { ReportSource = rptDoc, Visible = false };

                var memorystream = (MemoryStream)rptDoc.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

                byte[] report = memorystream.ToArray();

                rptDoc.Dispose();
                crv.Dispose();
                memorystream.Dispose();

                return report;
            }
            catch (Exception ex)
            {
                return new byte[] { };
            }
        }
        
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
