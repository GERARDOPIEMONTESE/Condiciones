using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocioDatos.CapaNegocio;
using Backend.Homes;
using Backend.DTO;

namespace Condiciones.Controles
{
    public partial class WucDocumento : System.Web.UI.UserControl
    {
        private const string DOCUMENTOS_GV = "DocumentosGv";
        public int ucIdioma 
        {
            get
            {
                return Convert.ToInt32(hfIdioma.Value);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        private void CargarCombos()
        {
            GvDocumentos.DataSource = TipoDocumentoHome.Buscar();
            GvDocumentos.DataBind();            
        }

        internal void SetIdioma(Idioma idioma)
        {
            hfIdioma.Value = idioma.Id.ToString();
            CargarCombos();
        }

        protected void DdlDocumento_DataBound(object sender, EventArgs e)
        {

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
                CargarDocumentos((DropDownList)e.Row.Cells[2].Controls[1], Convert.ToInt32(e.Row.Cells[0].Text));
            }
        }

        private void CargarDocumentos(DropDownList dropDownList, int IdTipoDoc)
        {
            IList<Backend.DTO.DocumentoDTO> lstDocs = ObtenerDocumentos();
            var DocsxIdioma = from p in lstDocs
                       where p.IdIdioma == ucIdioma && p.IdTipoDoc == IdTipoDoc
                       select new { p.Id, p.Nombre };

            dropDownList.DataSource = DocsxIdioma;
            dropDownList.DataBind();
            dropDownList.Items.Insert(0, new ListItem("Ninguno", "0"));
        }

        private IList<Backend.DTO.DocumentoDTO> ObtenerDocumentos()
        {
            if (Session[DOCUMENTOS_GV] == null)
            {
                Session[DOCUMENTOS_GV] = DocumentoHome.BuscarDocumentoDTO();
            }
            return (IList<Backend.DTO.DocumentoDTO>)Session[DOCUMENTOS_GV];
        }


        public IList<AdjuntoDTO> ObtenerAdjuntos()
        {
            IList<AdjuntoDTO> IAdjuntos = new List<AdjuntoDTO>();

            foreach (GridViewRow Row in GvDocumentos.Rows)
            {
                int IdDocumento = 0;

                Int32.TryParse(((DropDownList)Row.Cells[(GvDocumentos.Columns.Count - 1)].Controls[1]).SelectedValue, out IdDocumento);
                if (IdDocumento != 0)
                {
                    IAdjuntos.Add(new AdjuntoDTO(Convert.ToInt32(Row.Cells[0].Text), IdDocumento));
                }
            }

            return IAdjuntos;
        }

        public void SeleccionarAdjuntos(IList<Backend.Dominio.AsociacionDocumento> documentos)
        {
            var docsIdioma = from p in documentos where p.Documento.Idioma.Id == Convert.ToInt32(hfIdioma.Value) select new { p.Documento.Id, p.Documento.TipoDocumento };

            foreach (GridViewRow Row in GvDocumentos.Rows)
            {
                foreach (Backend.Dominio.AsociacionDocumento doc in documentos)
                {
                    if (doc.Documento.TipoDocumento.Id == Convert.ToInt32(Row.Cells[0].Text))
                    {
                        DropDownList DdlDocumento = (DropDownList)Row.Cells[(GvDocumentos.Columns.Count - 1)].Controls[1];
                        DdlDocumento.SelectedValue = doc.Documento.Id.ToString();
                    }
                }
            }
        }
    }
}