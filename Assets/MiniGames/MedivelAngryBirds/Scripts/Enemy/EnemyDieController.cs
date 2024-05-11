using System;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDieController : MonoBehaviour
{
   [SerializeField] private UnityEvent Died;
   private EnemyCounter _enemyCounter;

   private void Start()
   {
      _enemyCounter = FindObjectOfType<EnemyCounter>();
   }

   public void Die()
   {
      Died.Invoke();
      _enemyCounter.OnEnemyDied();
   }
    
}