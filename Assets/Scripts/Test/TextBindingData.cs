using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ReactiveData;
using TMPro;
using UnityEngine;

namespace Test
{
    public class TextBindingData:MonoBehaviour
    {
        [SerializeField] private TMP_Text _textUI;
        [SerializeField] private CalcVM _viewModel;
        [SerializeField] private List<string> _bindingReactivePropertyNames;
        private void Start()
        {
            PropertyInfo[] _reactiveProperties = _viewModel.GetType().GetProperties()
                .Where(m => m.GetCustomAttributes(typeof(ReactiveProp), true).Length > 0).ToArray();
            MethodInfo[] methods = GetType().GetMethods()
                .Where(m => m.GetCustomAttributes(typeof(BindingAction), true).Length > 0).ToArray();
            foreach (var propertyName in _bindingReactivePropertyNames)
            {
                PropertyInfo reactivePropertyInfo = _reactiveProperties.First(prop => prop.Name == propertyName);
                object reactivePropertyObj = reactivePropertyInfo.GetValue(_viewModel);
                
                if (reactivePropertyObj is IReactiveProperty<Property> reactiveProperty)
                {
                    string bindingActionName = "On" + propertyName;
                    var bindingAction = methods.First(methods => methods.Name ==bindingActionName);
                    Action<Property> action = (Action<Property>)Delegate.CreateDelegate(typeof(Action<Property>), this, bindingAction);
                    reactiveProperty.PropertyChanged += action;
                }

            }
        }
        [BindingAction]
        private void OnResult(Property property)
        {
            if (property is StringProp resultText)
            {
                _textUI.text = "Result: " + resultText.Value;
            }
        }

    }
}