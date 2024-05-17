using System;
using UnityEngine;

public class CoordinateSystem : MonoBehaviour
{
    [SerializeField] private Vector2 _origin;
    public Vector2 WorldOriginPos => (Vector2)_tr.position + _origin;    
    [SerializeField] private float _stepX;
    [SerializeField] private float _stepY;
    public Vector2 Step => new Vector2(_stepX, _stepY);
    private Transform _tr;

    private void Start()
    {
        _tr = GetComponent<Transform>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_origin,0.1f);
    }
}
