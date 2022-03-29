using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using Backend.Dominio;
using Backend.Homes;
using System.Web.Services;
using System.Web.Script.Services;
using ControlMenu;
using System.Collections;


namespace Condiciones.GrupoClausulas
{
    public partial class GrupoClausula_Datos : CustomPage
    {
        private enum TipoFiltroTarifa
        {
            NoCheck = 0,
            Check,
            Todos
        };

        private const string URL_PASO2 = "GrupoClausula_Clausulas.aspx?init=true";

        protected override void CustomPageLoad(object sender, EventArgs e)
        {
            ValidarSession();
            if (!IsPostBack)
            {
                Session["Modalidad"] = Request.QueryString["modalidad"];

                //Si es una copia o una edicion cargo los datos
                if (Session["Modalidad"] != null && !Session["Modalidad"].Equals("new") && Session["Modalidad"] != null)
                {
                    if ((Request.QueryString["Id"] != null) && (Session["GrupoClausulas"] == null))
                        Session["GrupoClausulas"] = GrupoClausulaHome.Obtener(Convert.ToInt32(Request.QueryString["Id"]));
                    
                    GrupoClausula Grupo = (GrupoClausula)Session["GrupoClausulas"];
                    CargarDatosGrupo(Grupo);
                }
            }
        }

        private void CargarDatosGrupo(GrupoClausula Grupo)
        {
            if (Grupo.Objetos.Count > 0)
            {
                
                Tarifa Tarifa = TarifaHome.Obtener(Grupo.Objetos[0].IdObjetoAgrupador);

                DdlPais.SelectedValue = Tarifa.CodigoPais.ToString();
                CbAnual.Checked = Grupo.Anual;

                DdlProducto.DataSource = ProductoHome.Buscar(Tarifa.CodigoPais, Tarifa.IdTipoGrupoClausula);
                DdlProducto.DataBind();

                DdlProducto.SelectedValue = Tarifa.IdProducto.ToString();
                string sufijo = TbSufijo.Text == "" ? null : TbSufijo.Text;
                IList<Tarifa> ITarifas = BuscarTarifas(Tarifa.CodigoPais, Tarifa.IdProducto, Grupo.Id, Grupo.TipoGrupoClausula.Id, sufijo);

                CargarTarifas(GvTarifas, FiltrarTarifas(ITarifas, Grupo, TipoFiltroTarifa.NoCheck), true, ITarifas.Count != 0 ? ITarifas[0].Sufijo : string.Empty);
                CargarTarifas(GvTarifasCheck, FiltrarTarifas(ITarifas, Grupo, TipoFiltroTarifa.Check), false, string.Empty);

                IList<int> IdsTarifas = new List<int>();

                foreach (ObjetoAgrupadorClausula Objeto in Grupo.Objetos)
                {
                    IdsTarifas.Add(Objeto.IdObjetoAgrupador);
                }

                foreach (GridViewRow Row in GvTarifasCheck.Rows)
                {
                    ((CheckBox)Row.Cells[0].Controls[1]).Checked =
                        IdsTarifas.Contains(Convert.ToInt32(Row.Cells[1].Text));
                }
            }

            DdlTipoGrupoClausula.SelectedValue = Grupo.TipoGrupoClausula.Id.ToString();

            DdlTipoGrupoClausula.Enabled = Grupo.Id == 0;
            DdlPais.Enabled = Grupo.Id == 0;
            CbAnual.Enabled = Grupo.Id == 0;
            DdlProducto.Enabled = Grupo.Id == 0;
        }

        protected void BCancelar_Click(object sender, EventArgs e)
        {
            if (Session[SessionDataHandler.SUCURSALES] != null)
                SessionDataHandler.RedireccionarFinSLA(Response, "", true);
            else
                SessionDataHandler.RedireccionarFin(Response, "");
        }

        protected void BBuscar_Click(object sender, EventArgs e)
        {
            CargarTarifas(TipoFiltroTarifa.Todos);
        }

        protected void BContinuar_Click(object sender, EventArgs e)
        {
            try
            {
                LErrorTarifas.Visible = false;
                Session["Pais"] = Convert.ToInt32(DdlPais.SelectedValue);
                Session["Anual"] = CbAnual.Checked;
                Session["Producto"] = ProductoHome.Obtener(Convert.ToInt32(DdlProducto.SelectedValue));
                Session["IsSLA"] = false;
                Session["TipoGrupoClausula"] = TipoGrupoClausulaHome.Obtener(Convert.ToInt32(DdlTipoGrupoClausula.SelectedValue));
                Session["DiasConsecutivos"] = 0;

                IList<Tarifa> ITarifas = new List<Tarifa>();

                foreach (GridViewRow Row in GvTarifasCheck.Rows)
                {
                    if (Row.RowState == DataControlRowState.Normal || Row.RowState == DataControlRowState.Alternate)
                    {
                        if (((CheckBox)Row.Cells[0].Controls[1]).Checked)
                        {
                            Tarifa Tarifa = TarifaHome.Obtener(Convert.ToInt32(Row.Cells[1].Text));
                            Validar(Tarifa);
                            ITarifas.Add(Tarifa);
                        }
                    }
                }

                RememberOldValues();
                if (Session["items"] != null)
                {
                    foreach (int dato in (ArrayList)Session["items"])
                    {
                        Tarifa Tarifa = TarifaHome.Obtener(dato);
                        Validar(Tarifa);
                        ITarifas.Add(Tarifa);
                    }
                }

                Session["Tarifas"] = ITarifas;

                if (ITarifas.Count > 0)
                {
                    Response.Redirect(URL_PASO2);
                }
                else
                {
                    CVSeleccionTarifas.IsValid = false;
                    CVSeleccionTarifas.Visible = true;                    
                }
            }
            catch (Exception ex)
            {
                LErrorTarifas.Visible = true;
                LErrorTarifas.Text = ex.Message;
            }
        }

        private void Validar(Tarifa Tarifa)
        {
            TipoGrupoClausula TipoGrupoClausula = (TipoGrupoClausula)Session["TipoGrupoClausula"];

            if (Session["Modalidad"] != null && !Session["Modalidad"].Equals("edit") && GrupoClausulaHome.Existe(Tarifa, TipoGrupoClausula))
            {
                throw new Exception("Ya existe grupo activo para tarifa " + Tarifa.Nombre + " (" + Tarifa.Codigo + ")");
            }
        }


        #region Eventos Grilla

        protected void GvTarifas_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void GvTarifasCheck_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void GvTarifas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrupoClausula Grupo = (GrupoClausula)Session[SessionDataHandler.GRUPO_CLAUSULAS];

            RememberOldValues();

            GvTarifas.PageIndex = e.NewPageIndex;

            CargarTarifas(TipoFiltroTarifa.NoCheck);

            IList<int> IdsTarifas = new List<int>();
            foreach (ObjetoAgrupadorClausula Objeto in Grupo.Objetos)
            {
                IdsTarifas.Add(Objeto.IdObjetoAgrupador);
            }

            foreach (GridViewRow Row in GvTarifas.Rows)
            {
                ((CheckBox)Row.Cells[0].Controls[1]).Checked =
                    IdsTarifas.Contains(Convert.ToInt32(Row.Cells[1].Text));
            }

            RePopulateValues();
        }

        #endregion

        private void RememberOldValues()
        {
            ArrayList categoryIDList = new ArrayList();
            int index = -1;
            foreach (GridViewRow row in GvTarifas.Rows)
            {
                index = Convert.ToInt32(row.Cells[1].Text);
                bool result = ((CheckBox)row.FindControl("CbGrupoClausula")).Checked;

                // Check in the Session
                if (Session["items"] != null)
                    categoryIDList = (ArrayList)Session["items"];
                if (result)
                {
                    if (!categoryIDList.Contains(index))
                        categoryIDList.Add(index);
                }
                else
                    categoryIDList.Remove(index);
            }
            if (categoryIDList != null && categoryIDList.Count > 0)
                Session["items"] = categoryIDList;
        }

        private void RePopulateValues()
        {
            ArrayList categoryIDList = (ArrayList)Session["items"];
            if (categoryIDList != null && categoryIDList.Count > 0)
            {
                foreach (GridViewRow row in GvTarifas.Rows)
                {
                    int index = Convert.ToInt32(row.Cells[1].Text);
                    if (categoryIDList.Contains(index))
                    {
                        CheckBox myCheckBox = (CheckBox)row.FindControl("CbTextoResumen");
                        myCheckBox.Checked = true;
                    }
                }
            }
        }

        
        
        protected void DropDownList_DataBound(object sender, EventArgs e)
        {
            ((DropDownList)sender).Items.Insert(0, new ListItem("Ninguno", "-1"));
        }

        protected void DdlTipoGrupoClausula_SelectedIndexChanged(object sender, EventArgs e)
        {
            LProducto.Text = "Producto: ";
            if (TipoGrupoClausula.PRODUCTO_SIN_EMISION.Equals(DdlTipoGrupoClausula.SelectedItem.Text))
            {
                LProducto.Text = "Convenio/Negocio: ";
            }
            if (TipoGrupoClausula.TARIFA_UPGRADE.Equals(DdlTipoGrupoClausula.SelectedItem.Text))
            {
                LProducto.Text = "Upgrade: ";
            }
        }

        protected void DdlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IdTipoGrupoClausula = Convert.ToInt32(DdlTipoGrupoClausula.SelectedValue);
            int CodigoPais = Convert.ToInt32(DdlPais.SelectedValue);

            DdlProducto.DataSource = ProductoHome.Buscar(CodigoPais, IdTipoGrupoClausula);
            DdlProducto.DataBind();
        }

        private void CargarTarifas(GridView objGrid, IEnumerable<Tarifa> tarifas, bool ordenarPorSufijo, string sufijo)
        {
            if (tarifas != null && ordenarPorSufijo && tarifas.Count() != 0)
            {
                IEnumerable<Tarifa> tarifasSufijo = tarifas.Where(x => x.Sufijo == sufijo);
                IEnumerable<Tarifa> tarifasSinSufijo = tarifas.Where(x => x.Sufijo != sufijo);
                List<Tarifa> tarifasTotales = new List<Tarifa>();

                foreach (Tarifa t in tarifasSufijo)
                   tarifasTotales.Add(t);

                foreach (Tarifa t in tarifasSinSufijo)
                    tarifasTotales.Add(t);

                objGrid.DataSource = tarifasTotales;
            }
            else
                objGrid.DataSource = tarifas.ToList();

            objGrid.DataBind();
        }

        private IList<Tarifa> BuscarTarifas(int CodigoPais, int IdProducto, 
            int IdGrupoClausula, int IdTipoGrupoClausula, string sufijo)
        {
            IList<Tarifa> ITarifa = new List<Tarifa>();

            if (Session["Modalidad"] != null && !Session["Modalidad"].Equals("new"))
            {
                ITarifa  = TarifaHome.BuscarPorOrden(CodigoPais, IdProducto, TbCodigoTarifa.Text, IdGrupoClausula, IdTipoGrupoClausula, sufijo, CbAnual.Checked);
            }
            else
            {
                ITarifa = TarifaHome.Buscar(CodigoPais, IdProducto, TbCodigoTarifa.Text, CbAnual.Checked, sufijo, CbAnual.Checked);
            }

            return ITarifa;
        }

        private void CargarTarifas(TipoFiltroTarifa Tipo)
        {
            int CodigoPais = Convert.ToInt32(DdlPais.SelectedValue);
            int IdProducto = Convert.ToInt32(DdlProducto.SelectedValue);
            CheckBox ch;

            GrupoClausula Grupo = (GrupoClausula)Session[SessionDataHandler.GRUPO_CLAUSULAS];

            int IdGrupoClausula = Grupo != null ? Grupo.Id : 0;
            int IdTipoGrupoClausula = Grupo != null && Grupo.TipoGrupoClausula != null ? 
                Grupo.TipoGrupoClausula.Id : 0;

            string sufijo = TbSufijo.Text == "" ? null : TbSufijo.Text;
            IList<Tarifa> ITarifas = BuscarTarifas(CodigoPais, IdProducto, IdGrupoClausula, IdTipoGrupoClausula, sufijo);
            IList<Tarifa> ITarifasCheck = BuscarTarifas(CodigoPais, IdProducto, IdGrupoClausula, IdTipoGrupoClausula, null);

            if (ITarifas.Count==0 && ITarifasCheck.Count==0)
            {
                GvTarifas.DataSource = ITarifas;
                GvTarifas.DataBind();
                GvTarifasCheck.DataSource = ITarifasCheck;
                GvTarifasCheck.DataBind();
            }

            if (ITarifas.Count>0 && ITarifasCheck.Count>0)
            {
                //Carga las 2 Grillas
                switch (Tipo)
                {
                    case TipoFiltroTarifa.Todos:
                        CargarTarifas(GvTarifas, FiltrarTarifas(ITarifas, Grupo, TipoFiltroTarifa.NoCheck), true, ITarifas.Count != 0 ? ITarifas[0].Sufijo : string.Empty);
                        CargarTarifas(GvTarifasCheck, FiltrarTarifas(ITarifasCheck, Grupo, TipoFiltroTarifa.Check), false, string.Empty);
                        foreach (GridViewRow row in GvTarifasCheck.Rows)
                        {
                            ch = (CheckBox)row.FindControl("CbGrupoClausula");
                            if (ch != null)
                            {
                                ch.Checked = true;
                            }
                        }
                        break;
                    case TipoFiltroTarifa.Check:
                        CargarTarifas(GvTarifasCheck, FiltrarTarifas(ITarifasCheck, Grupo, TipoFiltroTarifa.Check), false, string.Empty);
                        foreach (GridViewRow row in GvTarifasCheck.Rows)
                        {
                            ch = (CheckBox)row.FindControl("CbGrupoClausula");
                            if (ch != null)
                            {
                                ch.Checked = true;
                            }
                        }
                        break;
                    case TipoFiltroTarifa.NoCheck:
                        CargarTarifas(GvTarifas, FiltrarTarifas(ITarifas, Grupo, TipoFiltroTarifa.NoCheck), true, ITarifas.Count != 0 ? ITarifas[0].Sufijo : string.Empty);
                        break;
                }
            }


           
        }

        private IEnumerable<Tarifa> FiltrarTarifas(IList<Tarifa> tarifa, GrupoClausula grupos, TipoFiltroTarifa tipo)
        {

            IEnumerable<Tarifa> FiltroTarifa = tarifa.Join( grupos.Objetos,
                                   t => t.Id,
                                   g => g.IdObjetoAgrupador,
                                   (t, g) => t);
            switch (tipo)
            {
                case TipoFiltroTarifa.Check:
                    if (Request.QueryString["modalidad"] != null && Request.QueryString["modalidad"] != "copy")
                    {
                        return FiltroTarifa;
                    }
                    else
                    {
                        return new List<Tarifa>();
                    }
                case TipoFiltroTarifa.NoCheck:
                    return tarifa.Except(FiltroTarifa);
                    
                case TipoFiltroTarifa.Todos:
                    
                default:
                    return tarifa;
                    
            }
            
        }
    }
}