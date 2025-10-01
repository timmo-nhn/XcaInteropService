using System.Text;
using System.Xml;
using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Extensions;
using XcaInteropService.Commons.Models.Soap;

namespace XcaInteropService.Commons.Serializers;

public enum XmlSettings
{
    Soap
}

public class SoapXmlSerializerResult
{
    public string? Content { get; set; }
    public bool IsSuccess { get; set; }
}


/// <summary>
/// Works as a generic XML Serializer, but returns a SOAP-envelope as a serialization result
/// </summary>
public class SoapXmlSerializer
{
    private XmlWriterSettings? _xmlWriterSettings;
    public SoapXmlSerializer(XmlWriterSettings xmlSettings)
    {
        _xmlWriterSettings = xmlSettings;
    }

    public SoapXmlSerializer(XmlSettings xmlSettings)
    {
        _xmlWriterSettings = new XmlWriterSettings() { Indent = true, Encoding = Encoding.UTF8, OmitXmlDeclaration = true };
    }
    public SoapXmlSerializer()
    {

    }

    public T DeserializeXmlString<T>(string xmlString)
    {
        var byteArray = Encoding.UTF8.GetBytes(xmlString);
        var memStream = new MemoryStream(byteArray);
        return DeserializeSoapMessage<T>(memStream);
    }

    public T DeserializeSoapMessage<T>(Stream xmlStream)
    {
        var serializer = new XmlSerializer(typeof(T));

        using (var streamReader = new StreamReader(xmlStream))
        {
            var xmlContent = streamReader.ReadToEnd();

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlContent);

            // Having a "type" attribute on the <Body> tag causes an exception when deserializing
            // <s:Body p7:type="RegistryStoredQueryRequest" xmlns:p7="http://www.w3.org/2001/XMLSchema-instance">
            // so strip it away before deserializing, as its not used
            var namespaceManager = new XmlNamespaceManager(xmlDoc.NameTable);
            namespaceManager.AddNamespace("s", Constants.Soap.Namespaces.SoapEnvelope);
            namespaceManager.AddNamespace("p7", Constants.Soap.Namespaces.Xsi);
            namespaceManager.AddNamespace("lcm", Constants.Soap.Namespaces.Lcm);
            namespaceManager.AddNamespace("rim", Constants.Soap.Namespaces.Rim);

            var bodyElement = xmlDoc.SelectSingleNode("//s:Body", namespaceManager);


            if (bodyElement == null)
            {
                bodyElement = xmlDoc.SelectSingleNode("//Body");
            }

            if (bodyElement != null && bodyElement.Attributes?["type", "http://www.w3.org/2001/XMLSchema-instance"] != null)
            {
                bodyElement.Attributes.RemoveNamedItem("type", "http://www.w3.org/2001/XMLSchema-instance");
            }

            var modifiedXmlContent = xmlDoc.OuterXml;

            if (string.IsNullOrWhiteSpace(modifiedXmlContent))
                throw new ArgumentException("XML content cannot be null or whitespace.", nameof(modifiedXmlContent));


            using (var stringReader = new StringReader(modifiedXmlContent))
            {
                var result = serializer.Deserialize(stringReader);
                return result is T typedResult
                    ? typedResult
                    : throw new InvalidOperationException($"Deserialized object is not of type {typeof(T).FullName}.");
            }
        }
    }

    public SoapXmlSerializerResult SerializeToXmlString(object soapElement, XmlWriterSettings? settings = null)
    {
        if (soapElement == null) throw new ArgumentNullException(nameof(soapElement));

        settings ??= _xmlWriterSettings;
        var serializer = new XmlSerializer(soapElement.GetType());

        try
        {
            using (var stringWriter = new StringWriter())
            using (var writer = XmlWriter.Create(stringWriter, settings))
            {
                serializer.Serialize(writer, soapElement);
                return new SoapXmlSerializerResult() { Content = stringWriter.ToString(), IsSuccess = true };
            }
        }
        catch (Exception ex)
        {
            var soapFault = SoapExtensions.CreateSoapFault("Serialization Error", faultReason: ex.Message, detail: ex.InnerException?.Message);

            try
            {
                var faultSerializer = new XmlSerializer(soapFault.Value!.GetType());

                using (var stringWriter = new StringWriter())
                using (var writer = XmlWriter.Create(stringWriter, settings))
                {
                    faultSerializer.Serialize(writer, soapFault.Value);
                    return new SoapXmlSerializerResult() { Content = stringWriter.ToString(), IsSuccess = false };
                }
            }
            catch
            {
                return new SoapXmlSerializerResult()
                {
                    Content = $"<SoapFault><Reason>Serialization Failed {ex.ToString()}</Reason></SoapFault>",
                    IsSuccess = false
                };
            }
        }
    }
}
