using MiniGames;
using UnityEngine;

public class SpaceProjectile:Projectile,IDamageable
{
    public void TakeDamage(GameObject damager, float damage)
    {
        StartDeactivated();
    }
}