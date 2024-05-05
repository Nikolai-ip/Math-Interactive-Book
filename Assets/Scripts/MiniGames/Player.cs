using UnityEngine;
using UnityEngine.Events;

namespace MiniGames
{
    public class Player:MonoBehaviour, IDamageable
    {
        [SerializeField] protected float health;
        [SerializeField] protected UnityEvent Dead;
        [SerializeField] protected UnityEvent<float> HealthCnaged;
        protected float maxHealth;

        protected virtual void Start()
        {
            maxHealth = health;
        }

        public void TakeDamage(GameObject damager, float damage)
        {
            if (damager == gameObject) return;
            health -= damage;
            HealthCnaged.Invoke(health/maxHealth);
            if (health <= 0)
            {
                Die();
            }
        }

        protected virtual void Die()
        {
            Dead.Invoke();
        }
    }
}