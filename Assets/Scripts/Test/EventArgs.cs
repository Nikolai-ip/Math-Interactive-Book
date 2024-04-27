using ViewModelEventArgs;

namespace Test
{
    public class EventArgs:IBindArgs
    {
        public int A { get;}
        public int B { get;}

        public EventArgs(int a, int b)
        {
            A = a;
            B = b;
        }
    }
}