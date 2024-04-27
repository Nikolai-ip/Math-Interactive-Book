using System;
using System.Collections;
using UnityEngine;

public class FlickerController : MonoBehaviour
{
    [SerializeField] private int _quantity;
    [SerializeField] private float _duration;
    [SerializeField] private float _interval;
    private SpriteRenderer _sr;
    private Coroutine _flickCoroutine;
    [SerializeField] private bool _devTool;
    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    public void StartFlick()
    {
        _flickCoroutine = StartCoroutine(Flick());
    }
    
    private IEnumerator Flick()
    {
        var duration = new WaitForSeconds(_duration);
        var interval = new WaitForSeconds(_interval);
        for (int i = 0; i < _quantity; i++)
        {
            _sr.color = new Color(1, 1, 1, 0);
            yield return duration;
            _sr.color = new Color(1, 1, 1, 1);
            yield return interval;
        }
    }

    private void OnGUI()
    {
        if (_devTool)
        {
            if (GUI.Button(new Rect(0, 60, 100, 50),"Flick"))
            {
                StartFlick();
            }
        }
    }
}
