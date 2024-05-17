using UnityEngine;

namespace UI.Interactive.MousePos.MouseInteractiveAreas
{
    public class VectorForceArea:InteractiveArea
    {
        [SerializeField] private LineDrawer _drawer;
        private Transform _tr;
        [SerializeField] private Transform _ship;
        private Vector2 _origin;
        private void Start()
        {
            _tr = GetComponent<Transform>();
        }

        protected  void FixedUpdate()
        {
            if (enabled)
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _drawer.DrawLine(_tr.position,mousePos);
                Vector2 dir = mousePos - (Vector2)_tr.position;
                VectorChanged.Invoke(dir);
                _ship.position = mousePos;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                _ship.localEulerAngles = new Vector3(0, 0, angle-90);
            }
        }

        public override void Disable()
        {
            base.Disable();
            _drawer.ClearLine();
            _ship.localPosition = Vector3.zero;
            _ship.localEulerAngles = Vector3.zero;
            VectorChanged.Invoke(Vector2.zero);
        }
    }
}