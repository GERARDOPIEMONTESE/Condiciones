using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocioDatos.CapaHome;
using CapaNegocioDatos.Servicios;
using ControlMenu;
using CapaNegocioDatos.DTO;
using Backend.Homes;
using Backend.Dominio;

namespace Condiciones
{
    public partial class RiesgosDeTerceros : CustomPage
    {
        private const string EDITAR = "Editar";
        private const string ELIMINAR = "Eliminar";
        private const string EXPORTAR = "Export";

        protected override void CustomPageLoad(object sender, EventArgs e)
        {
            ValidarSession();
            if (!IsPostBack)
            {
                InicializarControles();
            }
        }

        private void InicializarControles()
        {
            DdlPais.DataSource = Backend.Homes.PaisHome.Buscar();
            DdlPais.DataTextField = "Nombre";
            DdlPais.DataValueField = "Codigo";
            DdlPais.DataBind();

            DdlCompaniaSeguro.DataSource = CompaniaSeguroHome.Buscar();
            DdlCompaniaSeguro.DataTextField = "Descripcion";
            DdlCompaniaSeguro.DataValueField = "Id";
            DdlCompaniaSeguro.DataBind();
            DdlCompaniaSeguro.Items.Insert(0, new ListItem("Todos", "0"));

            DdlTipoNegocio.DataSource = TipoGrupoClausulaHome.Buscar();
            DdlTipoNegocio.DataTextField = "Nombre";
            DdlTipoNegocio.DataValueField = "Id";
            DdlTipoNegocio.DataBind();
            DdlTipoNegocio.Items.Insert(0, new ListItem("Todos", "0"));

            string itemText = DdlTipoNegocio.Items.FindByValue("12").Text;
            ListItem li = new ListItem();
            li.Text = itemText;
            li.Value = "12";
            DdlTipoNegocio.Items.Remove(li);
            BExcel.Visible = false;
            LblRiesgosEmpty.Visible = true;
        }

        protected void BBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }
        protected void BAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("./RiesgoDeTercerosAdd.aspx");
        }

        private void Buscar()
        {
            string TipoNegocio = null;
            int? IdCompaniaSeguro = null;
            if (DdlTipoNegocio.SelectedItem.Text != "Todos") TipoNegocio = DdlTipoNegocio.SelectedItem.Text;
            if (DdlCompaniaSeguro.SelectedValue != "0") IdCompaniaSeguro = Convert.ToInt32(DdlCompaniaSeguro.SelectedValue.ToString());

            if (DdlPais.SelectedValue != "0")
            {
                var riesgoterceros = RiesgoTercerosHome.Buscar(Convert.ToInt32(DdlPais.SelectedValue), TipoNegocio, IdCompaniaSeguro);

                if (riesgoterceros.Count > 0)
                {
                    grvListaRiesgoTerceros.PageSize = riesgoterceros.Count();
                    grvListaRiesgoTerceros.DataSource = riesgoterceros;
                    grvListaRiesgoTerceros.PageIndex = 0;
                    grvListaRiesgoTerceros.DataBind();
                    grvListaRiesgoTerceros.AllowPaging = true;

                    LblRiesgosEmpty.Visible = false;
                    grvListaRiesgoTerceros.Visible = true;
                    BExcel.Visible = true;

                }
                else {
                    LblRiesgosEmpty.Visible = true;
                    grvListaRiesgoTerceros.Visible = false;
                    BExcel.Visible = false;
                }
            }
        }
        #region GridViewEvents

        protected void grvListaRiesgoTerceros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvListaRiesgoTerceros.PageIndex = e.NewPageIndex;
            this.Buscar();
        }
        protected void grvListaRiesgoTerceros_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.Cells[0].Visible = false;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.background ='#ecf0f9'");
                e.Row.Attributes.Add("onmouseout", "this.style.background ='#ffffff'");
                e.Row.Attributes.Add("onDblClick", "javascript:window.location.href='./RiesgoDeTercerosAdd.aspx?Id=" + e.Row.Cells[0].Text + "';");
                e.Row.Cells[0].Visible = false;
            }
        }
        protected void grvListaRiesgoTerceros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals(EDITAR))
            {
                int Index;
                if (Int32.TryParse((string)e.CommandArgument, out Index))

                    Response.Redirect(
                        "./RiesgoDeTercerosAdd.aspx?Id=" + grvListaRiesgoTerceros.Rows[Index].Cells[0].Text);
            }
            if (e.CommandName.Equals(ELIMINAR))
            {
                int Index;
                if (Int32.TryParse((string)e.CommandArgument, out Index)) ;
                RiesgoTerceros riesgoterceros = RiesgoTercerosHome.Obtener(Convert.ToInt32(grvListaRiesgoTerceros.Rows[Index].Cells[0].Text));


                riesgoterceros.IdUsuario = UsuarioLogueadoDTO() != null ?
                    UsuarioLogueadoDTO().IdUsuario : -1;

                riesgoterceros.Eliminar();
            }

            if (e.CommandName.Equals(EXPORTAR))
            {
                string TipoNegocio = null;
                int? IdCompaniaSeguro = null;
                if (DdlTipoNegocio.SelectedItem.Text != "Todos") TipoNegocio = DdlTipoNegocio.SelectedItem.Text;
                if (DdlCompaniaSeguro.SelectedValue != "0") IdCompaniaSeguro = Convert.ToInt32(DdlCompaniaSeguro.SelectedValue.ToString());

                var promocionesCuenta = (GridView)FindControl("grvListaRiesgoTerceros");

                IList<RiesgoTerceros> list = RiesgoTercerosHome.Buscar(Convert.ToInt32(DdlPais.SelectedValue), TipoNegocio, IdCompaniaSeguro);
                IList<RiesgoTerceros> excelList = new List<RiesgoTerceros>();
                foreach (RiesgoTerceros dto in list)
                {
                    excelList.Add(dto);
                }

                ExportToExcel(excelList, CargarColumnas(promocionesCuenta), "RiesgoTerceros.xls");
            }





            //if (e.CommandName == "Export")
            //{
            //    var promocionesCuenta = (GridView)FindControl("grvPromocionesCuenta");
            //    int IdLocacion = Convert.ToInt32(ddlLocacion.SelectedValue);
            //    int IdPromotor = Convert.ToInt32(ddlPromotor.SelectedValue);
            //    int IdTipoBonificacion = Convert.ToInt32(ddlTipoBonificacion.SelectedValue);
            //    int IdZona = Convert.ToInt32(ddlZona.SelectedValue);

            //    IList<CuentaComisionDTO> list = CuentaComisionDTOHome.Buscar(IdLocacion, IdPromotor, IdTipoBonificacion, IdZona);
            //    IList<CuentaComisionExcelDTO> excelList = new List<CuentaComisionExcelDTO>();
            //    CuentaComisionExcelDTO item;
            //    foreach (CuentaComisionDTO dto in list)
            //    {
            //        item = new CuentaComisionExcelDTO(dto);
            //        excelList.Add(item);
            //    }

            //    ExportToExcel(excelList, CargarColumnas(promocionesCuenta), "ClientesBonificacion.xls");
            //}
        }

        #endregion

        protected void Excel_Click(object sender, EventArgs e)
        {
            string TipoNegocio = null;
            int? IdCompaniaSeguro = null;
            if (DdlTipoNegocio.SelectedItem.Text != "Todos") TipoNegocio = DdlTipoNegocio.SelectedItem.Text;
            if (DdlCompaniaSeguro.SelectedValue != "0") IdCompaniaSeguro = Convert.ToInt32(DdlCompaniaSeguro.SelectedValue.ToString());

            var promocionesCuenta = (GridView)FindControl("grvListaRiesgoTerceros");

            IList<RiesgoTerceros> list = RiesgoTercerosHome.Buscar(Convert.ToInt32(DdlPais.SelectedValue), TipoNegocio, IdCompaniaSeguro);
            IList<RiesgoTerceros> excelList = new List<RiesgoTerceros>();
            foreach (RiesgoTerceros dto in list)
            {
                excelList.Add(dto);
            }

            ExportToExcel(excelList, CargarColumnas(promocionesCuenta), "RiesgoTerceros.xls");
        }
    }
}