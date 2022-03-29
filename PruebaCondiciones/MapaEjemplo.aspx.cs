using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaCondiciones
{
    public partial class MapaEjemplo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void mapMenu_Click(object sender, ImageMapEventArgs e)
        {
            switch (e.PostBackValue)
            {
                case "TOPL":
                    ImageMap2.ImageUrl = "~/IMG/Up Izq.gif";
                    break;
                case "DOWNL":
                    ImageMap2.ImageUrl = "~/IMG/Down Izq.gif";
                    break;
                case "TOPR":
                    ImageMap2.ImageUrl = "~/IMG/Up Izq.gif";
                    break;
            }
        }
    }
}
