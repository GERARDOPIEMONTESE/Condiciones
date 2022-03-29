using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.Homes;
using Backend.Dominio;
using AjaxControlToolkit;

namespace Condiciones.Controles
{
    public partial class WucCondicionClausula : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (IsPostBack)
            //{
            //    if (Request["__EVENTTARGET"] == "SelectClausulaTexto")
            //    {
            //        HfIdclausulaTexto.Value = Request["__EVENTARGUMENT"];
            //        MpeTextosClausula.Show();
            //    }
            //    //BuscarTextosResumen();
            //}
        }

        public string Contenido
        {
            get
            {
                return TbContenido.Text;
            }
            set
            {
                TbContenido.Text = value;
            }
        }

        public string IdIdioma
        {
            get
            {
                return HfIdioma.Value == null || HfIdioma.Value.Length == 0 
                    ? "1" : HfIdioma.Value;
            }
            set
            {
                HfIdioma.Value = value;
            }
        }

        public RequiredFieldValidator ObtenerValidador()
        {
            return RfvContenido;
        }

      
    }
}