using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using Backend.Servicios;
using FrameworkDAC.Negocio;
using System.Configuration;
using ControlMenu;
using Backend.Homes;
using Backend.Dominio;

namespace Condiciones.Admin
{
    public partial class CompaniasDeSeguro : CustomPage
    {
        private const string EDITAR = "Editar";

        private const string ELIMINAR = "Eliminar";

        protected override void CustomPageLoad(object sender, EventArgs e)
        {
            ValidarSession();
            if (!IsPostBack)
            {
                CargarGrilla();
            }
        }

       public void CargarGrilla()
       {
           GvCompaniasSeguro.DataSource = CompaniaSeguroHome.Buscar();
           GvCompaniasSeguro.DataBind();
       }

       protected void BNuevo_Click(object sender, EventArgs e)
       {
           Response.Redirect("./InformacionDeCompaniasDeSeguro.aspx");
       }


       protected void GvCompaniasSeguro_RowDataBound(object sender, GridViewRowEventArgs e)
       {
           if (e.Row.RowType == DataControlRowType.Header)
               e.Row.Cells[0].Visible = false;

           if (e.Row.RowType == DataControlRowType.DataRow)
           {
               e.Row.Attributes.Add("onmouseover", "this.style.background ='#ecf0f9'");
               e.Row.Attributes.Add("onmouseout", "this.style.background ='#ffffff'");
               e.Row.Attributes.Add("onDblClick", "javascript:window.location.href='./InformacionDeCompaniasDeSeguro.aspx?Id=" + e.Row.Cells[0].Text + "';");
               e.Row.Cells[0].Visible = false;
           }
       }
       protected void GvCompaniasSeguro_PageIndexChanging(object sender, GridViewPageEventArgs e)
       {
           GvCompaniasSeguro.PageIndex = e.NewPageIndex;
           CargarGrilla();
       }
       protected void GvCompaniasSeguro_RowCommand(object sender, GridViewCommandEventArgs e)
       {
           int Index;
           if (Int32.TryParse((string)e.CommandArgument, out Index))
           {
               if (e.CommandName.Equals(EDITAR))
               {
                   Response.Redirect(
                       "./InformacionDeCompaniasDeSeguro.aspx?Id=" + GvCompaniasSeguro.Rows[Index].Cells[0].Text);
               }
               if (e.CommandName.Equals(ELIMINAR))
               {
                   RiesgoTerceros riesgoterceros = RiesgoTercerosHome.SearchByIdCompania(Convert.ToInt32(Index));
                   if (riesgoterceros.Id == 0)
                   {
                       CompaniaSeguro companiaseguro = CompaniaSeguroHome.Obtener(Convert.ToInt32(Index));
                       companiaseguro.IdUsuario = UsuarioLogueadoDTO() != null ? UsuarioLogueadoDTO().IdUsuario : -1;
                       companiaseguro.Eliminar();
                       Response.Redirect("./ListaDeCompaniasDeSeguro.aspx");
                   }
                   else {
                       string script = " <script type=\"text/javascript\"> alert('No se pudo eliminar la compañia de Seguro, por tener riesgo de terceros activos');   </script> ";
                       ScriptManager.RegisterStartupScript(this, typeof(Page), "SHOW_ALERT", script, false);

                   }
               }
           }
       }
    }
}