using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.Dominio;

namespace Condiciones.Controles
{
    public partial class Clausulas : System.Web.UI.UserControl
    {

        #region Atributos

        private Idioma _Idioma;
        
        #endregion

        #region Propiedades

        public Idioma Idioma
        {
            get { return _Idioma; }
            set { _Idioma = value; }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Idioma != null)
                RfvNombre.ErrorMessage = RfvNombre.ErrorMessage.Replace("%", Idioma.Nombre);
        }

        public string ObtenerNombre()
        {
            return TbNombre.Text;
        }

        public void CargarInformacion(Clausula_Idioma Clausula_Idioma)
        {
            TbNombre.Text = Clausula_Idioma.Nombre;
            Idioma.Id = Clausula_Idioma.IdIdioma;
        }

    }
}