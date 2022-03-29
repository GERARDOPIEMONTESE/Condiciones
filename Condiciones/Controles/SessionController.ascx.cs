using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Text;

namespace Condiciones.Controles
{
    public partial class SessionController : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtURLLogin.Text = System.Configuration.ConfigurationSettings.AppSettings["PaginaLogin"];

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