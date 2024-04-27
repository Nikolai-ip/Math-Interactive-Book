using System;

namespace ReactiveData
{
    public class StringReactiveProperty:IReactiveProperty<StringProp>
    {
        public event Action<StringProp> PropertyChanged;
        private StringProp _value;
        public StringProp Value
        {
            get => _value;
            set
            {
                _value = value;
                PropertyChanged?.Invoke(_value);
            }
        }
    }
}