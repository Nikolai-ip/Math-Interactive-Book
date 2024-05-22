using System;
using System.Collections;
using UnityEngine;

public class UIScaler : MonoBehaviour
{
    private RectTransform _transform;
    [SerializeField] private float _increaseTime;
    [SerializeField] private float _widthScale;
    [SerializeField] private float _heightScale;
    private Vector2 _originSize;
    private void Start()
    {
        _transform = GetComponent<RectTransform>();
        _originSize = _transform.sizeDelta;
    }

    public void SlowIncrease()
    {
        StartCoroutine(SlowChangeScale(_originSize, new Vector2(_originSize.x*_widthScale,_originSize.y*_heightScale)));
    }

    public void SlowShrink()
    {
        StartCoroutine(SlowChangeScale(new Vector2(_originSize.x*_widthScale,_originSize.y*_heightScale), _originSize));
    }
    private IEnumerator SlowChangeScale(Vector2 startScale, Vector2 targetScale)
    {
        var delay = new WaitForFixedUpdate();
        float elapsedTime = 0;
        while (elapsedTime < _increaseTime)
        {
            elapsedTime += Time.deltaTime;
            float currentHeight = Mathf.Lerp(startScale.y, targetScale.y, elapsedTime / _increaseTime);
            float currentWidth = Mathf.Lerp(startScale.x, targetScale.x, elapsedTime / _increaseTime);
            _transform.sizeDelta = new Vector2(currentWidth, currentHeight);
            yield return delay;
        }
    }
    
}
