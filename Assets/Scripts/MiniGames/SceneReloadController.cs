using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniGames
{
    public class SceneReloadController:MonoBehaviour
    {
        [SerializeField] private float _delay;
        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void ReloadSceneByDelay()
        {
            Invoke(nameof(ReloadScene),_delay);
        }
    }
}