using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using ControlMenu;
using Backend.Homes;

namespace Condiciones.Admin
{
    public partial class ListaDeProductos : CustomPage
    {
        protected override void CustomPageLoad(object sender, EventArgs e)
        {
            ValidarSession();
            if (!IsPostBack) 
            {
                CargarCombos();
            }
        }

        #region Eventos Privados

        private void CargarCombos()
        {
            try
            {
                DdlPais.DataSource = PaisHome.Buscar();
                DdlPais.DataTextField = "Nombre";
                DdlPais.DataValueField = "Codigo";
                DdlPais.DataBind();
                DdlPais.Items.Insert(0, new ListItem("Todos", "0"));

                DdlTipoGrupoClausula.DataSource = TipoGrupoClausulaHome.Buscar();
                DdlTipoGrupoClausula.DataTextField = "Nombre";
                DdlTipoGrupoClausula.DataValueField = "Id";
                DdlTipoGrupoClausula.DataBind();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Buscar()
        {
            if (DdlPais.SelectedValue != "0") 
            {
                GvTarifas.DataSource = ProductoHome.Buscar(Convert.ToInt32(DdlPais.SelectedValue),
                    Convert.ToInt32(DdlTipoGrupoClausula.SelectedValue));
                GvTarifas.DataBind();
            }
        }

        #endregion

        #region Eventos Boton
        protected void BBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        protected void BNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("./InformacionDeProducto.aspx");
        }

        #endregion

        #region Eventos Grilla

        protected void GvTarifas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Export") 
            {
                List<Backend.Dominio.Producto> source = (List<Backend.Dominio.Producto>)ProductoHome.Buscar(Convert.ToInt32(DdlPais.SelectedValue), Convert.ToInt32(DdlTipoGrupoClausula.SelectedValue));
                ExportToExcel( source, CargarColumnas(GvTarifas));
            
            }
        }

        protected void GvTarifas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvTarifas.PageIndex = e.NewPageIndex;
            Buscar();
        }

        protected void GvTarifas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.Header)
                e.Row.Cells[0].Visible = false;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.background ='#ecf0f9'");
                e.Row.Attributes.Add("onmouseout", "this.style.background ='#ffffff'");
                e.Row.Attributes.Add("onDblClick", "javascript:window.location.href='./InformacionDeProducto.aspx?Id=" + e.Row.Cells[0].Text + "';");
                e.Row.Cells[0].Visible = false;
            }
        }

        #endregion

        #region Eventos Combo

        protected void DdlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        #endregion

        

      

    }
}
