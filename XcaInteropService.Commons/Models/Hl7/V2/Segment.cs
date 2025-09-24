using System.Text;

namespace XcaInteropService.Commons.Models.Hl7.V2
{
    public class Segment : MessageElement
    {
        internal FieldCollection FieldList { get; set; }
        internal int SequenceNo { get; set; }

        public string Name { get; set; }

        public Segment(HL7Encoding encoding)
        {
            FieldList = new FieldCollection();
            Encoding = encoding;
        }

        public Segment(string name, HL7Encoding encoding)
        {
            FieldList = new FieldCollection();
            Name = name;
            Encoding = encoding;
        }

        protected override void ProcessValue()
        {
            var allFields = _value.Split(Encoding.FieldDelimiter);

            for (int i = 1; i < allFields.Length; i++)
            {
                string strField = allFields[i];
                Field field = new Field(Encoding);

                if (Name == "MSH" && i == 1)
                    field.IsDelimitersField = true; // special case

                field.Value = strField;
                FieldList.Add(field);
            }

            if (Name == "MSH")
            {
                var field1 = new Field(Encoding);
                field1.IsDelimitersField = true;
                field1.Value = Encoding.FieldDelimiter.ToString();

                FieldList.Insert(0, field1);
            }
        }

        public Segment DeepCopy()
        {
            var newSegment = new Segment(Name, Encoding);
            newSegment.Value = Value;

            return newSegment;
        }

        public void AddEmptyField()
        {
            AddNewField(string.Empty);
        }

        public void AddNewField(string content, int position = -1)
        {
            AddNewField(new Field(content, Encoding), position);
        }

        public void AddNewField(string content, bool isDelimiters)
        {
            var newField = new Field(Encoding);

            if (isDelimiters)
                newField.IsDelimitersField = true; // Prevent decoding

            newField.Value = content;
            AddNewField(newField, -1);
        }

        public bool AddNewField(Field field, int position = -1)
        {
            try
            {
                if (position < 0)
                {
                    FieldList.Add(field);
                }
                else
                {
                    position--;
                    FieldList.Add(field, position);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new HL7Exception("Unable to add new field in segment " + Name + " Error - " + ex.Message, ex);
            }
        }

        public Field Fields(int position)
        {
            position--;

            try
            {
                return FieldList[position];
            }
            catch (Exception ex)
            {
                throw new HL7Exception("Field not available Error - " + ex.Message, ex);
            }
        }

        public List<Field> GetAllFields()
        {
            return FieldList;
        }

        public int GetSequenceNo()
        {
            return SequenceNo;
        }

        /// <summary>
        /// Serializes a segment into a string with proper encoding
        /// </summary>
        /// <param name="strMessage">A StringBuilder to write on</param>
        public void SerializeSegment(StringBuilder strMessage)
        {
            strMessage.Append(Name);

            if (FieldList.Count > 0)
                strMessage.Append(Encoding.FieldDelimiter);

            int startField = Name == "MSH" ? 1 : 0;

            for (int i = startField; i < FieldList.Count; i++)
            {
                if (i > startField)
                    strMessage.Append(Encoding.FieldDelimiter);

                var field = FieldList[i];

                if (field.IsDelimitersField)
                {
                    strMessage.Append(field.UndecodedValue);
                    continue;
                }

                if (field.HasRepetitions)
                {
                    for (int j = 0; j < field.RepetitionList.Count; j++)
                    {
                        if (j > 0)
                            strMessage.Append(Encoding.RepeatDelimiter);

                        field.RepetitionList[j].SerializeField(strMessage);
                    }
                }
                else
                {
                    field.SerializeField(strMessage);
                }
            }

            strMessage.Append(Encoding.SegmentDelimiter);
        }
    }
}
