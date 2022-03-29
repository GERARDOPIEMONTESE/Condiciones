using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using AjaxControlToolkit;
using Backend.Homes;
using Backend.Dominio;
using Backend.DTO;
using ControlMenu;
using CondicionesParser.Validadores;
using System.Configuration;
using Condiciones.Controles;
using System.Globalization;


namespace Condiciones
{
    public partial class InformacionDeGrupoClausula : CustomPage
    {
        #region Constantes

        private const string TREEVIEW_MENU = "TvClausula";
        private int _orden;

        #endregion

        #region Properties

        #endregion

        protected override void CustomPageInit(object sender, EventArgs e)
        {
            CcContenidosClausula.CargarLeyendas();
        }

        protected override void CustomPageLoad(object sender, EventArgs e)
        {
            ValidarSession();
            if (!IsPostBack)
            {
                Session["Contenido"] = new Dictionary<string, ClausulaDTO>();

                CargarCombos();

                if ((Session["Modalidad"].ToString()== "edit") || (Session["Modalidad"].ToString()== "copy"))
                {
                    InicializarContenido();
                }

                InicializarArbol();
                CcContenidosClausula.Inicializar(SessionDataHandler.TipoGrupoClausula(Session));
                ActualizarPadres();
            }
        }

        #region Eventos Privados

        private void CargarCombos()
        {
            try
            {
                DdlTipoClausula.DataSource = Backend.Homes.TipoClausulaHome.Buscar();
                DdlTipoClausula.DataTextField = "Nombre";
                DdlTipoClausula.DataValueField = "Id";
                DdlTipoClausula.DataBind();

                DdlTipoCobertura.DataSource = Backend.Homes.TipoCoberturaHome.Buscar();
                DdlTipoCobertura.DataTextField = "Nombre";
                DdlTipoCobertura.DataValueField = "Id";
                DdlTipoCobertura.DataBind();

                DdlTipoImpresionClausula.DataSource = Backend.Homes.TipoImpresionClausulaHome.Buscar();
                DdlTipoImpresionClausula.DataTextField = "Descripcion";
                DdlTipoImpresionClausula.DataValueField = "Id";
                DdlTipoImpresionClausula.DataBind();

                DdlTipoContenidoImpresion.DataSource = Backend.Homes.TipoContenidoImpresionHome.Buscar();
                DdlTipoContenidoImpresion.DataTextField = "Descripcion";
                DdlTipoContenidoImpresion.DataValueField = "Id";
                DdlTipoContenidoImpresion.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string TextoIdentificatorio(ContenidoClausula ContenidoClausula, Clausula Clausula)
        {
            string Texto = Clausula.Codigo + " - "
                + Clausula.ObtenerTitulo(UsuarioLogueadoDTO() != null ? UsuarioLogueadoDTO().Ididioma : 1) + " - "
                + ObtenerLeyenda(ContenidoClausula);

            return Texto;
        }

        private string TextoIdentificatorioOriginal(ContenidoClausula ContenidoClausula, Clausula Clausula)
        {
            string Texto = Clausula.Codigo + " - "
                + Clausula.ObtenerTitulo(UsuarioLogueadoDTO() != null ? UsuarioLogueadoDTO().Ididioma : 1) + " - "
                + ObtenerLeyenda(ContenidoClausula);

            return Texto;
        }

        private void InicializarContenido()
        {
            IDictionary<string, ClausulaDTO> Contenido = getContenido();

            GrupoClausula Grupo = (GrupoClausula)Session[SessionDataHandler.GRUPO_CLAUSULAS];

            foreach (ContenidoClausula ContenidoClausula in Grupo.Contenidos)
            {
                Clausula Clausula = ClausulaHome.Obtener(ContenidoClausula.IdClausula);

                ClausulaDTO ClausulaDTO = new ClausulaDTO();
                ClausulaDTO.Id = ContenidoClausula.Id;
                ClausulaDTO.TextoIdentificatorio = TextoIdentificatorioOriginal(ContenidoClausula, Clausula);
                ClausulaDTO.NombreClausula = Clausula.Codigo;
                ClausulaDTO.IdClausula = Clausula.Id;
                ClausulaDTO.IdTipoClausula = Clausula.TipoClausula.Id;
                ClausulaDTO.IdTipoImpresionClausula = ContenidoClausula.TipoImpresionClausula.Id;
                ClausulaDTO.IdTipoContenidoImpresion = ContenidoClausula.TipoContenidoImpresion.Id;
                ClausulaDTO.EvaluableEnAsistencia = ContenidoClausula.EvaluableEnAsistencia;
                ClausulaDTO.VisibleEnAsistencia = ContenidoClausula.VisibleEnAsistencia;
                ClausulaDTO.TipoCobertura = ContenidoClausula.TipoCobertura;
                ClausulaDTO.ContenidoClausula = ContenidoClausula;
                ClausulaDTO.Orden = ContenidoClausula.Orden;

                foreach (ContenidoClausulaRango Rango in ContenidoClausula.Contenidos)
                {
                    ContenidoRangoDTO RangoDTO = new ContenidoRangoDTO();

                    RangoDTO.EdadMinima = Rango.EdadMinima;
                    RangoDTO.EdadMaxima = Rango.EdadMaxima;
                    RangoDTO.IdTipoModalidad = Rango.TipoModalidad == null
                        ? 0 : Rango.TipoModalidad.Id;
                    RangoDTO.IdTipoPlan = Rango.TipoPlan == null
                        ? 0 : Rango.TipoPlan.Id;
                    RangoDTO.Categoria = Rango.Categoria;
                    RangoDTO.Contenido = Rango.Contenido;
                    RangoDTO.IdValidezTerritorialClausula = Rango.ValidezTerritorialClausula == null
                        ? 0 : Rango.ValidezTerritorialClausula.Id;
                    RangoDTO.IdValidezTerritorial = Rango.ValidezTerritorial == null
                        ? 0 : Rango.ValidezTerritorial.Id;
                    RangoDTO.Leyendas = Rango.Leyendas;
                    RangoDTO.Peso = Rango.Peso;


                    ClausulaDTO.Contenidos.Add(RangoDTO);
                }

                foreach (AsociacionContenidoClausula Padre in ContenidoClausula.Padres)
                {
                    ClausulaDTO.TextosIdentificatorioPadre.Add(TextoIdentificatorio
                        (Padre.ContenidoClausulaPadre,
                        ClausulaHome.Obtener(Padre.ContenidoClausulaPadre.IdClausula)));
                }

                if (!getContenido().Keys.Contains(ClausulaDTO.TextoIdentificatorio))
                {
                    getContenido().Add(ClausulaDTO.TextoIdentificatorio, ClausulaDTO);
                }
            }
        }

        private IDictionary<string, ClausulaDTO> getContenido()
        {
            return (IDictionary<string, ClausulaDTO>)Session["Contenido"];
        }

        private bool Existe(string key)
        {
            IDictionary<string, ClausulaDTO> test = getContenido();
            
            return getContenido().Keys != null && getContenido().Keys.Contains(key);
        }

        private void AgregarRangos(ClausulaDTO clausula)
        {
            clausula.Contenidos.Clear();

            foreach (Condiciones.Controles.WucContenidoClausula Contenido in CcContenidosClausula.Contenidos)
            {
                ContenidoRangoDTO Rango = new ContenidoRangoDTO();
                //Rango.Contenido = Contenido.Contenido;
                Rango.EdadMinima = Convert.ToInt32(Contenido.EdadMinima);
                Rango.EdadMaxima = Convert.ToInt32(Contenido.EdadMaxima);
                Rango.IdTipoPlan = Convert.ToInt32(Contenido.IdTipoPlan);
                Rango.IdTipoModalidad = Convert.ToInt32(Contenido.IdTipoModalidad);
                Rango.Categoria = Convert.ToInt32(Contenido.Categoria);
                Rango.IdValidezTerritorialClausula = Convert.ToInt32(Contenido.IdValidezTerritorialClausula);
                Rango.IdValidezTerritorial = Convert.ToInt32(Contenido.IdValidezTerritorial);
                Rango.IdTipoDestino = 0;
                Rango.Leyendas = Contenido.ObtenerLeyendas();
                Rango.Peso = Contenido.Peso;
                if (!String.IsNullOrEmpty(Contenido.ContenidosValidadores))
                {
                    string formula = Contenido.ContenidosValidadores + ": " + Contenido.Igual + " " + Contenido.Numero;
                    if (!String.IsNullOrEmpty(Contenido.Currency) && Contenido.ContenidosValidadores.Equals("MONTO"))
                    {
                        formula = formula + " " + Contenido.Currency;
                    }
                    Rango.Contenido = formula;
                }


                ValidadorCondiciones.Instancia(Condiciones.Properties.Settings.
                    Default.Ubicacion).ValidarCondicion(Rango.Contenido);

                clausula.Contenidos.Add(Rango);
            }
        }

        private void AgregarPadres(ClausulaDTO clausula)
        {
            if (SessionDataHandler.ObtenerSeteaPadres(Session))
            {
                clausula.TextosIdentificatorioPadre.Clear();

                foreach (GridViewRow Row in GvClausulasPadre.Rows)
                {
                    if (((CheckBox)Row.Cells[0].Controls[1]).Checked)
                    {
                        clausula.TextosIdentificatorioPadre.Add(Row.Cells[1].Text);
                        ((CheckBox)Row.Cells[0].Controls[1]).Checked = false;
                    }
                }
            }
        }

        private void Agregar(string Texto)
        {
            ClausulaDTO clausula = new ClausulaDTO();

            clausula.IdClausula = Convert.ToInt32(DdlClausula.SelectedValue);
            clausula.NombreClausula = DdlClausula.SelectedItem.Text;
            clausula.IdTipoClausula = Convert.ToInt32(DdlTipoClausula.SelectedValue);
            clausula.TipoCobertura = TipoCoberturaHome.Obtener(Convert.ToInt32(DdlTipoCobertura.SelectedValue));
            clausula.IdTipoImpresionClausula = Convert.ToInt32(DdlTipoImpresionClausula.SelectedValue);
            clausula.IdTipoContenidoImpresion = Convert.ToInt32(DdlTipoContenidoImpresion.SelectedValue);
            clausula.EvaluableEnAsistencia = CbEvaluableEnAsistencia.Checked;
            clausula.VisibleEnAsistencia = CbVisibleEnAsistencia.Checked;
            clausula.Orden = _orden;

            AgregarRangos(clausula);

            AgregarPadres(clausula);

            if (Existe(Texto))
            {
                getContenido().Remove(Texto);
            }
            getContenido().Add(Texto, clausula);
        }

        private void Editar(string Texto, ClausulaDTO clausula)
        {
            clausula.IdTipoClausula = Convert.ToInt32(DdlTipoClausula.SelectedValue);
            clausula.TipoCobertura = TipoCoberturaHome.Obtener(Convert.ToInt32(DdlTipoCobertura.SelectedValue));

            clausula.IdTipoImpresionClausula = Convert.ToInt32(DdlTipoImpresionClausula.SelectedValue);
            clausula.IdTipoContenidoImpresion = Convert.ToInt32(DdlTipoContenidoImpresion.SelectedValue);
            clausula.EvaluableEnAsistencia = CbEvaluableEnAsistencia.Checked;
            clausula.VisibleEnAsistencia = CbVisibleEnAsistencia.Checked;
            clausula.Orden = _orden;//Convert.ToInt32(TbOrden.Text);

            AgregarRangos(clausula);

            AgregarPadres(clausula);

            if (Existe(Texto))
            {
                getContenido().Remove(Texto);
            }

            getContenido().Add(Texto, clausula);

        }

        private void InicializarArbol()
        {
            TipoGrupoClausula TipoGrupo = (TipoGrupoClausula)Session["TipoGrupoClausula"];

            TreeNode Nodo;
            if (Session["IsSLA"] != null && Convert.ToBoolean(Session["IsSLA"]))
            {
                DdlTipoClausula.SelectedValue = TipoClausulaHome.Obtener("SLA").Id.ToString();
                DdlTipoClausula.Enabled = false;

                Nodo = new TreeNode(Session["Agencia"].ToString() + " (" + TipoGrupo.Nombre + ")", Session["Agencia"].ToString());
                ObtenerClausulasPorTipoClausula(DdlTipoClausula);
            }
            else
            {
                Producto Producto = (Producto)Session["PRODUCTO"];
                Nodo = new TreeNode(Producto.Nombre + " (" + TipoGrupo.Nombre + ")", Producto.Codigo);
                CcContenidosClausula.SetearPais(Producto.CodigoPais.ToString());
            }

            Nodo.ToolTip = Nodo.Text;
            Nodo.Expanded = true;
            Nodo.Selected = true;


            TvClausula.Nodes.Add(Nodo);

            foreach (ClausulaDTO ClausulaDTO in getContenido().Values)
            {
                string Valor = ClausulaDTO.IdClausula.ToString();

                TreeNode TnItem = new TreeNode(ClausulaDTO.TextoIdentificatorio, Valor);
                TnItem.ToolTip = ClausulaDTO.TextoIdentificatorio;
                TnItem.Expanded = true;
                TnItem.ImageToolTip = ClausulaDTO.Orden.ToString();

                Nodo.ChildNodes.Add(TnItem);
            }
        }

        private void ActualizarPadres()
        {
            GvClausulasPadre.DataSource = getContenido().Values;
            GvClausulasPadre.DataBind();
        }

        private string ObtenerLeyenda(ContenidoClausula ContenidoClausula)
        {
            int IdIdioma = UsuarioLogueadoDTO() != null ? UsuarioLogueadoDTO().Ididioma : 1;
            IList<Leyenda> Leyendas = ContenidoClausula.Contenidos.Count > 0 ?
                ContenidoClausula.Contenidos[0].Leyendas : new List<Leyenda>();
            
            foreach (Leyenda Leyenda in Leyendas)
            {
                if (Leyenda.IdIdioma == IdIdioma)
                {
                    return Leyenda.Texto;
                }
            }

            return "";
        }

        private string ObtenerLeyenda()
        {
            int IdIdioma = UsuarioLogueadoDTO() != null ? UsuarioLogueadoDTO().Ididioma : 1;
            IList<Leyenda> Leyendas = CcContenidosClausula.Contenidos[0].ObtenerLeyendas();

            foreach (Leyenda Leyenda in Leyendas)
            {
                if (Leyenda.IdIdioma == IdIdioma)
                {
                    return Leyenda.Texto;
                }
            }

            return "";
        }

        private string ObtenerTexto()
        {
            Clausula Clausula = ClausulaHome.Obtener(Convert.ToInt32(DdlClausula.SelectedValue));

            string Texto = ObtenerCodigoIdentificadorClausula(Clausula)
                + ObtenerLeyenda();

            return Texto;
        }

        private string ObtenerCodigoIdentificadorClausula()
        {
            Clausula Clausula = ClausulaHome.Obtener(Convert.ToInt32(DdlClausula.SelectedValue));

            return ObtenerCodigoIdentificadorClausula(Clausula);
        }

        private string ObtenerCodigoIdentificadorClausula(Clausula Clausula)
        {
            string Texto = Clausula.Codigo + " - "
                + Clausula.ObtenerTitulo(UsuarioLogueadoDTO() != null ? UsuarioLogueadoDTO().Ididioma : 1) + " - ";

            return Texto;
        }

        private void ValidarExistenciaClausula()
        {
            ICollection<string> Keys = getContenido().Keys;
            string CodigoIdentificadorClausula = ObtenerCodigoIdentificadorClausula();

            foreach (string Key in Keys)
            {
                if (Key.Contains(CodigoIdentificadorClausula))
                {
                    throw new Exception("Clausula existente en el grupo.");
                }
            }
        }

        private void SetDescripcionClausula(String idClausulaString)
        {
            if (idClausulaString != null && !idClausulaString.Equals("") && !idClausulaString.Equals("-1"))
            {
                int idClausula = int.Parse(idClausulaString);
                Clausula clausulaSeleccionada = ClausulaHome.Obtener(idClausula);
                int idIdioma = 1;
                if (UsuarioLogueadoDTO() != null)
                {
                    idIdioma = UsuarioLogueadoDTO().Ididioma;
                }
                labelDescripcionClausula.Text = clausulaSeleccionada.ObtenerTitulo(idIdioma);
                TbOrden.Text = clausulaSeleccionada.OrdenPredefinido.ToString();
            }
            else
            {
                labelDescripcionClausula.Text = "";
            }

        }

        private void MoverNodo(int IndiceActual)
        {
            bool Procesado = false;

            int NuevoIndice = Convert.ToInt32(TbOrden.Text) > 0 ? Convert.ToInt32(TbOrden.Text) - 1 : 0;

            TreeNode Nodo = TvClausula.SelectedNode;

            while (NuevoIndice > IndiceActual)
            {
                EstrategiasManejoArbol.ObtenerInstancia().ObtenerEstrategia(
                    TvClausula.SelectedNode.Depth).MoverNodoAbajo(TvClausula, TvClausula.SelectedNode);
                Nodo.Selected = true;
                IndiceActual++;
                Procesado = true;
            }

            if (Procesado == false)
            {
                while (NuevoIndice < IndiceActual)
                {
                    EstrategiasManejoArbol.ObtenerInstancia().ObtenerEstrategia(
                        TvClausula.SelectedNode.Depth).MoverNodoArriba(TvClausula, TvClausula.SelectedNode);
                    Nodo.Selected = true;
                    IndiceActual--;
                }
            }

        }

        private void ValidarNodoSeleccionado(TreeNode Nodo)
        {
            if (Nodo == null)
            {
                throw new Exception("nodo sin seleccionar");
            }
        }

        private void SetearOrdenes(TreeNodeCollection Nodos, int Inicio)
        {
            for (int I = 0; I < Nodos.Count; I++)
            {
                TreeNode Nodo = Nodos[I];
                if (Existe(Nodo.Text))
                {
                    ClausulaDTO Clausula = getContenido()[Nodo.Text];
                    Clausula.Orden = I + 1;
                }
            }
        }

        private void SetearDatos(TreeNode Nodo)
        {
            if (getContenido().Keys.Contains(Nodo.Text))
            {
                SessionDataHandler.SetearSeteaPadres(Session, false);

                CcContenidosClausula.Limpiar();

                ClausulaDTO clausula = getContenido()[Nodo.Text];

                clausula.TextoIdentificatorio = Nodo.Text;

                DdlTipoClausula.SelectedValue = clausula.IdTipoClausula.ToString();
                LClausula.Text = clausula.TextoIdentificatorio.Split('-')[0].Trim();
                CultureInfo culture = new CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.Name);
                float theFloat = Convert.ToSingle(ClausulaHome.Obtener(clausula.TextoIdentificatorio.Split('-')[0].Trim()).Tasa, culture);
                hfTasa.Value = ""+ClausulaHome.Obtener(clausula.TextoIdentificatorio.Split('-')[0].Trim()).Tasa;
                labelDescripcionClausula.Text = clausula.TextoIdentificatorio.Split('-')[1].Trim();
                //SetDescripcionClausula(Convert.ToString(clausula.IdClausula));
                DdlTipoCobertura.SelectedValue = clausula.TipoCobertura.Id.ToString();

                DdlTipoImpresionClausula.SelectedValue = clausula.IdTipoImpresionClausula.ToString();
                DdlTipoContenidoImpresion.SelectedValue = clausula.IdTipoContenidoImpresion.ToString();
                CbEvaluableEnAsistencia.Checked = clausula.EvaluableEnAsistencia;
                CbVisibleEnAsistencia.Checked = clausula.VisibleEnAsistencia;
                TbOrden.Text = Nodo.ImageToolTip;

                CcContenidosClausula.SetearContenido(clausula);
                SetearPadres(clausula);

                DdlClausula.Visible = false;
                LClausula.Visible = true;
                BAgregar.Visible = false;
                BEditar.Visible = true;
                BCopiar.Visible = true;
                BFinalizarCopia.Visible = false;
                bEliminar.Visible = true;
                BCancelarEdicion.Visible = true;

                Session["ClausulaSeleccionada"] = clausula;
            }
        }

        private void SetearPadres(ClausulaDTO clausula)
        {
            foreach (GridViewRow Row in GvClausulasPadre.Rows)
            {
                foreach (string Padre in clausula.TextosIdentificatorioPadre)
                {
                    try
                    {
                        string ClausulaPadre = Padre.Substring(0, Padre.IndexOf('-'));
                        string ClausulaRow = Row.Cells[1].Text.Substring(0, Row.Cells[1].Text.IndexOf('-')); ;

                        ((CheckBox)Row.Cells[0].Controls[1]).Checked =
                            (ClausulaRow.Equals(ClausulaPadre));
                    }
                    catch (Exception)
                    {
                        ((CheckBox)Row.Cells[0].Controls[1]).Checked =
                            (Row.Cells[1].Text.Equals(Padre));
                    }
                }
            }
        }

        private ListItem[] ObtenerClausulas(string knownCategoryValues, string category)
        {
            string[] _categoryValues = knownCategoryValues.Split(':', ';');
            int IdTipoClausula = Convert.ToInt32(_categoryValues[1]);

            List<ListItem> _Categoria = new List<ListItem>();
            if (IdTipoClausula == -1)
            {
                _Categoria.Add(new ListItem("", "-1"));
            }
            else
            {
                IList<Clausula> IClausula = ClausulaHome.BuscarPorParametros(IdTipoClausula, null, null);

                if (IClausula.Count > 0)
                {
                    for (int x = 0; x < IClausula.Count; x++)
                    {
                        _Categoria.Add(new ListItem(IClausula[x].Codigo, IClausula[x].Id.ToString()));
                    }
                }
                else
                {
                    _Categoria.Add(new ListItem("", "-1"));
                }
            }
            return _Categoria.ToArray();
        }

        private ClausulaDTO getClausulaSeleccionada()
        {
            return (ClausulaDTO)Session["ClausulaSeleccionada"];
        }

        private void ObtenerClausulasPorTipoClausula(DropDownList obj)
        {
            DdlClausula.Items.Clear();
            DdlClausula.Items.AddRange(this.ObtenerClausulas("undefined:" + obj.SelectedItem.Value + ";", "GrupoClausula"));
            SetDescripcionClausula(DdlClausula.SelectedItem.Value);
        }

        #endregion

        #region Eventos Boton

        protected void bEliminar_Click(object sender, EventArgs e)
        {
            TreeView Arbol = Utilitario.TreeView(this.Page, TREEVIEW_MENU);
            TreeNode Item = Arbol.SelectedNode;

            getContenido().Remove(TvClausula.SelectedNode.Text);

            ValidarNodoSeleccionado(Item);

            ActualizarPadres();

            BAgregar.Visible = true;
            BEditar.Visible = false;
            BCopiar.Visible = false;
            BFinalizarCopia.Visible = false;
            bEliminar.Visible = false;
            BCancelarEdicion.Visible = false;
            LClausula.Text = "";
            LClausula.Visible = false;
            DdlClausula.Visible = true;
            LMensajeError.Visible = false;
            TbOrden.Text = "0";

            CcContenidosClausula.Limpiar();

            EstrategiasManejoArbol.ObtenerInstancia().ObtenerEstrategia(Item.Depth).Eliminar(Arbol, (IList<int>)Session["NodosEliminados"]);
        }

        protected void BContinuar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GrupoClausula_InformacionAdicional.aspx");
        }

        protected void BCancelar_Click(object sender, EventArgs e)
        {
            if (Session[SessionDataHandler.SUCURSALES] != null)
                SessionDataHandler.RedireccionarFinSLA(Response, "", true);
            else
                SessionDataHandler.RedireccionarFin(Response, "");
        }

        protected void BCopiar_Click(object sender, EventArgs e)
        {
            BEditar.Visible = false;
            BCopiar.Visible = false;
            BFinalizarCopia.Visible = true;
            bEliminar.Visible = false;
            BCancelarEdicion.Visible = true;

            LClausula.Text = "";
            LClausula.Visible = false;
            DdlClausula.Visible = true;
        }

        protected void BAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarExistenciaClausula();

                string Texto = ObtenerTexto();

                string Valor = DdlClausula.SelectedValue;

                if (Convert.ToInt32(TbOrden.Text) > 0)
                    _orden = Convert.ToInt32(TbOrden.Text);
                else
                    _orden = ClausulaHome.Obtener(Convert.ToInt32(Valor)).OrdenPredefinido;


                TreeNode TnItem = new TreeNode(Texto, Valor);
                TnItem.ToolTip = Texto;
                TnItem.Expanded = true;
                TnItem.Selected = true;
                TnItem.ImageToolTip = _orden.ToString();

               

                int Indice;
                if (TvClausula.Nodes[0].ChildNodes.Count == 0)
                {
                    Indice = 0;
                }
                else
                {
                    Indice = Convert.ToInt32(TbOrden.Text) > 0 ? Convert.ToInt32(TbOrden.Text) - 1 : 0;
                }
                if (Indice > TvClausula.Nodes[0].ChildNodes.Count)
                    Indice = BuscarNuevoIndice(Indice);

                Utilitario.TreeView(this.Page, TREEVIEW_MENU).Nodes[0].ChildNodes.AddAt(Indice, TnItem);

                Agregar(Texto);

                ActualizarPadres();
                SessionDataHandler.SetearSeteaPadres(Session, false);
                CcContenidosClausula.Limpiar();


                LMensajeError.Visible = false;

                BAgregar.Visible = true;
                BEditar.Visible = false;
                BCopiar.Visible = false;
                BFinalizarCopia.Visible = false;
                bEliminar.Visible = false;
                BCancelarEdicion.Visible = false;
                LClausula.Text = "";
                LClausula.Visible = false;
                DdlClausula.Visible = true;

            }
            catch (Exception ex)
            {
                LMensajeError.Visible = true;
                LMensajeError.Text = ex.Message;
            }
        }

        protected void BEditar_Click(object sender, EventArgs e)
        {
            try
            {
                ClausulaDTO ClausulaSeleccionada = getClausulaSeleccionada();

                if (Convert.ToInt32(TbOrden.Text) > 0)
                    _orden = Convert.ToInt32(TbOrden.Text);
                else
                    _orden = ClausulaHome.Obtener(ClausulaSeleccionada.IdClausula).OrdenPredefinido;
                

                int Indice = BuscarNuevoIndice(_orden);

                //getContenido().Remove(ClausulaSeleccionada.TextoIdentificatorio);

                ////CON ESTE ANDA
                //string Texto = ClausulaSeleccionada.NombreClausula + " - ";
                //Texto += (DdlTipoImpresionClausula.SelectedItem != null) ? DdlTipoImpresionClausula.SelectedItem.Text + " - " : "";
                //Texto += (CbEvaluableEnAsistencia.Checked) ? CbEvaluableEnAsistencia.Text + " - " : "";
                //Texto += (CbVisibleEnAsistencia.Checked) ? CbVisibleEnAsistencia.Text + " - " : "";
              
                string Valor = DdlClausula.SelectedValue;
                
                TreeNode TnItem = TvClausula.SelectedNode;
                //TnItem.Text = ClauseText;
                //TnItem.ToolTip = ClauseText;
                TnItem.Expanded = true;
                TnItem.Selected = true;
                TnItem.ImageToolTip = _orden.ToString();

                Editar(ClausulaSeleccionada.TextoIdentificatorio, ClausulaSeleccionada);


                Utilitario.TreeView(this.Page, TREEVIEW_MENU).Nodes[0].ChildNodes.AddAt(Indice, TnItem);


                //MoverNodo(Indice);

                BAgregar.Visible = true;
                BEditar.Visible = false;
                BCopiar.Visible = false;
                BFinalizarCopia.Visible = false;
                bEliminar.Visible = false;
                BCancelarEdicion.Visible = false;
                LClausula.Text = "";
                LClausula.Visible = false;
                DdlClausula.Visible = true;
                LMensajeError.Visible = false;
                TbOrden.Text = "0";
                CcContenidosClausula.Limpiar();
                SessionDataHandler.SetearSeteaPadres(Session, false);
            }
            catch (Exception ex)
            {
                LMensajeError.Visible = true;
                LMensajeError.Text = ex.Message;
            }
        }

        protected void BCancelarEdicion_Click(object sender, EventArgs e)
        {
            BAgregar.Visible = true;
            BEditar.Visible = false;
            BCopiar.Visible = false;
            BFinalizarCopia.Visible = false;
            bEliminar.Visible = false;
            BCancelarEdicion.Visible = false;
            LClausula.Text = "";
            LClausula.Visible = false;
            DdlClausula.Visible = true;
            LMensajeError.Visible = false;
            TbOrden.Text = "0";
            CcContenidosClausula.Limpiar();
        }

        protected void BAplicarClausulasPadre_Click(object sender, EventArgs e)
        {
            SessionDataHandler.SetearSeteaPadres(Session, true);
            MpeClausulasPadre.Hide();
        }
        #endregion

        #region Eventos Combo

        protected void DdlClausula_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList obj = (DropDownList)sender;
            SetDescripcionClausula(obj.SelectedItem.Value);

        }

        protected void DdlTipoClausula_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObtenerClausulasPorTipoClausula((DropDownList)sender);
        }

        protected void DdlTipoClausula_DataBound(object sender, EventArgs e)
        {
            DropDownList obj = (DropDownList)sender;
            DdlClausula.Items.Clear();
            DdlClausula.Items.AddRange(this.ObtenerClausulas("undefined:" + obj.SelectedItem.Value + ";", "GrupoClausula"));
            SetDescripcionClausula(DdlClausula.SelectedItem.Value);
        }

        protected void DdlClausula_DataBound(object sender, EventArgs e)
        {
            DropDownList obj = (DropDownList)sender;
            SetDescripcionClausula(obj.SelectedItem.Value);
        }


        #endregion

        #region Eventos Grilla

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

        protected void GvClausulasPadre_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ((GridView)sender).PageIndex = e.NewPageIndex;
            ActualizarPadres();
            MpeClausulasPadre.Show();
        }

        #endregion

        #region Eventos TreeView

        protected void UpMenu_SelectedNodeChanged(object sender, EventArgs e)
        {
            TreeNode Nodo = TvClausula.SelectedNode;

            if (Nodo != null)
            {
                SetearDatos(Nodo);
            }
        }

        #endregion

        protected void labelDescripcionClausula_PreRender(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            if (label.Text.Length > 100)
            {
                ((Label)sender).Text = label.Text.Substring(0, 100) + "[...]";
            }
        }


        private int BuscarNuevoIndice(int Orden)
        {
            int original = Orden;
            int indice = 0;
            int i = 0;
            bool corte = false;

            while((i <  TvClausula.Nodes[0].ChildNodes.Count) && (!corte))
            {
                int ordennodo = Convert.ToInt32(TvClausula.Nodes[0].ChildNodes[i].ImageToolTip);
                if (Orden < ordennodo) 
                {
                    corte = true;
                    indice = i-1;
                }
                i++;
            }
            if (indice == -1)
                indice = 0;

            
            return indice;

        }

    }
}
