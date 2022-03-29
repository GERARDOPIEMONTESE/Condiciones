using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControlMenu;
using Backend.Homes;
using System.Linq.Expressions;


namespace Condiciones
{
    public partial class ListaDeDocumentos : CustomPage
    {

        protected override void CustomPageLoad(object sender, EventArgs e)
        {
            ValidarSession();
            if (!IsPostBack)
            {
                CargarCombos();
                ObtenerEstadoControles();
                Bind();
            }
        }

        private void CargarCombos()
        {
            DdlTipoDocumento.DataSource = Backend.Homes.TipoDocumentoHome.Buscar();
            DdlTipoDocumento.DataTextField = "Nombre";
            DdlTipoDocumento.DataValueField = "Id";
            DdlTipoDocumento.DataBind();
            DdlTipoDocumento.Items.Insert(0,new ListItem("", "-1"));
        }

        #region Eventos Boton

        protected void bBuscar_Click(object sender, EventArgs e)
        {
            SetearEstadoControles();
            Bind();
        }

        protected void bAgregar_Click(object sender, EventArgs e)
        {
            LimpiarSesion();
            Response.Redirect("./InformacionDeDocumento.aspx");
        }

        #endregion

        #region Eventos Grilla

        protected void GvDocumento_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.background ='#ecf0f9'");
                e.Row.Attributes.Add("onmouseout", "this.style.background ='#ffffff'");
                e.Row.Attributes.Add("onDblClick", "javascript:window.location.href='./InformacionDeDocumento.aspx?Id=" + e.Row.Cells[0].Text + "';");
                e.Row.Cells[0].Visible = false;
            }
        }

        protected void GvDocumento_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int Index;

            if (e.CommandName.Equals("Editar"))
            {
                if (Int32.TryParse((string)e.CommandArgument, out Index))
                {
                    LimpiarSesion();
                    Response.Redirect("./InformacionDeDocumento.aspx?Id=" + GvDocumento.Rows[Index].Cells[0].Text);
                }
            }
            if (e.CommandName == "Export") 
            {
                int IdTipoDocumento = Convert.ToInt32(DdlTipoDocumento.SelectedValue);
                string Nombre = TbNombre.Text == "" ? null : TbNombre.Text;

                IList<Backend.Dominio.Documento> IDocumento = DocumentoHome.BuscarPorParametros(IdTipoDocumento, Nombre);
                IList<Backend.Dominio.Documento> sortedList = IDocumento;

                if (ViewState["_Direction_"] != null && ViewState["_Expresion_"] != null)
                {
                    SortDirection Direction = (SortDirection)ViewState["_Direction_"];

                    var prm = Expression.Parameter(typeof(Backend.Dominio.Documento), "root");
                    sortedList = new Sorter<Backend.Dominio.Documento>().Sort(IDocumento, prm, (string)ViewState["_Expresion_"], Direction);
                }

               List<Backend.Dominio.Documento> List = (List<Backend.Dominio.Documento>) sortedList;
               ExportToExcel(List, CargarColumnas(GvDocumento));
            }
        }

        protected void GvDocumento_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["_Direction_"] == null)
                ViewState["_Direction_"] = e.SortDirection;

            ViewState["_Expresion_"] = e.SortExpression;

            if ((SortDirection)ViewState["_Direction_"] == SortDirection.Descending)
                ViewState["_Direction_"] = SortDirection.Ascending;
            else
                ViewState["_Direction_"] = SortDirection.Descending;

            Bind();
        }


        protected void GvDocumento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvDocumento.PageIndex = e.NewPageIndex;
            Bind();
        }

        #endregion

        #region Eventos Privados
        private void LimpiarSesion()
        {
            Session.Remove("DocumentoAbm");
            Session.Remove("AsociacionesDocumentoPaises");
            Session.Remove("AsociacionesDocumentoProductos");
            Session.Remove("AsociacionesDocumentoGruposClausulas");
        }

        private void ObtenerEstadoViewState(string Nombre, DropDownList DropDownList)
        {
            if (Session[Nombre] != null && !"-1".Equals(Session[Nombre].ToString()))
            {
                DropDownList.SelectedValue = Session[Nombre].ToString();
            }
        }

        private void ObtenerEstadoViewState(string Nombre, TextBox TextBox)
        {
            if (Session[Nombre] != null)
            {
                TextBox.Text = Session[Nombre].ToString();
            }
        }

        private void ObtenerEstadoControles()
        {
            ObtenerEstadoViewState("Documento_DdlTipoDocumento", DdlTipoDocumento);
            ObtenerEstadoViewState("Documento_TbNombre", TbNombre);
        }

        private void SetearEstadoControles()
        {
            Session["Documento_DdlTipoDocumento"] = DdlTipoDocumento.SelectedValue;
            Session["Documento_TbNombre"] = TbNombre.Text;
        }

        #endregion

        

        public void Bind()
        {
            int IdTipoDocumento = Convert.ToInt32(DdlTipoDocumento.SelectedValue);
            string Nombre = TbNombre.Text == "" ? null : TbNombre.Text;

            IList<Backend.Dominio.Documento> IDocumento = DocumentoHome.BuscarPorParametros(IdTipoDocumento, Nombre);
            IList<Backend.Dominio.Documento> sortedList = IDocumento;
            
            if (ViewState["_Direction_"] != null && ViewState["_Expresion_"] != null)
            {
                SortDirection Direction = (SortDirection)ViewState["_Direction_"];

                var prm = Expression.Parameter(typeof(Backend.Dominio.Documento), "root");
                sortedList = new Sorter<Backend.Dominio.Documento>().Sort(IDocumento, prm, (string)ViewState["_Expresion_"], Direction);
            }

            GvDocumento.DataSource = sortedList;
            GvDocumento.DataBind();
        }

        

      
    }
}
