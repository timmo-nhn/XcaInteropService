namespace XcaInteropService.Commons.Models.Hl7.V2
{
    public class Component : MessageElement
    {
        internal List<SubComponent> SubComponentList { get; set; }

        public bool IsSubComponentized { get; set; } = false;

        private bool isDelimiter = false;

        public Component(HL7Encoding encoding, bool isDelimiter = false)
        {
            this.isDelimiter = isDelimiter;
            SubComponentList = new List<SubComponent>();
            Encoding = encoding;
        }

        public Component(string pValue, HL7Encoding encoding)
        {
            SubComponentList = new List<SubComponent>();
            Encoding = encoding;
            Value = pValue;
        }

        protected override void ProcessValue()
        {
            string[] allSubComponents;

            if (isDelimiter)
                allSubComponents = [Value];
            else
                allSubComponents = _value.Split(Encoding.SubComponentDelimiter);

            if (allSubComponents.Length > 1)
                IsSubComponentized = true;

            SubComponentList.Clear(); // in case there's existing data in there
            SubComponentList.Capacity = allSubComponents.Length;

            foreach (string strSubComponent in allSubComponents)
            {
                SubComponent subComponent = new SubComponent(strSubComponent, Encoding);
                SubComponentList.Add(subComponent);
            }
        }

        public SubComponent SubComponents(int position)
        {
            position--;

            try
            {
                return SubComponentList[position];
            }
            catch (Exception ex)
            {
                throw new HL7Exception("SubComponent not available Error-" + ex.Message, ex);
            }
        }

        public List<SubComponent> SubComponents()
        {
            return SubComponentList;
        }
    }
}