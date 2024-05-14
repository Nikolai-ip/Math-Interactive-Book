using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PercentUIAnimationController : MonoBehaviour
{
    private Image _image;
    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private float _maxValue;
    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void OnValueChanged(object value)
    {
        float floatValue = (float)value;
        int index = Mathf.Clamp((int)Math.Floor(Mathf.Clamp01(floatValue/_maxValue) * _sprites.Count),0,_sprites.Count-1);
        _image.sprite = _sprites[index];
    }
}
