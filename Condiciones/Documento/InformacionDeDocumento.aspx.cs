using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.Dominio;
using ControlMenu;
using Backend.Homes;
using System.Collections.Specialized;

namespace Condiciones
{
    public partial class InformacionDeDocumento : CustomPage
    {
        
        protected override void CustomPageLoad(object sender, EventArgs e)
        {
            ValidarSession();
            lblErrorFileSize.Visible = false;
            if (!IsPostBack)
            {
                CargarCombos();
                if (Request.QueryString["Id"] != null)
                {
                    BEliminar.Visible = true;
                    
                    FDocumentoModif.Visible = true;
                    FDocumento.Visible = false;

                    Session["DocumentoAbm"] = DocumentoHome.Obtener(Convert.ToInt32(Request.QueryString["Id"]));
                    CargarInformacion((Backend.Dominio.Documento)Session["DocumentoAbm"]);
                }
                else
                {
                    
                    BEliminar.Visible = false;
                    
                    FDocumentoModif.Visible = false;
                    FDocumento.Visible = true;

                    Session["DocumentoAbm"] = new Backend.Dominio.Documento();
                    CargarInformacion(new Backend.Dominio.Documento());
                }
            }
        }

        protected void TVAsociaciones_TreeNodePopulate(object sender, TreeNodeEventArgs e)
        {
            if (e.Node.Depth == 0)
            {
                IList<AsociacionDocumento> AsociacionesDocumentoProductos = (IList<AsociacionDocumento>)Session["AsociacionesDocumentoProductos"];
                IDictionary<int, AsociacionDocumento> ProductosAsociados = ObtenerDiccionario(AsociacionesDocumentoProductos);

                int CodigoPais = Convert.ToInt32(e.Node.Text.Split('-')[0].Trim());
                IList<Producto> IProductos = ProductoHome.Buscar(CodigoPais, 0);
                if (IProductos.Count() > 0)
                {
                    for (int i = 0; i < IProductos.Count; i++)
                    {
                        TreeNode Nodo = new TreeNode(IProductos[i].CodigoYNombre, Convert.ToString(IProductos[i].Id));
                        if (ProductosAsociados.Keys.Contains(IProductos[i].Id))
                        {
                            Nodo.Checked = true;
                        }
                        Nodo.Expanded = true;
                        Nodo.ImageUrl = "~/IMG/icon_package.gif";
                        e.Node.ChildNodes.Add(Nodo);

                    }
                }
            }
        }

        #region Metodos Privados
        private void CargarCombos()
        {
            DdlIdioma.DataSource = Backend.Homes.IdiomaHome.Buscar();
            DdlIdioma.DataTextField = "Nombre";
            DdlIdioma.DataValueField = "Id";
            DdlIdioma.DataBind();

            DdlTipoDocumento.DataSource = Backend.Homes.TipoDocumentoHome.Buscar();
            DdlTipoDocumento.DataTextField = "Nombre";
            DdlTipoDocumento.DataValueField = "Id";
            DdlTipoDocumento.DataBind();
        }

        private void CargarInformacion(Backend.Dominio.Documento documento)
        {
            List<AsociacionDocumento> asociacionpaises = new List<AsociacionDocumento>();
            List<AsociacionDocumento> asociacionproductos  =  new List<AsociacionDocumento>();
            List<AsociacionDocumento> asociacionclausulas = new List<AsociacionDocumento>();

            if (documento.Id != 0)
            {
                TbNombre.Text = documento.Nombre;
                TbObservaciones.Text = documento.Observaciones;
                DdlIdioma.SelectedValue = documento.Idioma.Id.ToString();
                DdlTipoDocumento.SelectedValue = documento.TipoDocumento.Id.ToString();

                asociacionpaises = (List<AsociacionDocumento>)AsociacionDocumentoHome.BuscarPorDocumento(documento.Id, 1);
                asociacionproductos = (List<AsociacionDocumento>) AsociacionDocumentoHome.BuscarPorDocumento(documento.Id, 2);
                asociacionclausulas = (List<AsociacionDocumento>) AsociacionDocumentoHome.BuscarPorDocumento(documento.Id, 3);
            }

            Session["AsociacionesDocumentoPaises"] = asociacionpaises;
            Session["AsociacionesDocumentoProductos"] = asociacionproductos;
            Session["AsociacionesDocumentoGruposClausulas"] = asociacionclausulas;
         
            InicializarArbolCheckBox(asociacionpaises);
            InicializarArbolActuales(asociacionpaises,asociacionproductos, asociacionclausulas);
        }

        private void Redireccionar()
        {
            Session.Remove("AsociacionesDocumentoPaises");
            Session.Remove("AsociacionesDocumentoProductos");
            Response.Redirect("./ListaDeDocumentos.aspx");
        }

        private void Persistir()
        {


            Backend.Dominio.Documento Documento = (Backend.Dominio.Documento)Session["DocumentoAbm"];

            if (FDocumento.Visible)
            {
                HttpPostedFile File = FDocumento.PostedFile;

                byte[] Data = new Byte[File.ContentLength];
                File.InputStream.Read(Data, 0, File.ContentLength);

                Documento.DocumentoContenido = Data;
                Documento.DocumentoDimension = File.ContentLength;
                Documento.DocumentoTipoContenido = File.ContentType;
                Documento.CodigoValidacion = Guid.NewGuid();
            }

            if (FDocumentoModif.Visible)
            {
                HttpPostedFile File = FDocumentoModif.PostedFile;

                if (File.ContentLength != 0 && !File.FileName.Equals("") && File.ContentType != null)
                {
                    byte[] Data = new Byte[File.ContentLength];
                    File.InputStream.Read(Data, 0, File.ContentLength);

                    Documento.DocumentoContenido = Data;
                    Documento.DocumentoDimension = File.ContentLength;
                    Documento.DocumentoTipoContenido = File.ContentType;
                }
            }

            TipoDocumento tipodocumento = new TipoDocumento();
            tipodocumento.Id = Convert.ToInt32(DdlTipoDocumento.SelectedValue);

            Idioma idioma = new Idioma();
            idioma.Id = Convert.ToInt32(DdlIdioma.SelectedValue);

            Documento.Nombre = TbNombre.Text;
            Documento.Observaciones = TbObservaciones.Text;
            Documento.TipoDocumento = tipodocumento;
            Documento.Idioma = idioma;
            Documento.IdUsuario = UsuarioLogueadoDTO().Id;
            Documento.Fecha = DateTime.Now;
            Documento.Persistir();

            PersistirAsociacionesPaisesYProductos2(Documento);


        }

        private void InicializarArbolCheckBox(IList<AsociacionDocumento> AsociacionesDocumentoPaises)
        {



            TVAsociaciones.Nodes.Clear();
            IDictionary<int, AsociacionDocumento> PaisesAsociados = ObtenerDiccionario(AsociacionesDocumentoPaises);

            IList<Pais> IPaises = PaisHome.BuscarConProductos();
            if (IPaises.Count() > 0)
            {
                for (int i = 0; i < IPaises.Count; i++)
                {
                    TreeNode Nodo = new TreeNode(IPaises[i].Codigo + " - " + IPaises[i].Nombre, IPaises[i].Codigo.ToString());
                    if (PaisesAsociados.Keys.Contains(Convert.ToInt32(IPaises[i].Codigo)))
                    {
                        Nodo.Checked = true;
                    }
                    Nodo.PopulateOnDemand = true;
                    Nodo.Collapse();
                    Nodo.ImageUrl = "~/IMG/icon_world.gif";
                    TVAsociaciones.Nodes.Add(Nodo);
                }
            }
        }

        private IDictionary<int, AsociacionDocumento> ObtenerDiccionario(IList<AsociacionDocumento> AsociacionesDocumento)
        {
            IDictionary<int, AsociacionDocumento> AsociacionesEnDiccionario = new Dictionary<int, AsociacionDocumento>();

            for (int i = 0; i < AsociacionesDocumento.Count; i++) 
            {
                AsociacionesEnDiccionario.Add(AsociacionesDocumento[i].IdObjeto, AsociacionesDocumento[i]);
            }
    
            return AsociacionesEnDiccionario;
        }

        private void InicializarArbolActuales(IList<AsociacionDocumento> AsociacionesDocumentoPaises, IList<AsociacionDocumento> AsociacionesDocumentoProductos, IList<AsociacionDocumento> AsociacionesDocumentoGruposClausulas)
        {
            TVAsociacionesActuales.Nodes.Clear();

            IList<KeyValuePair<Producto, AsociacionDocumento>> AsociacionesDocumentoProductosConProductoSinPaisesAsignados = ObtenerAsociacionDocumentoProductoConProducto(AsociacionesDocumentoProductos);
            IList<KeyValuePair<Producto, AsociacionDocumento>> AsociacionesDocumentoProductosConProductoSinPaisesAsignadosClon = new List<KeyValuePair<Producto, AsociacionDocumento>> { };

            AsociacionesDocumentoProductosConProductoSinPaisesAsignadosClon = new List<KeyValuePair<Producto, AsociacionDocumento>>(((KeyValuePair<Producto, AsociacionDocumento>[])AsociacionesDocumentoProductosConProductoSinPaisesAsignados.ToArray().Clone()));

            TreeNode NodoNoPais = new TreeNode("No incluye al País", "0");

            foreach (AsociacionDocumento AsociacionPais in AsociacionesDocumentoPaises)
            {
                Pais pais = PaisHome.ObtenerPorCodigo(AsociacionPais.IdObjeto);
                if (pais != null)
                {
                    TreeNode NodoPais = new TreeNode(pais.Codigo + " - " + pais.Nombre, Convert.ToString(pais.Codigo));
                    NodoPais.ImageUrl = "~/IMG/icon_world.gif";
                    TVAsociacionesActuales.Nodes.Add(NodoPais);

                    //Buscar todos los productos para este pais y agregarlos
                    AsociacionesDocumentoProductosConProductoSinPaisesAsignados = new List<KeyValuePair<Producto, AsociacionDocumento>>(((KeyValuePair<Producto, AsociacionDocumento>[])AsociacionesDocumentoProductosConProductoSinPaisesAsignadosClon.ToArray().Clone()));
                    foreach (KeyValuePair<Producto, AsociacionDocumento> item in AsociacionesDocumentoProductosConProductoSinPaisesAsignados)
                    {
                        TreeNode NodoProducto = null;
                        if (item.Key.CodigoPais.Equals(Convert.ToInt32(pais.Codigo)))
                        {
                            NodoProducto = new TreeNode(item.Key.CodigoYNombre, Convert.ToString(item.Key.Id));
                            NodoProducto.ImageUrl = "~/IMG/icon_package.gif";
                            NodoPais.ChildNodes.Add(NodoProducto);
                            NodoProducto.Expanded = true;

                            //Eliminar del clon de la lista el producto ya asociado a un pais
                            AsociacionesDocumentoProductosConProductoSinPaisesAsignadosClon.Remove(item);
                        }
                    }
                    NodoPais.Expanded = true;
                }
            }

            if (AsociacionesDocumentoPaises.Count == 0)
            {
                //Solo Productos sin Pais
                foreach (AsociacionDocumento AsociacionProducto in AsociacionesDocumentoProductos)
                {
                    Producto producto = ProductoHome.Obtener(AsociacionProducto.IdObjeto);
                    if (producto != null)
                    {
                        TreeNode NodoProducto = new TreeNode(producto.CodigoYNombre, Convert.ToString(producto.Id));
                        NodoProducto.ImageUrl = "~/IMG/icon_package.gif";
                        NodoProducto.Text = producto.CodigoPais + " - " + NodoProducto.Text;
                        NodoNoPais.ChildNodes.Add(NodoProducto);
                        NodoProducto.Expanded = true;
                    }
                }
            }
            else
            {
                //Si quedan productos no asignados a paises en el arbol, cargarlos sin pais
                foreach (KeyValuePair<Producto, AsociacionDocumento> item in AsociacionesDocumentoProductosConProductoSinPaisesAsignadosClon)
                {
                    TreeNode NodoProductoSinPais = new TreeNode(item.Key.CodigoPais + " - " + item.Key.CodigoYNombre, Convert.ToString(item.Key.Id));
                    NodoNoPais.ChildNodes.Add(NodoProductoSinPais);
                }
            }

            if (NodoNoPais.ChildNodes.Count > 0)
            {
                TVAsociacionesActuales.Nodes.Add(NodoNoPais);
                NodoNoPais.Expanded = true;
            }

            //Grupo de Clausulas
            foreach (AsociacionDocumento AsociacionGrupoClausulas in AsociacionesDocumentoGruposClausulas)
            {
                GrupoClausula grupoClausula = GrupoClausulaHome.Obtener(AsociacionGrupoClausulas.IdObjeto);
                if (grupoClausula != null)
                {
                    TreeNode NodoGrupoClausula = new TreeNode("Grupo de Clausulas " + grupoClausula.Id, Convert.ToString(grupoClausula.Id));
                    NodoGrupoClausula.ImageUrl = "~/IMG/icon_component.gif";
                    NodoGrupoClausula.ToolTip = "Clauses";
                    TVAsociacionesActuales.Nodes.Add(NodoGrupoClausula);

                    IList<ObjetoAgrupadorClausula> AgrupadorTarifas = grupoClausula.Objetos;
                    foreach (ObjetoAgrupadorClausula AgrupadorTarifa in AgrupadorTarifas)
                    {
                        Tarifa tarifa = TarifaHome.Obtener(AgrupadorTarifa.IdObjetoAgrupador);
                        TreeNode NodoTarifa = new TreeNode(tarifa.Codigo + " - " + tarifa.Nombre, Convert.ToString(tarifa.Id));
                        NodoTarifa.ImageUrl = "~/IMG/list_components.gif";
                        NodoGrupoClausula.ChildNodes.Add(NodoTarifa);
                        NodoTarifa.Expanded = true;
                    }

                    NodoGrupoClausula.Expanded = true;
                }
            }

        }

        private void PersistirAsociacionesPaisesYProductos(Backend.Dominio.Documento Documento)
        {
            IList<AsociacionDocumento> AsociacionesDocumentoPaises = (IList<AsociacionDocumento>)Session["AsociacionesDocumentoPaises"];
            IList<AsociacionDocumento> AsociacionesDocumentoProductos = (IList<AsociacionDocumento>)Session["AsociacionesDocumentoProductos"];

            IDictionary<int, AsociacionDocumento> PaisesAsociados = ObtenerDiccionario(AsociacionesDocumentoPaises);
            IDictionary<int, AsociacionDocumento> ProductosAsociados = ObtenerDiccionario(AsociacionesDocumentoProductos);

            //Lista de NodosPaises No Checkeados
            IDictionary<int, string> EliminarAsociacionesDocumentoPais = new Dictionary<int, string>();
            IDictionary<int, string> EliminarAsociacionesDocumentoProducto = new Dictionary<int, string>();

            //Recorrer el arbol buscando los paises y productos seleccionados nuevos
            TreeNodeCollection NodosPaises = TVAsociaciones.Nodes;
            foreach (TreeNode NodoPais in NodosPaises)
            {
                if (NodoPais.Checked)
                {
                    if (!NodoPais.Value.Equals("-1"))
                    {
                        if (!(PaisesAsociados.Keys.Contains(Convert.ToInt32(NodoPais.Value))))
                        {
                            AsociacionDocumento NuevaAsociacionDocumento = new AsociacionDocumento();
                            NuevaAsociacionDocumento.TipoAsociacionDocumento = TipoAsociacionDocumentoHome.Pais();
                            NuevaAsociacionDocumento.Documento = Documento;
                            NuevaAsociacionDocumento.IdUsuario = ((UsuarioLogueadoDTO() != null) ? UsuarioLogueadoDTO().Id : -1);
                            NuevaAsociacionDocumento.IdObjeto = Convert.ToInt32(NodoPais.Value);
                            NuevaAsociacionDocumento.Crear();
                        }
                    }
                }
                else
                {
                    if (!NodoPais.Value.Equals("-1"))
                    {
                        EliminarAsociacionesDocumentoPais.Add(Convert.ToInt32(NodoPais.Value), NodoPais.Text);
                    }
                }
                if (NodoPais.ChildNodes.Count > 0)
                {
                    foreach (TreeNode NodoProducto in NodoPais.ChildNodes)
                    {
                        if (NodoProducto.Checked)
                        {
                            if (!NodoProducto.Value.Equals("-1"))
                            {
                                if (!(ProductosAsociados.Keys.Contains(Convert.ToInt32(NodoProducto.Value))))
                                {
                                    AsociacionDocumento NuevaAsociacionDocumento = new AsociacionDocumento();
                                    NuevaAsociacionDocumento.TipoAsociacionDocumento = TipoAsociacionDocumentoHome.Producto();
                                    NuevaAsociacionDocumento.Documento = Documento;
                                    NuevaAsociacionDocumento.IdUsuario = ((UsuarioLogueadoDTO() != null) ? UsuarioLogueadoDTO().Id : -1);
                                    NuevaAsociacionDocumento.IdObjeto = Convert.ToInt32(NodoProducto.Value);
                                    NuevaAsociacionDocumento.Crear();
                                }
                            }
                        }
                        else
                        {
                            if (!NodoProducto.Value.Equals("-1"))
                            {
                                EliminarAsociacionesDocumentoProducto.Add(Convert.ToInt32(NodoProducto.Value), NodoProducto.Text);
                            }
                        }
                    }
                }
            }

            //Recorrer Lista de asociaciones para determinar cuáles se eliminan
            foreach (AsociacionDocumento AsociacionDocumentoPais in AsociacionesDocumentoPaises)
            {
                if (EliminarAsociacionesDocumentoPais.Keys.Contains(AsociacionDocumentoPais.IdObjeto))
                {
                    AsociacionDocumentoPais.Eliminar();
                }
            }
            foreach (AsociacionDocumento AsociacionesDocumentoProducto in AsociacionesDocumentoProductos)
            {
                if (EliminarAsociacionesDocumentoProducto.Keys.Contains(AsociacionesDocumentoProducto.IdObjeto))
                {
                    AsociacionesDocumentoProducto.Eliminar();
                }
            }

        }


        private void PersistirAsociacionesPaisesYProductos2(Backend.Dominio.Documento Documento)
        {
            try
            {
                string asociacionPaises = string.Empty;
                string asociacionProducto = string.Empty;
                string asociacionClausula = string.Empty;

                CargarAsociaciones(ref asociacionPaises, ref asociacionProducto, ref asociacionClausula);

                //Borra Todas las asociasiones al documentos
                AsociacionDocumentoHome.BorrarAsociasiones(Convert.ToInt32(Documento.Id));

                AsociacionDocumentoHome.CrearAsociacionesADocumento(Documento.Id, asociacionPaises, 1, ((UsuarioLogueadoDTO() != null) ? UsuarioLogueadoDTO().Id : -1));
                AsociacionDocumentoHome.CrearAsociacionesADocumento(Documento.Id, asociacionProducto, 2, ((UsuarioLogueadoDTO() != null) ? UsuarioLogueadoDTO().Id : -1));
                AsociacionDocumentoHome.CrearAsociacionesADocumento(Documento.Id, asociacionClausula, 3, ((UsuarioLogueadoDTO() != null) ? UsuarioLogueadoDTO().Id : -1));

            }
            catch (Exception ex)
            {
                lblMensajeError.Text = ex.Message;
            }
         
        }

        private void CargarAsociaciones(ref string asociacionPaises, ref string asociacionProducto, ref string asociacionClausulas)
        {
            try
            {
                TreeNodeCollection NodosPaises = TVAsociaciones.Nodes;
                foreach (TreeNode NodoPais in NodosPaises)
                {
                    if (NodoPais.Checked)
                    {
                        if (!NodoPais.Value.Equals("-1"))
                        {
                            asociacionPaises = asociacionPaises + NodoPais.Value + ",";
                        }
                    }
                    NodoPais.ExpandAll(); //NO sacar esto porque por deja de tomar los nodos hijos.
                    foreach (TreeNode NodoProducto in NodoPais.ChildNodes)
                    {
                        if (NodoProducto.Checked)
                        {
                            if (!NodoProducto.Value.Equals("-1"))
                            {
                                asociacionProducto = asociacionProducto + NodoProducto.Value + ",";
                            }
                        }
                    }
                    
                }
                TreeNodeCollection NodosAsociacionesActuales = TVAsociacionesActuales.Nodes;
                foreach (TreeNode NodoClausula in NodosAsociacionesActuales)
                {
                    if (NodoClausula.ToolTip == "Clauses")
                    {
                        asociacionClausulas = asociacionClausulas + NodoClausula.Value + ",";
                    }
                }

                if (asociacionPaises != string.Empty)
                {
                    asociacionPaises = asociacionPaises.Substring(0, asociacionPaises.Length - 1);
                }

                if (asociacionProducto != string.Empty)
                {
                    asociacionProducto = asociacionProducto.Substring(0, asociacionProducto.Length - 1);
                }
                if (asociacionClausulas != string.Empty)
                {
                    asociacionClausulas = asociacionClausulas.Substring(0, asociacionClausulas.Length - 1);
                }
            }
            catch (Exception ex)
            {
                lblMensajeError.Text = ex.Message;
            }
        }

        private IList<KeyValuePair<Producto, AsociacionDocumento>> ObtenerAsociacionDocumentoProductoConProducto(IList<AsociacionDocumento> AsociacionesDocumentoProductos)
        {
            List<KeyValuePair<Producto, AsociacionDocumento>> listaProductosConProducto = new List<KeyValuePair<Producto, AsociacionDocumento>>();
            foreach (AsociacionDocumento AsociacionDocumentoProducto in AsociacionesDocumentoProductos)
            {
                Producto producto = ProductoHome.Obtener(AsociacionDocumentoProducto.IdObjeto);
                if (producto != null)
                {
                    listaProductosConProducto.Add(new KeyValuePair<Producto, AsociacionDocumento>(producto, AsociacionDocumentoProducto));
                }
            }
            return listaProductosConProducto;
        }

        #endregion

        #region Eventos Grilla

        protected void GvGruposClausulas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.background ='#ecf0f9'");
                e.Row.Attributes.Add("onmouseout", "this.style.background ='#ffffff'");
            }
        }

        #endregion

        #region Eventos Boton
        protected void BEliminar_Click(object sender, EventArgs e)
        {
            ValidarSession();
            Backend.Dominio.Documento Documento = (Backend.Dominio.Documento)Session[SessionDataHandler.DOCUMENTO];

            Documento.Eliminar();

            Redireccionar();
        }        

        protected void bGrabar_Click(object sender, EventArgs e)
        {
            if(ValidarTamañoArchivo())
            {
                Persistir();
                Redireccionar();
            }
            
           
        }

        private bool ValidarTamañoArchivo()
        {
            int maxsize = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["FileMaxSize"]);

            bool result = false;
            if (FDocumento.Visible) 
            {
                if(FDocumento.PostedFile != null)
                {
                    if(FDocumento.PostedFile.ContentLength < maxsize)
                        result = true;
                    else
                        lblErrorFileSize.Visible = true;
                }
            }

            if (FDocumentoModif.Visible) 
            {
                if (FDocumentoModif.PostedFile != null)
                {
                    if (FDocumentoModif.PostedFile.ContentLength < maxsize)
                        result = true;
                    else
                        lblErrorFileSize.Visible = true;
                }
            }

            return result;
        }


        

        protected void BCancelar_Click(object sender, EventArgs e)
        {
            Redireccionar();
        }

        protected void BAceptar_Click(object sender, EventArgs e)
        {
            //Persistir();
            Backend.Dominio.Documento Documento = (Backend.Dominio.Documento)Session["DocumentoAbm"];

            if (FDocumento.Visible)
            {
                HttpPostedFile File = FDocumento.PostedFile;

                byte[] Data = new Byte[File.ContentLength];
                File.InputStream.Read(Data, 0, File.ContentLength);

                Documento.DocumentoContenido = Data;
                Documento.DocumentoDimension = File.ContentLength;
                Documento.DocumentoTipoContenido = File.ContentType;
                Documento.CodigoValidacion = Guid.NewGuid();
            }

            if (FDocumentoModif.Visible)
            {
                HttpPostedFile File = FDocumentoModif.PostedFile;

                if (File.ContentLength != 0 && !File.FileName.Equals("") && File.ContentType != null)
                {
                    byte[] Data = new Byte[File.ContentLength];
                    File.InputStream.Read(Data, 0, File.ContentLength);

                    Documento.DocumentoContenido = Data;
                    Documento.DocumentoDimension = File.ContentLength;
                    Documento.DocumentoTipoContenido = File.ContentType;
                }
            }

            TipoDocumento tipodocumento = new TipoDocumento();
            tipodocumento.Id = Convert.ToInt32(DdlTipoDocumento.SelectedValue);

            Idioma idioma = new Idioma();
            idioma.Id = Convert.ToInt32(DdlIdioma.SelectedValue);


            Documento.Nombre = TbNombre.Text;
            Documento.Observaciones = TbObservaciones.Text;
            Documento.TipoDocumento = tipodocumento;
            Documento.Idioma = idioma;
            Documento.IdUsuario = UsuarioLogueadoDTO().Id;
            Documento.Fecha = DateTime.Now;
            Documento.Persistir();

            Redireccionar();
        }
    
        protected void BCancelarConfirmacion_Click(object sender, EventArgs e)
        {
            Redireccionar();
        }

        protected void BConfirmar_Click(object sender, EventArgs e)
        {
            Persistir();
            Redireccionar();
        }

        #endregion

    }
}
