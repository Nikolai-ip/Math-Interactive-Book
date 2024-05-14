using System;
using SpaceBattle;
using UnityEngine;

public class RotateInputHandler : MonoBehaviour
{
    [SerializeField] private InertialRotationController _rotationController;
    private float _rotateCoef=0;
    private void FixedUpdate()
    {
        _rotationController.RotateByFloat(_rotateCoef);
    }

    public void SetRotateCoef(float coef)
    {
        _rotateCoef = coef;
    }

    public void ResetRotateCoef() => _rotateCoef = 0;
}
