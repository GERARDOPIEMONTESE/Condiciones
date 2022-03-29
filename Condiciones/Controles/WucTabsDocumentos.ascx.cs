using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocioDatos.CapaNegocio;
using CapaNegocioDatos.CapaHome;
using Backend.DTO;
using AjaxControlToolkit;

namespace Condiciones.Controles
{
    public partial class WucTabsDocumentos : System.Web.UI.UserControl
    {

        private const string TabPanelName = "Tp{0}";
        private const string WucDocumentoName = "WucDocumento{0}";
        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        protected override void OnInit(EventArgs e)
        {
            SetTabIdiomas();
        }

        public string GetNameTabPanel(int idx)
        {
            return string.Format(TabPanelName, idx);
        }

        public string GetNameWucDocumento(int idx)
        {
            return string.Format(WucDocumentoName, idx);
        }

        private void SetTabIdiomas()
        {
            IList<Idioma> lstIdiomas = IdiomaHome.ObtenerPorTipoCarga();
            foreach (var idioma in lstIdiomas)
            {                
                TabPanel tbPanel = new TabPanel()
                {
                    ID = idioma.Id.ToString(),
                    HeaderText = idioma.Descripcion
                };
                var tab = (WucDocumento)TemplateControl.LoadControl("~/Controles/WucDocumento.ascx");
                tab.SetIdioma(idioma);
                tbPanel.Controls.Add(tab);
                TcDocumentos.Tabs.Add(tbPanel);
            }
        }

        public IList<AdjuntoDTO> ObtenerAdjuntos()
        {
            List<AdjuntoDTO> lstDocs = new List<AdjuntoDTO>();
            foreach (TabPanel tab in TcDocumentos.Tabs)
            {
                lstDocs.AddRange(((WucDocumento)tab.Controls[0]).ObtenerAdjuntos());
            }
            return lstDocs;
        }

        public void SeleccionarDocumentos(IList<Backend.Dominio.AsociacionDocumento> documentos)
        {
            foreach (TabPanel tab in TcDocumentos.Tabs)
            {
                ((WucDocumento)tab.Controls[0]).SeleccionarAdjuntos(documentos);
            }
        }           
    }
}