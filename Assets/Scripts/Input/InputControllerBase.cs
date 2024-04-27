using UnityEngine;

public abstract class InputControllerBase:MonoBehaviour
{
    protected Controls controls;

    protected virtual void Awake()
    {
        controls = new Controls();
    }

    protected virtual void OnEnable()
    {
        controls.Enable();
    }

    protected virtual void OnDisable()
    {
        controls.Disable();            
    }
}
