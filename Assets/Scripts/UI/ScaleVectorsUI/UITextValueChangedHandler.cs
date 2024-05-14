using System;
using TMPro;
using UnityEngine;

public class UITextValueChangedHandler : MonoBehaviour
{
    private TextMeshProUGUI _textUI;
    private void Start()
    {
        _textUI = GetComponent<TextMeshProUGUI>();
    }

    public void OnValueChanged(object value)
    {
         _textUI.text = value.ToString();
    }
}
