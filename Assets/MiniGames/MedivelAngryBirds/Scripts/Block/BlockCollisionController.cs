using System;
using MiniGames.MedivelAngryBirds.Scripts.Block;
using UnityEngine;

public class BlockCollisionController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private BlockDivider _blockDivider;
    private float _velocityMagnitude;
    [SerializeField] private float _updateFrequencyMagnitude;
    private float _elapsedTime;
    [SerializeField] private DistanceJoint2D _distanceJoint;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _blockDivider = GetComponent<BlockDivider>();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > _updateFrequencyMagnitude)
        {
            _elapsedTime = 0;
            _velocityMagnitude = _rb.velocity.magnitude;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        float hiterMagnitude = 0;
        if (other.collider.TryGetComponent(out Rigidbody2D hiter))
        {
            hiterMagnitude = hiter.velocity.magnitude;
        }
        float hitForce = _velocityMagnitude + hiterMagnitude;
        _blockDivider.HandleHitForce(hitForce);
    }
}
