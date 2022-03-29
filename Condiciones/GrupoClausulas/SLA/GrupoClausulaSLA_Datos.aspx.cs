using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControlMenu;
using Backend.Homes;
using Backend.Dominio;
using CapaNegocioDatos.CapaNegocio;
using CapaNegocioDatos.CapaHome;
using System.Collections;

namespace Condiciones.GrupoClausulas.SLA
{
    public partial class GrupoClausulaSLA_Datos : CustomPage
    {
        private const string URL_PASO2 = "../GrupoClausula_Clausulas.aspx?init=true";

        protected override void CustomPageLoad(object sender, EventArgs e)
        {
            ValidarSession();
            if (!IsPostBack)
            {
                Session.Remove("Sucursales");
                Session["Sucursales"] = new List<Sucursal>();
                Session.Remove("SucursalesLibres");
                Session["Modalidad"] = Request.QueryString["modalidad"];

                //Si es una copia o una edicion cargo los datos
                if (Session["Modalidad"] != null && !Session["Modalidad"].Equals("new") && Session["Modalidad"] != null)
                {
                    GrupoClausula Grupo = (GrupoClausula)Session["GrupoClausulas"];
                    CargarDatosGrupo(Grupo);
                }
            }
        }

        private void CargarDatosGrupo(GrupoClausula Grupo)
        {
            if (Grupo.Objetos.Count > 0)
            {
                Sucursal sucursal = SucursalHome.Obtener(Grupo.Objetos[0].IdObjetoAgrupador);

                IList<Sucursal> ISucursalesGrupo = SucursalHome.BuscarPorGrupoSLA(-1, Grupo.Id, TipoGrupoClausulaHome.Obtener("SLA").Id);
                Session["Sucursales"] = ISucursalesGrupo;

                grvSucursalesCheck.DataSource = ISucursalesGrupo;
                grvSucursalesCheck.DataBind();
            }
        }

        private IList<Sucursal> BuscarSucursales(int IdLocalidad, string CodigoAgencia)
        {
            return SucursalHome.BuscarPorFiltros(IdLocalidad, CodigoAgencia, txtRazonSocial.Text, "");
        }

        private void CargarSucursalesSinGrupo()
        {
            int IdLocalidad = Backend.Homes.PaisHome.ObtenerPorCodigo(Convert.ToInt32(ddlPais.SelectedValue)).IdLocacion;
            IList<Sucursal> ISucursales = BuscarSucursales(IdLocalidad, txtCodigoAgencia.Text);

            Session["SucursalesLibres"] = ISucursales;

            grvSucursales.DataSource = ISucursales;
            grvSucursales.DataBind();
        }

        private void Continuar()
        {
            try
            {
                lblErrorSucursales.Visible = false;
                Session["Pais"] = "0";//Convert.ToInt32(ddlPais.SelectedValue);
                Session["TipoGrupoClausula"] = TipoGrupoClausulaHome.Obtener("SLA");
                Session["IsSLA"] = true;
                Session["Agencia"] = txtCodigoAgencia.Text;
                Session["Anual"] = false;
                Session["DiasConsecutivos"] = 0;

                IList<Sucursal> ISucursales = new List<Sucursal>();

                foreach (GridViewRow Row in grvSucursalesCheck.Rows)
                {
                    if (Row.RowState == DataControlRowState.Normal || Row.RowState == DataControlRowState.Alternate)
                    {
                        if (((CheckBox)Row.Cells[0].Controls[1]).Checked)
                        {
                            Sucursal Sucursal = SucursalHome.Obtener(Convert.ToInt32(Row.Cells[1].Text));
                            ISucursales.Add(Sucursal);
                        }
                    }
                }

                Session["Sucursales"] = ISucursales;

                if (ISucursales.Count > 0)
                {
                    Response.Redirect(URL_PASO2);
                }
                else
                {
                    cmvSeleccionAgencia.IsValid = false;
                    cmvSeleccionAgencia.Visible = true;
                    mpeCargando.Hide();
                }
            }
            catch (Exception ex)
            {
                lblErrorSucursales.Visible = true;
                lblErrorSucursales.Text = ex.Message;
                mpeCargando.Hide();
            }
        }

        private void ActualizarGrillas()
        {
            lblErrorSucursales.Visible = false;
            foreach (GridViewRow Row in grvSucursales.Rows)
            {
                if (Row.RowState == DataControlRowState.Normal || Row.RowState == DataControlRowState.Alternate)
                {
                    if (((CheckBox)Row.Cells[0].Controls[1]).Checked)
                    {
                        Sucursal Sucursal = SucursalHome.Obtener(Convert.ToInt32(Row.Cells[1].Text));
                        bool agregado = false;

                        foreach (Sucursal sucursalChecked in (IList<Sucursal>)Session["Sucursales"])
                        {
                            if (sucursalChecked.Id == Sucursal.Id)
                            {
                                agregado = true;
                                break;
                            }
                        }

                        if (!agregado)
                        {
                            ((IList<Sucursal>)Session["Sucursales"]).Add(Sucursal);
                            Session["SucursalesLibres"] = ((IList<Sucursal>)Session["SucursalesLibres"]).Where(x => x.IdSucursal != Sucursal.Id).ToList();
                        }
                        else
                        {
                            lblErrorSucursales.Visible = true;
                            lblErrorSucursales.Text = "La sucursal ya se encuentra agregada al grupo.";
                        }

                        break;
                    }
                }
            }

            grvSucursalesCheck.DataSource = (IList<Sucursal>)Session["Sucursales"];
            grvSucursalesCheck.DataBind();

            grvSucursales.DataSource = (IList<Sucursal>)Session["SucursalesLibres"];
            grvSucursales.DataBind();
        }

        #region Events

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            SessionDataHandler.RedireccionarFinSLA(Response, "", false);
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            CargarSucursalesSinGrupo();
            mpeCargando.Hide();
        }

        protected void DropDownList_DataBound(object sender, EventArgs e)
        {
            ((DropDownList)sender).Items.Insert(0, new ListItem("Ninguno", "-1"));
        }

        protected void btnContinue_OnClick(object sender, EventArgs e)
        {
            Continuar();
        }

        protected void chbGrupoClausula_OnCkeckedChanged(object sender, EventArgs e)
        {
            ActualizarGrillas();
        }

        #endregion

        #region GridEvents

        protected void grvSucursales_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Visible = false;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.background ='#ecf0f9'");
                e.Row.Attributes.Add("onmouseout", "this.style.background ='#ffffff'");
                e.Row.Cells[1].Visible = false;
            }
        }

        protected void grvSucursalesCheck_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Visible = false;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.background ='#ecf0f9'");
                e.Row.Attributes.Add("onmouseout", "this.style.background ='#ffffff'");
                e.Row.Cells[1].Visible = false;
                CheckBox chbGrupoClausula = (CheckBox)e.Row.FindControl("chbGrupoClausula");
                chbGrupoClausula.Checked = true;
            }
        }

        protected void grvSucursales_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrupoClausula Grupo = (GrupoClausula)Session[SessionDataHandler.GRUPO_CLAUSULAS];
            grvSucursales.PageIndex = e.NewPageIndex;

            CargarSucursalesSinGrupo();

            IList<int> IdsCuentas = new List<int>();
            foreach (ObjetoAgrupadorClausula Objeto in Grupo.Objetos)
            {
                IdsCuentas.Add(Objeto.IdObjetoAgrupador);
            }

            foreach (GridViewRow Row in grvSucursales.Rows)
            {
                ((CheckBox)Row.Cells[0].Controls[1]).Checked =
                    IdsCuentas.Contains(Convert.ToInt32(Row.Cells[1].Text));
            }
        }

        #endregion

        

    }
}