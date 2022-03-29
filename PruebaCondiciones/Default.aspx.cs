using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Text;
using ServicioCondiciones;
using PruebaCondiciones.ServicioClausulaTestingWS;

namespace PruebaCondiciones
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ServicioClausulasWS ServicioWS = new ServicioClausulasWS();


            //string XML = "<ConsultaCondicionesDTO>  <CodigoPais>540</CodigoPais>  <Anual>false</Anual>  <Edad>52</Edad>  <IdTipoPlan>3</IdTipoPlan>  <IdTipoModalidad>6</IdTipoModalidad>  <Categoria>0</Categoria>  <CodigoProducto>R3</CodigoProducto>  <CodigoTarifa>0</CodigoTarifa>  <ConsultaPadre>    <CodigoPais>540</CodigoPais>    <CodigoProducto>R3</CodigoProducto>    <CodigoTarifa>0</CodigoTarifa>    <Anual>false</Anual>    <Edad>52</Edad>    <IdTipoPlan>3</IdTipoPlan>    <IdTipoModalidad>6</IdTipoModalidad>  </ConsultaPadre>  <Upgrades>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade>H2</CodigoUpgrade>      <CodigoTarifa>0</CodigoTarifa>      <Categoria>3000</Categoria>    </ConsultaCondicionesUpgradeDTO>  </Upgrades></ConsultaCondicionesDTO>";

            //string XML = "<ConsultaCondicionesDTO>  <CodigoPais>540</CodigoPais>  <Anual>false</Anual>  <Edad>51</Edad>  <IdTipoPlan>3</IdTipoPlan>  <IdTipoModalidad>6</IdTipoModalidad>  <Categoria>0</Categoria>  <CodigoProducto>R3</CodigoProducto>  <CodigoTarifa>0</CodigoTarifa>  <ConsultaPadre>    <CodigoPais>540</CodigoPais>    <CodigoProducto>R3</CodigoProducto>    <CodigoTarifa>0</CodigoTarifa>    <Anual>false</Anual>    <Edad>51</Edad>    <IdTipoPlan>3</IdTipoPlan>    <IdTipoModalidad>6</IdTipoModalidad>  </ConsultaPadre>  <Upgrades>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade>H0</CodigoUpgrade>      <CodigoTarifa>0</CodigoTarifa>      <Categoria>0</Categoria>    </ConsultaCondicionesUpgradeDTO>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade>H7</CodigoUpgrade>      <CodigoTarifa>0</CodigoTarifa>      <Categoria>200000</Categoria>    </ConsultaCondicionesUpgradeDTO>  </Upgrades></ConsultaCondicionesDTO>";
            //string XML = "<ConsultaCondicionesDTO>  <CodigoPais>540</CodigoPais>  <Anual>false</Anual>  <Edad>41</Edad>  <IdTipoPlan>3</IdTipoPlan>  <IdTipoModalidad>6</IdTipoModalidad>  <Categoria>0</Categoria>  <CodigoProducto>R3</CodigoProducto>  <CodigoTarifa>0</CodigoTarifa>  <ConsultaPadre>    <CodigoPais>540</CodigoPais>    <CodigoProducto>R3</CodigoProducto>    <CodigoTarifa>0</CodigoTarifa>    <Anual>false</Anual>    <Edad>41</Edad>    <IdTipoPlan>3</IdTipoPlan>    <IdTipoModalidad>6</IdTipoModalidad>  </ConsultaPadre>  <Upgrades>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade>H2</CodigoUpgrade>      <CodigoTarifa>0</CodigoTarifa>      <Categoria>3000</Categoria>    </ConsultaCondicionesUpgradeDTO>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade>H7</CodigoUpgrade>      <CodigoTarifa>0</CodigoTarifa>      <Categoria>200000</Categoria>    </ConsultaCondicionesUpgradeDTO>  </Upgrades></ConsultaCondicionesDTO>";
            //string XML = "<ConsultaCondicionesDTO>  <CodigoPais>540</CodigoPais>  <Anual>false</Anual>  <Edad>51</Edad>  <IdTipoPlan>3</IdTipoPlan>  <IdTipoModalidad>6</IdTipoModalidad>  <Categoria>0</Categoria>  <CodigoProducto>R3</CodigoProducto>  <CodigoTarifa>0</CodigoTarifa>  <ConsultaPadre>    <CodigoPais>540</CodigoPais>    <CodigoProducto>R3</CodigoProducto>    <CodigoTarifa>0</CodigoTarifa>    <Anual>false</Anual>    <Edad>51</Edad>    <IdTipoPlan>3</IdTipoPlan>    <IdTipoModalidad>6</IdTipoModalidad>  </ConsultaPadre>  <Upgrades>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade>H0</CodigoUpgrade>      <CodigoTarifa>0</CodigoTarifa>      <Categoria>0</Categoria>    </ConsultaCondicionesUpgradeDTO>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade>H7</CodigoUpgrade>      <CodigoTarifa>0</CodigoTarifa>      <Categoria>200000</Categoria>    </ConsultaCondicionesUpgradeDTO>  </Upgrades></ConsultaCondicionesDTO>";
            //string XML = "<ConsultaCondicionesDTO>  <CodigoPais>520</CodigoPais>  <Anual>false</Anual>  <Edad>61</Edad>  <IdTipoPlan>3</IdTipoPlan>  <IdTipoModalidad>6</IdTipoModalidad>  <Categoria>0</Categoria>  <CodigoProducto>R7</CodigoProducto>  <CodigoTarifa>0</CodigoTarifa>  <ConsultaPadre>    <CodigoPais>520</CodigoPais>    <CodigoProducto>R7</CodigoProducto>    <CodigoTarifa>0</CodigoTarifa>    <Anual>false</Anual>    <Edad>61</Edad>    <IdTipoPlan>3</IdTipoPlan>    <IdTipoModalidad>6</IdTipoModalidad>  </ConsultaPadre>  <Upgrades>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade></CodigoUpgrade>      <CodigoTarifa></CodigoTarifa>      <Categoria></Categoria>    </ConsultaCondicionesUpgradeDTO>  </Upgrades></ConsultaCondicionesDTO>";
            //string XML = "<ConsultaCondicionesDTO>  <CodigoPais>540</CodigoPais>  <Anual>false</Anual>  <Edad>31</Edad>  <IdTipoPlan>3</IdTipoPlan>  <IdTipoModalidad>6</IdTipoModalidad>  <Categoria>0</Categoria>  <CodigoProducto>R3</CodigoProducto>  <CodigoTarifa>0</CodigoTarifa>  <ConsultaPadre>    <CodigoPais>540</CodigoPais>    <CodigoProducto>R3</CodigoProducto>    <CodigoTarifa>0</CodigoTarifa>    <Anual>false</Anual>    <Edad>31</Edad>    <IdTipoPlan>3</IdTipoPlan>    <IdTipoModalidad>6</IdTipoModalidad>  </ConsultaPadre>  <Upgrades>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade>H2</CodigoUpgrade>      <CodigoTarifa>0</CodigoTarifa>      <Categoria>300</Categoria>    </ConsultaCondicionesUpgradeDTO>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade>H5</CodigoUpgrade>      <CodigoTarifa>0</CodigoTarifa>      <Categoria>1000</Categoria>    </ConsultaCondicionesUpgradeDTO>  </Upgrades></ConsultaCondicionesDTO>";
            
            //string XML = "<ConsultaCondicionesDTO>            <CodigoPais>598</CodigoPais>            <Anual>false</Anual>            <Edad>17</Edad>            <IdTipoPlan>3</IdTipoPlan>            <IdTipoModalidad>6</IdTipoModalidad>            <Categoria>0</Categoria>            <CodigoProducto>R3</CodigoProducto>            <CodigoTarifa>368</CodigoTarifa>            <ConsultaPadre>                        <CodigoPais>598</CodigoPais>                        <CodigoProducto>R3</CodigoProducto>                        <CodigoTarifa>0</CodigoTarifa>                        <Anual>false</Anual>                        <Edad>17</Edad>                        <IdTipoPlan>3</IdTipoPlan>                        <IdTipoModalidad>6</IdTipoModalidad>            </ConsultaPadre>            <Upgrades>                        <ConsultaCondicionesUpgradeDTO>                                   <CodigoUpgrade>H5</CodigoUpgrade>                                   <CodigoTarifa>0</CodigoTarifa>                                   <Categoria>3000</Categoria>                        </ConsultaCondicionesUpgradeDTO>            </Upgrades></ConsultaCondicionesDTO>";
            string XML = "<ConsultaCondicionesDTO>  <CodigoPais>540</CodigoPais>  <Anual>false</Anual>  <Edad>45</Edad>  <IdTipoPlan>3</IdTipoPlan>  <IdTipoModalidad>6</IdTipoModalidad>  <Categoria>0</Categoria>  <CodigoProducto>R2</CodigoProducto>  <CodigoTarifa>0</CodigoTarifa>  <ConsultaPadre>    <CodigoPais>540</CodigoPais>    <CodigoProducto>R2</CodigoProducto>    <CodigoTarifa>0</CodigoTarifa>    <Anual>false</Anual>    <Edad>45</Edad>    <IdTipoPlan>3</IdTipoPlan>    <IdTipoModalidad>6</IdTipoModalidad>  </ConsultaPadre>  <Upgrades>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade></CodigoUpgrade>      <CodigoTarifa></CodigoTarifa>      <Categoria>0</Categoria>    </ConsultaCondicionesUpgradeDTO>  </Upgrades></ConsultaCondicionesDTO>";

            string XmlRespuesta = ServicioWS.ObtenerCondicionesXml(XML, "", "");


            Response.ContentType = "text/xml";
            Response.Write(XmlRespuesta);
            Response.End();

//            //string XML = "<ConsultaCondicionesDTO>  <CodigoPais>540</CodigoPais>  <Anual>false</Anual>  <Edad>25</Edad>  <IdTipoPlan>3</IdTipoPlan>  <IdTipoModalidad>0</IdTipoModalidad>  <Categoria>0</Categoria>  <CodigoProducto>AA</CodigoProducto>  <CodigoTarifa>0</CodigoTarifa>  <ConsultaPadre>    <CodigoPais>540</CodigoPais>    <CodigoProducto>AA</CodigoProducto>    <CodigoTarifa>0</CodigoTarifa>    <Anual>false</Anual>    <Edad>25</Edad>    <IdTipoPlan>0</IdTipoPlan>    <IdTipoModalidad>0</IdTipoModalidad>  </ConsultaPadre>  <Upgrades>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade></CodigoUpgrade>      <CodigoTarifa></CodigoTarifa>      <Categoria>0</Categoria>    </ConsultaCondicionesUpgradeDTO>  </Upgrades></ConsultaCondicionesDTO>";
//            string XML = "<ConsultaCondicionesDTO>  <CodigoPais>540</CodigoPais>  <Anual>false</Anual>  <Edad>36</Edad>  <IdTipoPlan>3</IdTipoPlan>  <IdTipoModalidad>0</IdTipoModalidad>  <Categoria>0</Categoria>  <CodigoProducto>R3</CodigoProducto>  <CodigoTarifa>0</CodigoTarifa>  <ConsultaPadre>    <CodigoPais>540</CodigoPais>    <CodigoProducto>R3</CodigoProducto>    <CodigoTarifa>0</CodigoTarifa>    <Anual>false</Anual>    <Edad>36</Edad>    <IdTipoPlan>0</IdTipoPlan>    <IdTipoModalidad>0</IdTipoModalidad>  </ConsultaPadre>  <Upgrades>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade>H2</CodigoUpgrade>      <CodigoTarifa>0</CodigoTarifa>      <Categoria>300</Categoria>    </ConsultaCondicionesUpgradeDTO>  </Upgrades></ConsultaCondicionesDTO>";
//            //string XML = "<ConsultaCondicionesDTO>  <CodigoPais>100</CodigoPais>  <Anual>false</Anual>  <Edad>84</Edad>  <IdTipoPlan>3</IdTipoPlan>  <IdTipoModalidad>0</IdTipoModalidad>  <Categoria>0</Categoria>  <CodigoProducto>UC</CodigoProducto>  <CodigoTarifa>2000</CodigoTarifa>  <ConsultaPadre>    <CodigoPais>100</CodigoPais>    <CodigoProducto>UC</CodigoProducto>    <CodigoTarifa>0</CodigoTarifa>    <Anual>false</Anual>    <Edad>84</Edad>    <IdTipoPlan>0</IdTipoPlan>    <IdTipoModalidad>0</IdTipoModalidad>  </ConsultaPadre>  <Upgrades>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade></CodigoUpgrade>      <CodigoTarifa></CodigoTarifa>      <Categoria>0</Categoria>    </ConsultaCondicionesUpgradeDTO>  </Upgrades></ConsultaCondicionesDTO>";

////            string XML = "<ConsultaCondicionesDTO>  <CodigoPais>540</CodigoPais>  <Anual>false</Anual>  <Edad>30</Edad>  <IdTipoPlan>3</IdTipoPlan>  <IdTipoModalidad>0</IdTipoModalidad>  <Categoria>0</Categoria>  <CodigoProducto>R1</CodigoProducto>  <CodigoTarifa>0</CodigoTarifa>  <ConsultaPadre>    <CodigoPais>540</CodigoPais>    <CodigoProducto>R1</CodigoProducto>    <CodigoTarifa>0</CodigoTarifa>    <Anual>false</Anual>    <Edad>30</Edad>    <IdTipoPlan>0</IdTipoPlan>    <IdTipoModalidad>0</IdTipoModalidad>  </ConsultaPadre>  <Upgrades>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade></CodigoUpgrade>      <CodigoTarifa></CodigoTarifa>      <Categoria>0</Categoria>    </ConsultaCondicionesUpgradeDTO>  </Upgrades></ConsultaCondicionesDTO>";
//            //    510  true  70  3  0  0  XU  7303   510  XU  0  true  70  0  0       0   
//            // 998  true  39  3  0  0  52  804        0  0       0   
//            //string XML = "<ConsultaCondicionesDTO>  <CodigoPais>998</CodigoPais>  <Anual>true</Anual>  <Edad>39</Edad>  <IdTipoPlan>3</IdTipoPlan>  <IdTipoModalidad>0</IdTipoModalidad>  <Categoria>0</Categoria>  <CodigoProducto>52</CodigoProducto>  <CodigoTarifa>804</CodigoTarifa>  <ConsultaPadre>    <CodigoPais>998</CodigoPais>    <CodigoProducto>XU</CodigoProducto>    <CodigoTarifa>0</CodigoTarifa>    <Anual>true</Anual>    <Edad>70</Edad>    <IdTipoPlan>0</IdTipoPlan>    <IdTipoModalidad>0</IdTipoModalidad>  </ConsultaPadre>  <Upgrades>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade></CodigoUpgrade>      <CodigoTarifa></CodigoTarifa>      <Categoria>0</Categoria>    </ConsultaCondicionesUpgradeDTO>  </Upgrades></ConsultaCondicionesDTO>";
//            //string XML = " <ConsultaCondicionesDTO>  <CodigoPais>510</CodigoPais>  <Anual>true</Anual>  <Edad>70</Edad>  <IdTipoPlan>3</IdTipoPlan>  <IdTipoModalidad>0</IdTipoModalidad>  <Categoria>0</Categoria>  <CodigoProducto>XU</CodigoProducto>  <CodigoTarifa>7303</CodigoTarifa>  <ConsultaPadre>    <CodigoPais>510</CodigoPais>    <CodigoProducto>XU</CodigoProducto>    <CodigoTarifa>0</CodigoTarifa>    <Anual>true</Anual>    <Edad>70</Edad>    <IdTipoPlan>0</IdTipoPlan>    <IdTipoModalidad>0</IdTipoModalidad>  </ConsultaPadre>  <Upgrades>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade></CodigoUpgrade>      <CodigoTarifa></CodigoTarifa>      <Categoria>0</Categoria>    </ConsultaCondicionesUpgradeDTO>  </Upgrades></ConsultaCondicionesDTO>";
//            //string XML = "<ConsultaCondicionesDTO>  <CodigoPais>503</CodigoPais>  <Anual>true</Anual>  <Edad>59</Edad>  <IdTipoPlan>3</IdTipoPlan>  <IdTipoModalidad>0</IdTipoModalidad>  <Categoria>0</Categoria>  <CodigoProducto>26</CodigoProducto>  <CodigoTarifa>0</CodigoTarifa>  <ConsultaPadre>    <CodigoPais>503</CodigoPais>    <CodigoProducto>26</CodigoProducto>    <CodigoTarifa>0</CodigoTarifa>    <Anual>true</Anual>    <Edad>59</Edad>    <IdTipoPlan>0</IdTipoPlan>    <IdTipoModalidad>0</IdTipoModalidad>  </ConsultaPadre>  <Upgrades>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade></CodigoUpgrade>      <CodigoTarifa></CodigoTarifa>      <Categoria>0</Categoria>    </ConsultaCondicionesUpgradeDTO>  </Upgrades></ConsultaCondicionesDTO>";
//            //string XML = "<ConsultaCondicionesDTO>  <CodigoPais>540</CodigoPais>  <Anual>false</Anual>  <Edad>30</Edad>  <IdTipoPlan>0</IdTipoPlan>  <IdTipoModalidad>0</IdTipoModalidad>  <Categoria>0</Categoria>  <CodigoProducto>76</CodigoProducto>  <CodigoTarifa>0</CodigoTarifa>  <ConsultaPadre>    <CodigoPais>540</CodigoPais>    <CodigoProducto>76</CodigoProducto>    <CodigoTarifa>0</CodigoTarifa>    <Anual>true</Anual>    <Edad>30</Edad>    <IdTipoPlan>0</IdTipoPlan>    <IdTipoModalidad>0</IdTipoModalidad>  </ConsultaPadre>  <Upgrades>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade></CodigoUpgrade>      <CodigoTarifa></CodigoTarifa>      <Categoria>0</Categoria>    </ConsultaCondicionesUpgradeDTO>  </Upgrades></ConsultaCondicionesDTO>";

//            //string XML = "<ConsultaCondicionesDTO ><CodigoPais>540</CodigoPais><CodigoProducto>H7</CodigoProducto><CodigoTarifa>0</CodigoTarifa><Anual>false</Anual><Edad>30</Edad><IdTipoPlan>0</IdTipoPlan><IdTipoModalidad>0</IdTipoModalidad><ConsultaPadre><CodigoPais>540</CodigoPais><CodigoProducto>R3</CodigoProducto><CodigoTarifa>0</CodigoTarifa><Anual>false</Anual><Edad>30</Edad><IdTipoPlan>0</IdTipoPlan><IdTipoModalidad>0</IdTipoModalidad></ConsultaPadre></ConsultaCondicionesDTO>";

//            //string XML = "<ConsultaCondicionesDTO> <CodigoPais>900</CodigoPais> <Anual>false</Anual> <Edad>25</Edad> <IdTipoPlan>3</IdTipoPlan> <IdTipoModalidad>6</IdTipoModalidad> <Categoria>0</Categoria> <CodigoProducto>29</CodigoProducto> <CodigoTarifa>0</CodigoTarifa> <ConsultaPadre>   <CodigoPais>900</CodigoPais>   <CodigoProducto>29</CodigoProducto>   <CodigoTarifa>0</CodigoTarifa>   <Anual>false</Anual>   <Edad>25</Edad>   <IdTipoPlan>0</IdTipoPlan>   <IdTipoModalidad>6</IdTipoModalidad> </ConsultaPadre> <Upgrades>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade></CodigoUpgrade>      <CodigoTarifa></CodigoTarifa>      <Categoria>0</Categoria>    </ConsultaCondicionesUpgradeDTO>  </Upgrades></ConsultaCondicionesDTO>";
            
//            //string XML = "<ConsultaCondicionesDTO>  <CodigoPais>540</CodigoPais>  <Anual>false</Anual>  <Edad>25</Edad>  <IdTipoPlan>3</IdTipoPlan>  <IdTipoModalidad>0</IdTipoModalidad>  <Categoria>0</Categoria>  <CodigoProducto>R1</CodigoProducto>  <CodigoTarifa>0</CodigoTarifa>  <ConsultaPadre>    <CodigoPais>540</CodigoPais>    <CodigoProducto>R1</CodigoProducto>    <CodigoTarifa>0</CodigoTarifa>    <Anual>false</Anual>    <Edad>25</Edad>    <IdTipoPlan>0</IdTipoPlan>    <IdTipoModalidad>0</IdTipoModalidad>  </ConsultaPadre>  <Upgrades>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade>H0</CodigoUpgrade>      <CodigoTarifa>0</CodigoTarifa>      <Categoria>0</Categoria>    </ConsultaCondicionesUpgradeDTO>  </Upgrades></ConsultaCondicionesDTO>";

//            //string XML = "<ConsultaCondicionesDTO>  <CodigoPais>540</CodigoPais>  <Anual>false</Anual>  <Edad>30</Edad>  <IdTipoPlan>3</IdTipoPlan>  <IdTipoModalidad>6</IdTipoModalidad>  <Categoria>0</Categoria>  <CodigoProducto>R3</CodigoProducto>  <CodigoTarifa>0</CodigoTarifa>  <ConsultaPadre>    <CodigoPais>540</CodigoPais>    <CodigoProducto>R3</CodigoProducto>    <CodigoTarifa>0</CodigoTarifa>    <Anual>false</Anual>    <Edad>30</Edad>    <IdTipoPlan>3</IdTipoPlan>    <IdTipoModalidad>6</IdTipoModalidad>  </ConsultaPadre>  <Upgrades>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade></CodigoUpgrade>      <CodigoTarifa></CodigoTarifa>      <Categoria>0</Categoria>    </ConsultaCondicionesUpgradeDTO>  </Upgrades></ConsultaCondicionesDTO>";

//            //string XML = "<ConsultaCondicionesDTO>  <CodigoPais>598</CodigoPais>  <Anual>false</Anual>  <Edad>26</Edad>  <IdTipoPlan>3</IdTipoPlan>  <IdTipoModalidad>0</IdTipoModalidad>  <Categoria>0</Categoria>  <CodigoProducto>R6</CodigoProducto>  <CodigoTarifa>997</CodigoTarifa>  <ConsultaPadre>    <CodigoPais>598</CodigoPais>    <CodigoProducto>R6</CodigoProducto>    <CodigoTarifa>0</CodigoTarifa>    <Anual>false</Anual>    <Edad>26</Edad>    <IdTipoPlan>0</IdTipoPlan>    <IdTipoModalidad>0</IdTipoModalidad>  </ConsultaPadre>  <Upgrades>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade></CodigoUpgrade>      <CodigoTarifa></CodigoTarifa>      <Categoria>0</Categoria>    </ConsultaCondicionesUpgradeDTO>  </Upgrades></ConsultaCondicionesDTO>";

//            //string XML = "<ConsultaCondicionesDTO><CodigoPais>540</CodigoPais><Anual>false</Anual><Edad>40</Edad><IdTipoPlan>3</IdTipoPlan><IdTipoModalidad>0</IdTipoModalidad><Categoria>0</Categoria><CodigoProducto>R3</CodigoProducto><CodigoTarifa>0</CodigoTarifa><ConsultaPadre><CodigoPais>540</CodigoPais><CodigoProducto>R3</CodigoProducto><CodigoTarifa>0</CodigoTarifa><Anual>false</Anual><Edad>40</Edad><IdTipoPlan>0</IdTipoPlan><IdTipoModalidad>0</IdTipoModalidad></ConsultaPadre><Upgrades><ConsultaCondicionesUpgradeDTO><CodigoUpgrade>H0</CodigoUpgrade><CodigoTarifa>0</CodigoTarifa><Categoria>0</Categoria></ConsultaCondicionesUpgradeDTO></Upgrades></ConsultaCondicionesDTO>";
//            //string XML = "<ConsultaCondicionesDTO>  <CodigoPais>540</CodigoPais>  <Anual>false</Anual>  <Edad>30</Edad>  <IdTipoPlan>3</IdTipoPlan>  <IdTipoModalidad>0</IdTipoModalidad>  <Categoria>0</Categoria>  <CodigoProducto>R3</CodigoProducto>  <CodigoTarifa>0</CodigoTarifa>  <ConsultaPadre>    <CodigoPais>540</CodigoPais>    <CodigoProducto>R3</CodigoProducto>    <CodigoTarifa>0</CodigoTarifa>    <Anual>false</Anual>    <Edad>30</Edad>    <IdTipoPlan>0</IdTipoPlan>    <IdTipoModalidad>0</IdTipoModalidad>  </ConsultaPadre>  <Upgrades>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade></CodigoUpgrade>      <CodigoTarifa></CodigoTarifa>      <Categoria>0</Categoria>    </ConsultaCondicionesUpgradeDTO>  </Upgrades></ConsultaCondicionesDTO>";

//            TimeSpan a = new TimeSpan(DateTime.Now.Ticks);

//            string XmlRespuesta = ServicioWS.ObtenerCondicionesXml(XML, "", "");

//            TimeSpan b = new TimeSpan( DateTime.Now.Ticks);

//            double Diferencia = b.TotalSeconds - a.TotalSeconds;

//            GruposClausulaDTO dto = new GruposClausulaDTO();

//            dto = (GruposClausulaDTO)DeserializeObject(XmlRespuesta, dto.GetType());
            
//            for (int I = 0; I < 10; I++)
//            {
//                Diferencia += 0;
//            }
            
//            //Servicio.c
//            /*            ServicioClausulasClient Servicio = new ServicioClausulasClient();

//                        ConsultaCondi cionesDTO ConsultaDTO = new ConsultaCondicionesDTO();
//                        ConsultaDTO.CodigoPais = 540;
//                        ConsultaDTO.CodigoProducto = "R3";
//                        ConsultaDTO.CodigoTarifa = "0";
//                        ConsultaDTO.Anual = false;
//                        ConsultaDTO.Edad = 30;
//                        ConsultaDTO.IdTipoPlan = 2; //Individual
//                        ConsultaDTO.IdTipoModalidad = 1; //No aplica

//                        ConsultaDTO.ConsultaPadre = new ConsultaCondicionesDTO();
//                        ConsultaDTO.ConsultaPadre.CodigoPais = 540;
//                        ConsultaDTO.ConsultaPadre.CodigoProducto = "R3";
//                        ConsultaDTO.ConsultaPadre.CodigoTarifa = "0";
//                        ConsultaDTO.ConsultaPadre.Anual = false;
//                        ConsultaDTO.ConsultaPadre.Edad = 30;
//                        ConsultaDTO.ConsultaPadre.IdTipoPlan = 2; //Individual
//                        ConsultaDTO.ConsultaPadre.IdTipoModalidad = 0; //No aplica

//                        //string XML = "<ConsultaCondicionesDTO><codigoPais>540</codigoPais><anual>false</anual><edad>65</edad><idTipoPlan>2</idTipoPlan><idTipoModalidad></idTipoModalidad>  <categoria></categoria>  <codigoProducto>A4</codigoProducto>  <codigoTarifa>0</codigoTarifa>  <ConsultaPadre>    <CodigoPais>540</CodigoPais>    <CodigoProducto>A4</CodigoProducto>    <CodigoTarifa>0</CodigoTarifa>    <Anual>false</Anual>    <Edad>65</Edad>    <IdTipoPlan>0</IdTipoPlan>    <IdTipoModalidad>0</IdTipoModalidad>  </ConsultaPadre>  <Upgrades>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade></CodigoUpgrade>      <CodigoTarifa></CodigoTarifa>      <Categoria>0</Categoria>    </ConsultaCondicionesUpgradeDTO>  </Upgrades></ConsultaCondicionesDTO>";
//                        //string XML = "<ConsultaCondicionesDTO>  <CodigoPais>540</CodigoPais>  <Anual>false</Anual>  <Edad>30</Edad>  <IdTipoPlan>3</IdTipoPlan>  <IdTipoModalidad>0</IdTipoModalidad>  <Categoria>0</Categoria>  <CodigoProducto>R3</CodigoProducto>  <CodigoTarifa>0</CodigoTarifa>  <ConsultaPadre>    <CodigoPais>540</CodigoPais>    <CodigoProducto>R3</CodigoProducto>    <CodigoTarifa>0</CodigoTarifa>    <Anual>false</Anual>    <Edad>30</Edad>    <IdTipoPlan>0</IdTipoPlan>    <IdTipoModalidad>0</IdTipoModalidad>  </ConsultaPadre>  <Upgrades>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade></CodigoUpgrade>      <CodigoTarifa></CodigoTarifa>      <Categoria>0</Categoria>    </ConsultaCondicionesUpgradeDTO>  </Upgrades></ConsultaCondicionesDTO>";
//                        //string XML = "<ConsultaCondicionesDTO>  <CodigoPais>540</CodigoPais>  <Anual>false</Anual>  <Edad>30</Edad>  <IdTipoPlan>3</IdTipoPlan>  <IdTipoModalidad>0</IdTipoModalidad>  <Categoria>0</Categoria>  <CodigoProducto>R3</CodigoProducto>  <CodigoTarifa>0</CodigoTarifa>  <ConsultaPadre>    <CodigoPais>540</CodigoPais>    <CodigoProducto>R3</CodigoProducto>    <CodigoTarifa>0</CodigoTarifa>    <Anual>false</Anual>    <Edad>30</Edad>    <IdTipoPlan>0</IdTipoPlan>    <IdTipoModalidad>0</IdTipoModalidad>  </ConsultaPadre>  <Upgrades>    <ConsultaCondicionesUpgradeDTO>      <CodigoUpgrade></CodigoUpgrade>      <CodigoTarifa></CodigoTarifa>      <Categoria>0</Categoria>    </ConsultaCondicionesUpgradeDTO>  </Upgrades></ConsultaCondicionesDTO>";
//                        ////string XML = "<ConsultaCondicionesDTO><codigoPais>540</codigoPais><anual>false</anual><edad>65</edad><idTipoPlan>2</idTipoPlan><idTipoModalidad></idTipoModalidad>  <categoria></categoria>  <codigoProducto>A4</codigoProducto>  <codigoTarifa>0</codigoTarifa>  <ConsultaPadre>    <CodigoPais>540</CodigoPais>    <CodigoProducto>A4</CodigoProducto>    <CodigoTarifa>0</CodigoTarifa>    <Anual>false</Anual>    <Edad>65</Edad>    <IdTipoPlan></IdTipoPlan>    <IdTipoModalidad></IdTipoModalidad>  </ConsultaPadre>  <Upgrades></Upgrades></ConsultaCondicionesDTO>";
//                        //string XML = "<ConsultaCondicionesDTO><codigoPais>540</codigoPais><anual>false</anual><edad>30</edad><idTipoPlan>3</idTipoPlan><codigoProducto>R3</codigoProducto>  <codigoTarifa>14010</codigoTarifa>  <ConsultaPadre>    <CodigoPais>540</CodigoPais>    <CodigoProducto>R1</CodigoProducto>    <CodigoTarifa>0</CodigoTarifa>    <Anual>false</Anual>    <Edad>30</Edad>    <IdTipoPlan>3</IdTipoPlan> </ConsultaPadre>  <Upgrades></Upgrades></ConsultaCondicionesDTO>";

//                        /*
//                         Anual = false
//            CodigoPais = 540
//            CodigoProducto = "R1"
//            CodigoTarifa = "14010"
//            ConsultaPadre = null
//            Edad = 0
//            ExtensionData = null
//            IdTipoModalidad = 1
//            IdTipoPlan = 3
//            Upgrades = null
//                         */
//            /*           GruposClausulaDTO Respuesta = Servicio.ObtenerCondiciones(ConsultaDTO, "", ""); //Servicio.ObtenerCondicionesXml(XML, "", "");

//                       for (int I = 0; I < 10; I++)
//                       {
//                           int cantidad = Respuesta.Grupos.Length;
//                       }
//                       //ConsultaDTO.Upgrades = new ConsultaCondicionesUpgradeDTO[1];

//                       //ConsultaCondicionesUpgradeDTO ConsultaUpgrade = new ConsultaCondicionesUpgradeDTO();
//                       //ConsultaUpgrade.CodigoUpgrade = "H2";
//                       //ConsultaUpgrade.CodigoTarifa = "0";
//                       //ConsultaUpgrade.Categoria = 0;

//                       //ConsultaDTO.Upgrades[0] = ConsultaUpgrade;

//                       //string XmlConsulta = Servicio.ConvertirConsulta(ConsultaDTO);

//                       //XmlConsulta = "<ConsultaCondicionesDTO><CodigoPais>540</CodigoPais> <Anual>false</Anual> <Edad>0</Edad> <IdTipoPlan>0</IdTipoPlan> <IdTipoModalidad>0</IdTipoModalidad></ConsultaCondicionesDTO>";
//                       //GruposClausulaDTO Grupos = Servicio.ObtenerCondiciones(ConsultaDTO, "", "");

//                       //string XmlGrupos = Servicio.ConvertirGrupos(Grupos);

//                       //GruposClausulaDTO Grupos = Servicio.ObtenerCondiciones(ConsultaDTO, "", "");
//                       //string XmlRespuesta = Servicio.ConvertirGrupos(Grupos);
//                       ////string XmlRespuesta = Servicio.ObtenerCondicionesXml(XML, "", "");

//                       //string hh = "hola";
//                       ////for (int I = 0; I < Grupos.Grupos.Length; I++)
//                       //{
                                                                                                                                                                                                                                                                                                                                                                                                                     

//            //ServicioTarifaWS.ServicioTarifaWS Servicio = new ServicioTarifaWS.ServicioTarifaWS();

//            //string xml = "<TarifaWS>  <IdTipoGrupoClausula>1</IdTipoGrupoClausula>   <CodigoPais>540</CodigoPais>   <CodigoTarifa>777</CodigoTarifa>   <Nombre>LORE</Nombre>   <Anual>false</Anual>   <Sufijo>LPC77</Sufijo>   <Activa>true</Activa>  <Producto>  <CodigoProducto>LPC</CodigoProducto>   <Nombre>PRODUCTO LORE</Nombre>   </Producto>  </TarifaWS>";

//            //Servicio.AgregarTarifa(xml, "", "");
//            /*
//            TarifaWS Tarifa = new TarifaWS();
//            Tarifa.IdTipoGrupoClausula = 1;
//            Tarifa.CodigoPais = 540;
//            Tarifa.CodigoTarifa = "111";
//            Tarifa.Nombre = "MI TARIFA";
//            Tarifa.Sufijo = "";
//            Tarifa.Activa = true;
//            Tarifa.Anual = false;

//            Tarifa.Producto = new ProductoWS();
//            Tarifa.Producto.CodigoProducto = "RR";
//            Tarifa.Producto.Nombre = "MI PRODUCTO";

//            ServicioTarifa.AgregarTarifa(Tarifa);*/

        }


        public Object DeserializeObject(String pXmlizedString, Type pType)
        {
            XmlSerializer xs = new XmlSerializer(pType);
            MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(pXmlizedString));
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            return xs.Deserialize(memoryStream);
        }

        private Byte[] StringToUTF8ByteArray(String pXmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        }

    }
}
