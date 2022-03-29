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
    public partial class InformacionDeTarifa : CustomPage
    {
        protected override void CustomPageLoad(object sender, EventArgs e)
        {
            ValidarSession();
            BAceptar.Focus();
            if (!IsPostBack)
            {
                Session["Tarifa"] = new Tarifa();
                CargarCombos();
                if (Request.QueryString["Id"] != null)
                {
                    Session["Tarifa"] = TarifaHome.Obtener(Convert.ToInt32(Request.QueryString["Id"]));
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


                DdlTipoModalidad.DataSource = Backend.Homes.TipoModalidadHome.Buscar();
                DdlTipoModalidad.DataTextField = "Descripcion";
                DdlTipoModalidad.DataValueField = "Id";
                DdlTipoModalidad.DataBind();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Tarifa ObtenerTarifa()
        {
            return (Tarifa) Session["Tarifa"];
        }

        private void SetearInformacion()
        {
            Tarifa Tarifa = ObtenerTarifa();
            Producto Producto = ProductoHome.Obtener(Tarifa.IdProducto);

            if (Tarifa.Id > 0)
            {
                TbCodigoPais.ReadOnly = true;
                TbProducto.ReadOnly = true;
                TbCodigo.ReadOnly = true;
                DdlTipoGrupo.Enabled = false;
                CbAnual.Enabled = false;
            }

            TbCodigoPais.Text = Tarifa.CodigoPais.ToString();
            TbProducto.Text = Producto.Codigo;
            TbCodigo.Text = Tarifa.Codigo;
            TbNombre.Text = Tarifa.Nombre;
            TbSufijo.Text = Tarifa.Sufijo;
            DdlTipoModalidad.SelectedValue = Tarifa.IdTipoModalidad.ToString();
            DdlTipoGrupo.SelectedValue = Tarifa.IdTipoGrupoClausula.ToString();
            CbActiva.Checked = Tarifa.Activa;
            CbAnual.Checked = Tarifa.Anual;
        }

        protected void BCancelar_Click(object sender, EventArgs e)
        {
            Redireccionar();
        }

        protected void BAceptar_Click(object sender, EventArgs e)
        {
            Tarifa Tarifa = ObtenerTarifa();
                        
            Tarifa.CodigoPais = Convert.ToInt32(TbCodigoPais.Text);
            Tarifa.Codigo = TbCodigo.Text;
            Tarifa.Nombre = TbNombre.Text;
            Tarifa.Sufijo = TbSufijo.Text;
            Tarifa.IdTipoGrupoClausula = Convert.ToInt32(DdlTipoGrupo.SelectedValue);
            Tarifa.IdTipoModalidad = Convert.ToInt32(DdlTipoModalidad.SelectedValue);
            Tarifa.IdProducto = ProductoHome.Obtener(Tarifa.CodigoPais, TbProducto.Text, Tarifa.IdTipoGrupoClausula).Id;
            Tarifa.Anual = CbAnual.Checked;
            Tarifa.Activa = CbActiva.Checked;
            

            Tarifa.Persistir();

            Redireccionar();
        }

        private void Redireccionar()
        {
            Session.Remove("Tarifa");
            Response.Redirect("./ListaDeTarifas.aspx");
        }

    }
}
