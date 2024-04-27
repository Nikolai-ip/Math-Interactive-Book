using System;
using UnityEngine;

namespace Test
{
    public class ButtonBindingData:MonoBehaviour, IBindingData<NullProp>
    {
        [SerializeField] private string _name;
        public event Action<NullProp> PropertyChanged;

        public void OnButtonClicked()
        {
            PropertyChanged?.Invoke(new NullProp());
        }

        string IBindingData.Name
        {
            get => _name;
            set => _name = value;
        }
    }
}