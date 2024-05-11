using System;
using SpaceBattle;
using UnityEngine;

public class HealBoost : MonoBehaviour
{
    [SerializeField] private float _helath;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerShip player))
        {
            player.TakeDamage(gameObject, -_helath);
            Destroy(gameObject);
        }
    }


}
