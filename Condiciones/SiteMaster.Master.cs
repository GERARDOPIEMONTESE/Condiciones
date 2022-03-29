using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MenuPortalLibrary.CapaDTO;
using System.IO;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using AjaxControlToolkit;

namespace Condiciones
{
    public partial class SiteMaster :  System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtURLLogin.Text = System.Configuration.ConfigurationSettings.AppSettings["PaginaLogin"].ToString();

            if (Session["UsuarioDTO"] == null)
            {
                Session.Clear();
                panelUpdateProgress.Visible = true;
                ModalProgress.Show();
                StringBuilder sb = new StringBuilder();
                sb.Append("<script>RedireccionarConTiempo();</script>");
                Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Timer", sb.ToString());
            }
        }
      
    }
}
