namespace XcaInteropService.Commons.Models.Hl7.V2
{
    public class SubComponent : MessageElement
    {
        public SubComponent(string val, HL7Encoding encoding)
        {
            Encoding = encoding;
            Value = val;
        }

        protected override void ProcessValue()
        {
        }
    }
}
