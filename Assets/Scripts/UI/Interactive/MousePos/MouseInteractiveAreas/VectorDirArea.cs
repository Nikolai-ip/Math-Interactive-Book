using System;
using UnityEngine;

namespace UI.Interactive.MousePos.MouseInteractiveAreas
{
    public class VectorDirArea:InteractiveArea
    {
        [SerializeField] private LineDrawer _drawer;
        private Transform _tr;
        [SerializeField] private float _scaleLine;
        private void Start()
        {
            _tr = GetComponent<Transform>();
        }

        protected  void FixedUpdate()
        {
            if (enabled)
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _drawer.DrawLine(_tr.position,(Vector2)_tr.position + (mousePos-(Vector2)_tr.position).normalized*_scaleLine);
                VectorChanged.Invoke((mousePos-(Vector2)_tr.position).normalized*_scaleLine);
            }
        }

        public override void Disable()
        {
            base.Disable();
            _drawer.ClearLine();
            VectorChanged.Invoke(Vector2.zero);
        }
    }
}