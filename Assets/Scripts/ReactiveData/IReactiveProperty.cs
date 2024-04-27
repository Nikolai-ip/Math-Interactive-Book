using System;

namespace ReactiveData
{
    public interface IReactiveProperty<out T> where T:Property
    {
        public event Action<T> PropertyChanged;
        public T Value { get; }
    }
}