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
using PruebaCondiciones.ServicioClausulaWS;
using ServicioCondiciones;

namespace PruebaCondiciones
{
    public partial class ComparacionesTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicioClausulasWS ServicioWS = new ServicioClausulasWS();

            ConsultasCondicionesDTO Consultas = new ConsultasCondicionesDTO();
            Consultas.Consultas = new ConsultaCondicionesDTO[3];

            Consultas.Consultas[0] = ObtenerConsulta(540, "R3", "0", "0");
            Consultas.Consultas[1] = ObtenerConsulta(540, "R2", "0", "0");
            Consultas.Consultas[2] = ObtenerConsulta(540, "R1", "0", "0");

            string XML = "<ConsultasCondicionesDTO><Consultas><ConsultaCondicionesDTO><CodigoPais>540</CodigoPais><CodigoProducto>R3</CodigoProducto><CodigoTarifa>0</CodigoTarifa><Anual>false</Anual><Edad>28</Edad><IdTipoPlan>3</IdTipoPlan><IdTipoModalidad>1</IdTipoModalidad><ConsultaPadre><CodigoPais>540</CodigoPais><CodigoProducto>R3</CodigoProducto><CodigoTarifa>0</CodigoTarifa><Anual>false</Anual><Edad>28</Edad><IdTipoPlan>3</IdTipoPlan><IdTipoModalidad>1</IdTipoModalidad></ConsultaPadre></ConsultaCondicionesDTO><ConsultaCondicionesDTO><CodigoPais>540</CodigoPais><CodigoProducto>R2</CodigoProducto><CodigoTarifa>0</CodigoTarifa><Anual>false</Anual><Edad>28</Edad><IdTipoPlan>3</IdTipoPlan><IdTipoModalidad>1</IdTipoModalidad><ConsultaPadre><CodigoPais>540</CodigoPais><CodigoProducto>R2</CodigoProducto><CodigoTarifa>0</CodigoTarifa><Anual>false</Anual><Edad>28</Edad><IdTipoPlan>3</IdTipoPlan><IdTipoModalidad>1</IdTipoModalidad></ConsultaPadre></ConsultaCondicionesDTO><ConsultaCondicionesDTO><CodigoPais>540</CodigoPais><CodigoProducto>R1</CodigoProducto><CodigoTarifa>0</CodigoTarifa><Anual>false</Anual><Edad>28</Edad><IdTipoPlan>3</IdTipoPlan><IdTipoModalidad>1</IdTipoModalidad><ConsultaPadre><CodigoPais>540</CodigoPais><CodigoProducto>R1</CodigoProducto><CodigoTarifa>0</CodigoTarifa><Anual>false</Anual><Edad>28</Edad><IdTipoPlan>3</IdTipoPlan><IdTipoModalidad>1</IdTipoModalidad></ConsultaPadre></ConsultaCondicionesDTO><ConsultaCondicionesDTO><CodigoPais>540</CodigoPais><CodigoProducto>R4</CodigoProducto><CodigoTarifa>0</CodigoTarifa><Anual>false</Anual><Edad>28</Edad><IdTipoPlan>3</IdTipoPlan><IdTipoModalidad>1</IdTipoModalidad><ConsultaPadre><CodigoPais>540</CodigoPais><CodigoProducto>R4</CodigoProducto><CodigoTarifa>0</CodigoTarifa><Anual>false</Anual><Edad>28</Edad><IdTipoPlan>3</IdTipoPlan><IdTipoModalidad>1</IdTipoModalidad></ConsultaPadre></ConsultaCondicionesDTO></Consultas></ConsultasCondicionesDTO>";

            //string XML = "<ConsultasCondicionesDTO><Consultas><ConsultaCondicionesDTO><CodigoPais>540</CodigoPais><CodigoProducto>R3</CodigoProducto><CodigoTarifa>0</CodigoTarifa><Anual>false</Anual><Edad>30</Edad><IdTipoPlan>2</IdTipoPlan><IdTipoModalidad>1</IdTipoModalidad><ConsultaPadre><CodigoPais>540</CodigoPais><CodigoProducto>R3</CodigoProducto><CodigoTarifa>0</CodigoTarifa><Anual>false</Anual><Edad>30</Edad><IdTipoPlan>2</IdTipoPlan><IdTipoModalidad>0</IdTipoModalidad></ConsultaPadre></ConsultaCondicionesDTO><ConsultaCondicionesDTO><CodigoPais>540</CodigoPais><CodigoProducto>R3</CodigoProducto><CodigoTarifa>0</CodigoTarifa><Anual>false</Anual><Edad>30</Edad><IdTipoPlan>2</IdTipoPlan><IdTipoModalidad>1</IdTipoModalidad><ConsultaPadre><CodigoPais>540</CodigoPais><CodigoProducto>R3</CodigoProducto><CodigoTarifa>0</CodigoTarifa><Anual>false</Anual><Edad>30</Edad><IdTipoPlan>2</IdTipoPlan><IdTipoModalidad>0</IdTipoModalidad></ConsultaPadre></ConsultaCondicionesDTO><ConsultaCondicionesDTO><CodigoPais>540</CodigoPais><CodigoProducto>R3</CodigoProducto><CodigoTarifa>0</CodigoTarifa><Anual>false</Anual><Edad>30</Edad><IdTipoPlan>2</IdTipoPlan><IdTipoModalidad>1</IdTipoModalidad><ConsultaPadre><CodigoPais>540</CodigoPais><CodigoProducto>R3</CodigoProducto><CodigoTarifa>0</CodigoTarifa><Anual>false</Anual><Edad>30</Edad><IdTipoPlan>2</IdTipoPlan><IdTipoModalidad>0</IdTipoModalidad></ConsultaPadre></ConsultaCondicionesDTO></Consultas></ConsultasCondicionesDTO>";

            //string XMLRespuesta = ServicioWS.ObtenerComparacionesXml(SerializeObject(Consultas), "", "");
            string XMLRespuesta = ServicioWS.ObtenerClausulasCoincidentesXml(XML, "", "");

            for (int i = 0; i < 2; i++)
            {
            }

        }

        private ConsultaCondicionesDTO ObtenerConsulta(int Pais, string Producto, string Tarifa, string TarifaPadre)
        {
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

            return ConsultaDTO;
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
        
        private String SerializeObject(Object pObject)
        {
            try
            {
                String XmlizedString = null;
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(pObject.GetType());
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                xs.Serialize(xmlTextWriter, pObject);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
                return ConvertXml(XmlizedString);
            }
            catch (Exception e) { System.Console.WriteLine(e); return null; }
        }

        private String ConvertXml(String pXml)
        {
            String pXmlConvertido = pXml;

            pXmlConvertido = pXmlConvertido.Replace('á', 'a');
            pXmlConvertido = pXmlConvertido.Replace('é', 'e');
            pXmlConvertido = pXmlConvertido.Replace('í', 'i');
            pXmlConvertido = pXmlConvertido.Replace('ó', 'o');
            pXmlConvertido = pXmlConvertido.Replace('ú', 'u');
            pXmlConvertido = pXmlConvertido.Replace('ñ', 'n');

            pXmlConvertido = pXmlConvertido.Replace('Á', 'A');
            pXmlConvertido = pXmlConvertido.Replace('É', 'E');
            pXmlConvertido = pXmlConvertido.Replace('Í', 'I');
            pXmlConvertido = pXmlConvertido.Replace('Ó', 'O');
            pXmlConvertido = pXmlConvertido.Replace('Ú', 'U');
            pXmlConvertido = pXmlConvertido.Replace('Ñ', 'N');
            pXmlConvertido = pXmlConvertido.Replace('Ê', 'E');
            pXmlConvertido = pXmlConvertido.Replace('Ã', 'A');
            pXmlConvertido = pXmlConvertido.Replace('Ç', 'C');
            pXmlConvertido = pXmlConvertido.Replace('Ô', 'O');
            pXmlConvertido = pXmlConvertido.Replace('Õ', 'O');

            return pXmlConvertido;
        }

        private String UTF8ByteArrayToString(Byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            String constructedString = encoding.GetString(characters);
            return (constructedString);
        }

    }
}
