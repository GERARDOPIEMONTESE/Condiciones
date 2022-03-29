using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControlMenu;
using Backend.Dominio;
using Backend.Homes;
using Backend.DTO;

namespace Condiciones.GrupoClausulas.SLA
{
    public partial class ListaDeGrupoClausulasSLA : CustomPage
    {
        protected override void CustomPageLoad(object sender, EventArgs e)
        {
            ValidarSession();
            btnSearch.Focus();
            if (!IsPostBack)
            {
                Session.Remove("Tarifas");
                LoadControls();
                //ObtenerEstadoControles();
                Search();
            }
        }

        private void LoadControls()
        {
            ddlPais.DataSource = PaisHome.Buscar();
            ddlPais.DataTextField = "Nombre";
            ddlPais.DataValueField = "Codigo";
            ddlPais.DataBind();
        }

        private void Search()
        {
            TipoGrupoClausula tipoGrupoClausula = TipoGrupoClausulaHome.Obtener("SLA");
            grvSLAGroup.DataSource = GrupoClausulaHome.BuscarGrupoSLA(tipoGrupoClausula.Id, Convert.ToInt32(ddlPais.SelectedValue), 
                    txtAgencia.Text.Equals(string.Empty) ? null : txtAgencia.Text, txtSucursal.Text.Equals(string.Empty) ? -1 : Convert.ToInt32(txtSucursal.Text));
            grvSLAGroup.DataBind();
        }

        private void NewSLAGroup()
        {
            CleanSession();
            Session["GrupoClausulas"] = new GrupoClausula();
            Response.Redirect("./GrupoClausulaSLA_Datos.aspx?modalidad=new");
        }

        private void CleanSession()
        {
            Session.Remove(SessionDataHandler.GRUPO_CLAUSULAS);
            Session.Remove(SessionDataHandler.PAIS);
        }

        private GrupoClausula ObtenerGrupoClausula(int Index)
        {
            int Id = Convert.ToInt32(grvSLAGroup.Rows[Index].Cells[0].Text);
            GrupoClausula Grupo = GrupoClausulaHome.Obtener(Id);

            return Grupo;
        }

        #region Events

        protected void DropDownList_DataBound(object sender, EventArgs e)
        {
            ((DropDownList)sender).Items.Insert(0, new ListItem("Todos", "0"));
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            Search();
            mpeCargando.Hide();
        }

        protected void btnNew_OnClick(object sender, EventArgs e)
        {
            NewSLAGroup();
        }

        #endregion

        #region GridEvents

        protected void grvSLAGroup_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvSLAGroup.PageIndex = e.NewPageIndex;
            Search();
        }

        protected void grvSLAGroup_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
                //Segun permisos del usuario logueado
                //e.Row.Cells[9].Visible = PuedeEjecutarAccion(PermisosConstant.CREACION_GRUPOS);
                //e.Row.Cells[10].Visible = e.Row.Cells[9].Visible;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.background ='#ecf0f9'");
                e.Row.Attributes.Add("onmouseout", "this.style.background ='#ffffff'");
                e.Row.Attributes.Add("ondblclick", "javascript:window.location.href='./GrupoClausula_Datos.aspx?modalidad=edit&Id=" + e.Row.Cells[0].Text + "';");
                e.Row.Cells[0].Visible = false;
                //Segun permisos del usuario logueado
                //e.Row.Cells[9].Visible = PuedeEjecutarAccion(PermisosConstant.CREACION_GRUPOS);
                //e.Row.Cells[10].Visible = e.Row.Cells[9].Visible;
            }
        }

        protected void grvSLAGroup_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = 0;

            switch (e.CommandName)
            {
                case "Editar":
                    //Index = Convert.ToInt32(e.CommandArgument);
                    Id = Int32.Parse(((Button)(e.CommandSource)).CommandArgument);
                    CleanSession();
                    Session["GrupoClausulas"] = GrupoClausulaHome.Obtener(Id);
                    Response.Redirect("./GrupoClausulaSLA_Datos.aspx?modalidad=edit");
                    break;
                case "Eliminar":
                    Id = Int32.Parse(((Button)(e.CommandSource)).CommandArgument);
                    CleanSession();
                    GrupoClausula Grupo = GrupoClausulaHome.Obtener(Id);
                    Grupo.IdUsuario = UsuarioLogueadoDTO() != null ? UsuarioLogueadoDTO().IdUsuario : -1;
                    Grupo.Eliminar();
                    Search();
                    break;
                case "Copiar":
                    Id = Int32.Parse(((Button)(e.CommandSource)).CommandArgument);
                    CleanSession();
                    Session["GrupoClausulas"] = GrupoClausulaHome.Obtener(Id).Copiar();
                    Response.Redirect("./GrupoClausulaSLA_Datos.aspx?modalidad=copy");
                    break;
                case "Export":
                    TipoGrupoClausula tipoGrupoClausula = TipoGrupoClausulaHome.Obtener("SLA");
                    List<GrupoClausulaSLADTO> source = (List<GrupoClausulaSLADTO>)GrupoClausulaHome.BuscarGrupoSLA(tipoGrupoClausula.Id,
                        Convert.ToInt32(ddlPais.SelectedValue), txtAgencia.Text.Equals(string.Empty) ? null : txtAgencia.Text, Convert.ToInt32(txtSucursal.Text));
                    ExportToExcel(source, CargarColumnas(grvSLAGroup));
                    break;
                case "ExportToPDF":
                    TipoGrupoClausula tipoGrupoClausulaPDF = TipoGrupoClausulaHome.Obtener("SLA");
                    List<GrupoClausulaSLADTO> sourcepdf = (List<GrupoClausulaSLADTO>)GrupoClausulaHome.BuscarGrupoSLA(tipoGrupoClausulaPDF.Id, 
                        Convert.ToInt32(ddlPais.SelectedValue), txtAgencia.Text.Equals(string.Empty) ? null : txtAgencia.Text, Convert.ToInt32(txtSucursal.Text));
                    ExportToPDF(sourcepdf, "nombrearchivo");
                    break;
            }
        }

        #endregion
    }
}