using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Backend.Homes;
using Backend.Dominio;
using Backend.DTO;
using Backend.Servicios;
using ControlMenu;
using System.Linq.Expressions;
using CapaNegocioDatos.CapaNegocio;


namespace Condiciones.GrupoClausulas
{
    public partial class GrupoClausula_InformacionAdicional : CustomPage
    {
        private const string DOCUMENTOS_GV = "DocumentosGv";


        private IList<TipoPlan> _tipoPlanSource;

        private IList<TipoPlan> TipoPlanSource 
        {
            get { 
                if(_tipoPlanSource == null)
                {
                    _tipoPlanSource = Backend.Homes.TipoPlanHome.Buscar();
                }
                return _tipoPlanSource;
            
            }
            set { _tipoPlanSource = value; }
        
        }



        private IList<Backend.DTO.DocumentoDTO> ObtenerDocumentos()
        {
            if (Session[DOCUMENTOS_GV] == null) 
            {
                Session[DOCUMENTOS_GV] = DocumentoHome.BuscarDocumentoDTO();
            }
            return (IList<Backend.DTO.DocumentoDTO>)Session[DOCUMENTOS_GV]; 
        }

        protected override void CustomPageLoad(object sender, EventArgs e)
        {
            ValidarSession();
            if (!IsPostBack)
            {
                BindTexto();
                InicializarContenido();
            }
        }

        protected void BBuscar_Click(object sender, EventArgs e)
        {
            BindTexto();
            RePopulateValues();
        }

        public void BindTexto()
        {
            string Nombre = TbNombre.Text == "" ? null : TbNombre.Text;
            
            IList<Texto> ITexto = TextoHome.BuscarPorParametros(Nombre, Texto.RESUMEN, 
                (int)Backend.Dominio.Idioma.Idiomas.Español);

            IList<Texto> sortedList = ITexto;

            if (ViewState["_Direction_"] != null && ViewState["_Expresion_"] != null)
            {
                SortDirection Direction = (SortDirection)ViewState["_Direction_"];

                var prm = Expression.Parameter(typeof(Texto), "root");
                sortedList = new Sorter<Texto>().Sort(ITexto, prm, (string)ViewState["_Expresion_"], Direction);
            }

            GvTextosResumen.DataSource = sortedList;
            GvTextosResumen.DataBind();
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

            BindTexto();
        }


        private void RememberOldValues()
        {
            IDictionary<int, string> categoryIDList = new Dictionary<int, string>();

            int index = -1;
            foreach (GridViewRow row in GvTextosResumen.Rows)
            {
                index = Convert.ToInt32(row.Cells[1].Text);
                bool result = ((CheckBox)row.FindControl("CbTextoResumen")).Checked;

                // Check in the Session
                if (Session["itemsDocumentos"] != null)
                    categoryIDList = (IDictionary<int, string>)Session["itemsDocumentos"];
                if (result)
                {
                    if (!categoryIDList.Keys.Contains(index))
                    {
                        categoryIDList.Add(index, 
                            ((DropDownList)row.FindControl("DdlTipoPlan")).SelectedValue);
                    }                        
                }
                else
                {
                    categoryIDList.Remove(index);
                }
                    
            }
            if (categoryIDList != null && categoryIDList.Count > 0)
                Session["itemsDocumentos"] = categoryIDList;
        }

        private void RePopulateValues()
        {
            IDictionary<int, string> categoryIDList = (IDictionary<int, string>)Session["itemsDocumentos"];
            if (categoryIDList != null && categoryIDList.Count > 0)
            {
                foreach (GridViewRow row in GvTextosResumen.Rows)
                {
                    int index = Convert.ToInt32(row.Cells[1].Text);
                    if (categoryIDList.Keys.Contains(index))
                    {
                        CheckBox myCheckBox = (CheckBox)row.FindControl("CbTextoResumen");
                        myCheckBox.Checked = true;

                        DropDownList TipoPlanList = (DropDownList)row.FindControl("DdlTipoPlan");
                        TipoPlanList.SelectedValue = categoryIDList[index];
                    }
                }
            }
        }

        protected void GvTextosResumen_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            RememberOldValues();
            
            GvTextosResumen.PageIndex = e.NewPageIndex;
            BindTexto();
            InicializarContenido();
            
            RePopulateValues();
        }

        private IList<int> ObtenerIdsTextoResumen(GrupoClausula Grupo)
        {
            IList<int> Ids = new List<int>();

            foreach (AsociacionTexto Texto in Grupo.Textos)
            {
                Ids.Add(Texto.IdTexto);
            }

            return Ids;
        }

        private void InicializarContenido()
        {
            if ((SessionDataHandler.MODALIDAD_EDITAR.Equals(Session[SessionDataHandler.MODALIDAD].ToString()))
                || (SessionDataHandler.MODALIDAD_COPIAR.Equals(Session[SessionDataHandler.MODALIDAD].ToString())))
            {

                GrupoClausula Grupo = (GrupoClausula)Session[SessionDataHandler.GRUPO_CLAUSULAS];
              

                if (Session["itemsDocumentos"] == null)
                {
                    IDictionary<int, string> Items = new Dictionary<int, string>();
                    foreach (AsociacionTexto Asociacion in Grupo.Textos)
                    {
                        Items.Add(Asociacion.IdTexto, Asociacion.IdTipoPlan.ToString());
                    }

                    Session["itemsDocumentos"] = Items;
                }

                RePopulateValues();

                WucTabsDocumentos1.SeleccionarDocumentos(Grupo.Documentos);                
            }
        }

        //private FileUpload ObtenerFileUpload(int IdTipoDocumento)
        //{
        //    foreach (GridViewRow Row in GvDocumentos.Rows)
        //    {
        //        if (Convert.ToInt32(Row.Cells[0].Text) == IdTipoDocumento)
        //        {
        //            return (FileUpload)Row.Cells[(GvDocumentos.Columns.Count - 1)].Controls[1];
        //        }
        //    }

        //    return null;
        //}

        protected void DropDownList_DataBound(object sender, EventArgs e)
        {
            ((DropDownList)sender).Items.Insert(0, new ListItem("Ninguno", "0"));
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
                DropDownList dropdownlist = (DropDownList)e.Row.Cells[3].FindControl("DdlTipoPlan");
                dropdownlist.DataSource = TipoPlanSource;
                dropdownlist.DataBind();
            }
        }

        private void CargarDocumentos(DropDownList DropDownList)
        {
            DropDownList.DataSource = ObtenerDocumentos();
            DropDownList.DataBind();
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
                CargarDocumentos((DropDownList) e.Row.Cells[2].Controls[1]);
            }
        }

        private IList<AsociacionTexto> ObtenerTextoResumen()
        {
            IList<AsociacionTexto> Textos = new List<AsociacionTexto>();

            //int IdTextoResumen = -1;

            RememberOldValues();
            if (Session["itemsDocumentos"] != null)
            {
                foreach (int IdTextoResumen in ((Dictionary<int, string>)Session["itemsDocumentos"]).Keys)
                {
                    Texto Texto = TextoHome.Obtener(IdTextoResumen);

                    AsociacionTexto Asociacion = new AsociacionTexto();
                    Asociacion.IdTexto = Texto.Id;
                    Asociacion.IdTipoTexto = Texto.TipoTexto.Id;
                    Asociacion.IdTipoPlan = Convert.ToInt32(
                        ((Dictionary<int, string>)Session["itemsDocumentos"])[IdTextoResumen]);

                    Textos.Add(Asociacion);
                }
            }

            return Textos;
        }    

        private void Editar()
        {
            if (PuedeEjecutarAccion(PermisosConstant.CREACION_GRUPOS))
            {
                ServicioGrupoClausula.Editar(CrearGrupo());
            }
            else
            {
                 int IdGrupoClausula = Session[SessionDataHandler.GRUPO_CLAUSULAS] == null ?
                    0 : ((GrupoClausula)Session[SessionDataHandler.GRUPO_CLAUSULAS]).Id;

                if (IdGrupoClausula != 0) 
                {
                    GrupoClausula Grupo = GrupoClausulaHome.Obtener(IdGrupoClausula);

                    Grupo.IdUsuario = UsuarioLogueadoDTO() != null ? UsuarioLogueadoDTO().IdUsuario : -1;

                    ServicioGrupoClausula.Editar(Grupo, 
                        (IList<Tarifa>)Session[SessionDataHandler.TARIFAS]);
                }
            }
        }

        private Backend.DTO.GrupoClausulaDTO CrearGrupo()
        {
            Backend.DTO.GrupoClausulaDTO Grupo = new Backend.DTO.GrupoClausulaDTO();

            Grupo.IdGrupoClausula = Session[SessionDataHandler.GRUPO_CLAUSULAS] == null ?
                0 : ((GrupoClausula)Session[SessionDataHandler.GRUPO_CLAUSULAS]).Id;

            Grupo.CodigoPais = Convert.ToInt32(Session[SessionDataHandler.PAIS]);
            Grupo.Producto = (Producto)Session[SessionDataHandler.PRODUCTO];
            Grupo.TipoGrupoClausula = (TipoGrupoClausula)Session[SessionDataHandler.TIPO_GRUPO_CLAUSULA];
            Grupo.Anual = (bool)Session[SessionDataHandler.ANUAL];
            Grupo.DiasConsecutivos = (int)Session[SessionDataHandler.DIAS_CONSECUTIVOS];
            Grupo.Clausulas = (IDictionary<string, Backend.DTO.ClausulaDTO>)Session[SessionDataHandler.CONTENIDO];
            Grupo.Textos = ObtenerTextoResumen();
            Grupo.Adjuntos = WucTabsDocumentos1.ObtenerAdjuntos(); //ObtenerAdjuntos();
            Grupo.Tarifas = (IList<Tarifa>)Session[SessionDataHandler.TARIFAS];
            Grupo.IdUsuario = UsuarioLogueadoDTO().IdUsuario;
            
            //04012013 SLA
            Grupo.Sucursales = (IList<Sucursal>)Session[SessionDataHandler.SUCURSALES];

            return Grupo;
        }

        protected void BAceptar_Click(object sender, EventArgs e)
        {
      
            if (SessionDataHandler.MODALIDAD_CREAR.Equals(Session["Modalidad"].ToString()) ||
                SessionDataHandler.MODALIDAD_COPIAR.Equals(Session["Modalidad"].ToString()))
            {
                ServicioGrupoClausula.Crear(CrearGrupo());
            }
            else
            {
                Editar();
            }

            if (Session[SessionDataHandler.SUCURSALES] != null)
                SessionDataHandler.RedireccionarFinSLA(Response, "", true);
            else
                SessionDataHandler.RedireccionarFin(Response, "");
        }

        protected void BCancelar_Click(object sender, EventArgs e)
        {
            if (Session[SessionDataHandler.SUCURSALES] != null)
                SessionDataHandler.RedireccionarFinSLA(Response, "", true);
            else
                SessionDataHandler.RedireccionarFin(Response, "");
        }

        protected override void HabilitarControles()
        {
            if (PuedeEjecutarAccion(PermisosConstant.SOLO_VISUALIZA_GRUPOS))
            {
                BAceptar.Visible = false;
            }

            if (Session[SessionDataHandler.GRUPO_CLAUSULAS] == null 
                && PuedeEjecutarAccion(PermisosConstant.SOLO_ASOCIACION_GRUPOS))
            {
                BAceptar.Visible = false;
            }
        } 
    }
}
