using UnityEngine;
using UnityEngine.Events;

namespace SpaceBattle
{
    public class InertialMovementController : MonoBehaviour
    {
        [SerializeField] private float _maxForce;
        [SerializeField] private float _forceAcceleration;
        [SerializeField] private float _inertion;
        private Rigidbody2D _rb;
        private Transform _tr;
        [SerializeField] private float _velocity;
        private float Velocity => _velocity;
        private float _decelerationStep;
        private float _accelerationStep; 
        private bool _engineIsWorking;
        [SerializeField] private UnityEvent<bool> _engineWorked;
        [SerializeField] private UnityEvent<object> _veloctiyChanged;
        private void Start()
        {
            _tr = GetComponent<Transform>();
            _rb = GetComponent<Rigidbody2D>();
        }
        public void EnableEngine()
        {
            _accelerationStep = 0;
            _engineIsWorking = true;
            _engineWorked.Invoke(true);
        }

        public void DisableEngine()
        {
            _decelerationStep = 0;
            _engineIsWorking = false;
            _engineWorked.Invoke(false);
        }
        private void FixedUpdate()
        {
            if (!_engineIsWorking)
            {
                _decelerationStep += Time.fixedDeltaTime * _inertion;
                _velocity = Mathf.Lerp(_velocity, 0, Mathf.Clamp(_decelerationStep, 0, 1));
                if (_velocity < 0.1f)
                    _velocity = 0;
            }
            else
            {
                 _accelerationStep += Time.fixedDeltaTime * _forceAcceleration;
                _velocity = Mathf.Lerp(_velocity, _maxForce ,Mathf.Clamp(_accelerationStep, 0, 1));  

            }
            _rb.velocity = _tr.up * _velocity;
            _veloctiyChanged.Invoke(_velocity);
        }
    }
}

