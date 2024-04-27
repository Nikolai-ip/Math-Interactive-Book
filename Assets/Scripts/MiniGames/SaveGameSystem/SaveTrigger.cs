using MiniGames.ServiceLocatorModule;
using UnityEngine;
using UnityEngine.Events;

namespace MiniGames.SaveGameSystem
{
    public class SaveTrigger:MonoBehaviour
    {
        public UnityEvent Triggered;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out ISaveableEntityTrigger saveableEntity))
            {
                Triggered.Invoke();
                gameObject.SetActive(false);
                ServiceLocator.Get<ISaver>().SaveGame();
            }
        }
    }
}