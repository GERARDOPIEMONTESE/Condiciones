using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Backend.Homes;
using Backend.Dominio;
using AjaxControlToolkit;
using Backend.Servicios;
using Backend.Contextos;
using Condiciones.Controles;
using ControlMenu;
using System.Collections;
using Backend.DTO;

namespace Condiciones.ProcesosMasivos
{
    public partial class ListaDeGruposClausulasMasiva : CustomPage
    {
        private const string ITEMS_TEXTOS = "itemsTextos";
        private const string ITEMS_PAISES_SELECCIONADOS = "itemsPaisesSeleccionados";

        protected override void CustomPageInit(object sender, EventArgs e)
        {
            CcContenidosClausula.CargarLeyendas();
        }

        protected override void CustomPageLoad(object sender, EventArgs e)
        {
            ValidarSession();
            if (!IsPostBack)
            {
                CargarCombos();
                SessionDataHandler.SetearSeteaPadres(Session, false);
                BuscarGrupos();
                BuscarClausulasPadre();
                BuscarTextosResumen();
                BuscarDocumentos();
                BuscarPaises();

                CargarClausulas(1);

                SetearFuncionalidad();
            }
        }

        private void CargarCombos()
        {
            DdlTipoGrupoClausula.DataSource = TipoGrupoClausulaHome.Buscar();
            DdlTipoGrupoClausula.DataTextField = "Nombre";
            DdlTipoGrupoClausula.DataValueField = "Id";
            DdlTipoGrupoClausula.DataBind();

            DdlTipoCobertura.DataSource = TipoCoberturaHome.Buscar();
            DdlTipoCobertura.DataTextField = "Nombre";
            DdlTipoCobertura.DataValueField = "Id";
            DdlTipoCobertura.DataBind();

            DdlTipoClausula.DataSource = TipoClausulaHome.Buscar();
            DdlTipoClausula.DataTextField = "Nombre";
            DdlTipoClausula.DataValueField = "Id";
            DdlTipoClausula.DataBind();

            DdlTipoImpresionClausula.DataSource = TipoImpresionClausulaHome.Buscar();
            DdlTipoImpresionClausula.DataTextField = "Descripcion";
            DdlTipoImpresionClausula.DataValueField = "Id";
            DdlTipoImpresionClausula.DataBind();

            DdlTipoContenidoImpresion.DataSource = TipoContenidoImpresionHome.Buscar();
            DdlTipoContenidoImpresion.DataTextField = "Descripcion";
            DdlTipoContenidoImpresion.DataValueField = "Id";
            DdlTipoContenidoImpresion.DataBind();
        }

        private void SetearFuncionalidad()
        {
            BTextosResumen.Visible = Request.QueryString["Texto"] != null;
            BDocumentos.Visible = Request.QueryString["Documento"] != null;
            BCotenidoClausulaRango.Visible = Request.QueryString["Contenido"] != null;

            PTextosResumen.Visible = BTextosResumen.Visible;
            PDocumentos.Visible = BDocumentos.Visible;
            PContenidoClausulaRango.Visible = BCotenidoClausulaRango.Visible;

            LFuncionalidad.Text = PTextosResumen.Visible ? ": Textos Resumen" : PDocumentos.Visible ? ": Documentos" : ": Contenidos";
        }

        protected void GvGruposClausulas_RowDataBound(object sender, GridViewRowEventArgs e)
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

            if (Session["MarcarClausulas"] != null && (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow))
            {
                bool MarcarTodos = (bool)Session["MarcarClausulas"];

                ((CheckBox)e.Row.Cells[0].FindControl("CbGrupoClausula")).Checked = MarcarTodos;
            }
        }

        protected void GvDocumentos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.background ='#ecf0f9'");
                e.Row.Attributes.Add("onmouseout", "this.style.background ='#ffffff'");
                e.Row.Cells[0].Visible = false;
            }
        }

        protected void GvPaises_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.background ='#ecf0f9'");
                e.Row.Attributes.Add("onmouseout", "this.style.background ='#ffffff'");                               
            }
            
            if (Session["MarcarTodos"] != null && (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow))
            {
                bool MarcarTodos = (bool)Session["MarcarTodos"];

                ((CheckBox)e.Row.Cells[0].FindControl("CbSeleccionaPais")).Checked = MarcarTodos;
            }
        }

        protected void GvDocumentos_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HoverMenuExtender hoveMenu = (HoverMenuExtender)e.Row.FindControl("HoverMenuExtender1");
                e.Row.ID = e.Row.RowIndex.ToString();
                hoveMenu.TargetControlID = e.Row.ID;
            }
        }

        private GrupoClausula ObtenerGrupoClausula(int Index)
        {
            int Id = Convert.ToInt32(GvGruposClausulas.Rows[Index].Cells[0].Text);
            return GrupoClausulaHome.Obtener(Id);
        }

        protected void DropDownList_DataBound_Ninguno(object sender, EventArgs e)
        {
            ((DropDownList)sender).Items.Insert(0, new ListItem("Ninguno", "0"));
        }

        protected void DropDownList_DataBound(object sender, EventArgs e)
        {
            ((DropDownList)sender).Items.Insert(0, new ListItem("Todos", "0"));
        }

        protected void DdlProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            AceCodigoTarifa.ContextKey = ((DropDownList)sender).SelectedValue;
        }

        protected void DdlTipoGrupoClausula_SelectedIndexChanged(object sender, EventArgs e)
        {
            LProducto.Text = "Producto: ";
            bool VisibleTarifa = true;

            if (TipoGrupoClausula.PRODUCTO_SIN_EMISION.Equals(DdlTipoGrupoClausula.SelectedItem.Text))
            {
                LProducto.Text = "Convenio/Negocio: ";
                VisibleTarifa = false;
            }
            if (TipoGrupoClausula.TARIFA_UPGRADE.Equals(DdlTipoGrupoClausula.SelectedItem.Text))
            {
                LProducto.Text = "Upgrade: ";
            }
            LSufijo.Visible = VisibleTarifa;
            TbSufijo.Visible = VisibleTarifa;
            LCodigoTarifa.Visible = VisibleTarifa;
            TbCodigoTarifa.Visible = VisibleTarifa;
        }

        private void BuscarDocumentos()
        {
            GvDocumentos.DataSource = TipoDocumentoHome.Buscar();
            GvDocumentos.DataBind();
        }

        private void BuscarPaises()
        {
            GvPaises.DataSource = PaisHome.Buscar().Where(x => !x.Codigo.Contains("-")).ToList();
            GvPaises.DataBind();
        }

        private void BuscarTextosResumen()
        {
            GvTextosResumen.DataSource = TextoHome.BuscarPorParametros(TbNombreTexto.Text, Texto.RESUMEN, (int)Idioma.Idiomas.Español);
            GvTextosResumen.DataBind();
        }

        private IList<int> ObtenerListaPaisesSeleccionados()
        {
            return Session["itemsPaisesSeleccionados"] != null ? (IList<int>)Session["itemsPaisesSeleccionados"] : new List<int>();
        }

        private void BuscarGrupos()
        {
            int IdTipoGrupoClausula = Convert.ToInt32(DdlTipoGrupoClausula.SelectedValue);

            string CodigoProducto = (DdlProducto.SelectedValue == null ||
                DdlProducto.SelectedValue.Length == 0 || DdlProducto.SelectedValue == "0") ? "" :
                DdlProducto.SelectedValue;

            GvGruposClausulas.DataSource = GrupoClausulaHome.BuscarGrupoTarifa(
                    IdTipoGrupoClausula, ObtenerListaPaisesSeleccionados(),
                    CodigoProducto, TbSufijo.Text, TbCodigoTarifa.Text);


            GvGruposClausulas.DataBind();
        }

        private void BuscarClausulasPadre()
        {
            GvClausulasPadre.DataSource = ClausulaHome.BuscarDTO(
                ObtenerGruposClausulaTodos());
            GvClausulasPadre.DataBind();
        }

        private void LimpiarGrillaPaises()
        {
            Session.Remove("itemsCodigoPais");
            Session.Remove("itemsPaisesSeleccionados");
            Session.Remove("itemsPais");
            DesSeleccionarTodos();
        }

        protected void BBuscar_Click(object sender, EventArgs e)
        {
            BuscarGrupos();
            BuscarClausulasPadre();

            LimpiarGrillaPaises();
        }

        protected void BBuscarTexto_Click(object sender, EventArgs e)
        {
            BuscarTextosResumen();
            MpeTextosResumen.Show();
        }

        protected void SeleccionarTodos(object sender, EventArgs e)
        {
            Session["MarcarTodos"] = ((CheckBox)sender).Checked;
            BuscarPaises();

            if (((CheckBox)sender).Checked)
            {
                IList<Pais> Paises = PaisHome.Buscar();
                ArrayList CodigosPaises = new ArrayList();

                foreach (Pais Pais in Paises)
                {
                    CodigosPaises.Add(Pais.Codigo);
                }

                Session["itemsCodigoPais"] = CodigosPaises;
            }
            Session["MarcarTodos"] = null;
            MpePaises.Show();
        }

        protected void DesSeleccionarTodos()
        {
            Session.Remove("MarcarTodos");
            BuscarPaises();
        }

        protected void BuscarPaises(object sender, EventArgs e)
        {
            MpePaises.Show();
        }
        protected void SeleccionarTodosGruposClausulas(object sender, EventArgs e)
        {
            Session["MarcarClausulas"] = ((CheckBox)sender).Checked;
            BuscarGrupos();
            Session["MarcarClausulas"] = null;
        }

        private void RememberOldValuesTextos()
        {
            ArrayList categoryIDList = new ArrayList();

            int index = -1;
            foreach (GridViewRow row in GvTextosResumen.Rows)
            {
                index = Convert.ToInt32(row.Cells[1].Text);
                bool result = ((CheckBox)row.FindControl("CbTextoResumen")).Checked;

                // Check in the Session
                if (Session["itemsPais"] != null)
                    categoryIDList = (ArrayList)Session[ITEMS_TEXTOS];

                if (result)
                {
                    if (!categoryIDList.Contains(index))
                        categoryIDList.Add(index);
                }
                else
                {
                    if (index != -1)
                    {
                        categoryIDList.Remove(index);
                    }                    
                }
                    
            }
            if (categoryIDList != null && categoryIDList.Count > 0)
                Session[ITEMS_TEXTOS] = categoryIDList;
        }

        private void RePopulateValuesTextos()
        {
            ArrayList categoryIDList = (ArrayList)Session[ITEMS_TEXTOS];
            if (categoryIDList != null && categoryIDList.Count > 0)
            {
                foreach (GridViewRow row in GvTextosResumen.Rows)
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

        protected void GvPaises_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            RememberOldValuesPaises();
            if(((CheckBox)((System.Web.UI.WebControls.TableRow)(GvPaises.HeaderRow)).Cells[0].FindControl("CbSeleccionaPais")).Checked)
                Session["MarcarTodos"] = true;

            GvPaises.PageIndex = e.NewPageIndex;
            BuscarPaises();
            MpePaises.Show();

            Session["MarcarTodos"] = null;
            RePopulateValuesPaises();
        }

        private ContextoModificacionMasiva CrearContextoTextoResumen()
        {
            ContextoModificacionMasiva Contexto = new ContextoModificacionMasiva();

            Contexto.IdsGrupoClausula = ObtenerGruposClausula();

            Contexto.TextosResumen = ObtenerTextosResumen();

            return Contexto;
        }

        private void CargarClausulas(int IdTipoClausula)
        {
            GvClausulas.DataSource = ClausulaHome.Buscar();
            GvClausulas.DataBind();
        }

        protected void GvClausulas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ((GridView)sender).PageIndex = e.NewPageIndex;
            int IdTipoClausula = Convert.ToInt32(DdlTipoClausula.SelectedValue);
            CargarClausulas(IdTipoClausula);
        }

        protected void DdlTipoClausula_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IdTipoClausula = Convert.ToInt32(DdlTipoClausula.SelectedValue);

            CargarClausulas(IdTipoClausula);
        }

        private ContextoModificacionMasiva CrearContextoContenido(bool EsQuery)
        {
            ContextoModificacionMasiva Contexto = new ContextoModificacionMasiva();

            Contexto.IdsGrupoClausula = ObtenerGruposClausula();
            Contexto.IdsClausula = ObtenerClausulas();
            Contexto.Rangos = ObtenerRangos(EsQuery);
            Contexto.IdsPadre = ObtenerPadres();
            Contexto.Documentos = ObtenerDocumentos();
            if (!DdlTipoCobertura.SelectedValue.Equals("")) 
            {
                Contexto.IdTipoCobertura = Convert.ToInt32(DdlTipoCobertura.SelectedValue);
            }
            if (!DdlTipoImpresionClausula.SelectedValue.Equals(""))
            {
                Contexto.IdTipoImpresionClausula = Convert.ToInt32(DdlTipoImpresionClausula.SelectedValue);
            }
            if (!DdlTipoContenidoImpresion.SelectedValue.Equals(""))
            {
                Contexto.IdTipoContenidoClausula = Convert.ToInt32(DdlTipoContenidoImpresion.SelectedValue);
            }
            
            return Contexto;
        }

        protected void BAplicarTextoResumen_Click(object sender, EventArgs e)
        {
            ServicioModificacionMasiva.AsociarTextoResumen(CrearContextoTextoResumen());
            MpeTextosResumen.Hide();
        }

        protected void BAplicarDocumentos_Click(object sender, EventArgs e)
        {
            ServicioModificacionMasiva.ModificarDocumentos(CrearContextoContenido(true));
            MpeDocumentos.Hide();
        }

        protected void BAplicarContenido_Click(object sender, EventArgs e)
        {
            ServicioModificacionMasiva.ModificarCondicion(CrearContextoContenido(true));

            MpeContenidoClausulaRango.Hide();
        }

        protected void BPaises_Click(object sender, EventArgs e)
        {
            BuscarPaises();
            RePopulateValuesPaises();
        }

        protected void BEliminarContenido_Click(object sender, EventArgs e)
        {
            ServicioModificacionMasiva.EliminarCondicion(CrearContextoContenido(true));

            MpeContenidoClausulaRango.Hide();
        }

        protected void BAgregarContenido_Click(object sender, EventArgs e)
        {
            ServicioModificacionMasiva.AgregarCondicion(CrearContextoContenido(false));

            MpeContenidoClausulaRango.Hide();
        }

        private IList<int> ObtenerPaises()
        {
            RememberOldValuesPaises();
            IList<int> Paises = new List<int>();
            if (Session["itemsCodigoPais"] != null)
            {
                foreach (string CodigoPais in (ArrayList)Session["itemsCodigoPais"])
                {
                    Paises.Add(Convert.ToInt32(CodigoPais));
                }
            }
            else
            {
                foreach (GridViewRow Row in GvPaises.Rows)
                {
                    CheckBox CheckBox = (CheckBox)Row.Cells[0].Controls[1];

                    if (CheckBox.Checked)
                    {
                        Paises.Add(Convert.ToInt32(Row.Cells[1].Text));
                    }
                }
            }

            return Paises;
        }



        protected void BCancelarPaises_Click(object sender, EventArgs e)
        {
            Session.Remove(ITEMS_PAISES_SELECCIONADOS);
            Session.Remove("itemsCodigoPais");
            Session.Remove("itemsPais");
        }

        protected void BAplicarPaises_Click(object sender, EventArgs e)
        {
            int IdTipoGrupoClausula = Convert.ToInt32(DdlTipoGrupoClausula.SelectedValue);

            Session[ITEMS_PAISES_SELECCIONADOS] = ObtenerPaises();

            DdlProducto.DataSource = ProductoHome.Buscar((IList<int>) Session[ITEMS_PAISES_SELECCIONADOS], IdTipoGrupoClausula);
            DdlProducto.DataBind();

            Session.Remove("MarcarTodos");
        }

        
        protected void GvTextosResumen_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void GvTextosResumen_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HoverMenuExtender hoveMenu = (HoverMenuExtender)e.Row.FindControl("HoverMenuExtender1");
                e.Row.ID = e.Row.RowIndex.ToString();
                hoveMenu.TargetControlID = e.Row.ID;
            }
        }

        private void RememberOldValuesPaises()
        {
            ArrayList categoryIDList = new ArrayList();

            ArrayList codigoPaisList = new ArrayList();

            
            if (Session["itemsPais"] != null)
                categoryIDList = (ArrayList)Session["itemsPais"];

            if (Session["itemsCodigoPais"] != null)
            {
                codigoPaisList = (ArrayList)Session["itemsCodigoPais"];
            }

            int index = -1;
            foreach (GridViewRow row in GvPaises.Rows)
            {
                index = Convert.ToInt32(row.Cells[1].Text);
                bool result = ((CheckBox)row.FindControl("CbSeleccionaPais")).Checked;

                if (result)
                {
                    if (!categoryIDList.Contains(index))
                        categoryIDList.Add(index);

                    string CodigoPais = row.Cells[1].Text;

                    if (!codigoPaisList.Contains(CodigoPais))
                    {
                        codigoPaisList.Add(CodigoPais);
                    }
                }
                else
                {
                    categoryIDList.Remove(index);
                    codigoPaisList.Remove(row.Cells[1].Text);
                }

            }
            if (categoryIDList != null && categoryIDList.Count > 0)
                Session["itemsPais"] = categoryIDList;

            if (codigoPaisList != null && codigoPaisList.Count > 0)
            {
                Session["itemsCodigoPais"] = codigoPaisList;
            }
        }

        private void RePopulateValuesPaises()
        {
            ArrayList categoryIDList = (ArrayList)Session["itemsPais"];
            if (categoryIDList != null && categoryIDList.Count > 0)
            {
                foreach (GridViewRow row in GvPaises.Rows)
                {
                    int index = Convert.ToInt32(row.Cells[1].Text);
                    if (categoryIDList.Contains(index))
                    {
                        CheckBox myCheckBox = (CheckBox)row.FindControl("CbSeleccionaPais");
                        myCheckBox.Checked = true;
                    }
                }
            }
        }

        protected void GvTextosResumen_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            RememberOldValuesTextos();

            GvTextosResumen.PageIndex = e.NewPageIndex;
            BuscarTextosResumen();
            MpeTextosResumen.Show();

            RePopulateValuesTextos();
        }

        protected void GvClausulasPadre_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void GvClausulasPadre_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ((GridView)sender).PageIndex = e.NewPageIndex;
            BuscarClausulasPadre();

        }

        protected void BAplicarClausulasPadre_Click(object sender, EventArgs e)
        {
            SessionDataHandler.SetearSeteaPadres(Session, true);
        }        

        private IList<int> ObtenerClausulas()
        {
            IList<int> IdsClausula = new List<int>();
            foreach (GridViewRow Row in GvClausulas.Rows)
            {
                bool Seleccionado = ((CheckBox)Row.Cells[0].Controls[1]).Checked;

                if (Seleccionado)
                {
                    IdsClausula.Add(Convert.ToInt32(Row.Cells[1].Text));
                }
            }
            return IdsClausula;
        }

        private IList<int> ObtenerPadres()
        {
            IList<int> Padres = new List<int>();
            if (SessionDataHandler.ObtenerSeteaPadres(Session))
            {
                foreach (GridViewRow Row in GvClausulasPadre.Rows)
                {
                    bool Seleccionado = ((CheckBox)Row.Cells[0].Controls[1]).Checked;

                    if (Seleccionado)
                    {
                        Padres.Add(Convert.ToInt32(Row.Cells[1].Text));
                    }
                }
            }
            return Padres;
        }

        private IList<int> ObtenerGruposClausulaTodos()
        {
            IList<int> IdsClausula = new List<int>();
            foreach (GridViewRow Row in GvGruposClausulas.Rows)
            {
                IdsClausula.Add(Convert.ToInt32(Row.Cells[1].Text));
            }
            return IdsClausula;
        }

        private IList<int> ObtenerGruposClausula()
        {
            IList<int> IdsClausula = new List<int>();
            foreach (GridViewRow Row in GvGruposClausulas.Rows)
            {
                bool Seleccionado = ((CheckBox)Row.Cells[0].Controls[1]).Checked;

                if (Seleccionado)
                {
                    IdsClausula.Add(Convert.ToInt32(Row.Cells[1].Text));
                }                
            }
            return IdsClausula;
        }

        private IList<TextoResumenDTO> ObtenerTextosResumen()
        {
            IList<TextoResumenDTO> TextosDto = new List<TextoResumenDTO>();


            foreach (GridViewRow Row in GvTextosResumen.Rows)
            {
                bool Seleccionado = ((CheckBox)Row.Cells[0].Controls[1]).Checked;

                if (Seleccionado)
                {
                    TextoResumenDTO TextoDto = new TextoResumenDTO();
                    TextoDto.IdTextoResumen = Convert.ToInt32(Row.Cells[1].Text);
                    TextoDto.IdTipoPlan = Convert.ToInt32(((DropDownList)
                        Row.FindControl("DdlTipoPlan")).SelectedValue);

                    TextosDto.Add(TextoDto);                   
                }
            }

            return TextosDto;
        }

        private IList<ContextoModificacionDocumento> ObtenerDocumentos()
        {
            IList<ContextoModificacionDocumento> Documentos = 
                new List<ContextoModificacionDocumento>();
            foreach (GridViewRow Row in GvDocumentos.Rows)
            {
                CheckBox CbAplica = (CheckBox)Row.Cells[1].Controls[1];
                if (CbAplica.Checked)
                {
                    int IdDocumento = Convert.ToInt32(((DropDownList)Row.Cells[
                        (GvDocumentos.Columns.Count - 1)].Controls[3]).SelectedValue);

                    Documentos.Add(new ContextoModificacionDocumento(
                        Convert.ToInt32(Row.Cells[0].Text), IdDocumento));
                }
            }

            return Documentos;
        }

        //ASCOOOOO totallll .. esto no se haceeeeee!!!!
        private IList<ContextoModificacionRango> ObtenerRangos(bool EsQuery) 
        {
            IList<ContextoModificacionRango> Rangos = new List<ContextoModificacionRango>();

            foreach (WucContenidoClausula Contenido in CcContenidosClausula.Contenidos)
            {
                //if (Contenido.Contenido != null && Contenido.Contenido.Length > 0)
                //{
                    ContextoModificacionRango Rango = new ContextoModificacionRango();

                    Rango.Contenido = Contenido.Contenido;
                    Rango.Leyendas = Contenido.ObtenerLeyendas();
                    Rango.IdValidezTerritorialClausula = Convert.ToInt32(Contenido.IdValidezTerritorialClausula);
                    Rango.IdValidezTerritorial = Convert.ToInt32(Contenido.IdValidezTerritorial);

                    if (!EsQuery || (Contenido.EdadMinima != null && Contenido.EdadMinima.Length > 0))
                    {
                        Rango.EdadMinima = Convert.ToInt32(Contenido.EdadMinima);
                    }

                    if (!EsQuery || (Contenido.EdadMaxima != null && Contenido.EdadMaxima.Length > 0))
                    {
                        Rango.EdadMaxima = Convert.ToInt32(Contenido.EdadMaxima);
                    }

                    if (!EsQuery || (Contenido.IdTipoPlan != null && Contenido.IdTipoPlan.Length > 0))
                    {
                        Rango.IdTipoPlan = Convert.ToInt32(Contenido.IdTipoPlan);
                    }

                    if (!EsQuery || (Contenido.IdTipoModalidad != null && Contenido.IdTipoModalidad.Length > 0))
                    {
                        Rango.IdTipoModalidad = Convert.ToInt32(Contenido.IdTipoModalidad);
                    }

                    if (!EsQuery || (Contenido.Categoria != null && Contenido.Categoria.Length > 0))
                    {
                        Rango.Categoria = Convert.ToInt32(Contenido.Categoria);
                    }

                    Rangos.Add(Rango);
                //}
            }

            return Rangos;
        }
    }
}
