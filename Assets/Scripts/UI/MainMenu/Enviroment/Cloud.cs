using UnityEngine;

public class Cloud : MonoBehaviour
{
    private float _speed;
    private float _endX;
    private float _startX;
    private Transform _tr;
    public Vector2 Position => _tr.position;

    public void Initialize(float speed, float endX, float startX)
    {
        _speed = speed;
        _endX = endX;
        _startX = startX;
        _tr = GetComponent<Transform>();
    }

    public void Move()
    {
        _tr.Translate(Vector3.right * _speed * Time.deltaTime);
    }

    public void ResetPosition(float minY, float maxY,float speed)
    {
        float randomY = Random.Range(minY, maxY);
        _tr.position = new Vector3(_startX, randomY, transform.position.z);
        _speed = speed;
    }
}