using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Servicios;
using FrameworkDAC.Negocio;
using System.Configuration;
using ControlMenu;

namespace Condiciones.Admin
{
    public partial class InformacionDeAdministrador : CustomPage
    {
        protected override void CustomPageLoad(object sender, EventArgs e)
        {
            ValidarSession();
            BAceptar.Focus();
            if (!IsPostBack)
            {
                int Id = Convert.ToInt32(Request.QueryString["Id"]);
                string Tipo = Request.QueryString["Tipo"] != null ? Request.QueryString["Tipo"] : "-";

                Session["ObjetoAdministrador"] = LaPapaService.Instancia().ObtenerHome(Tipo).ObtenerObjetoCodificado(Id);
                if (Id != 0)
                    InicializarContenido(ObtenerObjeto(), Tipo);
                else 
                    LNombreTipo.Text = Tipo;
            }
        }

        private ObjetoCodificado ObtenerObjeto()
        {
            return (ObjetoCodificado)Session["ObjetoAdministrador"];
        }

        private void InicializarContenido(ObjetoCodificado Objeto, string tipo)
        {
            TbCodigo.Text = Objeto.Codigo;
            TbNombre.Text = Objeto.Nombre;
            TbDescripcion.Text = Objeto.Descripcion;

            BEliminar.Visible = Objeto.Id != 0;
            LNombreTipo.Text = tipo;

            TbCodigo.Enabled = Objeto.Id == 0;
            TbNombre.Enabled = (Objeto.Nombre != null && 
                Objeto.Nombre.Length > 0) || Objeto.Id == 0;
            TbDescripcion.Enabled = (Objeto.Descripcion != null &&
                Objeto.Descripcion.Length > 0) || Objeto.Id == 0;
            

        }
        
        protected void BCancelar_Click(object sender, EventArgs e)
        {
            Redireccionar();
        }

        protected void BAceptar_Click(object sender, EventArgs e)
        {
            var Objeto = ObtenerObjeto();
            
            Objeto.Codigo = TbCodigo.Text;
            Objeto.Nombre = TbNombre.Text;
            Objeto.Descripcion = TbDescripcion.Text;

            LaPapaService.Instancia().Persistir(Objeto, LNombreTipo.Text,
                ConfigurationManager.ConnectionStrings["Condiciones"].ToString());

            Redireccionar();
        }

        protected void BEliminar_Click(object sender, EventArgs e)
        {
            ObjetoCodificado Objeto = ObtenerObjeto();

            LaPapaService.Instancia().Eliminar(Objeto, LNombreTipo.Text,
                ConfigurationManager.ConnectionStrings["Condiciones"].ToString());

            Redireccionar();
        }

        private void Redireccionar()
        {
            Session.Remove("ObjetoAdministrador");
            Response.Redirect("./ListaDeAdministrador.aspx");
        }
                
    }
}
