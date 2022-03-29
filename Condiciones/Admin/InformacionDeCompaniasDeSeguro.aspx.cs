using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControlMenu;
using Backend.Dominio;
using Backend.Homes;
using Backend.Datos;

namespace Condiciones.Admin
{
    public partial class InformacionDeCompaniasDeSeguro : CustomPage
    {
        protected override void CustomPageLoad(object sender, EventArgs e)
        {
            ValidarSession();
            BAceptar.Focus();
            if (!IsPostBack)
            {
                Session["CompaniaSeguro"] = new CompaniaSeguro();

                if (Request.QueryString["Id"] != null)
                {
                    Session["CompaniaSeguro"] = CompaniaSeguroHome.Obtener(Convert.ToInt32(Request.QueryString["Id"]));
                    SetearInformacion();
                }
            }
        }
        private CompaniaSeguro ObtenerCompaniaSeguro()
        {
            return (CompaniaSeguro)Session["CompaniaSeguro"];
        }
        private void SetearInformacion()
        {
            CompaniaSeguro CompaniaSeguro = ObtenerCompaniaSeguro();
            TbDescripcion.Text = CompaniaSeguro.Descripcion;
        }

        protected void BCancelar_Click(object sender, EventArgs e)
        {
            Redireccionar();
        }

        protected void BAceptar_Click(object sender, EventArgs e)
        {
            CompaniaSeguro CompaniaSeguro = ObtenerCompaniaSeguro();

            CompaniaSeguro.Descripcion = TbDescripcion.Text;
            CompaniaSeguro.IdUsuario = UsuarioLogueadoDTO() != null ? UsuarioLogueadoDTO().IdUsuario : -1;
            CompaniaSeguro.Persistir();
            Redireccionar();
        }
        private void Redireccionar()
        {
            Session.Remove("CompaniaSeguro");
            Response.Redirect("./ListaDeCompaniasDeSeguro.aspx");
        }
    }
}