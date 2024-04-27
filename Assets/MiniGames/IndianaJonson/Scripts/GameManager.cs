using MiniGames.AudioSystem;
using MiniGames.ServiceLocatorModule;
using UnityEngine;

namespace MiniGames.IndianaJonson.Scripts
{
    public class GameManager:GameManagerBase
    {
        [SerializeField] private CameraFollow _cameraFollow;
        [SerializeField] private float _loseDuration;
        private IndianaInputController _inputController;
        private Player _player;
        public override void Init()
        {
            base.Init();
            _player = FindObjectOfType<Player>();
            _inputController = FindObjectOfType<IndianaInputController>();
            ServiceLocator.Get<AudioService>().PlaySound("BackGround").SetLoop("BackGround",true);
        }

        public void Lose()
        {
            _cameraFollow.ResetTarget();
            _inputController.enabled = false;
            Invoke(nameof(RestartGame),_loseDuration);
        }

        public void RestartGame()
        {
            _player.Reborn();
            _cameraFollow.SetTarget(_player.gameObject);
            _inputController.enabled = true;
            ServiceLocator.Get<ISaver>().LoadGame();
        }

        public static GameManager GetInstance()
        {
            return Instance as GameManager;
        }
        
    }
}