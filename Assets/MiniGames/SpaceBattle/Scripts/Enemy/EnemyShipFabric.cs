using System;
using System.Collections;
using System.Collections.Generic;
using MiniGames;
using SpaceBattle;
using SpaceBattle.Enemy;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyShipFabric : InitializeableMono
{
    private List<PoolMono<Enemy>> _enemiesPools = new();
    [SerializeField] private ProjectilesContainer _projectilesContainer;
    [SerializeField] private List<Enemy> _enemyTypes;
    [SerializeField] private int _capacity;
    [SerializeField] private bool _autoExpand;
    [SerializeField] private float _initializationRange;
    [SerializeField] private float _initializationInterval;
    [SerializeField] private int _countOfInitializations;
    public override void Init()
    {
        foreach (var enemyType in _enemyTypes)
        {
            enemyType.GetComponent<DoubleShotController>().SetProjectilesContainer(_projectilesContainer);
            var poolObjectName = enemyType.name + "Pool";
            var poolObject = new GameObject(poolObjectName);
            poolObject.transform.SetParent(transform);
            var pool = new PoolMono<Enemy>(enemyType, _capacity, poolObject.transform);
            pool.AutoExpand = _autoExpand;
            _enemiesPools.Add( pool);
            foreach (var enemyPool in _enemiesPools)
            {
                foreach (var enemy in enemyPool)
                {
                    enemy.Init();
                }
            }
            StartCoroutine(InitEnemyCoroutine());
        }

    }

    private IEnumerator InitEnemyCoroutine()
    {
        var delay = new WaitForSeconds(_initializationInterval);
        while (true)
        {
            for (int i = 0; i < _countOfInitializations; i++)
            {
                Enemy enemy = GetRandomEnemy();
                float angle = Random.Range(0, 360) * Mathf.Deg2Rad;
                Vector2 position = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle))*_initializationRange;
                enemy.transform.position = position;
            }
            yield return delay;
        }
    }

    public void StopCreateEnemies()
    {
        StopAllCoroutines();
    }
    private Enemy GetRandomEnemy()
    {
        int randomEnemyType = Random.Range(0, _enemiesPools.Count);
        return _enemiesPools[randomEnemyType].GetFreeElement();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position,_initializationRange);
    }
}
