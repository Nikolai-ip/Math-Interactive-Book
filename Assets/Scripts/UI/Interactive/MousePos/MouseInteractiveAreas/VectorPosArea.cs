using System;
using UnityEngine;

namespace UI.Interactive.MousePos.MouseInteractiveAreas
{
    public class VectorPosArea:InteractiveArea
    {
        private Vector2 _originPos;
        [SerializeField] protected Transform FolowTarget;

        protected  void FixedUpdate()
        {
            if (enabled)
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                FolowTarget.position = mousePos;
                VectorChanged.Invoke(PosTranslator.WordPosToLocal(CoordinateSystem,mousePos));
            }
        }
        private void Start()
        {
            _originPos = FolowTarget.position;
        }

        public override void Disable()
        {
            FolowTarget.position = _originPos;
            VectorChanged.Invoke(Vector2.zero);
            base.Disable();
        }
    }
}