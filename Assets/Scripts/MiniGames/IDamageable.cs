using UnityEngine;

namespace MiniGames
{
    public interface IDamageable
    {
        void TakeDamage(GameObject damager, float damage);
    }
}