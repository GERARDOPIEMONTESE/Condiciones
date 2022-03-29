using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControlMenu;
using Backend.Dominio;
using Backend.Homes;

namespace Condiciones.Admin
{
    public partial class InformacionDeProducto : CustomPage
    {
        
        protected override void CustomPageLoad(object sender, EventArgs e)
        {
            ValidarSession();
            BAceptar.Focus();
            if (!IsPostBack)
            {
                CargarCombos();
                Session["Producto"] = new Producto();

                if (Request.QueryString["Id"] != null)
                {
                    Session["Producto"] = ProductoHome.Obtener(Convert.ToInt32(Request.QueryString["Id"]));
                    SetearInformacion();
                }
            }
        }

        private void CargarCombos()
        {
            try
            {
                DdlTipoGrupo.DataSource = Backend.Homes.TipoGrupoClausulaHome.Buscar();
                DdlTipoGrupo.DataTextField = "Nombre";
                DdlTipoGrupo.DataValueField = "Id";
                DdlTipoGrupo.DataBind();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Producto ObtenerProducto()
        {
            return (Producto)Session["Producto"];
        }

        private void SetearInformacion()
        {
            Producto Producto = ObtenerProducto();

            TbCodigoPais.Text = Producto.CodigoPais.ToString();
            TbCodigo.Text = Producto.Codigo;
            TbNombre.Text = Producto.Nombre;
            DdlTipoGrupo.SelectedValue = Producto.IdTipoGrupoClausula.ToString();
        }

        protected void BCancelar_Click(object sender, EventArgs e)
        {
            Redireccionar();
        }

        protected void BAceptar_Click(object sender, EventArgs e)
        {
            Producto Producto = ObtenerProducto();

            Producto.CodigoPais = Convert.ToInt32(TbCodigoPais.Text);
            Producto.Codigo = TbCodigo.Text;
            Producto.Nombre = TbNombre.Text;
            Producto.IdTipoGrupoClausula = Convert.ToInt32(DdlTipoGrupo.SelectedValue);

            Producto.Persistir();
            Redireccionar();
        }

        private void Redireccionar()
        {
            Session.Remove("Producto");
            Response.Redirect("./ListaDeProductos.aspx");
        }

    }
}
