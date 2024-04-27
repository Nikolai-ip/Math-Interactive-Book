using MiniGames;
using UnityEngine;

namespace SpaceBattle
{
    public class Player:MonoBehaviour, IDamageable
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