using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Backend.Homes;
using Backend.Dominio;
using ControlMenu;


namespace Condiciones.Admin
{
    public partial class ListaDeTarifas : CustomPage
    {
        protected override void CustomPageLoad(object sender, EventArgs e)
        {
            ValidarSession();
            if(!IsPostBack)
                CargarCombos();

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
            GvTarifas.DataSource = TarifaHome.Buscar(Convert.ToInt32(DdlPais.SelectedValue),
                Convert.ToInt32(DdlProducto.SelectedValue), TbCodigoTarifa.Text);
            GvTarifas.DataBind();
        }

        private void BuscarProductos()
        {
            DdlProducto.DataSource = ProductoHome.Buscar(Convert.ToInt32(DdlPais.SelectedValue), Convert.ToInt32(DdlTipoGrupoClausula.SelectedValue));
            DdlProducto.DataTextField = "CodigoYNombre";
            DdlProducto.DataValueField = "Id";
            DdlProducto.DataBind();
        }

        #endregion

        #region Eventos Grilla

        protected void GvTarifas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.Header)
                e.Row.Cells[0].Visible = false;
           
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = false;
                e.Row.Attributes.Add("onmouseover", "this.style.background ='#ecf0f9'");
                e.Row.Attributes.Add("onmouseout", "this.style.background ='#ffffff'");
                e.Row.Attributes.Add("onDblClick", "javascript:window.location.href='./InformacionDeTarifa.aspx?Id=" + e.Row.Cells[0].Text + "';");
            }
        }

        protected void GvTarifas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvTarifas.PageIndex = e.NewPageIndex;
            Buscar();
        }

        #endregion

        #region Eventos Boton

        protected void BBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        protected void BNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("./InformacionDeTarifa.aspx");
        }

        #endregion

        #region Eventos Combo

        protected void DdlTipoGrupoClausula_SelectedIndexChanged(object sender, EventArgs e)
        {
            LProducto.Text = "Producto: ";
            bool VisibleTarifa = true;



            if (TipoGrupoClausula.PRODUCTO_SIN_EMISION.Equals(DdlTipoGrupoClausula.SelectedItem.Text))
            {
                LProducto.Text = "Convenio/Negocio: ";
                VisibleTarifa = false;
            }
            else
            {
                if (TipoGrupoClausula.TARIFA_UPGRADE.Equals(DdlTipoGrupoClausula.SelectedItem.Text))
                {
                    LProducto.Text = "Upgrade: ";
                }
            }

            LCodigoTarifa.Visible = VisibleTarifa;
            TbCodigoTarifa.Visible = VisibleTarifa;
            BuscarProductos();
        }
        
        protected void DdlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarProductos();
        }

        #endregion

        

        
    }
}
