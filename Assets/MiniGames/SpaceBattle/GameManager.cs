using MiniGames.ServiceLocatorModule;
using SpaceBattle.Enemy;
using UnityEngine;
using UnityEngine.Events;

namespace MiniGames.SpaceBattle
{
    public class GameManager:GameManagerBase
    {
        [SerializeField] private bool _stopGameOnAwake;
        [SerializeField] private int _countOfEnemyForWin;
        private int _currentCountOfEnemy;
        [SerializeField] private UnityEvent GameWon;
        
        private int CurrentCountOfEnemy
        {
            get => _currentCountOfEnemy;
            set
            {
                _currentCountOfEnemy = value;
                _currentCountOfEnemy = Mathf.Max(0, _currentCountOfEnemy);
                _scoreViewController.OnValueChanged(_currentCountOfEnemy.ToString(),_countOfEnemyForWin.ToString());
            }
        }
        [SerializeField] private ScoreViewController _scoreViewController;
        public override void Init()
        {
            bool isFirstLaunch = IsFirstLaunchGame();
            base.Init();
            if (_stopGameOnAwake && isFirstLaunch)
            {
                _stopGameOnAwake = false;
                ServiceLocator.Get<PauseGameController>().PauseGame();
            }
            CurrentCountOfEnemy = _countOfEnemyForWin;
        }

        public void OnEnemyDied()
        {
            CurrentCountOfEnemy--;
            if (CurrentCountOfEnemy == 0)
                Win();
        }

        private void Win()
        {
            GameWon.Invoke();
            FindObjectOfType<EnemyShipFabric>().StopCreateEnemies();

            foreach (var enemy in FindObjectsOfType<Enemy>())
            {
                enemy.Die();
            }
        }
    }
}