using System;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveArea : MonoBehaviour
{
    [SerializeField] protected CoordinateSystem CoordinateSystem;
    [SerializeField] protected UnityEvent<object> VectorChanged;
    [SerializeField] protected MousePosTranslator PosTranslator;
    
    public virtual void Enable()
    {
        enabled = true;
    }

    public virtual void Disable()
    {
        enabled = false;
    }
}
