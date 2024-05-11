using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MiniGames;
using UnityEngine;

public class ProjectileUIAnimator : InitializeableMono
{
    [SerializeField] private List<GameObject> _projectilesUI;
    private ProjectileUIGenerator _generator;
    [SerializeField] private float _liftingHeight;
    [SerializeField] private float _toArivalAnimDuration=1;
    [SerializeField] private float _toGunAnimDuration=1;
    [SerializeField] private Transform _gunTr;
    [SerializeField] private Vector2 _arrivePoint;
    [SerializeField] private float _moveToGunForce;
    private Transform _tr;
    [Range(0, 1)] [SerializeField] private float _animationDurationRatio;
    public override void Init()
    {
        _generator = GetComponent<ProjectileUIGenerator>();
        _tr = GetComponent<Transform>();
        _projectilesUI = _generator.GeneratePilesOfProjectiles();
        transform.localScale = new Vector3(-1, 1, 1);
        PlayReloadAnimation();
    }

    public void StartPlayReloadAnimation(float reloadTime)
    {
        _toArivalAnimDuration = reloadTime * _animationDurationRatio;
        _toGunAnimDuration = reloadTime - _toArivalAnimDuration;
        PlayReloadAnimation();
    }
    private void PlayReloadAnimation()
    {
        var projectile = _projectilesUI.Last();
        StartCoroutine(TranslateProjectileToArrivalPoint(projectile));
        _projectilesUI.Remove(projectile);
    }

    private IEnumerator TranslateProjectileToArrivalPoint(GameObject projectile)
    {
        float elapsedTime = 0;
        Vector2 projectileOriginalPos = projectile.transform.position;
        while (elapsedTime<_toArivalAnimDuration)
        {
            elapsedTime += Time.deltaTime;
            float deltaY = 0;
            if (elapsedTime < _toArivalAnimDuration / 2)
            {
                deltaY = Mathf.Lerp(0, _liftingHeight, elapsedTime / (_toArivalAnimDuration / 2));
            }
            else
            {
                float remainingTime = _toArivalAnimDuration - (_toArivalAnimDuration / 2);
                deltaY = Mathf.Lerp(_liftingHeight, 0, (elapsedTime - (_toArivalAnimDuration / 2)) / remainingTime);
            }
            Vector2 newPos = Vector2.Lerp(projectileOriginalPos, (Vector2)_tr.position+_arrivePoint, elapsedTime / _toArivalAnimDuration);
            newPos = new Vector2(newPos.x, newPos.y + deltaY);
            projectile.transform.position = newPos;
            yield return null;
        }

        StartCoroutine(MoveProjectileToGun(projectile));
    }

    private IEnumerator MoveProjectileToGun(GameObject projectile)
    {
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        Transform projectileTr = projectile.GetComponent<Transform>();
        Vector2 target = new Vector2(_gunTr.position.x, projectileTr.position.y);
        Vector2 originalPos = projectileTr.position;
        float elapsedTime = 0;
        while (elapsedTime<_toGunAnimDuration)
        {
            elapsedTime += Time.deltaTime;
            projectileTr.position = Vector2.Lerp(originalPos, target, elapsedTime / _toGunAnimDuration);
            yield return null;
        }
        Destroy(projectile);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position+_arrivePoint,0.1f);
    }
}
