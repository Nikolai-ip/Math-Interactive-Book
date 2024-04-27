namespace ReactiveData
{
    public class StringProp:Property
    {
        public string Value { get; set; }

        public StringProp(string value)
        {
            Value = value;
        }
        public override object GetValue()
        {
            return Value;
        }
    }
}