using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using ServicioCondiciones;
using EMailAdmin.BackEnd;
using EMailAdmin.BackEnd.Strategies.Attachment;
using EMailAdmin.BackEnd.DTO;

namespace Condiciones.Handlers
{
    /// <summary>
    /// Summary description for CondicionesHandler
    /// </summary>
    public class CondicionesHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string codigoPais = context.Request.QueryString["pais"];
            string producto = context.Request.QueryString["producto"];
            string tarifa = context.Request.QueryString["tarifa"];
            int edad = Convert.ToInt32(context.Request.QueryString["edad"]);
            GrupoClausulaDTO grupo = new GrupoClausulaDTO();
            if (!String.IsNullOrEmpty(codigoPais) && !String.IsNullOrEmpty(producto) && !String.IsNullOrEmpty(tarifa) && edad!=null)
            {                
                grupo = ServicioClausulas.Instancia().ObtenerCondiciones(codigoPais, producto, tarifa, edad);
                context.Response.Cache.SetCacheability(HttpCacheability.NoCache);

                //to do... obtener pdf de emailadmin

                byte[] PDFContent;// = report;


                context.Response.ClearHeaders();
                context.Response.ContentType = "application/pdf";
                //context.Response.BinaryWrite(PDFContent);
                context.Response.Flush();
                context.Response.End();
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