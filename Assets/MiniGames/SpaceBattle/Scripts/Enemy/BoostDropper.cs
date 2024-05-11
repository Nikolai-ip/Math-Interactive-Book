using System;
using MiniGames;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoostDropper : MonoBehaviour
{
    [SerializeField] private GameObject _boost;
    [SerializeField] private float _chanceDrop;
    private IDieable _dieable;
    private void OnEnable()
    {
        _dieable = GetComponent<IDieable>();
        _dieable.Died += TryDropBoost;
    }

    private void OnDisable()
    {
        _dieable.Died -= TryDropBoost;
    }

    public void TryDropBoost()
    {
        float randValue = Random.Range(0, 100);
        if (randValue <= _chanceDrop)
        {
            DropBoost();
        }
    }

    public void DropBoost()
    {
        Instantiate(_boost, transform.position, new Quaternion());
    }
}
