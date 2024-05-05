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
        private Vector2 _velocity;
        private float _decelerationStep;
        private float _accelerationStep; 
        private bool _engineIsWorking;
        [SerializeField] private UnityEvent<bool> _engineWorked;
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
                _velocity = Vector2.Lerp(_velocity, Vector2.zero, Mathf.Clamp(_decelerationStep, 0, 1));
                if (Vector2.Distance(_velocity, Vector2.zero) < 0.1f)
                    _velocity = Vector2.zero;
            }
            else
            {
                 _accelerationStep += Time.fixedDeltaTime * _forceAcceleration;
                _velocity = Vector2.Lerp(_velocity, new Vector2(_maxForce,_maxForce), Mathf.Clamp(_accelerationStep, 0, 1));  

            }
            _rb.velocity = _tr.up * _velocity;
        }
    }
}

