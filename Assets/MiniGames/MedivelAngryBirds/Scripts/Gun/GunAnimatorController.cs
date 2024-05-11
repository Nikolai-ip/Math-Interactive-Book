using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class GunAnimatorController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;
    [SerializeField] private float _recoilTime =1;
    [SerializeField] private float _backMovementTime =1;
    [SerializeField] private float _recoilXPos;
    private Transform _tr;
    private void Start()
    {
        _tr = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    public void PlayShotAnimation()
    {
        _animator.SetTrigger("Shot");
    }

    public void PlayRecoilAnimation()
    {
        StartCoroutine(RecoilAnimation());
    }

    private IEnumerator RecoilAnimation()
    {
        Vector2 originPos = _tr.position;
        Vector2 target = originPos - (Vector2)_tr.right * _recoilXPos;
        float step = 0;
        while (step < _recoilTime)
        {
            step += Time.deltaTime;
            _tr.position = Vector2.Lerp(originPos, target, step/_recoilTime);
            yield return null;
        }
        step = 0;
        Vector2 _recoilFinalPoint = _tr.position;
        while (step < _backMovementTime)
        {
            step += Time.deltaTime;
            _tr.position = Vector2.Lerp( _recoilFinalPoint, originPos, step/_backMovementTime);
            yield return null;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position-transform.right*_recoilXPos,0.1f);
    }
}
