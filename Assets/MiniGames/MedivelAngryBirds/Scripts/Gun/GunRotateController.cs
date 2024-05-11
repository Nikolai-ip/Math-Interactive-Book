using System;
using SpaceBattle;
using UnityEngine;
using UnityEngine.Serialization;

namespace MiniGames.MedivelAngryBirds.Scripts.Gun
{
    public class GunRotateController:MonoBehaviour
    {
        [SerializeField] private float _maxRotateAngle;
        [SerializeField] private float _minRotateAngle;
        [SerializeField] private Transform _gunTr;
        [SerializeField] private float _rotateVelocity;
        [SerializeField] private float _step;
        private float _previousAngle;
        [SerializeField] private float _deltaAngleBetweenUpdates;
        [SerializeField] private float _deltaTargetY;
        [SerializeField] private float _sensivityCoef = 1;
        public void Rotate(Vector2 target)
        {
            target = new Vector2(target.x, target.y - _deltaTargetY)* _sensivityCoef;
            Vector2 dir = (target - (Vector2)_gunTr.position).normalized;
            float targetAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            targetAngle = Mathf.Clamp(targetAngle, _minRotateAngle, _maxRotateAngle);
            
            if (Math.Abs(targetAngle - _previousAngle) < _deltaAngleBetweenUpdates)
            {
                _step = 0;
            }
            _previousAngle = targetAngle;
            _step += Time.deltaTime * _rotateVelocity;
            float angle = Mathf.LerpAngle(_gunTr.eulerAngles.z, targetAngle, Math.Clamp(_step,0,1));
            _gunTr.eulerAngles = new Vector3(0, 0, angle);
        }
        private void OnDrawGizmos()
        {
            Vector2 pos = _gunTr.position;
            Vector2 finalPointOfMaxAngle = new Vector3(pos.x+1*Mathf.Cos(_maxRotateAngle*Mathf.Deg2Rad),pos.y+1*Mathf.Sin(_maxRotateAngle*Mathf.Deg2Rad));
            Gizmos.DrawLine(pos,finalPointOfMaxAngle);
            Vector2 finalPointOfMinAngle = new Vector3(pos.x+1*Mathf.Cos(_minRotateAngle*Mathf.Deg2Rad),pos.y+1*Mathf.Sin(_minRotateAngle*Mathf.Deg2Rad));
            Gizmos.DrawLine(pos,finalPointOfMinAngle);  
        }
    }
}