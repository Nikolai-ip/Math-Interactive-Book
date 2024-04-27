using System;
using ReactiveData;

namespace Test
{
    public interface IBindingData<out TArgs>: IBindingData where TArgs:Property 
    {
        public event Action<TArgs> PropertyChanged;
    }

    public interface IBindingData
    {
        public string Name { get; protected set; }
    }
}