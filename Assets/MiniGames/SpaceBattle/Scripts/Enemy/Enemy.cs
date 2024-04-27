using MiniGames;
using UnityEngine;

namespace SpaceBattle.Enemy
{
    public class Enemy:MonoBehaviour, IDamageable
    {
        [SerializeField] private float _health;
        public void TakeDamage(GameObject damager, float damage)
        {
            if (damager == gameObject) return;
            _health -= damage;
            if (_health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            
        }
        
    }
}