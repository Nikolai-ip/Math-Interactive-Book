using System;
using UnityEngine;
using UnityEngine.Events;

namespace MiniGames.MedivelAngryBirds.Scripts.Block
{
    public class Block:MonoBehaviour
    {
        private SpriteRenderer _sr;
        private Rigidbody2D _rb;
        private Collider2D _collider;
        private bool _isActive;
        private Transform _tr;
        private Vector2 _originLocalPos;
        [SerializeField] private bool _isGlobalParent;
        [SerializeField] private UnityEvent Activated; 
        public void Init()
        {
            _tr = GetComponent<Transform>();
            _originLocalPos = _tr.localPosition;
            _sr = GetComponent<SpriteRenderer>();
            _rb = GetComponent<Rigidbody2D>();
            _collider = GetComponent<Collider2D>();
        }

        public void Enable()
        {
            _sr.enabled = true;
            _collider.enabled = true;
            _rb.bodyType = RigidbodyType2D.Dynamic;
            _tr.localPosition = _originLocalPos;
            _isActive = true;
            Activated.Invoke();
        }

        public void Disable()
        {
            _sr.enabled = false;
            _collider.enabled = false;
            _rb.bodyType = RigidbodyType2D.Static;
            _isActive = false;
        }

        private float _elapsedTime;
        private void Update()
        {
            if (!_isActive&&!_isGlobalParent)
                _tr.localPosition = _originLocalPos;

        }
    }
}