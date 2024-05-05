using UnityEngine;

namespace MiniGames
{
    public class HideObjectController : MonoBehaviour
    {
        [SerializeField] private GameObject[] _hideObjects;

        public void HideObjects()
        {
            SetOpacityObjects(false);
        }

        public void ShowObjects()
        {
            SetOpacityObjects(true);
        }

        public void SetOpacityObjects(bool isActive)
        {
            foreach (var spriteRenderer in _hideObjects)
            {
                spriteRenderer.SetActive(isActive);
            }
        }
    }
}

