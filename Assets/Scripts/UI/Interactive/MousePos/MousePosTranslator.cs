using UnityEngine;

public class MousePosTranslator : MonoBehaviour
{
    public Vector2 WordPosToLocal(CoordinateSystem coordinateSystem, Vector2 worldMousePos)
    {
        return worldMousePos - coordinateSystem.WorldOriginPos;
    }
}
