using System;
using MiniGames;
using MiniGames.SpaceBattle;
using StateMachine;
using UnityEngine;

namespace SpaceBattle.Enemy
{
    public class Enemy:PoolObject, IDamageable,IDieable
    {
        [SerializeField] private float _health;
        private float _initialHealth;
        [SerializeField] private float _collisionDamage;
        public event Action Died; 
        private Collider2D _collider;
        public void TakeDamage(GameObject damager, float damage)
        {
            if (damager == gameObject) return;
            _health -= damage;
            if (_health <= 0)
            {
                (GameManager.Instance as GameManager).OnEnemyDied();
                Die();
            }
        }

        public void Die()
        {
            _collider.enabled = false;
            Died?.Invoke();
        }

        public override void Activated()
        {
            base.Activated();
            _collider.enabled = true;
            _health = _initialHealth;
        }

        public override void Init()
        {
            GetComponent<StateMachineBase>().Init();
            GetComponent<EnemyAnimator>().Init();
            _collider = GetComponent<Collider2D>();
            _initialHealth = _health;
        }
        

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Player player))
            {
                player.TakeDamage(gameObject,_collisionDamage);
                Die();
            }
        }
    }
}