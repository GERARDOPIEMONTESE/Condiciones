using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.Dominio;
using Backend.Homes;
using AjaxControlToolkit;
using ControlMenu;
using System.Globalization;

namespace Condiciones
{
    public partial class InformacionDeClausula : CustomPage
    {
        protected override void CustomPageLoad(object sender, EventArgs e)
        {
            ValidarSession();
            bAgregar.Focus();
            if (!IsPostBack)
            {
                Session["ClausulaEditar"] = new Clausula();
      
                if (Request.QueryString["Id"] != null)
                {
                    Session["IdClausula"] = Request.QueryString["Id"];
                    Edicion();
                }
                else 
                {
                    bEliminar.Visible = false;
                    TasaVisible(false);
                }
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

                Condiciones.Controles.Clausulas TabIdioma = (Condiciones.Controles.Clausulas)TemplateControl.LoadControl("~/Controles/Clausulas.ascx");
                TabIdioma.Idioma = IdiomaHome.Obtener(Idi.Id);

                TabPanel.Controls.Add((Control)TabIdioma);

                TCIdioma.Tabs.Add(TabPanel);
            }

            TCIdioma.ActiveTabIndex = 0;
            TCIdioma.Visible = true;
            base.OnInit(e);
        }

        protected void DropDownList_DataBound(object sender, EventArgs e)
        {
            ((DropDownList)sender).Items.Insert(0, new ListItem("", "-1"));
        }

        protected void DropDownList_IndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)FvClausula.Row.FindControl("DdlTipoClausula");
            TipoClausula tipo = TipoClausulaHome.Obtener("SEGU");

            if (ddl.SelectedValue == tipo.Id.ToString())
            {
                PesoVisible(true);
                TasaVisible(true);
            }
            else
            {
                PesoVisible(false);
                TasaVisible(false);
            }
        }

        #region "Metodos Privados"

        private void Edicion()
        {
            IList<Clausula> IClausula = new List<Clausula>();
            Clausula Clausula = ClausulaHome.Obtener(Convert.ToInt32(Session["IdClausula"]));
            Session[SessionDataHandler.CLAUSULA_EDITAR] = Clausula;
            IClausula.Add(Clausula);

            FvClausula.DefaultMode = FormViewMode.Edit;
            FvClausula.DataSource = IClausula;
            FvClausula.DataBind();
            CargarDatoClausula(IClausula);

            if (Clausula.TipoClausula.Id == TipoClausulaHome.Obtener("SEGU").Id)
            {
                PesoVisible(true);
                TasaVisible(true);
            }
            else
            {
                PesoVisible(false);
                TasaVisible(false);
            }
        }

        private void CargarDatoClausula(IList<Clausula> IClausula)
        {
            foreach (TabPanel TabPanel in TCIdioma.Tabs)
            {
                if (TabPanel.Visible)
                {
                    Controles.Clausulas TabIdioma = (Controles.Clausulas)TabPanel.Controls[0];

                    foreach (Clausula_Idioma CI in IClausula[0].Clausula_Idioma)
                    {
                        if (CI.IdIdioma == TabIdioma.Idioma.Id)
                        {
                            TabIdioma.CargarInformacion(CI);
                            TabIdioma.Visible = true;
                            break;
                        }
                    }
                }
            }

            TCIdioma.ActiveTabIndex = 0;
            TCIdioma.Visible = true;
 
        }

        private void Redireccionar()
        {
            Response.Redirect("ListaDeClausulas.aspx");
        }

        private IList<Clausula_Idioma> ObtenerDatoClausula()
        {
            IList<Clausula_Idioma> IClausula_Idioma = new List<Clausula_Idioma>();

            foreach (TabPanel TabPanel in TCIdioma.Tabs)
            {
                if (TabPanel.Visible)
                {
                    Condiciones.Controles.Clausulas TabIdioma = (Condiciones.Controles.Clausulas)TabPanel.Controls[0];

                    Clausula_Idioma Clausula_Idioma = new Clausula_Idioma();

                    Clausula_Idioma.Nombre = TabIdioma.ObtenerNombre();
                    Clausula_Idioma.IdIdioma = TabIdioma.Idioma.Id;
                    IClausula_Idioma.Add(Clausula_Idioma);
                }
            }

            return IClausula_Idioma;
        }

        private void ObtenerDatoClausula(IList<Clausula_Idioma> IClausula_Idioma)
        {
            int CantidadOriginal = IClausula_Idioma.Count;
            int I = 0;
            foreach (TabPanel TabPanel in TCIdioma.Tabs)
            {
                if (TabPanel.Visible)
                {
                    Condiciones.Controles.Clausulas TabIdioma = (Condiciones.Controles.Clausulas)TabPanel.Controls[0];

                    Clausula_Idioma Clausula_Idioma = I < CantidadOriginal ? IClausula_Idioma[I] : new Clausula_Idioma();

                    Clausula_Idioma.Nombre = TabIdioma.ObtenerNombre();
                    Clausula_Idioma.IdIdioma = TabIdioma.Idioma.Id;

                    if (I >= CantidadOriginal)
                    {
                        IClausula_Idioma.Add(Clausula_Idioma);
                    }

                    I++;
                }
            }
        }

        private void PesoVisible(bool visible)
        {
            Label lblPeso = ((Label)FvClausula.Row.FindControl("lblPeso"));
            TextBox tbPeso = ((TextBox)FvClausula.Row.FindControl("TbPeso"));
            lblPeso.Visible = visible;
            tbPeso.Visible = visible;
        }

        private void TasaVisible(bool visible)
        {
            Label lblTasa = ((Label)FvClausula.Row.FindControl("lblTasa"));
            TextBox tbTasa = ((TextBox)FvClausula.Row.FindControl("TbTasa"));
            lblTasa.Visible = visible;
            tbTasa.Visible = visible;
        }

        #endregion 

        #region "Eventos de Botones"

        protected void BCancelar_Click(object sender, EventArgs e)
        {
            Redireccionar();
        }

        protected void BEliminar_Click(object sender, EventArgs e)
        {
            Clausula Clausula = ClausulaHome.Obtener(
                Convert.ToInt32(Session["IdClausula"]));
            if (!GrupoClausulaHome.Existe(Clausula))
            {
                Clausula.IdUsuario = UsuarioLogueadoDTO() != null ? UsuarioLogueadoDTO().IdUsuario : -1;
                Clausula.Eliminar();
                Redireccionar();
            }
            else
            {
                CustomValidator valida = (CustomValidator)FvClausula.FindControl("CVClausulaUsada");
                valida.IsValid = false;
                valida.Text = "No se puede eliminar ya que actualmente esta siendo utilizada por grupos de condiciones.";

                return;
            }

        }

        protected void bAgregar_Click(object sender, EventArgs e)
        {
            Clausula Clausula = (Clausula)Session[SessionDataHandler.CLAUSULA_EDITAR];

            TipoClausula TipoClausula = new TipoClausula();
            TipoClausula.Id = int.Parse(Utilitario.DropDownListValue(FvClausula, "DdlTipoClausula"));

            Clausula.TipoClausula = TipoClausula;
            Clausula.Codigo = Utilitario.TextBoxValue(FvClausula, "TbCodigo");
            Clausula.OrdenPredefinido = Convert.ToInt32(Utilitario.TextBoxValue(FvClausula, "TbOrdenPredefinido"));

            if (TipoClausula.Id == TipoClausulaHome.Obtener("SEGU").Id)
            {
                string aux = Utilitario.TextBoxValue(FvClausula, "tbPeso");
                if (!string.IsNullOrEmpty(aux))
                    Clausula.Peso = Convert.ToDecimal(aux);
                else
                    Clausula.Peso = null;
                CultureInfo culture = new CultureInfo("en-US");
                Clausula.Tasa = Convert.ToDecimal(ReplaceComa(Utilitario.TextBoxValue(FvClausula, "tbTasa")), culture);
            }
            else
            {
                Clausula.Peso = null;
                Clausula.Tasa = null;
            }
            
            if (Clausula.Id == 0)
            {
                Clausula.Clausula_Idioma = ObtenerDatoClausula();
            }
            else
            {
                ObtenerDatoClausula(Clausula.Clausula_Idioma);
            }


            //Valida si el codigo es existente
            Clausula ExisteClausula = ClausulaHome.Obtener(Clausula.Codigo);

            if (ExisteClausula.Id != 0 &&
                ExisteClausula.Id != Clausula.Id)
            {
                //No persiste, davuelve un mensaje
                CustomValidator valida = (CustomValidator)FvClausula.FindControl("CVCodigoClausula");
                valida.IsValid = false;
                valida.Text = "Codigo Existente";

                return;
            }


            Clausula.IdUsuario = UsuarioLogueadoDTO() == null ? -1 : UsuarioLogueadoDTO().Id;
            Clausula.Fecha = DateTime.Now;
            Clausula.IdUsuario = UsuarioLogueadoDTO() != null ?
                    UsuarioLogueadoDTO().IdUsuario : -1;
            Clausula.Persistir();

            Redireccionar();
        }

        private string ReplaceComa(string tasa)
        {
            if (tasa.Contains(","))
                tasa = tasa.Replace(',', '.');
            return tasa;
        }

        #endregion 

    }
}
