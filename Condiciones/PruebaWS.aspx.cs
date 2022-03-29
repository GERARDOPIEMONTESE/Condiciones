using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Condiciones.ServiceReference2;
using ControlMenu;
using System.IO;
using System.Text;
//using Condiciones.com.assist_card.serviciocondiciones;
using Condiciones.ClausulasWSLocalHost;
//using Condiciones.ClausulasWSPreProd;

namespace Condiciones
{
    public partial class PruebaWS : CustomPage
    {
        protected override void CustomPageLoad(object sender, EventArgs e)
        {
            ServicioClausulasWS ServicioWS = new ServicioClausulasWS();
            //Condiciones.ClausulasWSLocalHost.ServicioClausulasWS ServicioWS = new Condiciones.ClausulasWSLocalHost.ServicioClausulasWS();

            //string XML = "<ConsultaCondicionesDTO>  <CodigoPais>540</CodigoPais>  <Anual>true</Anual>  <Edad>25</Edad>  <IdTipoPlan>3</IdTipoPlan>  <IdTipoModalidad>0</IdTipoModalidad>  <Categoria>0</Categoria>  <CodigoProducto>R2</CodigoProducto>  <CodigoTarifa>13007</CodigoTarifa>  <ConsultaPadre>    <CodigoPais>540</CodigoPais>    <CodigoProducto>R2</CodigoProducto>    <CodigoTarifa>13007</CodigoTarifa>    <Anual>true</Anual>    <Edad>25</Edad>    <IdTipoPlan>0</IdTipoPlan>    <IdTipoModalidad>0</IdTipoModalidad>  </ConsultaPadre>  <Upgrades>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade></CodigoUpgrade>      <CodigoTarifa></CodigoTarifa>      <Categoria>0</Categoria>    </ConsultaCondicionesUpgradeDTO>  </Upgrades></ConsultaCondicionesDTO>";

            //string XML = "<ConsultaCondicionesDTO><CodigoPais>510</CodigoPais><Anual>false</Anual><Edad>72</Edad><IdTipoPlan>3</IdTipoPlan><IdTipoModalidad>6</IdTipoModalidad><Categoria>0</Categoria><CodigoProducto>10</CodigoProducto><CodigoTarifa>6005</CodigoTarifa><ConsultaPadre><CodigoPais>510</CodigoPais><CodigoProducto>10</CodigoProducto><CodigoTarifa>0</CodigoTarifa><Anual>false</Anual><Edad>72</Edad><IdTipoPlan>3</IdTipoPlan>    <IdTipoModalidad>6</IdTipoModalidad></ConsultaPadre><Upgrades><ConsultaCondicionesUpgradeDTO><CodigoUpgrade></CodigoUpgrade><CodigoTarifa></CodigoTarifa><Categoria>0</Categoria></ConsultaCondicionesUpgradeDTO></Upgrades></ConsultaCondicionesDTO>";
            //string XML = "<ConsultaCondicionesDTO>  <CodigoPais>540</CodigoPais>   <Anual>false</Anual>   <Edad>37</Edad>   <IdTipoPlan>3</IdTipoPlan>   <IdTipoModalidad>6</IdTipoModalidad>   <Categoria>0</Categoria>   <CodigoProducto>AB</CodigoProducto>   <CodigoTarifa>0</CodigoTarifa>  <ConsultaPadre>  <CodigoPais>540</CodigoPais>   <CodigoProducto>AB</CodigoProducto>   <CodigoTarifa>0</CodigoTarifa>   <Anual>false</Anual>   <Edad>37</Edad>   <IdTipoPlan>3</IdTipoPlan>   <IdTipoModalidad>6</IdTipoModalidad>   </ConsultaPadre> <Upgrades> <ConsultaCondicionesUpgradeDTO>  <CodigoUpgrade>H2</CodigoUpgrade>   <CodigoTarifa>0</CodigoTarifa>   <Categoria>10000</Categoria>   </ConsultaCondicionesUpgradeDTO>  </Upgrades>  </ConsultaCondicionesDTO>";
            //string XML = "<ConsultasCondicionesDTO><Consultas><ConsultaCondicionesDTO><CodigoPais>540</CodigoPais><CodigoProducto>R2</CodigoProducto><CodigoTarifa>0</CodigoTarifa><Anual>false</Anual><Edad>24</Edad><IdTipoPlan>3</IdTipoPlan><IdTipoModalidad>1</IdTipoModalidad><ConsultaPadre><CodigoPais>540</CodigoPais><CodigoProducto>R2</CodigoProducto><CodigoTarifa>0</CodigoTarifa><Anual>false</Anual><Edad>24</Edad><IdTipoPlan>3</IdTipoPlan><IdTipoModalidad>1</IdTipoModalidad></ConsultaPadre></ConsultaCondicionesDTO><ConsultaCondicionesDTO><CodigoPais>540</CodigoPais><CodigoProducto>R1</CodigoProducto><CodigoTarifa>0</CodigoTarifa><Anual>false</Anual><Edad>24</Edad><IdTipoPlan>3</IdTipoPlan><IdTipoModalidad>1</IdTipoModalidad><ConsultaPadre><CodigoPais>540</CodigoPais><CodigoProducto>R1</CodigoProducto><CodigoTarifa>0</CodigoTarifa><Anual>false</Anual><Edad>24</Edad><IdTipoPlan>3</IdTipoPlan><IdTipoModalidad>1</IdTipoModalidad></ConsultaPadre></ConsultaCondicionesDTO></Consultas></ConsultasCondicionesDTO>";

            //Para clausulas Coincidentes
            //string XML = "<?xml version=\"1.0\" encoding=\"utf-8\"?><ConsultasCondicionesDTO xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><Consultas><ConsultaCondicionesDTO><CodigoPais>104</CodigoPais><CodigoProducto>YE</CodigoProducto><CodigoTarifa>4005</CodigoTarifa><Anual>false</Anual><Edad>37</Edad><IdTipoPlan>3</IdTipoPlan><IdTipoModalidad>1</IdTipoModalidad><ConsultaPadre><CodigoPais>104</CodigoPais><CodigoProducto>YE</CodigoProducto><CodigoTarifa>4005</CodigoTarifa><Anual>false</Anual><Edad>37</Edad><IdTipoPlan>3</IdTipoPlan><IdTipoModalidad>1</IdTipoModalidad></ConsultaPadre></ConsultaCondicionesDTO><ConsultaCondicionesDTO><CodigoPais>540</CodigoPais><CodigoProducto>R2</CodigoProducto><CodigoTarifa>0</CodigoTarifa><Anual>false</Anual><Edad>24</Edad><IdTipoPlan>3</IdTipoPlan><IdTipoModalidad>1</IdTipoModalidad><ConsultaPadre><CodigoPais>540</CodigoPais><CodigoProducto>R2</CodigoProducto><CodigoTarifa>0</CodigoTarifa><Anual>false</Anual><Edad>24</Edad><IdTipoPlan>3</IdTipoPlan><IdTipoModalidad>1</IdTipoModalidad></ConsultaPadre></ConsultaCondicionesDTO><ConsultaCondicionesDTO><CodigoPais>540</CodigoPais><CodigoProducto>R1</CodigoProducto><CodigoTarifa>0</CodigoTarifa><Anual>false</Anual><Edad>24</Edad><IdTipoPlan>3</IdTipoPlan><IdTipoModalidad>1</IdTipoModalidad><ConsultaPadre><CodigoPais>540</CodigoPais><CodigoProducto>R1</CodigoProducto><CodigoTarifa>0</CodigoTarifa><Anual>false</Anual><Edad>24</Edad><IdTipoPlan>3</IdTipoPlan><IdTipoModalidad>1</IdTipoModalidad></ConsultaPadre></ConsultaCondicionesDTO></Consultas></ConsultasCondicionesDTO>";
            //string XML = "<ConsultaCondicionesDTO><CodigoPais>104</CodigoPais><Anual>false</Anual><Edad>36</Edad><IdTipoPlan>3</IdTipoPlan><IdTipoModalidad>6</IdTipoModalidad><Categoria>0</Categoria><CodigoProducto>YE</CodigoProducto><CodigoTarifa>4005</CodigoTarifa><ConsultaPadre><CodigoPais></CodigoPais><CodigoProducto></CodigoProducto><CodigoTarifa></CodigoTarifa><Anual></Anual><Edad></Edad><IdTipoPlan>0</IdTipoPlan><IdTipoModalidad>0</IdTipoModalidad></ConsultaPadre><Upgrades><ConsultaCondicionesUpgradeDTO><CodigoUpgrade></CodigoUpgrade><CodigoTarifa></CodigoTarifa><Categoria>0</Categoria></ConsultaCondicionesUpgradeDTO></Upgrades></ConsultaCondicionesDTO>";
            //string XML = "<ConsultaCondicionesDTO>  <CodigoPais>540</CodigoPais>  <Anual>false</Anual>  <Edad>25</Edad>  <IdTipoPlan>3</IdTipoPlan>  <IdTipoModalidad>0</IdTipoModalidad>  <Categoria>0</Categoria>  <CodigoProducto>R1</CodigoProducto>  <CodigoTarifa>0</CodigoTarifa>  <ConsultaPadre>    <CodigoPais>540</CodigoPais>    <CodigoProducto>R1</CodigoProducto>    <CodigoTarifa>0</CodigoTarifa>    <Anual>false</Anual>    <Edad>25</Edad>    <IdTipoPlan>0</IdTipoPlan>    <IdTipoModalidad>0</IdTipoModalidad>  </ConsultaPadre>  <Upgrades>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade>H0</CodigoUpgrade>      <CodigoTarifa>0</CodigoTarifa>      <Categoria>0</Categoria>    </ConsultaCondicionesUpgradeDTO>  </Upgrades></ConsultaCondicionesDTO>";

            //string XML = "<ConsultaCondicionesDTO><CodigoPais>540</CodigoPais><Anual>true</Anual><Edad>30</Edad><IdTipoPlan>3</IdTipoPlan><IdTipoModalidad>0</IdTipoModalidad><Categoria>0</Categoria><CodigoProducto>R3</CodigoProducto><CodigoTarifa>13000</CodigoTarifa><ConsultaPadre><CodigoPais>540</CodigoPais><CodigoProducto>R3</CodigoProducto><CodigoTarifa>13000</CodigoTarifa><Anual>true</Anual><Edad>30</Edad><IdTipoPlan>0</IdTipoPlan><IdTipoModalidad>0</IdTipoModalidad></ConsultaPadre><Upgrades><ConsultaCondicionesUpgradeDTO><CodigoUpgrade>H0</CodigoUpgrade><CodigoTarifa>0</CodigoTarifa><Categoria>0</Categoria></ConsultaCondicionesUpgradeDTO><ConsultaCondicionesUpgradeDTO><CodigoUpgrade>H7</CodigoUpgrade><CodigoTarifa>0</CodigoTarifa><Categoria>100000</Categoria></ConsultaCondicionesUpgradeDTO></Upgrades></ConsultaCondicionesDTO>";


            string XML = "<ConsultaCondicionesDTO><CodigoPais>540</CodigoPais><Anual>false</Anual><Edad>40</Edad><IdTipoPlan>3</IdTipoPlan><IdTipoModalidad>0</IdTipoModalidad><Categoria>0</Categoria><CodigoProducto>R3</CodigoProducto><CodigoTarifa>0</CodigoTarifa><ConsultaPadre><CodigoPais>540</CodigoPais><CodigoProducto>R3</CodigoProducto><CodigoTarifa>0</CodigoTarifa><Anual>false</Anual><Edad>40</Edad><IdTipoPlan>0</IdTipoPlan><IdTipoModalidad>0</IdTipoModalidad></ConsultaPadre><Upgrades><ConsultaCondicionesUpgradeDTO><CodigoUpgrade>H0</CodigoUpgrade><CodigoTarifa>0</CodigoTarifa><Categoria>0</Categoria></ConsultaCondicionesUpgradeDTO></Upgrades><Agencia>99899</Agencia><Sucursal>0</Sucursal></ConsultaCondicionesDTO>";
            //string XML = "<ConsultaCondicionesDTO><CodigoPais>540</CodigoPais>  <Anual>false</Anual>  <Edad>30</Edad>  <IdTipoPlan>3</IdTipoPlan>  <IdTipoModalidad>0</IdTipoModalidad>  <Categoria>0</Categoria>  <CodigoProducto>R3</CodigoProducto>  <CodigoTarifa>0</CodigoTarifa>  <ConsultaPadre>    <CodigoPais>540</CodigoPais>    <CodigoProducto>R3</CodigoProducto>    <CodigoTarifa>0</CodigoTarifa>    <Anual>false</Anual>    <Edad>30</Edad>    <IdTipoPlan>0</IdTipoPlan>    <IdTipoModalidad>0</IdTipoModalidad>  </ConsultaPadre>  <Upgrades>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade></CodigoUpgrade>      <CodigoTarifa></CodigoTarifa>      <Categoria>0</Categoria>    </ConsultaCondicionesUpgradeDTO>  </Upgrades></ConsultaCondicionesDTO>";
            
            TimeSpan a = new TimeSpan();

            string XmlRespuesta = ServicioWS.ObtenerCondicionesXml(XML, "", "");
            //string XmlRespuesta = ServicioWS.ObtenerClausulasCoincidentesXml(XML, "", "");

            Response.Write(XmlRespuesta);
            Response.End();

            //TimeSpan b = new TimeSpan();
            

            //FileStream fs = File.Create("c:/  .xml");

            //byte[] bytes = Encoding.UTF8.GetBytes(XmlRespuesta.ToCharArray());

            //fs.Write(bytes, 0, bytes.Length);
            
            //fs.Flush();
            //fs.Close();

            //for (int I = 0; I < 10; I++)
            //{
                
            //}

            
            //Servicio.c
/*            ServicioClausulasClient Servicio = new ServicioClausulasClient();

            ConsultaCondicionesDTO ConsultaDTO = new ConsultaCondicionesDTO();
            ConsultaDTO.CodigoPais = 540;
            ConsultaDTO.CodigoProducto = "R3";
            ConsultaDTO.CodigoTarifa = "0";
            ConsultaDTO.Anual = false;
            ConsultaDTO.Edad = 30;
            ConsultaDTO.IdTipoPlan = 2; //Individual
            ConsultaDTO.IdTipoModalidad = 1; //No aplica

            ConsultaDTO.ConsultaPadre = new ConsultaCondicionesDTO();
            ConsultaDTO.ConsultaPadre.CodigoPais = 540;
            ConsultaDTO.ConsultaPadre.CodigoProducto = "R3";
            ConsultaDTO.ConsultaPadre.CodigoTarifa = "0";
            ConsultaDTO.ConsultaPadre.Anual = false;
            ConsultaDTO.ConsultaPadre.Edad = 30;
            ConsultaDTO.ConsultaPadre.IdTipoPlan = 2; //Individual
            ConsultaDTO.ConsultaPadre.IdTipoModalidad = 0; //No aplica

            //string XML = "<ConsultaCondicionesDTO><codigoPais>540</codigoPais><anual>false</anual><edad>65</edad><idTipoPlan>2</idTipoPlan><idTipoModalidad></idTipoModalidad>  <categoria></categoria>  <codigoProducto>A4</codigoProducto>  <codigoTarifa>0</codigoTarifa>  <ConsultaPadre>    <CodigoPais>540</CodigoPais>    <CodigoProducto>A4</CodigoProducto>    <CodigoTarifa>0</CodigoTarifa>    <Anual>false</Anual>    <Edad>65</Edad>    <IdTipoPlan>0</IdTipoPlan>    <IdTipoModalidad>0</IdTipoModalidad>  </ConsultaPadre>  <Upgrades>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade></CodigoUpgrade>      <CodigoTarifa></CodigoTarifa>      <Categoria>0</Categoria>    </ConsultaCondicionesUpgradeDTO>  </Upgrades></ConsultaCondicionesDTO>";
            //string XML = "<ConsultaCondicionesDTO>  <CodigoPais>540</CodigoPais>  <Anual>false</Anual>  <Edad>30</Edad>  <IdTipoPlan>3</IdTipoPlan>  <IdTipoModalidad>0</IdTipoModalidad>  <Categoria>0</Categoria>  <CodigoProducto>R3</CodigoProducto>  <CodigoTarifa>0</CodigoTarifa>  <ConsultaPadre>    <CodigoPais>540</CodigoPais>    <CodigoProducto>R3</CodigoProducto>    <CodigoTarifa>0</CodigoTarifa>    <Anual>false</Anual>    <Edad>30</Edad>    <IdTipoPlan>0</IdTipoPlan>    <IdTipoModalidad>0</IdTipoModalidad>  </ConsultaPadre>  <Upgrades>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade></CodigoUpgrade>      <CodigoTarifa></CodigoTarifa>      <Categoria>0</Categoria>    </ConsultaCondicionesUpgradeDTO>  </Upgrades></ConsultaCondicionesDTO>";
            //string XML = "<ConsultaCondicionesDTO>  <CodigoPais>540</CodigoPais>  <Anual>false</Anual>  <Edad>30</Edad>  <IdTipoPlan>3</IdTipoPlan>  <IdTipoModalidad>0</IdTipoModalidad>  <Categoria>0</Categoria>  <CodigoProducto>R3</CodigoProducto>  <CodigoTarifa>0</CodigoTarifa>  <ConsultaPadre>    <CodigoPais>540</CodigoPais>    <CodigoProducto>R3</CodigoProducto>    <CodigoTarifa>0</CodigoTarifa>    <Anual>false</Anual>    <Edad>30</Edad>    <IdTipoPlan>0</IdTipoPlan>    <IdTipoModalidad>0</IdTipoModalidad>  </ConsultaPadre>  <Upgrades>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade></CodigoUpgrade>      <CodigoTarifa></CodigoTarifa>      <Categoria>0</Categoria>    </ConsultaCondicionesUpgradeDTO>  </Upgrades></ConsultaCondicionesDTO>";
            ////string XML = "<ConsultaCondicionesDTO><codigoPais>540</codigoPais><anual>false</anual><edad>65</edad><idTipoPlan>2</idTipoPlan><idTipoModalidad></idTipoModalidad>  <categoria></categoria>  <codigoProducto>A4</codigoProducto>  <codigoTarifa>0</codigoTarifa>  <ConsultaPadre>    <CodigoPais>540</CodigoPais>    <CodigoProducto>A4</CodigoProducto>    <CodigoTarifa>0</CodigoTarifa>    <Anual>false</Anual>    <Edad>65</Edad>    <IdTipoPlan></IdTipoPlan>    <IdTipoModalidad></IdTipoModalidad>  </ConsultaPadre>  <Upgrades></Upgrades></ConsultaCondicionesDTO>";
            //string XML = "<ConsultaCondicionesDTO><codigoPais>540</codigoPais><anual>false</anual><edad>30</edad><idTipoPlan>3</idTipoPlan><codigoProducto>R3</codigoProducto>  <codigoTarifa>14010</codigoTarifa>  <ConsultaPadre>    <CodigoPais>540</CodigoPais>    <CodigoProducto>R1</CodigoProducto>    <CodigoTarifa>0</CodigoTarifa>    <Anual>false</Anual>    <Edad>30</Edad>    <IdTipoPlan>3</IdTipoPlan> </ConsultaPadre>  <Upgrades></Upgrades></ConsultaCondicionesDTO>";

            /*
             Anual = false
CodigoPais = 540
CodigoProducto = "R1"
CodigoTarifa = "14010"
ConsultaPadre = null
Edad = 0
ExtensionData = null
IdTipoModalidad = 1
IdTipoPlan = 3
Upgrades = null
             */
 /*           GruposClausulaDTO Respuesta = Servicio.ObtenerCondiciones(ConsultaDTO, "", ""); //Servicio.ObtenerCondicionesXml(XML, "", "");

            for (int I = 0; I < 10; I++)
            {
                int cantidad = Respuesta.Grupos.Length;
            }
            //ConsultaDTO.Upgrades = new ConsultaCondicionesUpgradeDTO[1];

            //ConsultaCondicionesUpgradeDTO ConsultaUpgrade = new ConsultaCondicionesUpgradeDTO();
            //ConsultaUpgrade.CodigoUpgrade = "H2";
            //ConsultaUpgrade.CodigoTarifa = "0";
            //ConsultaUpgrade.Categoria = 0;

            //ConsultaDTO.Upgrades[0] = ConsultaUpgrade;

            //string XmlConsulta = Servicio.ConvertirConsulta(ConsultaDTO);

            //XmlConsulta = "<ConsultaCondicionesDTO><CodigoPais>540</CodigoPais> <Anual>false</Anual> <Edad>0</Edad> <IdTipoPlan>0</IdTipoPlan> <IdTipoModalidad>0</IdTipoModalidad></ConsultaCondicionesDTO>";
            //GruposClausulaDTO Grupos = Servicio.ObtenerCondiciones(ConsultaDTO, "", "");

            //string XmlGrupos = Servicio.ConvertirGrupos(Grupos);

            //GruposClausulaDTO Grupos = Servicio.ObtenerCondiciones(ConsultaDTO, "", "");
            //string XmlRespuesta = Servicio.ConvertirGrupos(Grupos);
            ////string XmlRespuesta = Servicio.ObtenerCondicionesXml(XML, "", "");

            //string hh = "hola";
            ////for (int I = 0; I < Grupos.Grupos.Length; I++)
            //{
            //}*/

 /*           Condiciones.TarifaWSTesting.ServicioTarifaWS Servicio = new Condiciones.TarifaWSTesting.ServicioTarifaWS();

            string xml = "<TarifaWS>  <IdTipoGrupoClausula>1</IdTipoGrupoClausula>   <CodigoPais>540</CodigoPais>   <CodigoTarifa>111</CodigoTarifa>   <Nombre>MI TARIFA 3</Nombre>   <Anual>false</Anual>   <Sufijo />   <Activa>true</Activa>  <Producto>  <CodigoProducto>RF</CodigoProducto>   <Nombre>MI PRODUCTO 3</Nombre>   </Producto>  </TarifaWS>";

            ServicioTarifaClient ServicioTarifa = new ServicioTarifaClient();

            Servicio.AgregarTarifa(xml, "", "");*/
            /*
            TarifaWS Tarifa = new TarifaWS();
            Tarifa.IdTipoGrupoClausula = 1;
            Tarifa.CodigoPais = 540;
            Tarifa.CodigoTarifa = "111";
            Tarifa.Nombre = "MI TARIFA";
            Tarifa.Sufijo = "";
            Tarifa.Activa = true;
            Tarifa.Anual = false;

            Tarifa.Producto = new ProductoWS();
            Tarifa.Producto.CodigoProducto = "RR";
            Tarifa.Producto.Nombre = "MI PRODUCTO";

            ServicioTarifa.AgregarTarifa(Tarifa);
            */
        }
    }
}
