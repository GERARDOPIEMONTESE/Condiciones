using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using Backend.DTO;
using Backend.Dominio;
using Backend.Homes;
using CondicionesParser.Validadores;
using System.Globalization;

namespace Condiciones.Controles
{
    public partial class WucContenidoClausula : System.Web.UI.UserControl
    {
        private string _IdTab = "";

        #region "Properties"

        public string ContenidosValidadores
        {
            get
            {
                return DdlContenidosValidadores.SelectedValue;
            }
            set
            {
                DdlContenidosValidadores.SelectedValue = value;
            }
        }

        public string Igual
        {
            get
            {
                return DdlIgual.SelectedValue;
            }
            set
            {
                DdlIgual.SelectedValue = value;
            }
        }

        public string Numero
        {
            get
            {
                return tbNumero.Text;
            }
            set
            {
                tbNumero.Text = "" + value;
            }
        }

        public string Currency
        {
            get
            {
                return DdlCurrency.SelectedValue;
            }
            set
            {
                DdlCurrency.SelectedValue = value;
            }
        }

        public string Contenido
        {
            get
            {
                return Condicion.Contenido;
            }
            set
            {
                Condicion.Contenido = value;
            }
        }

        public string EdadMinima
        {
            get
            {
                return EsDatoNumericoVacio(TbEdadMinima.Text) ?
                    "0" : TbEdadMinima.Text;
            }
            set
            {
                TbEdadMinima.Text = value;
            }
        }

        public string EdadMaxima
        {
            get
            {
                return EsDatoNumericoVacio(TbEdadMaxima.Text) ?
                    "100" : TbEdadMaxima.Text;
            }
            set
            {
                TbEdadMaxima.Text = value;
            }
        }

        public string IdTipoPlan
        {
            get
            {
                return EsDatoNumericoVacio(DdlTipoPlan.SelectedValue) ?
                    "0" : DdlTipoPlan.SelectedValue;
            }
            set
            {
            }
        }

        public string IdTipoModalidad
        {
            get
            {
                return EsDatoNumericoVacio(DdlTipoModalidad.SelectedValue) ?
                    "0" : DdlTipoModalidad.SelectedValue;
            }
            set
            {
            }
        }

        public string Categoria
        {
            get
            {
                return EsDatoNumericoVacio(TbCategoria.Text) ?
                    "0" : TbCategoria.Text;
            }
            set
            {
            }
        }

        public string IdValidezTerritorial
        {
            get
            {
                return EsDatoNumericoVacio(DdlValidezTerritorial.SelectedValue) ?
                    "0" : DdlValidezTerritorial.Text;
            }
            set
            {
            }
        }

        public string IdValidezTerritorialClausula
        {
            get
            {
                return EsDatoNumericoVacio(DdlValidezTerritorialClausula.SelectedValue) ?
                    "0" : DdlValidezTerritorialClausula.SelectedValue;
            }
            set
            {
            }
        }

        public string IdTab
        {
            get
            {
                return _IdTab;
            }
            set
            {
                _IdTab = value;
            }
        }

        public decimal? Peso
        {
            get { return EsDatoNumericoVacio(txtPeso.Text) ? 0 : Convert.ToDecimal(txtPeso.Text, CultureInfo.InvariantCulture); }
            set { txtPeso.Text = value.ToString().Replace(',','.'); }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IdTab != "")
            {
                RfvEdadMinima.ErrorMessage = RfvEdadMinima.ErrorMessage.Replace("%", IdTab);
                RevEdadMinima.ErrorMessage = RevEdadMinima.ErrorMessage.Replace("%", IdTab);
                CVEdadMinima.ErrorMessage = CVEdadMinima.ErrorMessage.Replace("%", IdTab);
                RfvEdadMaxima.ErrorMessage = RfvEdadMaxima.ErrorMessage.Replace("%", IdTab);
                RevEdadMaxima.ErrorMessage = RevEdadMaxima.ErrorMessage.Replace("%", IdTab);
                RfvCategoria.ErrorMessage = RfvCategoria.ErrorMessage.Replace("%", IdTab);
                //Condicion.ObtenerValidador().ErrorMessage = "El contenido en " + IdTab + " no puede estar vacío.";
            }
            if (!IsPostBack)
            {
                CargarCombos();
            }
        }


        #region "Metodos Privados"
        private bool EsDatoNumericoVacio(string Texto)
        {
            return Texto == null || Texto.Length == 0;
        }

        private void CargarCombos()
        {
            DdlTipoModalidad.DataSource = Backend.Homes.TipoModalidadHome.Buscar();
            DdlTipoModalidad.DataTextField = "Descripcion";
            DdlTipoModalidad.DataValueField = "Id";
            DdlTipoModalidad.DataBind();

            DdlTipoPlan.DataSource = Backend.Homes.TipoPlanHome.Buscar();
            DdlTipoPlan.DataTextField = "Descripcion";
            DdlTipoPlan.DataValueField = "Id";
            DdlTipoPlan.DataBind();

            DdlValidezTerritorialClausula.DataSource = Backend.Homes.ValidezTerritorialClausulaHome.Buscar();
            DdlValidezTerritorialClausula.DataTextField = "Descripcion";
            DdlValidezTerritorialClausula.DataValueField = "Id";
            DdlValidezTerritorialClausula.DataBind();

            DdlValidezTerritorial.DataSource = Backend.Homes.ValidezTerritorialHome.Buscar();
            DdlValidezTerritorial.DataTextField = "Nombre";
            DdlValidezTerritorial.DataValueField = "Id";
            DdlValidezTerritorial.DataBind();
            DdlValidezTerritorial.Items.Insert(0, new ListItem("Seleccionar", "0"));
            
            //for (int i = 0; i < 5; i++)
            //{
            //    DropDownList DdlContenidos = (DropDownList)FindControl("DdlContenidosValidadores"+i);
            //    DdlContenidos.DataSource = Backend.Homes.ValidadoresHome.FindAllVisible();
            //    DdlContenidos.DataValueField = "Codigo";
            //    DdlContenidos.DataBind();
            //    DdlContenidos.Items.Insert(0, new ListItem("", "0"));
            //}
            DdlContenidosValidadores.DataSource = Backend.Homes.ValidadoresHome.FindAllVisible();
            DdlContenidosValidadores.DataValueField = "Codigo";
            DdlContenidosValidadores.DataBind();
            DdlContenidosValidadores.Items.Insert(0, new ListItem("", ""));
            List<string> monedas = "USD|$|R$|Euros|Won|Bolívares|Guaraníes|U$S|ADP|AED|AFA|ALL|AMD|ANG|AOK|ARA|ARS|ATS|AUD|AWG|AZM|BAD|BBD|BDT|BEF|BGL|BHD|BIF|BMD|BND|BOB|BRL|BRR|BSD|BWP|BYR|BZD|CAD|CDP|CHF|CLP|CNY|COP|CRC|CUP|CVE|CYP|CZK|DEM|DJF|DKK|DOP|DRP|DZD|ECS|ECU|EEK|EGP|ESP|ETB|EUR|FIM|FJD|FKP|FRF|GBP|GEK|GHC|GIP|GMD|GNF|GRD|GTQ|GWP|GYD|HKD|HNL|HRD|HTG|HUF|IDR|IEP|ILS|INR|IQD|IRR|ISK|ITL|JMD|JOD|JPY|KES|KHR|KIS|KMF|KPW|KRW|KWD|KYD|KZT|LAK|LBP|LKR|LRD|LSL|LTL|LUF|LVL|LYD|MAD|MDL|MGF|MNC|MNT|MOP|MRO|MTL|MUR|MVR|MWK|MXN|MXP|MYR|MZM|NGN|NIC|NIO|NIS|NLG|NOK|NPR|NZD|OMR|PAB|PEI|PEN|PES|PGK|PHP|PKR|PLN|PLZ|PTE|PYG|QAR|RMB|ROL|RUR|RWF|SAR|SBD|SCR|SDP|SEK|SGD|SHP|SIT|SKK|SLL|SOL|SOS|SRG|STD|SUR|SVC|SYP|SZL|THB|TJR|TMM|TND|TOP|TPE|TRL|TTD|TWD|TZS|UAK|UGS|USD|UYP|UYU|VEB|VND|VUV|WST|XAF|XCD|XOF|YER|ZAR|ZMK|ZRZ|ZWD|UF".Split('|').ToList();
            DdlCurrency.DataSource = monedas;
            DdlCurrency.DataBind();

        }

        protected void DdlContenidosValidadores_IndexChanged(object sender, EventArgs e)
        {
            tbNumero.Style.Add("width", "90px");
            if (DdlContenidosValidadores.SelectedValue.Equals(""))
            {
                tbNumero.Visible = false;
                DdlCurrency.Visible = false;
                DdlIgual.Visible = false;
            }
            else if (DdlContenidosValidadores.SelectedValue.Equals("DIAS"))
            {
                tbNumero.Visible = true;
                DdlCurrency.Visible = false;
                DdlIgual.Visible = true;
            }
            else if (DdlContenidosValidadores.SelectedValue.Contains("MONTO"))
            {
                tbNumero.Visible = true;
                if (DdlCurrency != null) DdlCurrency.Visible = true;
                DdlIgual.Visible = true;
            }
            else
            {
                DdlIgual.Visible = true;
                tbNumero.Visible = true;
                DdlCurrency.Visible = false;
                tbNumero.Style.Add("width", "90%");
            }
        }

        public void CargarLeyendas()
        {
            WlLeyendas.Cargar();
        }

        public IList<Leyenda> ObtenerLeyendas()
        {
            return WlLeyendas.ObtenerLeyendas();
        }

        /// <summary>
        /// Setea la informacion del rango de cada clausula. 
        /// Si el pais tiene poliza hablita el el campo Peso.
        /// </summary>
        /// <param name="Contenido">ContenidoRangoDTO</param>
        /// <param name="tienePoliza">bool si es un pais con poliza, default false</param>
        public void SetearInformacion(ContenidoRangoDTO Contenido, bool tienePoliza = false)
        {
            TbEdadMinima.Text = Contenido.EdadMinima.ToString();
            TbEdadMaxima.Text = Contenido.EdadMaxima.ToString();
            String[] test = Contenido.Contenido.Split(' ');
            tbNumero.Style.Add("width", "90px");
            try
            {
                if (!String.IsNullOrEmpty(Contenido.Contenido))
                {
                    string[] split = Contenido.Contenido.Split(':');

                    string valor;
                    string numero;
                    DdlContenidosValidadores.SelectedValue = split[0];


                    if (split[1].Contains("MAYOR"))
                    {
                        DdlIgual.SelectedValue = "MAYOR-IGUAL";
                        valor = split[1].Substring(13);
                    }
                    else if (split[1].Contains("MENOR"))
                    {
                        DdlIgual.SelectedValue = "MENOR-IGUAL";
                        valor = split[1].Substring(13);
                    }
                    else
                    {
                        DdlIgual.SelectedValue = "IGUAL";
                        valor = split[1].Substring(7);
                    }
                    string[] split2 = valor.Split(' ');
                    if (split2.Length == 1) //Dias
                        numero = split2[0];
                    else if(split[0].Contains("MONTO"))
                        numero = valor.Substring(0, valor.IndexOf(" "));
                    else
                        numero = valor;
                    tbNumero.Text = "" + numero;

                    if (split[0].Contains("MONTO"))
                    {
                        DdlIgual.Visible = true;
                        tbNumero.Visible = true;
                        DdlCurrency.Visible = true;
                        string currency = fixUSD(split2[1]);
                        DdlCurrency.SelectedValue = currency;
                    }
                    else if (split[0].Contains("DIAS"))
                    {
                        DdlIgual.Visible = true;
                        tbNumero.Visible = true;
                        DdlCurrency.Visible = false;
                    }
                    else if (split[0].Contains("TEXTO"))
                    {
                        DdlIgual.Visible = true;
                        tbNumero.Visible = true;
                        DdlCurrency.Visible = false;
                        tbNumero.Style.Add("width", "90%");
                    }
                    else
                    {
                        DdlContenidosValidadores.SelectedValue = "";
                        tbNumero.Visible = false;
                        tbNumero.Text = "";
                        DdlIgual.Visible = false;
                        DdlCurrency.Visible = false;
                    }
                }
                else
                {
                    DdlContenidosValidadores.SelectedValue = "";
                    DdlIgual.Visible = false;
                    tbNumero.Visible = false;
                    DdlCurrency.Visible = false;
                }
                lbFormulaError.Visible = false;
            }
            catch (Exception e)
            {
                lbFormulaError.Text = "Failed to load: " + Contenido.Contenido;
                DdlContenidosValidadores.SelectedValue = "";
            }

            DdlTipoModalidad.SelectedValue = Contenido.IdTipoModalidad.ToString();
            DdlTipoPlan.SelectedValue = Contenido.IdTipoPlan.ToString();
            TbCategoria.Text = Contenido.Categoria.ToString();
            DdlValidezTerritorialClausula.SelectedValue = Contenido.IdValidezTerritorialClausula.ToString();
            if (Contenido.IdValidezTerritorial != 0)
            {
                DdlValidezTerritorial.SelectedValue = Contenido.IdValidezTerritorial.ToString();
            }

            if (tienePoliza == true)
            {
                lblPeso.Visible = true;
                txtPeso.Text = Contenido.Peso.ToString().Replace(',','.');
                txtPeso.ReadOnly = false;
                txtPeso.Visible = true;
                rfvPeso.Enabled = true;
                btnCalcular.Visible = true;
            }
            else
            {
                lblPeso.Visible = false;
                txtPeso.Text = "0";
                txtPeso.ReadOnly = true;
                txtPeso.Visible = false;
                rfvPeso.Enabled = false;
            }
            
            WlLeyendas.SetearLeyendas(Contenido.Leyendas);
        }

        private string fixUSD(string p)
        {
            if (p.Equals("U$S"))
                p = "USD";
            return p;
        }

        public ContenidoRangoDTO ObtenerContenido()
        {
            ContenidoRangoDTO Contenido = new ContenidoRangoDTO();

            Contenido.EdadMaxima = Convert.ToInt32(TbEdadMaxima.Text);
            Contenido.EdadMinima = Convert.ToInt32(TbEdadMinima.Text);
            Contenido.Contenido = Condicion.Contenido;
            Contenido.IdTipoModalidad = Convert.ToInt32(DdlTipoModalidad.SelectedValue);
            Contenido.IdTipoPlan = Convert.ToInt32(DdlTipoPlan.SelectedValue);
            Contenido.Categoria = Convert.ToInt32(TbCategoria.Text);
            Contenido.IdValidezTerritorialClausula = Convert.ToInt32(DdlValidezTerritorialClausula.SelectedValue);
            Contenido.IdValidezTerritorial = Convert.ToInt32(DdlValidezTerritorial.SelectedValue);
            Contenido.Leyendas = WlLeyendas.ObtenerLeyendas();
            Contenido.Peso = string.IsNullOrEmpty(txtPeso.Text) ? 0 : Convert.ToDecimal(txtPeso.Text);

            return Contenido;
        }

        public void Inicializar(TipoGrupoClausula TipoGrupoClausula)
        {
            TbCategoria.Enabled = TipoGrupoClausulaHome.Upgrade().Id == TipoGrupoClausula.Id;
            DdlTipoModalidad.Enabled = !TbCategoria.Enabled;
            LTipoModalidad.Enabled = DdlTipoModalidad.Visible;
        }

        public bool TieneInformacion()
        {
            return Condicion.Contenido != null;
        }

        public void Limpiar()
        {
            TbEdadMinima.Text = "0";
            TbEdadMaxima.Text = "100";
            //Condicion.Contenido = "";
            DdlContenidosValidadores.SelectedValue = "";
            DdlIgual.SelectedValue = "IGUAL";
            tbNumero.Text = "";
            DdlCurrency.SelectedValue = "USD";
            DdlIgual.Visible = false;
            tbNumero.Visible = false;
            DdlCurrency.Visible = false;
            TbCategoria.Text = "0";
            DdlTipoPlan.SelectedValue = TipoPlanHome.Todos().Id.ToString();
            DdlTipoModalidad.SelectedValue = TipoModalidadHome.Obtener(TipoModalidad.NO_APLICA).Id.ToString();
            WlLeyendas.Limpiar();
            txtPeso.Text = "";
        }

        #endregion
    }
}