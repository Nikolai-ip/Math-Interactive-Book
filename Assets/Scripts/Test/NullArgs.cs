using ReactiveData;

namespace Test
{
    public class NullProp:Property
    {
        public override object GetValue()
        {
            return null;
        }
    }
}