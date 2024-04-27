using System;
using UnityEngine;

public class MoveFX
{
    public Vector2 Move(Vector2 objectPos, Vector2 move)
    {
        return objectPos + move;
    }

    public Vector2 Move(Vector2 objectPos, Vector2 move, float speed)
    {
        return objectPos + move * speed;
    }
}
