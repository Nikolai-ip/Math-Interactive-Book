using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace SpaceBattle
{
    public class InertialRotationController:MonoBehaviour
    { 
        [SerializeField] private float _maxRotateVelocity;
        [SerializeField] private float _velocityAcceleration;
        [SerializeField] private float _inertion;
        private Transform _tr;
        [SerializeField] private float _rotateVelocity;
        private float _accelerationStep; 
        private bool _isLeftRotate;
        private bool _isRightRotate;
        
        private void Start()
        {
            _tr = GetComponent<Transform>();
        }
        private void FixedUpdate()
        {
             _tr.eulerAngles = new Vector3(0, 0, _tr.eulerAngles.z - _rotateVelocity);
        }
        public void RotateByFloat(float moveX)
        {
            if (moveX != 0)
            {
                _accelerationStep += Time.fixedDeltaTime * _velocityAcceleration;
                _rotateVelocity = Mathf.Lerp(_rotateVelocity, moveX*_maxRotateVelocity,
                    Mathf.Clamp(_accelerationStep, 0, 1));  
            }
            else
            {
                _rotateVelocity -= Mathf.Sign(_rotateVelocity)*Time.fixedDeltaTime * _inertion;
                _rotateVelocity = Mathf.Clamp(_rotateVelocity, -_maxRotateVelocity, _maxRotateVelocity);
                _accelerationStep = 0;
            }

            if (Mathf.Abs(_rotateVelocity) < 0.1f)
                _rotateVelocity = 0;
        }
        
    }
}