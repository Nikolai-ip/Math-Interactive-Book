using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Statue : MonoBehaviour
{
    [SerializeField] private float _shotInterval;
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private float _projectileDamage;
    [SerializeField] private float _startShootDelay;
    private Vector2 _shotDirection;
    private Transform _tr;
    [SerializeField] private ProjectilesContainer _projectilesContainer;
    [SerializeField] private Transform _rightShotPoint;
    [SerializeField] private Transform _leftShotPoint;
    public UnityEvent Shoted;
    private void Start()
    {
        _tr = GetComponent<Transform>();
        _projectilesContainer = FindObjectOfType<ProjectilesContainer>();
        Invoke(nameof(StartShot),_startShootDelay);
    }

    private void StartShot()
    {
        StartCoroutine(ShotCoroutine());
    }
    private IEnumerator ShotCoroutine()
    {
        var delay = new WaitForSeconds(_shotInterval);
        while (true)
        {
            Shot(_rightShotPoint.position);
            Shot(_leftShotPoint.position);
            yield return delay;
        }

    }

    private void Shot(Vector2 shootPoint)
    {
        var rotationAngle = _tr.eulerAngles.z * Mathf.Deg2Rad;
        Vector2 shotDir = new Vector2((float)Math.Cos(rotationAngle), (float)Math.Sin(rotationAngle)).normalized;
        var projectile =   _projectilesContainer.GetProjectile();
        projectile.SetPosition(shootPoint)
            .StartMove(shotDir,_projectileSpeed)
            .SetDamage(_projectileDamage)
            .transform.Rotate(transform.forward*_tr.eulerAngles.z);
        Shoted.Invoke();
    }
}
