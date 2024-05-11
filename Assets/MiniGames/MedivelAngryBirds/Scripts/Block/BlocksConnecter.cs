using System;
using System.Linq;
using UnityEngine;

public class BlocksConnecter : MonoBehaviour
{
    [SerializeField] private FixedJoint2D[] _blockJoints;
    [SerializeField] private bool _connect;
    private void OnValidate()
    {
        ConnectedBlockJoints();
    }

    private void ConnectedBlockJoints()
    {
        foreach (var joint in _blockJoints)
        {
            joint.connectedBody = _blockJoints.OrderBy(block =>
                    Vector2.Distance(joint.transform.position, block.transform.position)).Skip(1).First()
                .GetComponent<Rigidbody2D>();
        }
    }
}
