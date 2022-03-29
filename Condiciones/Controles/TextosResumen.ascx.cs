using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.Dominio;

namespace Condiciones.Controles
{
    public partial class TextosResumen : System.Web.UI.UserControl
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

        public string ObtenerTexto()
        {
            return TbTexto.Text;
        }

        public void SetearTexto(string Texto)
        {
            TbTexto.Text = Texto;
        }
 
        public void CargarInformacion(Texto_Idioma TextoResumen_Idioma)
        {
            TbTexto.Text = TextoResumen_Idioma.Texto;
            Idioma.Id = TextoResumen_Idioma.IdIdioma;
        }
    }
}