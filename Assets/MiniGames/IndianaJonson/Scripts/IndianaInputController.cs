using UnityEngine;

public class IndianaInputController : MonoBehaviour
{
    [SerializeField] private PlayerMoveController _playerMoveController;
    private void FixedUpdate()
    {
        _playerMoveController.Move(GetMoveVector());
    }

    private Vector2 GetMoveVector()
    {
        int moveX = 0;
        int moveY = 0;
        if (Input.GetKey(KeyCode.A))
            moveX = -1;
        if (Input.GetKey(KeyCode.D))
            moveX = 1;
        if (Input.GetKey(KeyCode.W))
            moveY = 1;
        if (Input.GetKey(KeyCode.S))
            moveY = -1;
        return new Vector2(moveX, moveY).normalized;
    }
}
