    using System;
using UnityEngine;
using UnityEngine.Events;

public class GunShotController : MonoBehaviour
{
    private ProjectilesContainer _projectilesContainer;
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private Transform _gunTr;
    [SerializeField] private float _projectileForce;
    [SerializeField] private UnityEvent Shoted;
    [SerializeField] private float _shotInterval;
    private float _elapsedTime = 0;
    private bool _canShot = true;
    [SerializeField] private UnityEvent<float> GunReloadStarted;
    private void Start()
    {
        _projectilesContainer = FindObjectOfType<ProjectilesContainer>();
    }

    private void Update()
    {
        if (!_canShot)
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime > _shotInterval)
            {
                _elapsedTime = 0;
                _canShot = true;
            }
        }
    }

    public void Shot()
    {
        if (!_canShot) return;
        _canShot = false;
        var projectile = _projectilesContainer.GetProjectile();
        if (projectile != null)
        {
            projectile.SetPosition(_shotPoint.position)
                .StartMoveByForce(_gunTr.right,_projectileForce)
                .transform.Rotate(transform.forward*_gunTr.eulerAngles.z);
            Shoted.Invoke();
            GunReloadStarted.Invoke(_shotInterval);
        }
    }
}
