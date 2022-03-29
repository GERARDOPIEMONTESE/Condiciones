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

namespace Condiciones.Controles
{
    public partial class WucContenidosClausula : System.Web.UI.UserControl
    {

        private void AgregarTab()
        {
            foreach (TabPanel Panel in TcContenidos.Tabs)
            {
                if (Panel.Visible == false)
                {
                    
                    Panel.Visible = true;
                    TcContenidos.ActiveTab = Panel;
                    break;
                }
            }
        }

        private int ObtenerCantidadTabsVisibles()
        {
            int Cantidad = 0;

            foreach (TabPanel Panel in TcContenidos.Tabs)
            {
                Cantidad += Panel.Visible ? 1 : 0;
            }

            return Cantidad;
        }

        private void EliminarTab()
        {
            int I = TcContenidos.Tabs.IndexOf(TcContenidos.ActiveTab);

            if (I < (ObtenerCantidadTabsVisibles() -1))
            {
                for (; I < TcContenidos.Tabs.Count - 1; I++)
                {
                    if (!TcContenidos.Tabs[I + 1].Visible)
                    {
                        break;
                    }
                    ((Condiciones.Controles.WucContenidoClausula)TcContenidos.Tabs[I].Controls[0].Controls[1]).SetearInformacion(
                        ((Condiciones.Controles.WucContenidoClausula)TcContenidos.Tabs[I + 1].Controls[0].Controls[1]).ObtenerContenido());
                    TcContenidos.Tabs[I].Visible = true;
                }
                if (I < TcContenidos.Tabs.Count)
                {
                    TcContenidos.Tabs[I].Visible = false;
                    ((Condiciones.Controles.WucContenidoClausula)TcContenidos.Tabs[I].Controls[0].Controls[1]).Limpiar();
                }
                TcContenidos.Tabs[0].Visible = true;
            }
            else
            {
                for (int i = TcContenidos.Tabs.Count - 1; i > 0; i--)
                {
                    if (TcContenidos.Tabs[i].Visible == true)
                    {
                        TcContenidos.Tabs[i].Visible = false;
                        ((Condiciones.Controles.WucContenidoClausula)TcContenidos.Tabs[i].Controls[0].Controls[1]).Limpiar();

                        TcContenidos.ActiveTab = TcContenidos.Tabs[i - 1];

                        break;
                    }
                }
            }
        }

        protected void IbAgregarRango_Click(object sender, ImageClickEventArgs e)
        {
            AgregarTab();
        }

        protected void IbEliminarRango_Click(object sender, ImageClickEventArgs e)
        {
            EliminarTab();
        }
        
        public void Limpiar()
        {
            foreach (TabPanel Panel in TcContenidos.Tabs)
            {
                ((Condiciones.Controles.WucContenidoClausula)Panel.Controls[0].Controls[1]).Limpiar();
            }
            TcContenidos.ActiveTabIndex = 0;
            for (int I = 0; I < TcContenidos.Tabs.Count; I++)
            {
                TabPanel Panel = TcContenidos.Tabs[I];
                Panel.Visible = I == TcContenidos.ActiveTabIndex;
            }
        }

        public void Inicializar(TipoGrupoClausula TipoGrupoClausula)
        {
            foreach (TabPanel Panel in TcContenidos.Tabs)
            {
                ((Condiciones.Controles.WucContenidoClausula)Panel.Controls[0].Controls[1]).Inicializar(TipoGrupoClausula);
                ((Condiciones.Controles.WucContenidoClausula)Panel.Controls[0].Controls[1]).IdTab = Panel.HeaderText;
            }
        }

        public void CargarLeyendas()
        {
            foreach (TabPanel Panel in TcContenidos.Tabs)
            {
                ((Condiciones.Controles.WucContenidoClausula)Panel.Controls[0].Controls[1]).
                    CargarLeyendas();
            }
        }

        public void SetearContenido(ClausulaDTO Clausula)
        {
            int I = 0;
            
            foreach (ContenidoRangoDTO Rango in Clausula.Contenidos)
            {
                TabPanel Panel = TcContenidos.Tabs[I];
                Panel.Visible = true;

                Condiciones.Controles.WucContenidoClausula Control = (Condiciones.Controles.WucContenidoClausula)
                    Panel.Controls[0].Controls[1];
                //TODO: pasar el tipo de clausula que es porque solo se habilita para las clausulas de seguro.

                bool tipoClausula = Clausula.ContenidoClausula.Clausula.TipoClausula.Id == TipoClausulaHome.Obtener("SEGU").Id;
                bool esPaisConPoliza = EsPaisConPoliza();

                Control.SetearInformacion(Rango, (tipoClausula && esPaisConPoliza));
                I++;
            }
        }
        
        private bool EsPaisConPoliza()
        {
            string[] paises = CapaNegocioDatos.CapaHome.CodigoActivadorHome.ObtenerPaisesConPoliza();

            foreach (string item in paises)
            {
                if (hfCodigoPais.Value != null && !hfCodigoPais.Value.Equals("0"))
                {
                    if(hfCodigoPais.Value.Equals(item))
                        return true;
                }
            }
            return false;
        }

        public void SetearPais(string codigoPais)
        {
            hfCodigoPais.Value = codigoPais;
        }

        public IList<Condiciones.Controles.WucContenidoClausula> Contenidos
        {
            get
            {
                IList<Condiciones.Controles.WucContenidoClausula> Contenidos = new List<Condiciones.Controles.WucContenidoClausula>();

                foreach (TabPanel Panel in TcContenidos.Tabs)
                {
                    Condiciones.Controles.WucContenidoClausula ControlContenido = (Condiciones.Controles.WucContenidoClausula)
                            Panel.Controls[0].Controls[1];

                    if (Panel.Visible == true && ControlContenido.TieneInformacion())
                    {
                        Contenidos.Add(ControlContenido);
                    }                    
                }

                return Contenidos;
            }
            set
            {
            }
        }

    }
}