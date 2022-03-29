using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControlMenu;
using AjaxControlToolkit;
using Backend.DTO;
using Backend.Homes;
using Backend.Dominio;
using System.Configuration;

namespace Condiciones.Consulta
{
    public partial class InformacionGrupoCondiciones : CustomPage
    {
        protected override void CustomPageLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["IdGrupoClausula"] = Convert.ToInt32(Request.QueryString["IdGrupoClausula"]);
                Session["IdIdiomaGrupoClausula"] = Convert.ToInt32(Request.QueryString["IdIdiomaGrupoClausula"]);
                Inicializar();
            }
        }

        private void Inicializar()
        {
            GrupoClausula Grupo = Session["GrupoClausulas"] != null ?(GrupoClausula)Session["GrupoClausulas"] : GrupoClausulaHome.Obtener((int)Session["IdGrupoClausula"]);
            int idIdioma = (int)Session["IdIdiomaGrupoClausula"];
            if (idIdioma == 0) 
            {
                idIdioma = 1;
                idIdioma = UsuarioLogueadoDTO() != null ? UsuarioLogueadoDTO().Ididioma : idIdioma;
            }

            LBusinessPlan.Visible = true;
            
            Tarifa Tarifa = TarifaHome.Obtener(Grupo.Objetos[0].IdObjetoAgrupador);
            Producto Producto = ProductoHome.Obtener(Tarifa.IdProducto);

            LBusinessPlan.Text = (TipoGrupoClausulaHome.ProductoSinEmision().Id == Grupo.TipoGrupoClausula.Id)
                ? "Business: " + Producto.Nombre + " / Plan: " + Tarifa.Nombre
                : "Product: " + Producto.Nombre + " / Suffix: " + (Tarifa.Sufijo == null || Tarifa.Sufijo.Length == 0 ? "-" : Tarifa.Sufijo);
            
            //(int)Idioma.Idiomas.Español
            ACondiciones.DataSource = GrupoCondicionesHome.Buscar((int)Session["IdGrupoClausula"], idIdioma);
            ACondiciones.DataBind();

            AAyuda.DataSource = AyudaHome.Buscar();
            AAyuda.DataBind();

            CargarDocumentos(Grupo);            
        }

        protected override void InitializeCulture()
        {
            var cCulture = new System.Globalization.CultureInfo("es-AR");
            Session["IdIdiomaGrupoClausula"] = Convert.ToInt32(Request.QueryString["IdIdiomaGrupoClausula"]);

            switch (Session["IdIdiomaGrupoClausula"].ToString())
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

        protected void ACondiciones_ItemDataBound(object sender, AjaxControlToolkit.AccordionItemEventArgs e)
        {
            if (e.ItemType == AjaxControlToolkit.AccordionItemType.Content)
            {
                GrupoCondicionesDTO GrupoClausulaDTO = (GrupoCondicionesDTO)e.Item;
                GridView GvCondiciones = (GridView)e.AccordionItem.FindControl("GvCondiciones");
                GvCondiciones.DataSource = GrupoClausulaDTO.Rangos;
                GvCondiciones.DataBind();
            }
        }

        protected void AAyuda_ItemDataBound(object sender, AjaxControlToolkit.AccordionItemEventArgs e)
        {
            if (e.ItemType == AjaxControlToolkit.AccordionItemType.Content)
            {
                Ayuda Ayuda = (Ayuda)e.Item;
                Label LNombre = (Label)e.AccordionItem.FindControl("LNombre");
                LNombre.Text = Ayuda.Descripcion;
            }
        }

        protected void GvCondiciones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.background ='#ecf0f9'");
                e.Row.Attributes.Add("onmouseout", "this.style.background ='#ffffff'");

                var item = (GrupoCondicionesRangoDTO)e.Row.DataItem;

                if (item.TipoPlan.ToLowerInvariant() == "todos")
                {
                    e.Row.Cells[2].Text = GetLocalResourceObject("All").ToString();
                }
                if (item.TipoPlan.ToLowerInvariant() == "plan familiar")
                {
                    e.Row.Cells[2].Text = GetLocalResourceObject("FamilyPlan").ToString();
                }
                // si se pide rtaducir mas de modalidad, entonces habria que hacer tabla de idiomas
                if (item.TipoModalidad.ToLowerInvariant() == "no aplica")
                {
                    e.Row.Cells[3].Text = GetLocalResourceObject("DontApply").ToString();
                }
            }
        }

        protected void BVolver_Click(object sender, EventArgs e)
        {
            Session.Remove("IdGrupoClausula");
            Response.Redirect("./ListaDeGrupoCondiciones.aspx?lang=" + Request.QueryString["IdIdiomaGrupoClausula"]);
        }

        protected void BIHelp_Click(object sender, EventArgs e)
        {
            AAyuda.Visible = !AAyuda.Visible;
        }

        protected void dlDocumentos_OnItemDataBound(object sender, DataListItemEventArgs e)
        {
            AsociacionDocumento documento = (AsociacionDocumento)e.Item.DataItem;
            HyperLink HlDocumento = (HyperLink)e.Item.FindControl("HlDocumento");
            HlDocumento.Text = documento.Documento.Nombre;
            HlDocumento.NavigateUrl = ConfigurationManager.AppSettings["URLDocumentos"].Replace("%documento%", documento.Documento.Id + "&").Replace("%codigoverificacion%", documento.Documento.CodigoValidacion.ToString());

            Label LIdiomaDocumento = (Label)e.Item.FindControl("LIdiomaDocumento");
            LIdiomaDocumento.Text = documento.Documento.Idioma.Nombre;
        }

        private void CargarDocumentos(GrupoClausula Grupo)
        {
            if (Grupo == null || Grupo.Documentos == null)
                return;

            if (Grupo.Documentos.Count == 0)
            {
                ObjetoAgrupadorClausula Objeto = Grupo.Objetos[0];

                Tarifa Tarifa = TarifaHome.Obtener(Objeto.IdObjetoAgrupador);

                Grupo.Documentos = AsociacionDocumentoHome.Buscar(Tarifa.IdProducto, TipoAsociacionDocumentoHome.Producto().Id);

                if (Grupo.Documentos.Count == 0)                
                    Grupo.Documentos = AsociacionDocumentoHome.Buscar(Tarifa.CodigoPais, TipoAsociacionDocumentoHome.Pais().Id);                
            }

            DlLinks.DataSource = Grupo.Documentos;
            DlLinks.DataBind();
        }

        protected void BVerDocumentos_Click(object sender, EventArgs e)
        {
            MpeDocumentos.Show();
        }
    }
}
