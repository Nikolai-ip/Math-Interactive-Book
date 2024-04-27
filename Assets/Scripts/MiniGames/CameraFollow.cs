using System;
using MiniGames;
using UnityEngine;

public class CameraFollow : InitializeableMono
{
    [SerializeField] private Camera _this;
    [SerializeField] private GameObject _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector2 _xBorder;
    [SerializeField] private Vector2 _yBorder;
    [SerializeField] private bool _devTool;
    private float CameraWidth => 2 * _this.orthographicSize * _this.aspect;
    private float CameraHeight => 2 * _this.orthographicSize;
    private Transform _tr;
    private void FixedUpdate()
    {
        if (_target)
        {
            Vector3 targetPos = _target.transform.position;
            float maxX = _xBorder.y - CameraWidth / 2;
            float minX = _xBorder.x + CameraWidth/2;
            float x = Math.Clamp(targetPos.x + _offset.x,minX,maxX);
            float minY = _yBorder.x + CameraHeight/2;
            float maxY = _yBorder.y - CameraHeight/2;
            float y = Math.Clamp(targetPos.y+_offset.y, minY, maxY);
            Vector3 newCameraPos = new Vector3(x, y, -10);
            _tr.position = newCameraPos;
        }
    }

    public void ResetTarget()
    {
        _target = null;
    }

    public void SetTarget(GameObject target)
    {
        _target = target;
    }

    private void OnDrawGizmos()
    {
        if (!_devTool) return;
        Gizmos.DrawWireSphere(new Vector3(_xBorder.x,0),0.3f);
        Gizmos.DrawWireSphere(new Vector3(_xBorder.y,0),0.3f);
        Gizmos.DrawWireSphere(new Vector3((_xBorder.x+_xBorder.y)/2,_yBorder.x),0.3f);
        Gizmos.DrawWireSphere(new Vector3((_xBorder.x+_xBorder.y)/2,_yBorder.y),0.3f);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(new Vector3(_xBorder.x + CameraWidth/2,0),0.3f);
        Gizmos.DrawWireSphere(new Vector3(_xBorder.y - CameraWidth/2,0),0.3f);
        Gizmos.DrawWireSphere(new Vector3((_xBorder.x+_xBorder.y)/2,_yBorder.x + CameraHeight/2),0.3f);
        Gizmos.DrawWireSphere(new Vector3((_xBorder.x+_xBorder.y)/2,_yBorder.y - CameraHeight/2),0.3f);
    }

    public override void Init()
    {
        _tr = GetComponent<Transform>();

    }
}
