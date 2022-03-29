using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControlMenu;
using System.IO;
using Backend.Homes;


namespace Condiciones.Documento
{
    public partial class DescargaDeDocumento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(Request.QueryString["IdDocumento"]);

            if (Id == 0)
            {
                Response.Write("<div style=\"color:black;font-weight:bold;text-align:center;margin-top:100px;\">File no found.</div>");
                return;
            }

            Backend.Dominio.Documento Documento = DocumentoHome.Obtener(Id);
            byte[] file = Documento.DocumentoContenido;
            MemoryStream ms = new MemoryStream(file.Length);

            ms.Write(file, 0, file.Length);

            Response.ContentType = Documento.DocumentoTipoContenido;
            Response.Buffer = true;
            Response.BinaryWrite(file);

            ms.Dispose();
        }
    }
}
