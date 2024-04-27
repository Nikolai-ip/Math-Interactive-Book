using System;
using ReactiveData;
using TMPro;
using UnityEngine;

namespace Test
{
    public class InputFieldBindingData : MonoBehaviour, IBindingData<StringProp>
    {
        public string Text
        {
            get => _text;
            private set
            {
                _text = value;
                PropertyChanged?.Invoke(new StringProp(value));
            } 
        }
        

        [SerializeField] private TMP_InputField _inputFiled;
        [SerializeField] private string _name;
        private string _text;
        public void ValueChanged()
        {
            Text = _inputFiled.text;
        }

        public event Action<StringProp> PropertyChanged;
        
        string IBindingData.Name
        {
            get => _name;
            set => _name = value;
        }
    }
}