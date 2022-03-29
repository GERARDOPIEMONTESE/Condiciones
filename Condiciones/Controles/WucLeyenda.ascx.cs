using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.Homes;
using Backend.Dominio;
using AjaxControlToolkit;

namespace Condiciones.Controles
{
    public partial class WucLeyenda : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (Request["__EVENTTARGET"] == "SelectClausulaTexto")
                {
                    HfIdclausulaTexto.Value = Request["__EVENTARGUMENT"];
                    MpeTextosClausula.Show();
                }
            }

            if (!IsPostBack)
            {
                BuscarTextos();
            }
        }

        public void Cargar()
        {
            TcLeyenda.Tabs.Clear();
            IList<Idioma> Idiomas = IdiomaHome.Buscar();
            
            foreach (Idioma Idioma in Idiomas)
            {
                TabPanel TpLeyenda = new TabPanel();
                TpLeyenda.ID = Idioma.Id.ToString();
                TpLeyenda.HeaderText = Idioma.Nombre;
                TpLeyenda.Visible = true;

                TextBox TbLeyenda = new TextBox();
                TbLeyenda.ID = "Tb" + Idioma.Nombre;
                TbLeyenda.TextMode = TextBoxMode.MultiLine;
                TbLeyenda.Width = 255;
                TbLeyenda.Height = 50;
                TpLeyenda.Controls.Add(TbLeyenda);

                TcLeyenda.Tabs.Add(TpLeyenda);
            }
            
            TcLeyenda.ActiveTabIndex = 0;
        }

        public IList<Leyenda> ObtenerLeyendas()
        {
            IList<Leyenda> Leyendas = new List<Leyenda>();

            foreach(TabPanel Panel in TcLeyenda.Tabs)
            {
                if (Panel.Controls.Count > 0)
                {
                    Leyendas.Add(new Leyenda(
                        Convert.ToInt32(Panel.ID), ((TextBox)Panel.Controls[0]).Text));
                }
            }
            return Leyendas;
        }

        private Leyenda ObtenerLeyenda(int IdIdioma, IList<Leyenda> Leyendas)
        {
            foreach (Leyenda Leyenda in Leyendas)
            {
                if (Leyenda.IdIdioma == IdIdioma)
                {
                    return Leyenda;
                }
            }
            return new Leyenda();
        }

        public void SetearLeyendas(IList<Leyenda> Leyendas)
        {
             foreach (TabPanel Panel in TcLeyenda.Tabs)
            {
                Leyenda Leyenda = ObtenerLeyenda(
                    Convert.ToInt32(Panel.ID), Leyendas);

                if (Panel.Controls.Count > 0)
                {
                    ((TextBox)Panel.Controls[0]).Text = Leyenda.Texto;
                }                
            }
        }

        public void Limpiar()
        {
            foreach (TabPanel Panel in TcLeyenda.Tabs)
            {
                if (Panel.Controls.Count > 0)
                {
                    ((TextBox)Panel.Controls[0]).Text = "";
                }
            }
        }

        private void BuscarTextos()
        {
            GvTextosClausula.DataSource = TextoHome.Buscar(
                TbNombreTexto.Text, Texto.CLAUSULA, (int)Idioma.Idiomas.Español);
            GvTextosClausula.DataBind();
        }

        private void BuscarTextosResumen()
        {
            BuscarTextos();
            MpeTextosClausula.Show();
        }
        
        private Texto ObtenerTexto()
        {
            int IdTexto = 0;

            if (HfIdclausulaTexto.Value != "")
            {
                IdTexto = Convert.ToInt32(HfIdclausulaTexto.Value);
            }

            return TextoHome.Obtener(IdTexto);
        }

        protected void BBuscarNombreTexto_Click(object sender, EventArgs e)
        {
            HfIdclausulaTexto.Value = "";
            BuscarTextosResumen();
        }

        protected void BAplicarTextoClausula_Click(object sender, EventArgs e)
        {
            Texto Texto = ObtenerTexto();

            foreach (TabPanel Panel in TcLeyenda.Tabs)
            {
                TextBox TextBox = (TextBox) Panel.Controls[0];

                TextBox.Text += Texto.Texto_Idioma != null && Texto.Texto_Idioma.Count > 0
                    ? Texto.Texto_Idioma[0].Texto : "";
            }

            GvTextosClausula.DataSource = new List<Texto>();
            GvTextosClausula.DataBind();

            MpeTextosClausula.Hide();
        }

        protected void GvTextosClausula_RowDataBound(object sender, GridViewRowEventArgs e)
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

                Literal Literal = (Literal)e.Row.FindControl("LTextoClausula");
                if (Literal != null)
                {
                    Literal.Text = "<input type=\"radio\" id=\"RbClausulaTexto" + e.Row.RowIndex.ToString() +
                                   "\" name=\"Clausulas\" value=\" +";

                    Literal.Text = String.Format("<input type=\"radio\" id=\"RbClausulaTexto{0}\" " +
                                                 "name=\"clausulas\" value=\"{1}\" " +
                                                 "onclick=\"javascript:seleccionClausula(this,'{2}');\" " +
                                                 (HfIdclausulaTexto.Value != "" && HfIdclausulaTexto.Value == ((GridView)sender).DataKeys[e.Row.RowIndex].Values["Id"].ToString() ? "checked" : "") + " />",
                                                  e.Row.RowIndex.ToString(),
                                                  ((GridView)sender).DataKeys[e.Row.RowIndex].Values["Id"],
                                                  HfIdclausulaTexto.ClientID);
                }

            }
        }

        protected void GvTextosClausula_RowCreated(object sender, GridViewRowEventArgs e)
        {
        }

        protected void GvTextosClausula_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvTextosClausula.PageIndex = e.NewPageIndex;
            BuscarTextosResumen();
        }

    }
}