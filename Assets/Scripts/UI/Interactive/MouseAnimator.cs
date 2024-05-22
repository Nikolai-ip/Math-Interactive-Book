using System;
using System.Collections;
using UnityEngine;

public class MouseAnimator : MonoBehaviour
{
    private Transform _tr;
    private float _elapsedTime = 0;
    private float _originLocalY;
    [Header("ShakeAnimation")] 
    [SerializeField] private float _amplitudeX;
    [SerializeField] private float _animationDuration;
    [SerializeField] private float _intervalAnimation;
    [SerializeField] private int _countOfShake;
    [SerializeField] private bool _startPlay;
    private void Start()
    {
        _tr = GetComponent<Transform>();
        _originLocalY = _tr.localPosition.y;
        if (_startPlay)
            StartCoroutine(PlayShakeAnimation());
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > _intervalAnimation)
        {
            _elapsedTime = 0;
            StartCoroutine(PlayShakeAnimation());
        }
        _tr.localPosition = new Vector3(_tr.localPosition.x, _originLocalY);
    }
    public IEnumerator PlayShakeAnimation()
    {
        Vector3 originalPosition = _tr.position;
        Vector3 leftPosition = new Vector3(originalPosition.x - _amplitudeX, originalPosition.y, originalPosition.z);
        Vector3 rightPosition = new Vector3(originalPosition.x + _amplitudeX, originalPosition.y, originalPosition.z);
        for (int i = 0; i < _countOfShake; i++)
        {
            Vector3 targetPosition = i % 2 == 0 ? leftPosition : rightPosition;
            yield return MoveToPosition(targetPosition);
            _tr.localPosition = new Vector3(_tr.localPosition.x, _originLocalY);
            yield return MoveToPosition(originalPosition);
        }
        _tr.position = originalPosition;
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        Vector3 startPosition = _tr.position;
        float elapsedTime = 0f;

        while (elapsedTime < _animationDuration)
        {
            _tr.position = Vector3.Lerp(startPosition, new Vector3(targetPosition.x,_tr.position.y), elapsedTime / _animationDuration);
            _tr.localPosition = new Vector3(_tr.localPosition.x, _originLocalY);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        _tr.position = targetPosition;
        
    }
    
    private void OnDrawGizmos()
    {
        Vector3 originalPosition = transform.position;
        Gizmos.DrawWireSphere(new Vector3(originalPosition.x+(-_amplitudeX),originalPosition.y),0.1f);
        Gizmos.DrawWireSphere(new Vector3(originalPosition.x+(_amplitudeX),originalPosition.y),0.1f);
    }
}
