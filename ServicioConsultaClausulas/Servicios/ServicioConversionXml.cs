using System.Text;
using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

public class ServicioConversionXml
{
    #region Singleton

    private static ServicioConversionXml _Instancia;

    private ServicioConversionXml()
    {
    }

    public static ServicioConversionXml Instancia()
    {
        if (_Instancia == null)
        {
            _Instancia = new ServicioConversionXml();
        }
        return _Instancia;
    }

    #endregion

    private String UTF8ByteArrayToString(Byte[] characters)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        String constructedString = encoding.GetString(characters);
        return (constructedString);
    }

    private Byte[] StringToUTF8ByteArray(String pXmlString)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        Byte[] byteArray = encoding.GetBytes(pXmlString);
        return byteArray;
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

    public String SerializeObject(Object pObject)
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

    public Object DeserializeObject(String pXmlizedString, Type pType)
    {
        XmlSerializer xs = new XmlSerializer(pType);
        MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(pXmlizedString));
        XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
        return xs.Deserialize(memoryStream);
    } 
}