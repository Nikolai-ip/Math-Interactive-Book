using System;
using UnityEngine;

public class ArrowPositionController : MonoBehaviour
{
    [SerializeField] private Transform _shipIconTr;
    private Transform _tr;
    [SerializeField] private float _moveRadius;
    [SerializeField] private float _activateRadius;
    [SerializeField] private Transform _target;
    private SpriteRenderer[] _spriteRenderers;

    private void Start()
    {
        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        _tr = GetComponent<Transform>();
    }

    public void ShowArrow()
    {
        foreach (var spriteRenderer in _spriteRenderers)
        {
            spriteRenderer.color = new Color(1, 1, 1, 1);
        }
    }

    public void HideArrow()
    {
        foreach (var spriteRenderer in _spriteRenderers)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0);
        }
    }

    private void Update()
    {
        if (Vector2.Distance(Vector2.zero, (Vector2)_target.position)>_activateRadius)
            ShowArrow();
        else
            HideArrow();
        float  angleToTarget = Mathf.Atan2(_target.position.y, _target.position.x);
        SetPositionArrow(angleToTarget);
        RotateAngleArrow(angleToTarget);
        RotateShipIcon();
    }

    private void SetPositionArrow(float angleToTarget)
    {
        float x = Mathf.Cos(angleToTarget);
        float y = Mathf.Sin(angleToTarget);
        _tr.position = new Vector2(x, y) * _moveRadius;
    }

    private void RotateAngleArrow(float angleToTarget)
    {
        _tr.eulerAngles = new Vector3(0, 0, angleToTarget*Mathf.Rad2Deg - 90);
    }

    private void RotateShipIcon()
    {
        _shipIconTr.eulerAngles = _target.eulerAngles;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(Vector3.zero, _moveRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(Vector3.zero, _activateRadius);

    }
}
