using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class LineDrawer : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = 0;
    }

    public void DrawLine(Vector2 startPos, Vector2 endPos)
    {
        ClearLine();
        _lineRenderer.positionCount = 2;
        _lineRenderer.SetPosition(0, new Vector3(startPos.x, startPos.y, 0));
        _lineRenderer.SetPosition(1, new Vector3(endPos.x, endPos.y, 0));
    }

    public void ClearLine()
    {
        _lineRenderer.positionCount = 0;
    }

}
