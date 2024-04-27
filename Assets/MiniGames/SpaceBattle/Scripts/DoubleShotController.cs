using UnityEngine;
using UnityEngine.Events;

namespace SpaceBattle
{
    public class DoubleShotController:MonoBehaviour
    {
        private Transform _tr;
        [SerializeField] private ProjectilesContainer _projectilesContainer;
        [SerializeField] private float _projectileSpeed;
        [SerializeField] private float _projectileDamage;
        public UnityEvent Shoted;
        [SerializeField] private Transform _leftShotPoint;
        [SerializeField] private Transform _rightShotPoint;
        [SerializeField] private float _shotInterval;
        private float _timer;
        private bool _isShoting = false;
        public void StartShot()
        {
            _isShoting = true;
        }

        public void StopShot()
        {
            _isShoting = false;
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= _shotInterval && _isShoting)
            {
                Shot();
                _timer = 0;
            }
        }

        private void Shot()
        {
            CreateProjectile(_leftShotPoint.position);
            CreateProjectile(_rightShotPoint.position);
        }
        private void CreateProjectile(Vector2 shootPoint)
        {
            var rotationAngle = _tr.eulerAngles.z * Mathf.Deg2Rad;
            Vector2 shotDir = _tr.up.normalized;
            var projectile =   _projectilesContainer.GetProjectile();
            projectile.SetPosition(shootPoint)
                .StartMove(shotDir,_projectileSpeed)
                .SetDamage(_projectileDamage)
                .transform.Rotate(transform.forward*_tr.eulerAngles.z);
            Shoted.Invoke();
        }

        private void Start()
        {
            _timer = _shotInterval;
            _tr = GetComponent<Transform>();
        }
    }
}