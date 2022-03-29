using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.Homes;
using Backend.Dominio;
using AjaxControlToolkit;
using ControlMenu;
using System.Text;

namespace Condiciones
{
    public partial class InformacionDeTextoResumen : CustomPage
    {
       
        protected override void CustomPageLoad(object sender, EventArgs e)
        {
            ValidarSession();
            bAgregar.Focus();
            if (!IsPostBack)
            {
                Session["Texto"] = new Texto();

                string NombreTipoTexto = Request.QueryString[SessionDataHandler.TIPO_TEXTO] != null ?
                    Request.QueryString[SessionDataHandler.TIPO_TEXTO] : TipoTexto.CODIGO_RESUMEN_BENEFICIOS;
                
                if (Request.QueryString["Id"] != null)
                {
                    Session["Texto"] = TextoHome.Obtener(
                        Convert.ToInt32(Request.QueryString["Id"]));

                    if (Request.QueryString["TipoTexto"] != null)
                    {
                        NombreTipoTexto = Request.QueryString["TipoTexto"];
                        Session["TipoTexto"] = TipoTextoHome.Obtener(NombreTipoTexto);
                    }

                    Edicion();
                    
                }
                SetearVisibilidad(NombreTipoTexto);
            }
        }

        protected override void HabilitarControles()
        {
            if (!IsPostBack)
            {
                Texto texto = (Texto)Session["Texto"];
                TbNombre.Enabled = texto.Id == 0;
                DdlTipoTextoResumen.Enabled = texto.Id == 0;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            IList<Idioma> IIdioma = IdiomaHome.Buscar();

            foreach (Idioma Idi in IIdioma)
            {
                TabPanel TabPanel = new TabPanel();

                TabPanel.HeaderText = Idi.Nombre;
                TabPanel.ID = Convert.ToString(Idi.Id);

                Condiciones.Controles.TextosResumen TabIdioma = (Condiciones.Controles.TextosResumen)TemplateControl.LoadControl("~/Controles/TextosResumen.ascx");
                TabIdioma.Idioma = IdiomaHome.Obtener(Idi.Id);

                TabPanel.Controls.Add((Control)TabIdioma);
                TCIdioma.Tabs.Add(TabPanel);
            }

            TCIdioma.ActiveTabIndex = 0;
            base.OnInit(e);
        }

        #region "Metodos Privados"

        private void SetearVisibilidad(string TipoTexto)
        {
            BAgregarMascara.Visible = Backend.Dominio.TipoTexto.CODIGO_RESUMEN_BENEFICIOS.Equals(
                TipoTexto);
            TbMascara.Visible = BAgregarMascara.Visible;
            lblNombreMascara.Visible = TbMascara.Visible;
        }

        private void Edicion()
        {
            IList<Texto> ITextoResumen = new List<Texto>();
            Texto TextoResumen = SessionDataHandler.Texto(Session);
            ITextoResumen.Add(TextoResumen);
            
            if (TextoResumen.Id != 0) {
                TbNombre.Text = TextoResumen.Nombre;
                DdlTipoTextoResumen.SelectedValue = TextoResumen.TipoTextoResumen.Id.ToString();
            }

            CargarDatoTextoResumen(ITextoResumen);
        }

        private void CargarDatoTextoResumen(IList<Texto> ITextoResumen)
        {
            foreach (TabPanel TabPanel in TCIdioma.Tabs)
            {
                if (TabPanel.Visible)
                {
                    Controles.TextosResumen TabIdioma = (Controles.TextosResumen)TabPanel.Controls[0];

                    foreach (Texto_Idioma TRI in ITextoResumen[0].Texto_Idioma)
                    {
                        if (TRI.IdIdioma == TabIdioma.Idioma.Id)
                        {
                            TabIdioma.CargarInformacion(TRI);
                            TabIdioma.Visible = true;
                            break;
                        }
                    }
                }
            }

            TCIdioma.ActiveTabIndex = 0;
            TCIdioma.Visible = true;
        }

        private IList<Texto_Idioma> ObtenerDatoTextoResumen()
        {
            IList<Texto_Idioma> ITextoResumen_Idioma = new List<Texto_Idioma>();

            foreach (TabPanel TabPanel in TCIdioma.Tabs)
            {
                if (TabPanel.Visible)
                {
                    Condiciones.Controles.TextosResumen TabIdioma = (Condiciones.Controles.TextosResumen)TabPanel.Controls[0];

                    Texto_Idioma TextoResumen_Idioma = new Texto_Idioma();

                    TextoResumen_Idioma.Texto = TabIdioma.ObtenerTexto();
                    TextoResumen_Idioma.IdIdioma = TabIdioma.Idioma.Id;
                    ITextoResumen_Idioma.Add(TextoResumen_Idioma);
                }
            }

            return ITextoResumen_Idioma;
        }

        private IList<Texto_Idioma> ObtenerDatoTextoResumen(IList<Texto_Idioma> ITextoResumen_Idioma)
        {
            int CantidadInicial = ITextoResumen_Idioma.Count;

            int I = 0;
            foreach (TabPanel TabPanel in TCIdioma.Tabs)
            {
                if (TabPanel.Visible)
                {
                    Condiciones.Controles.TextosResumen TabIdioma = (Condiciones.Controles.TextosResumen)TabPanel.Controls[0];

                    Texto_Idioma TextoResumen_Idioma = CantidadInicial > I ? ITextoResumen_Idioma[I] : new Texto_Idioma();

                    TextoResumen_Idioma.Texto = TabIdioma.ObtenerTexto();
                    TextoResumen_Idioma.IdIdioma = TabIdioma.Idioma.Id;

                    if (CantidadInicial <= I)
                    {
                        ITextoResumen_Idioma.Add(TextoResumen_Idioma);
                    }

                    I++;
                }
            }

            return ITextoResumen_Idioma;
        }

        #endregion

        #region "Eventos de Botones"

        protected void BAgregarMascara_Click(object sender, EventArgs e)
        {
            Condiciones.Controles.TextosResumen TabIdioma = (Condiciones.Controles.TextosResumen)
                TCIdioma.ActiveTab.Controls[0];

            StringBuilder Builder = new StringBuilder(TabIdioma.ObtenerTexto());

            Builder = Builder.Append("<<");
            Builder = Builder.Append(TbMascara.Text != null ? TbMascara.Text.ToUpper().Trim() : "");
            Builder = Builder.Append(">>");

            TabIdioma.SetearTexto(Builder.ToString());
        }

        protected void bVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("./ListaDeTexto.aspx?" + SessionDataHandler.TIPO_TEXTO
                + "=" + SessionDataHandler.TipoTexto(Session).Codigo);
        }

        protected void bAgregar_Click(object sender, EventArgs e)
        {
            Texto TextoResumen = SessionDataHandler.Texto(Session);

            TextoResumen.Nombre = TbNombre.Text;
            TextoResumen.TipoTextoResumen = TipoTextoResumenHome.Obtener(Convert.ToInt32(
                DdlTipoTextoResumen.SelectedValue));

            if (TextoResumen.Id == 0)
            {
                TextoResumen.Texto_Idioma = ObtenerDatoTextoResumen();
            }
            else
            {
                ObtenerDatoTextoResumen(TextoResumen.Texto_Idioma);
            }

            TextoResumen.TipoTexto = SessionDataHandler.TipoTexto(Session);

            if (TextoResumen.Id == 0 && TextoHome.Obtener(TextoResumen.TipoTexto.Id, TextoResumen.Nombre).Id != 0)
            {
                //CustomValidator valida = (CustomValidator)FvTextoResumen.FindControl("CVNombreTexto");
                CVNombreTexto.IsValid = false;
                CVNombreTexto.Text = "Nombre Existente";

                return;
            }

            TextoResumen.IdUsuario = UsuarioLogueadoDTO() != null ? UsuarioLogueadoDTO().IdUsuario : -1;
            TextoResumen.Fecha = DateTime.Now;
            TextoResumen.Persistir();

            Response.Redirect("./ListaDeTexto.aspx?TipoTexto=" + SessionDataHandler.TipoTexto(Session).Codigo);
        }


        #endregion
    }
}
