using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControlMenu;
using Backend.Homes;
using Backend.Dominio;
using Backend.DTO;

namespace Condiciones.Consulta
{
    public partial class ListaDeGrupoCondiciones : CustomPage
    {
     
        protected override void CustomPageLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCombos();
                BBuscar.Focus();
            }
        }

        protected override void InitializeCulture()
        {
            var cCulture = new System.Globalization.CultureInfo("es-AR");

            string sIdioma = "1";

            if (!string.IsNullOrEmpty(Request.QueryString["lang"]))
            {
                sIdioma = Request.QueryString["lang"];
            }
            else if (UsuarioLogueadoDTO() != null)
            {
                sIdioma = IdiomaHome.Obtener(UsuarioLogueadoDTO().Ididioma).Id.ToString();
            }

            switch (sIdioma)
            {
                case "1":
                    cCulture = new System.Globalization.CultureInfo("es-AR");
                    break;
                case "2":
                    cCulture = new System.Globalization.CultureInfo("en-US");
                    break;
                case "3":
                    cCulture = new System.Globalization.CultureInfo("pt-BR");
                    break;
                default:
                    cCulture = new System.Globalization.CultureInfo("es-AR");
                    break;
            }
            
            System.Threading.Thread.CurrentThread.CurrentCulture = cCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = cCulture;
        }

        protected void GvGruposClausulas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvGruposClausulas.PageIndex = e.NewPageIndex;
            Buscar();
        }
        private void CargarCombos() 
        {
            string everyOne = GetLocalResourceObject("everyone").ToString();
            DdlPais.DataSource = Backend.Homes.PaisHome.Buscar();
            DdlPais.DataTextField = "Nombre";
            DdlPais.DataValueField = "Codigo";
            DdlPais.DataBind();
            DdlProducto.Items.Insert(0, new ListItem(everyOne, "0"));
            DdlUpgrade.Items.Insert(0, new ListItem(everyOne, "0"));
            DdlProductoSinEmision.Items.Insert(0, new ListItem(everyOne, "0"));

            string sIdioma = "1";
            if (!string.IsNullOrEmpty(Request.QueryString["lang"]))
            {
                sIdioma = Request.QueryString["lang"];
            }
            else if (UsuarioLogueadoDTO() != null)
            {
                sIdioma = IdiomaHome.Obtener(UsuarioLogueadoDTO().Ididioma).Id.ToString();
            }
            ddlIdioma.SelectedValue = sIdioma;
        }

        protected void GvGruposClausulas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.background ='#ecf0f9'");
                e.Row.Attributes.Add("onmouseout", "this.style.background ='#ffffff'");
                e.Row.Attributes.Add("onDblClick", "javascript:window.location.href='./InformacionGrupoCondiciones.aspx?IdGrupoClausula=" + e.Row.Cells[0].Text + "';");
                e.Row.Cells[0].Visible = false;
                GrupoClausulaTarifaDTO Grupo = (GrupoClausulaTarifaDTO)e.Row.DataItem;

                if (Grupo.NombreTipoGrupoClausula == "Producto Sin Emision")
                {
                    IList<Tarifa> Tarifas = TarifaHome.BuscarPorGrupo(Grupo.Id, Grupo.NombreTipoGrupoClausula);

                    ((System.Web.UI.WebControls.TableRow)(e.Row)).Cells[3].Text =                        
                        ((System.Web.UI.WebControls.TableRow)(e.Row)).Cells[3].Text.Substring(0, e.Row.Cells[3].Text.IndexOf("(")) 
                        + " / " + (Tarifas.Count > 0 ? Tarifas[0].Nombre : "-");
                }


                if (Grupo.NombreTipoGrupoClausula.ToLowerInvariant() == "producto")
                {
                    e.Row.Cells[1].Text = GetLocalResourceObject("prod").ToString();
                }
                if (Grupo.NombreTipoGrupoClausula.ToLowerInvariant() == "producto sin emision")
                {
                    e.Row.Cells[1].Text = GetLocalResourceObject("noEmisionProduct").ToString();
                }
                // si se pide rtaducir mas de modalidad, entonces habria que hacer tabla de idiomas
                if (Grupo.TipoModalidad.ToLowerInvariant() == "no aplica")
                {
                    e.Row.Cells[5].Text = GetLocalResourceObject("DontApply").ToString();
                }

            }
        }

        private GrupoClausula ObtenerGrupoClausula(int Index)
        {
            return GrupoClausulaHome.Obtener(Convert.ToInt32(GvGruposClausulas.Rows[Index].Cells[0].Text));
        }

        protected void GvGruposClausulas_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("VerDetalle"))
            {
                LimpiarSesion();
                Session["GrupoClausulas"] = ObtenerGrupoClausula(Index);
                Response.Redirect("./InformacionGrupoCondiciones.aspx?IdGrupoClausula=" + GvGruposClausulas.Rows[Index].Cells[0].Text + "&IdIdiomaGrupoClausula=" + ddlIdioma.SelectedItem.Value);
            }
        }

        private void LimpiarSesion()
        {
            Session.Remove("IdGrupoClausula");
            Session.Remove("GrupoClausulas");
        }

        protected void DdlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            string everyOne = GetLocalResourceObject("everyone").ToString();
            ListItem item = new ListItem(everyOne, "0");

            int CodigoPais = Convert.ToInt32(DdlPais.SelectedValue);
            DdlProducto.DataSource = ProductoHome.Buscar(CodigoPais, TipoGrupoClausulaHome.Producto().Id);
            DdlProducto.DataBind();
            
            DdlUpgrade.DataSource = ProductoHome.Buscar(CodigoPais, TipoGrupoClausulaHome.Upgrade().Id);
            DdlUpgrade.DataBind();

            DdlProductoSinEmision.DataSource = ProductoHome.BuscarOrdenadoNombre(CodigoPais, TipoGrupoClausulaHome.ProductoSinEmision().Id);
            DdlProductoSinEmision.DataBind();

            DdlProducto.Items.Insert(0,item);
            DdlUpgrade.Items.Insert(0, item);
            DdlProductoSinEmision.Items.Insert(0, item);
        }

        protected void DdlIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("ListaDeGrupoCondiciones.aspx?lang=" + ddlIdioma.SelectedItem.Value);
        }

        private int ObtenerIdProducto()
        {
            int IdProducto = Convert.ToInt32(DdlProducto.SelectedValue);
            IdProducto = IdProducto != 0 ? IdProducto : Convert.ToInt32(DdlUpgrade.SelectedValue);
            IdProducto = IdProducto != 0 ? IdProducto : Convert.ToInt32(DdlProductoSinEmision.SelectedValue);
            return IdProducto;
        }

        private void Buscar()
        {
            GvGruposClausulas.DataSource = GrupoClausulaHome.BuscarGrupoTarifa(0, Convert.ToInt32(DdlPais.SelectedValue),ObtenerIdProducto(), TbSufijo.Text);
            GvGruposClausulas.DataBind();
        }

        protected void BBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}