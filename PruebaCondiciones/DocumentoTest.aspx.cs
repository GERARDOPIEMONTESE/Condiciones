using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PruebaCondiciones.ServicioClausulaTestingWS;

namespace PruebaCondiciones
{
    public partial class DocumentoTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicioClausulasWS ServicioWS = new ServicioClausulasWS();

            string XML = ServicioWS.ObtenerDocumentosPaisXml(540, "", "");
        }
    }
}
