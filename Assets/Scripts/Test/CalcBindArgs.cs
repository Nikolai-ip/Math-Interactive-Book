using ViewModelEventArgs;

namespace Test
{
    public class CalcBindArgs:IBindArgs
    {
        public string FirstValue { get; set; }
        public string SecondValue { get; set; }
        public string Sign { get; set; }
        public override string ToString()
        {
            return FirstValue + " " +  SecondValue + " " + Sign;
        }
    }
}