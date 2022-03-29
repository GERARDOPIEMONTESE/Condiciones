using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControlMenu;
using Backend.Dominio;
using Backend.Homes;
using System.Globalization;

namespace Condiciones
{
    public partial class RiesgoDeTercerosAdd : CustomPage
    {

        protected override void CustomPageLoad(object sender, EventArgs e)
        {
            ValidarSession();
            BAceptar.Focus();
            lblProducto.Visible = false;
            lblProductAsociado.Visible = false;
            if (!IsPostBack)
            {
                CargarCombos();
                Session["RiesgoTerceros"] = new RiesgoTerceros();

                if (Request.QueryString["Id"] != null)
                {
                    Session["RiesgoTerceros"] = RiesgoTercerosHome.Obtener(Convert.ToInt32(Request.QueryString["Id"]));
                    SetearInformacion();
                }
            }
        }

        private void CargarCombos()
        {
            try
            {
                DdlPais.DataSource = PaisHome.Buscar();
                DdlPais.DataTextField = "Nombre";
                DdlPais.DataValueField = "Codigo";
                DdlPais.DataBind();
                DdlPais.Items.Insert(0, new ListItem("Seleccionar", "0"));


                DdlCompaniaSeguro.DataSource = CompaniaSeguroHome.Buscar();
                DdlCompaniaSeguro.DataTextField = "Descripcion";
                DdlCompaniaSeguro.DataValueField = "Id";
                DdlCompaniaSeguro.DataBind();
                DdlCompaniaSeguro.Items.Insert(0, new ListItem("Seleccionar", "0"));


                DdlTipoNegocio.DataSource = TipoGrupoClausulaHome.Buscar();
                DdlTipoNegocio.DataTextField = "Nombre";
                DdlTipoNegocio.DataValueField = "Id";
                DdlTipoNegocio.DataBind();
                string itemText = DdlTipoNegocio.Items.FindByValue("12").Text;
                ListItem li = new ListItem();
                li.Text = itemText;
                li.Value = "12";
                DdlTipoNegocio.Items.Remove(li);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetearInformacion()
        {
            RiesgoTerceros riesgoterceros = ObtenerRiesgoTerceros();

            if (riesgoterceros.FechaInicioVigencia != null)
            {
                var stringfechainicio = riesgoterceros.FechaInicioVigencia.ToString().Split(' ');
                var fechainicio = stringfechainicio[0].Split('/');
                string FromDate = fechainicio[1] + "/" + fechainicio[0] + "/" + fechainicio[2];
                txtFromDate.Text = FromDate;
            }
            else { txtFromDate.Text = ""; }

            if (riesgoterceros.FechaFinVigencia != null)
            {
                var stringfechafin = riesgoterceros.FechaFinVigencia.ToString().Split(' ');
                var fechafin = stringfechafin[0].Split('/');
                string ToDate = fechafin[1] + "/" + fechafin[0] + "/" + fechafin[2];
                txtToDate.Text = ToDate;
            }
            else { txtToDate.Text = ""; }

            DdlTipoNegocio.SelectedItem.Text = riesgoterceros.TipoNegocio;
            DdlTipoNegocio.Enabled = false;
            DdlCompaniaSeguro.SelectedValue = riesgoterceros.IdCompaniaSeguro.ToString();
            DdlCompaniaSeguro.Enabled = false;
            DdlPais.SelectedValue = riesgoterceros.IdPais.ToString();
            DdlPais.Enabled = false;
            lblProducto.Visible = true;
            lblProductAsociado.Visible = true;
            lblProductAsociado.Text = riesgoterceros.Codigo + "-"+ riesgoterceros.Descripcion.ToString();
            idTableProducto.Visible = false;
        }

        protected void BCancelar_Click(object sender, EventArgs e)
        {
            Redireccionar();
        }

        protected void BAceptar_Click(object sender, EventArgs e)
        {

            RiesgoTerceros riesgoterceros = ObtenerRiesgoTerceros();
            if ((DdlPais.SelectedValue != "0") && (DdlCompaniaSeguro.SelectedValue != "0") && (!string.IsNullOrEmpty(riesgoterceros.Descripcion) || IdProductos.CheckedNodes.Count > 0))
            {
                riesgoterceros.IdPais = Convert.ToInt32(DdlPais.SelectedValue);
                riesgoterceros.DescripcionPais = DdlPais.SelectedItem.Text;
                riesgoterceros.TipoNegocio = DdlTipoNegocio.SelectedItem.Text;
                riesgoterceros.IdUsuario = UsuarioLogueadoDTO() != null ? UsuarioLogueadoDTO().IdUsuario : -1;
                riesgoterceros.IdCompaniaSeguro = Convert.ToInt32(DdlCompaniaSeguro.SelectedValue);
                riesgoterceros.CompaniaSeguro = DdlCompaniaSeguro.SelectedItem.Text;
                riesgoterceros.Riesgo = "TERCEROS";

                if (txtFromDate.Text != "")
                {
                    var fromdate = txtFromDate.Text.Split('/');
                    string FromDate = fromdate[1] + "/" + fromdate[0] + "/" + fromdate[2];
                    riesgoterceros.FechaInicioVigencia = DateTime.ParseExact(FromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                
                if (txtToDate.Text != "")
                {
                    var todate = txtToDate.Text.Split('/');
                    string ToDate = todate[1] + "/" + todate[0] + "/" + todate[2];
                    riesgoterceros.FechaFinVigencia = Convert.ToDateTime(ToDate);
                }
                if (string.IsNullOrEmpty(riesgoterceros.Descripcion))
                {
                    List<string> productlist = new List<string>();
                    foreach (TreeNode item in IdProductos.CheckedNodes)
                    {
                        productlist.Add(item.Text);
                    }

                    if (productlist[0].ToString() == "Todos")
                    {
                        riesgoterceros.Codigo = null;
                        riesgoterceros.Descripcion = "TODOS";
                        riesgoterceros.Persistir();

                    }
                    else
                    {
                        foreach (var item in productlist)
                        {
                            var product = item.Split('-');
                            riesgoterceros.Codigo = product[0].ToString();
                            riesgoterceros.Descripcion = product[1].ToString();
                            var afaf = riesgoterceros.Id;
                            riesgoterceros.Id = 0;
                            riesgoterceros.Persistir();
                        }
                    }
                }
                else 
                {
                    riesgoterceros.Persistir();     
                }
                Redireccionar();
            }
            else
            {
                CustomValidator valida = (CustomValidator)form1.FindControl("CVCompaniaSeguro");
                valida.IsValid = false;
                valida.Text = "Debe seleccionar Pais, Compañia de Seguro y Producto";
            }
        }

        private void Redireccionar()
        {
            Response.Redirect("./RiesgosDeTerceros.aspx");
        }

        private RiesgoTerceros ObtenerRiesgoTerceros()
        {
            return (RiesgoTerceros)Session["RiesgoTerceros"];
        }

        protected void DdlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarProductos();
        }

        protected void DdlTipoNegocio_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarProductos();
        }

        private void BuscarProductos()
        {
            if (DdlPais.SelectedValue != "0")
            {
                IdProductos.Nodes.Clear();

                IList<Producto> Productos = ProductoHome.Buscar(Convert.ToInt32(DdlPais.SelectedValue),
                        Convert.ToInt32(DdlTipoNegocio.SelectedValue));

                if (Productos.Count() > 0)
                {
                    TreeNode All = new TreeNode("Todos");
                    IdProductos.Nodes.Add(All);

                    for (int i = 0; i < Productos.Count; i++)
                    {
                        TreeNode Nodo = new TreeNode(Productos[i].Codigo + "-" + Productos[i].Nombre, Productos[i].Codigo.ToString());
                        IdProductos.Nodes.Add(Nodo);
                    }
                }
            }
        }
    }
}
