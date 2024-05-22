using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CloudsMover : MonoBehaviour
{
    [SerializeField] private List<Cloud> _clouds; 
    [SerializeField] private float _minSpeed = 0.5f; 
    [SerializeField] private float _maxSpeed = 2f; 
    [SerializeField] private float _minY = -4f; 
    [SerializeField] private float _maxY = 4f; 
    [SerializeField] private float _startX = -10f; 
    [SerializeField] private float _endX = 10f; 

    private void Start()
    {
        foreach (var cloud in  GetComponentsInChildren<Cloud>())
        {
            cloud.Initialize(Random.Range(_minSpeed, _maxSpeed), _endX, _startX);
            _clouds.Add(cloud);
        }
    }

    private void Update()
    {
        MoveClouds();
    }
    private void MoveClouds()
    {
        foreach (Cloud cloud in _clouds)
        {
            if (cloud != null)
            {
                cloud.Move();
                if (cloud.Position.x > _endX)
                {
                    cloud.ResetPosition(_minY,_maxY,Random.Range(_minSpeed, _maxSpeed));
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(new Vector3(_startX,_maxY),0.3f);
        Gizmos.DrawWireSphere(new Vector3(_startX,_minY),0.3f);
        Gizmos.DrawWireSphere(new Vector3(_endX,_minY),0.3f);
        Gizmos.DrawWireSphere(new Vector3(_endX,_maxY),0.3f);
    }
}
