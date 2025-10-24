using XcaInteropService.Commons.Models.Hl7.V3;
using XcaInteropService.Commons.Serializers;

namespace XcaInteropService.Tests;

public class UnitTests_Functionalities
{
    [Fact]
    public void SerializeDeserializeITI44()
    {
        var testData = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..","XcaInteropService.Tests","TestData");

        var files = Directory.GetFiles(testData);

        var iti44Request = File.ReadAllText(files.FirstOrDefault(f => f.Contains("iti44-request.xml")));
        var iti44ResponseAck = File.ReadAllText(files.FirstOrDefault(f => f.Contains("iti44-request-ack.xml")));

        var sxmls = new SoapXmlSerializer();
        var iti44 = sxmls.DeserializeXmlString<PRPA_IN201301UV02_AddNewPatient>(iti44Request);
        var iti44StringAgain = sxmls.SerializeToXmlString(iti44).Content;

        var iti44Ack = sxmls.DeserializeXmlString<MCCI_IN000002UV01_Acknowledgement>(iti44ResponseAck);
        var iti44AckStringAgain = sxmls.SerializeToXmlString(iti44Ack).Content;
    }
}