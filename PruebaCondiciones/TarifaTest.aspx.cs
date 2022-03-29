using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaCondiciones
{
    public partial class TarifaTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string xml = "<TarifaWS>  <IdTipoGrupoClausula>1</IdTipoGrupoClausula>  <CodigoPais>540</CodigoPais>  <CodigoTarifa>7998</CodigoTarifa>  <Nombre>TARIF TEST</Nombre>  <Anual>false</Anual>  <Sufijo></Sufijo>  <Activa>true</Activa>  <ModalidadTarifa>M30D</ModalidadTarifa> <Producto>   <CodigoProducto>02</CodigoProducto>    <Nombre>NACIONAL (NO RESIDENTE)</Nombre>  </Producto></TarifaWS>";

            ServicioTarifaWS.ServicioTarifaWS Servicio = new PruebaCondiciones.ServicioTarifaWS.ServicioTarifaWS();

            string Mensaje = Servicio.AgregarTarifa(xml, "", "");

            for (int I = 0; I < 10; I++)
            {
                I++;
            }

        }
    }
}
