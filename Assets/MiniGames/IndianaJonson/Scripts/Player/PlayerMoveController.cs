using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMoveController : MonoBehaviour
{
    private MoveFX _moveFX = new();
    private Transform _tr;
    [SerializeField] private float _speed = 1;
    public UnityEvent<Vector2> Moved;
    private void Start()
    {
        _tr = GetComponent<Transform>();
    }

    public void Move(Vector2 moveInput)
    {
        _tr.position = _moveFX.Move(_tr.position,moveInput,_speed);
        Flip(moveInput);
        Moved.Invoke(moveInput);
    }

    private void Flip(Vector2 moveInput)
    {
        if (!Mathf.Approximately(moveInput.x, 0))
        {
            _tr.localScale = new Vector3(Math.Sign(moveInput.x), _tr.localScale.y,1);
        }
    }
    
}
