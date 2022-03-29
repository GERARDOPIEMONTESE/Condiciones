using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using ControlMenu;
using Backend.Homes;
using Backend.DTO;
using System.Linq.Expressions;

namespace Condiciones
{
    public partial class ListaDeClausulas : CustomPage
    {

        protected  override void CustomPageLoad(object sender, EventArgs e)
        {
            ValidarSession();
            bBuscar.Focus();
            if (!IsPostBack)
            {
                CargarCombos();
                Buscar();
            }
        }

        #region "Metodos Privados"

        private void CargarCombos()
        {
            DdlTipoClausula.DataSource = TipoClausulaHome.Buscar();
            DdlTipoClausula.DataTextField = "Nombre";
            DdlTipoClausula.DataValueField = "Id";
            DdlTipoClausula.DataBind();
            DdlTipoClausula.Items.Insert(0, new ListItem("", "-1"));

        }

        public void Buscar()
        {
            int IdTipoClausula = Convert.ToInt32(DdlTipoClausula.SelectedValue);
            string codigo = TbCodigo.Text == "" ? null : TbCodigo.Text;
            string nombre = TbNombre.Text == "" ? null : TbNombre.Text;

            IList<ClausulaIdiomaDTO> IClausulaIdiomaDTO = ClausulaHome.BuscarDTOPorParametros(IdTipoClausula, codigo, nombre);
            IList<ClausulaIdiomaDTO> sortedList = IClausulaIdiomaDTO;

            if (ViewState["_Direction_"] != null && ViewState["_Expresion_"] != null)
            {
                SortDirection Direction = (SortDirection)ViewState["_Direction_"];

                var prm = Expression.Parameter(typeof(ClausulaIdiomaDTO), "root");
                sortedList = new Sorter<ClausulaIdiomaDTO>().Sort(IClausulaIdiomaDTO, prm, (string)ViewState["_Expresion_"], Direction);
            }

            GvClausula.DataSource = sortedList;
            GvClausula.DataBind();
        }

        private void LimpiarSesion()
        {
            Session.Remove("IdClausula");
        }

        #endregion

        #region "Eventos de Botones"

        protected void bBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        protected void bAgregar_Click(object sender, EventArgs e)
        {
            LimpiarSesion();
            Response.Redirect("./InformacionDeClausula.aspx");
        }

        #endregion

        #region "Eventos de la Grilla"

        protected void GvClausula_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["_Direction_"] == null)
                ViewState["_Direction_"] = e.SortDirection;

            ViewState["_Expresion_"] = e.SortExpression;

            if ((SortDirection)ViewState["_Direction_"] == SortDirection.Descending)
                ViewState["_Direction_"] = SortDirection.Ascending;
            else
                ViewState["_Direction_"] = SortDirection.Descending;

            Buscar();
        }

        protected void GvClausula_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.background ='#ecf0f9'");
                e.Row.Attributes.Add("onmouseout", "this.style.background ='#ffffff'");
                e.Row.Attributes.Add("onDblClick", "javascript:window.location.href='./InformacionDeClausula.aspx?Id=" + e.Row.Cells[0].Text + "';");
                e.Row.Cells[0].Visible = false;
            }
        }

        protected void GvClausula_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Index;

            if (e.CommandName.Equals("Editar"))
            {
                if (Int32.TryParse((string)e.CommandArgument, out Index))
                {
                    LimpiarSesion();
                    Response.Redirect("./InformacionDeClausula.aspx?Id=" + GvClausula.Rows[Index].Cells[0].Text);
                }
            }
            if (e.CommandName == "Export")
            {
                int IdTipoClausula = Convert.ToInt32(DdlTipoClausula.SelectedValue);
                string codigo = TbCodigo.Text == "" ? null : TbCodigo.Text;
                string nombre = TbNombre.Text == "" ? null : TbNombre.Text;

                IList<ClausulaIdiomaDTO> IClausulaIdiomaDTO = ClausulaHome.BuscarDTOPorParametros(IdTipoClausula, codigo, nombre);
                IList<ClausulaIdiomaDTO> sortedList = IClausulaIdiomaDTO;

                if (ViewState["_Direction_"] != null && ViewState["_Expresion_"] != null)
                {
                    SortDirection Direction = (SortDirection)ViewState["_Direction_"];

                    var prm = Expression.Parameter(typeof(ClausulaIdiomaDTO), "root");
                    sortedList = new Sorter<ClausulaIdiomaDTO>().Sort(IClausulaIdiomaDTO, prm, (string)ViewState["_Expresion_"], Direction);
                }

                List<ClausulaIdiomaDTO> list = (List<ClausulaIdiomaDTO>)sortedList;
                ExportToExcel(list, CargarColumnas(GvClausula));
            }
        }
        protected void GvClausula_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvClausula.PageIndex = e.NewPageIndex;
            Buscar();
        }

        #endregion





        

      

       

    }
}
