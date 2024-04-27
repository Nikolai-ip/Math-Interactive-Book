using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ReactiveData;
using Test;
using UnityEngine;

namespace Abstract.ViewModel
{
    public abstract class ViewModel:MonoBehaviour
    {
        [SerializeField] protected List<MonoBehaviour> _dataBindingObjects;
        protected List<IBindingData<Property>> _bindings = new();
        [SerializeField] protected List<MonoBehaviour> _VMtoViewDataBindingObjects;
        public virtual void Start()
        {
            AddBindingsFromMonoBehaviours();
            BindViewToMethods();
        }

        private void AddBindingsFromMonoBehaviours()
        {
            foreach (var dataBindingObject in _dataBindingObjects)
            {
                IBindingData<Property> binding = (IBindingData<Property>) dataBindingObject.GetComponent<IBindingData>();
                if (binding!=null)
                    _bindings.Add(binding);
                else
                    Debug.LogAssertion("Failed get bindingData component from the: " + dataBindingObject.name);
            }
        }
        private void BindViewToMethods()
        {  
            MethodInfo[] methods =  GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(m => m.GetCustomAttributes(typeof(BindingAction), true).Length > 0).ToArray();
            foreach (var method in methods)
            {
                string propName = method.Name.Remove(0,"On".Length);
                Action<Property> action = (Action<Property>)Delegate.CreateDelegate(typeof(Action<Property>), this, method);
                var bindingData = _bindings.Find(bindProp => bindProp.Name == propName);
                if (bindingData!=null)
                {
                    bindingData.PropertyChanged += action;
                }
                else
                {
                    Debug.LogAssertion("Failed bind the data by name: " + propName);
                }
            }
        }

        private void BindVMPropsToView()
        {
            PropertyInfo[] properties = GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var dataBindingObject in _VMtoViewDataBindingObjects)
            {
                
            }
            
        }

    }
}