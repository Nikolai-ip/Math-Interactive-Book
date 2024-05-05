using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
    private Image _statBarFilling;

    private void Start()
    {
        _statBarFilling = GetComponent<Image>();
    }

    public void OnStatValueChanged(float value)
    {
        _statBarFilling.fillAmount = value;
    }
    public void OnStatValueChanged(float maxValue, float currentValue)
    {
        _statBarFilling.fillAmount = currentValue/maxValue;
    }
}
