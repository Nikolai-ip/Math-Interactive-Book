using UnityEngine;
using UnityEngine.Events;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] private int _initialCountOfEnemies;
    private int _currentCountOfEnemies;
    [SerializeField] private UnityEvent<object,object> CountOfEnemiesChanged;
    [SerializeField] private UnityEvent EnemiesRunOut;
    private void Start()
    {
        _initialCountOfEnemies = FindObjectsOfType<EnemyCollisionController>().Length;
        _currentCountOfEnemies = _initialCountOfEnemies;
        CountOfEnemiesChanged.Invoke(_currentCountOfEnemies,_initialCountOfEnemies);
    }

    public void OnEnemyDied()
    {
        _currentCountOfEnemies--;
        _currentCountOfEnemies = Mathf.Clamp(_currentCountOfEnemies, 0, _initialCountOfEnemies);
        if (_currentCountOfEnemies == 0)
            EnemiesRunOut.Invoke();
        CountOfEnemiesChanged.Invoke(_currentCountOfEnemies,_initialCountOfEnemies);
    }
}
