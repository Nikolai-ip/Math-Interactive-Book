using System;
using UnityEngine;
using UnityEngine.Events;

public class PackManArea : MonoBehaviour
{
    private CoordinateSystem _coordinateSystem;
    [SerializeField] private Transform _packManTr;
    [SerializeField] private UnityEvent<object> PackManPosChanged;
    [SerializeField] private MousePosTranslator _posTranslator;
    [SerializeField] private float _scale;
    private void Start()
    {
        _coordinateSystem = GetComponent<CoordinateSystem>();
    }

    private void AddMoveToPackManPos(Vector2 move)
    {
        _packManTr.localPosition = (Vector2)_packManTr.localPosition + move * _scale;
        float angle = Mathf.Atan2(move.y, move.x) * Mathf.Rad2Deg;
        _packManTr.localEulerAngles = new Vector3(0, 0, angle);
        PackManPosChanged.Invoke(  (Vector2)_packManTr.localPosition/_scale);
    }
    public void MoveUp()
    {
        AddMoveToPackManPos(new Vector2(0, 1));
    }

    public void MoveDown()
    {
        AddMoveToPackManPos(new Vector2(0, -1));
    }

    public void MoveLeft()
    {
        AddMoveToPackManPos(new Vector2(-1, 0));
    }

    public void MoveRight()
    {
        AddMoveToPackManPos(new Vector2(1, 0));
    }
}
