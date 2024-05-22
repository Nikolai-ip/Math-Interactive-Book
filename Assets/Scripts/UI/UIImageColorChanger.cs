using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIImageColorChanger : MonoBehaviour
{
    private Image _imageUI;
    [SerializeField] private float _animationTime;
    [SerializeField] private Color _setColor;
    private Color _originColor;
    private void Start()
    {
        _imageUI = GetComponent<Image>();
        _originColor = _imageUI.color;
    }
    
    public void SlowChangeColor()
    {
        StartCoroutine(SlowChangeColor(_originColor,_setColor));
    }
    
    public void SlowRevertColor()
    {
        StartCoroutine(SlowChangeColor(_setColor,_originColor));
    }
    private IEnumerator SlowChangeColor(Color startColor, Color targetColor)
    {
        var delay = new WaitForFixedUpdate();
        float elapsedTime = 0;
        while (elapsedTime < _animationTime)
        {
            elapsedTime += Time.deltaTime;
            float r = Mathf.Lerp(startColor.r, targetColor.r, elapsedTime / _animationTime);
            float g = Mathf.Lerp(startColor.g, targetColor.g, elapsedTime / _animationTime);
            float b = Mathf.Lerp(startColor.b, targetColor.b, elapsedTime / _animationTime);
            float a = Mathf.Lerp(startColor.a, targetColor.a, elapsedTime / _animationTime);
            _imageUI.color = new Color(r, g, b, a);
            yield return delay;
        }
    }
}
