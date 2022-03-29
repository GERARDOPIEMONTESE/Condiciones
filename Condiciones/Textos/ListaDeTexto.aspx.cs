using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Backend.Dominio;
using Backend.Homes;
using ControlMenu;
using System.Linq.Expressions;


namespace Condiciones
{
    public partial class ListaDeTextoResumen : CustomPage
    {
        private const string EDITAR = "Editar";

        private const string ELIMINAR = "Eliminar";

        protected override void CustomPageLoad(object sender, EventArgs e)
        {
            ValidarSession();
            if (!IsPostBack)
            {
                TipoTexto TipoTexto = TipoTextoHome.Obtener(
                    Request.QueryString[SessionDataHandler.TIPO_TEXTO] != null ?
                    Request.QueryString[SessionDataHandler.TIPO_TEXTO] :
                    TipoTexto.CODIGO_RESUMEN_BENEFICIOS);
                Session[SessionDataHandler.TIPO_TEXTO] = TipoTexto;

                LSiteMap.Text = ": " + TipoTexto.Nombre;

                CargarIdiomas();
                Bind();
            }
        }

        protected void bBuscar_Click(object sender, EventArgs e)
        {
            Bind();
        }

        private void CargarIdiomas()
        {
            DdlIdioma.DataSource = IdiomaHome.Buscar();
            DdlIdioma.DataBind();
        }

        protected void bAgregar_Click(object sender, EventArgs e)
        {
            LimpiarSesion();
            Response.Redirect("./InformacionDeTexto.aspx?TipoTexto=" + SessionDataHandler.TipoTexto(Session).Codigo);
        }

        public void Bind()
        {
            IList<Texto> ITexto = TextoHome.BuscarPorParametros(TbNombre.Text, SessionDataHandler.TipoTexto(Session).Id, Int32.Parse(DdlIdioma.SelectedValue));
            IList<Texto> sortedList = ITexto;   

            if (ViewState["_Direction_"] != null && ViewState["_Expresion_"] != null)
            {
                SortDirection Direction = (SortDirection)ViewState["_Direction_"];

                var prm = Expression.Parameter(typeof(Texto), "root");
                sortedList = new Sorter<Texto>().Sort(ITexto, prm, (string)ViewState["_Expresion_"], Direction);
            }

            GvTextoResumen.DataSource = sortedList;
            GvTextoResumen.DataBind();
        }

        protected void GvTextoResumen_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvTextoResumen.PageIndex = e.NewPageIndex;
            Bind();
        }

        private void LimpiarSesion()
        {
            Session.Remove("Texto");
        }

        protected void GvTextoResumen_Sorting(object sender, GridViewSortEventArgs e)
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

        protected void GvTextoResumen_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Index;

            if (Int32.TryParse((string)e.CommandArgument, out Index))
            {
                if (e.CommandName.Equals(EDITAR))
                {
                    LimpiarSesion();
                    Response.Redirect(
                        "./InformacionDeTexto.aspx?TipoTexto=" + SessionDataHandler.TipoTexto(Session).Codigo
                        + "&Id=" + GvTextoResumen.Rows[Index].Cells[0].Text);
                }

                if (e.CommandName.Equals(ELIMINAR))
                {
                    int IdTexto = Convert.ToInt32(GvTextoResumen.Rows[Index].Cells[0].Text);

                    Texto Texto = TextoHome.Obtener(IdTexto);
                    Texto.IdUsuario = UsuarioLogueadoDTO() != null ? 
                        UsuarioLogueadoDTO().IdUsuario : -1;

                    Texto.Eliminar();
                    Bind();
                }
            }
        }

        protected void GvTextoResumen_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onDblClick", "javascript:window.location.href='InformacionDeTexto.aspx?TipoTexto=" + SessionDataHandler.TipoTexto(Session).Codigo + "&Id=" + e.Row.Cells[0].Text + "';");
                e.Row.Cells[0].Visible = false;
            }
        }

    }
}
