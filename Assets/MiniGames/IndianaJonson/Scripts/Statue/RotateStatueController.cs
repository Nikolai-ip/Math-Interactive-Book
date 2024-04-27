using System;
using System.Collections;
using UnityEngine;

public class RotateStatueController : MonoBehaviour
{
    private RotateFX _rotateFX = new();
    [SerializeField] private float _rotateInterval;
    [SerializeField] private float[] _angle;
    [SerializeField] private float _rotateTime;
    [SerializeField] private RotateFX.RotationDirection _rotationDirection;

    private void Start()
    {
        StartCoroutine(RotateCoroutine());
    }
    private IEnumerator RotateCoroutine()
    {
        var delay = new WaitForSeconds(_rotateInterval);
        int index = 0;
        while (true)
        {
            _rotateFX.Rotate(this,_angle[index],_rotateTime,_rotationDirection);
            index++;
            if (index == _angle.Length)
            {
                index = 0;
                _rotationDirection = _rotationDirection == RotateFX.RotationDirection.Clockwise
                    ? RotateFX.RotationDirection.CounterClockwise
                    : RotateFX.RotationDirection.Clockwise;
            }
            yield return delay;
        }
    }
}
