using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Backend.DTO;
using Backend.Dominio;
using Backend.Servicios;
using ControlMenu;

namespace Condiciones.Admin
{
    public partial class ListaDeAdministrador : CustomPage
    {

        protected override void CustomPageLoad(object sender, EventArgs e)
        {
            ValidarSession();
            if (!IsPostBack)
            {
                if (Session["Tipo"] != null)
                {
                    DdlTipoEntidad.SelectedValue = Session["Tipo"].ToString();
                }

                CargarComboTiposEndidad();
                Buscar();
                BBuscar.Focus();
            }
        }

        #region Eventos Grilla
        protected void GvEntidades_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onclick", "javascript:window.location.href='InformacionDeAdministrador.aspx?Id=" + e.Row.Cells[0].Text + "&Tipo=" + DdlTipoEntidad.SelectedValue + "';");    
            }
        }

        #endregion

        #region Eventos Privados

        private void Buscar()
        {
            GvEntidades.DataSource = LaPapaService.Instancia().
                ObtenerHome(DdlTipoEntidad.SelectedValue).BuscarObjetosCodificados();
            GvEntidades.DataBind();
        }

        private void CargarComboTiposEndidad()
        {
            DdlTipoEntidad.DataSource = CargarTiposEntidad();
            DdlTipoEntidad.DataBind();
        }

        private IList<TipoEntidadDTO> CargarTiposEntidad()
        {
            IList<TipoEntidadDTO> Objetos = new List<TipoEntidadDTO>();

            Objetos.Add(new TipoEntidadDTO("Cláusula", typeof(TipoClausula).Name));
            Objetos.Add(new TipoEntidadDTO("Asociación Documento", typeof(TipoAsociacionDocumento).Name));
            Objetos.Add(new TipoEntidadDTO("Cobertura", typeof(TipoCobertura).Name));
            Objetos.Add(new TipoEntidadDTO("Contenido Impresión", typeof(TipoContenidoImpresion).Name));
            Objetos.Add(new TipoEntidadDTO("Documento", typeof(TipoDocumento).Name));
            Objetos.Add(new TipoEntidadDTO("GrupoCláusula", typeof(TipoGrupoClausula).Name));
            Objetos.Add(new TipoEntidadDTO("Impresión Cláusula", typeof(TipoImpresionClausula).Name));
            Objetos.Add(new TipoEntidadDTO("Modalidad", typeof(TipoModalidad).Name));
            Objetos.Add(new TipoEntidadDTO("Plan", typeof(TipoPlan).Name));

            return Objetos;
        }

        #endregion

        #region Eventos Boton

        protected void BBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
            Session.Remove("ObjetoAdministrador");
            Session.Remove("Tipo");
        }

        protected void BNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("InformacionDeAdministrador.aspx?Id=0&Tipo=" + DdlTipoEntidad.SelectedValue);
        }

        #endregion




        
    }
}
