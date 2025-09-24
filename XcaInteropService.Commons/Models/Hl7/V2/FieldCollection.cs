namespace XcaInteropService.Commons.Models.Hl7.V2
{
    internal sealed class FieldCollection : List<Field>
    {
        internal new Field this[int index]
        {
            get
            {
                Field field = null;

                if (index < Count)
                    field = base[index];

                return field;
            }
            set
            {
                base[index] = value;
            }
        }

        /// <summary>
        /// Add field at next position
        /// </summary>
        /// <param name="field">Field</param>
        internal new void Add(Field field)
        {
            base.Add(field);
        }

        /// <summary>
        /// Add field at specific position
        /// </summary>
        /// <param name="field">Field</param>
        /// <param name="position">position</param>
        internal void Add(Field field, int position)
        {
            int listCount = Count;

            if (position < listCount)
            {
                base[position] = field;
            }
            else
            {
                for (int fieldIndex = listCount; fieldIndex < position; fieldIndex++)
                {
                    Field blankField = new Field(string.Empty, field.Encoding);
                    base.Add(blankField);
                }

                base.Add(field);
            }
        }
    }
}
