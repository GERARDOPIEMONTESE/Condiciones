using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Backend.Homes;
using Backend.Dominio;
using ControlMenu;
using Backend.DTO;

namespace Condiciones.GrupoClausulas
{
    public partial class ListaDeGrupoClausulas : CustomPage
    {
        protected override void CustomPageLoad(object sender, EventArgs e)
        {
            ValidarSession();
            BBuscar.Focus();
            if (!IsPostBack)
            {
                Session.Remove("Sucursales");
                CargarCombos();
                ObtenerEstadoControles();
                Buscar();
            }
        }

        #region Metodos Privados

        private void CargarCombos()
        {
            DdlPais.DataSource = PaisHome.Buscar();
            DdlPais.DataTextField = "Nombre";
            DdlPais.DataValueField = "Codigo";
            DdlPais.DataBind();

            DdlTipoGrupoClausula.DataSource = TipoGrupoClausulaHome.Buscar();
            DdlTipoGrupoClausula.DataTextField = "Nombre";
            DdlTipoGrupoClausula.DataValueField = "Id";
            DdlTipoGrupoClausula.DataBind();

        }

        private void ObtenerEstadoViewState(string Nombre, DropDownList DropDownList)
        {
            if (Session[Nombre] != null && !"".Equals(Session[Nombre]) && !"0".Equals(Session[Nombre]))
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
            ObtenerEstadoViewState("DdlTipoGrupoClausula", DdlTipoGrupoClausula);
            ObtenerEstadoViewState("DdlPais", DdlPais);
            CargarProductos();
            ObtenerEstadoViewState("DdlProducto", DdlProducto);
            ObtenerEstadoViewState("TbCodigoTarifa", TbCodigoTarifa);
            ObtenerEstadoViewState("TbSufijo", TbSufijo);
        }

        private void SetearEstadoControles()
        {
            Session["DdlTipoGrupoClausula"] = DdlTipoGrupoClausula.SelectedValue;
            Session["DdlPais"] = DdlPais.SelectedValue;
            Session["DdlProducto"] = DdlProducto.SelectedValue;
            Session["TbCodigoTarifa"] = TbCodigoTarifa.Text;
            Session["TbSufijo"] = TbSufijo.Text;
        }

        private GrupoClausula ObtenerGrupoClausula(int Index)
        {
            int Id = Convert.ToInt32(GvGruposClausulas.Rows[Index].Cells[0].Text);
            GrupoClausula Grupo = GrupoClausulaHome.Obtener(Id);

            return Grupo;

        }

        private void CargarProductos()
        {
            if (Session["DdlTipoGrupoClausula"] != null && Session["DdlPais"] != null)
            {
                DdlProducto.DataSource = ProductoHome.Buscar(Convert.ToInt32(Session["DdlPais"]), Convert.ToInt32(Session["DdlTipoGrupoClausula"]));
                DdlProducto.DataTextField = "CodigoYNombre";
                DdlProducto.DataValueField = "Id";
                DdlProducto.DataBind();

            }
        }

        private void BuscarProductos()
        {
            IList<Producto> products = ProductoHome.Buscar(Convert.ToInt32(DdlPais.SelectedValue), Convert.ToInt32(DdlTipoGrupoClausula.SelectedValue));
            if (Convert.ToInt32(DdlTipoGrupoClausula.SelectedValue) == TipoGrupoClausulaHome.ProductoSinEmision().Id)
            {
                
                IEnumerable<Producto> sortedEnum = products.OrderBy(f => f.Nombre);
                products = sortedEnum.ToList();
                DdlProducto.DataTextField = "NombreYCodigo";
            }
            else
            {
                DdlProducto.DataTextField = "CodigoYNombre";
            }
            DdlProducto.DataSource = products;
            DdlProducto.DataValueField = "Id";
            DdlProducto.DataBind();

        }

        private void Buscar()
        {
            string CodigoTarifa = TbCodigoTarifa.Visible ? TbCodigoTarifa.Text : DdlPlanes.SelectedValue;
            int Producto = (DdlProducto.SelectedValue == string.Empty) ? 0 : Convert.ToInt32(DdlProducto.SelectedValue);
            GvGruposClausulas.DataSource = GrupoClausulaHome.BuscarGrupoTarifa(Convert.ToInt32(DdlTipoGrupoClausula.SelectedValue), Convert.ToInt32(DdlPais.SelectedValue),
                Producto, TbSufijo.Text, CodigoTarifa);
            GvGruposClausulas.DataBind();

        }

        private void LimpiarSesion()
        {
            Session.Remove(SessionDataHandler.GRUPO_CLAUSULAS);
            Session.Remove(SessionDataHandler.PAIS);
            Session.Remove(SessionDataHandler.PRODUCTO);
            Session.Remove(SessionDataHandler.TIPO_GRUPO_CLAUSULA);
            Session.Remove(SessionDataHandler.ANUAL);
            Session.Remove(SessionDataHandler.DIAS_CONSECUTIVOS);
            Session.Remove(SessionDataHandler.CONTENIDO);
            Session.Remove(SessionDataHandler.TARIFAS);
            Session.Remove("items");
            Session.Remove("itemsDocumentos");
        }

        protected override void HabilitarControles()
        {
            BNuevo.Visible = PuedeEjecutarAccion(PermisosConstant.CREACION_GRUPOS);
        }


        #endregion

        #region Eventos Grilla

        protected void GvGruposClausulas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvGruposClausulas.PageIndex = e.NewPageIndex;
            Buscar();
        }

        protected void GvGruposClausulas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
                //Segun permisos del usuario logueado
                e.Row.Cells[9].Visible = PuedeEjecutarAccion(PermisosConstant.CREACION_GRUPOS);
                e.Row.Cells[10].Visible = e.Row.Cells[9].Visible;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.background ='#ecf0f9'");
                e.Row.Attributes.Add("onmouseout", "this.style.background ='#ffffff'");
                e.Row.Attributes.Add("ondblclick", "javascript:window.location.href='./GrupoClausula_Datos.aspx?modalidad=edit&Id=" + e.Row.Cells[0].Text + "';");
                e.Row.Cells[0].Visible = false;
                //Segun permisos del usuario logueado
                e.Row.Cells[9].Visible = PuedeEjecutarAccion(PermisosConstant.CREACION_GRUPOS);
                e.Row.Cells[10].Visible = e.Row.Cells[9].Visible;
            }
        }

        protected void GvGruposClausulas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Index = 0;
            int Id = 0;
            string CodigoTarifa = TbCodigoTarifa.Visible ? TbCodigoTarifa.Text : DdlPlanes.SelectedValue;
            int Producto = (DdlProducto.SelectedValue == string.Empty) ? 0 : Convert.ToInt32(DdlProducto.SelectedValue);

            switch (e.CommandName) 
            {
                case "Editar":
                    Index = Convert.ToInt32(e.CommandArgument);
                    LimpiarSesion();
                    Session["GrupoClausulas"] = ObtenerGrupoClausula(Index);
                    Response.Redirect("./GrupoClausula_Datos.aspx?modalidad=edit");
                    break;
                case "Eliminar":
                    Id = Int32.Parse(((Button)(e.CommandSource)).CommandArgument);
                    LimpiarSesion();
                    GrupoClausula Grupo = GrupoClausulaHome.Obtener(Id);
                    Grupo.IdUsuario = UsuarioLogueadoDTO() != null ? UsuarioLogueadoDTO().IdUsuario : -1;
                    Grupo.Eliminar();
                    Buscar();
                    break;
                case "Copiar":
                    Index = Convert.ToInt32(e.CommandArgument);
                    LimpiarSesion();
                    Session["GrupoClausulas"] = ObtenerGrupoClausula(Index).Copiar();
                    Response.Redirect("./GrupoClausula_Datos.aspx?modalidad=copy");
                    break;
                case "Export":
                    
                    List<GrupoClausulaTarifaDTO> source = (List<GrupoClausulaTarifaDTO>)GrupoClausulaHome.BuscarGrupoTarifa(Convert.ToInt32(DdlTipoGrupoClausula.SelectedValue), Convert.ToInt32(DdlPais.SelectedValue), Producto, TbSufijo.Text, CodigoTarifa);
                    ExportToExcel(source, CargarColumnas(GvGruposClausulas));
                    break;
                case "ExportToPDF":
                    
                    List<GrupoClausulaTarifaDTO> sourcepdf = (List<GrupoClausulaTarifaDTO>)GrupoClausulaHome.BuscarGrupoTarifa(Convert.ToInt32(DdlTipoGrupoClausula.SelectedValue), Convert.ToInt32(DdlPais.SelectedValue), Producto, TbSufijo.Text, CodigoTarifa);
                    ExportToPDF(sourcepdf, "nombrearchivo");
                    break;
            }
        }

        #endregion

        #region Eventos Boton

        protected void BNuevo_Click(object sender, EventArgs e)
        {
            LimpiarSesion();
            Session["GrupoClausulas"] = new GrupoClausula();
            Response.Redirect("./GrupoClausula_Datos.aspx?modalidad=new");
        }

        protected void BBuscar_Click(object sender, EventArgs e)
        {
            SetearEstadoControles();
            Buscar();
        }

        #endregion

        #region Eventos Combo


        protected void DropDownList_DataBoundEmptyCode(object sender, EventArgs e)
        {
            ((DropDownList)sender).Items.Insert(0, new ListItem("Todos", ""));            
        }

        protected void DdlTipoGrupoClausula_SelectedIndexChanged(object sender, EventArgs e)
        {
            LProducto.Text = "Producto: ";
            bool VisibleTarifa = true;
            DdlPlanes.Visible = false;

            if (TipoGrupoClausula.PRODUCTO_SIN_EMISION.Equals(DdlTipoGrupoClausula.SelectedItem.Text))
            {
                LProducto.Text = "Convenio/Negocio: ";
                VisibleTarifa = false;
                DdlPlanes.Visible = true;
            }
            if (TipoGrupoClausula.TARIFA_UPGRADE.Equals(DdlTipoGrupoClausula.SelectedItem.Text))
            {
                LProducto.Text = "Upgrade: ";
            }
            LSufijo.Visible = VisibleTarifa;
            TbSufijo.Visible = VisibleTarifa;
            LCodigoTarifa.Visible = VisibleTarifa;
            TbCodigoTarifa.Visible = VisibleTarifa;

            BuscarProductos();
        }

        protected void DdlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarProductos();
        }

        protected void DdlProducto_SelectedIndexChange(object sender, EventArgs e)
        {
            AceCodigoTarifa.ContextKey = DdlProducto.SelectedValue;

            Producto Producto = ProductoHome.Obtener(Convert.ToInt32(DdlProducto.SelectedValue));
            DdlPlanes.DataSource = TarifaHome.Buscar(Producto.CodigoPais, Producto.Id);
            DdlPlanes.DataBind();
            Buscar();
        }

        protected void DropDownList_DataBound(object sender, EventArgs e)
        {
            ((DropDownList)sender).Items.Insert(0, new ListItem("Todos", "0"));
        }
        #endregion

    }
}