using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent OnTrigger;
    [SerializeField] private string _tagObjectActivated;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(_tagObjectActivated))
        {
            OnTrigger.Invoke();
        }
    }
}
