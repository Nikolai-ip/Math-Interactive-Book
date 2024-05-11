using UnityEngine;

public class GridBlock : MonoBehaviour
{
    [SerializeField] private GameObject _tile;
    [SerializeField] private int _columns;
    [SerializeField] private int _rows;
    [SerializeField] private float _size;
    private GameObject[,] _grid;
    [SerializeField] private bool _isFixedJoint;
    private void Start()
    {
        BuildGrid();
    }

    private void BuildGrid()
    {
         _size = _tile.GetComponent<Collider2D>().bounds.size.x;
         _grid = new GameObject[_rows,_columns];
         for (int i = 0; i < _rows; i++)
         {
             for (int j = 0; j < _columns; j++)
             {
                 _grid[i,j] = Instantiate(_tile, transform);
                 _grid[i,j].transform.position = transform.position + new Vector3(i * _size, j * _size);

                 if (i > 0)
                 {
                     if (!_isFixedJoint && _grid[i, j].TryGetComponent(out DistanceJoint2D distanceJoint))
                     {
                         distanceJoint.connectedBody = 
                             _grid[i - 1, j].GetComponent<Rigidbody2D>();
                     }
                     if (_isFixedJoint && _grid[i, j].TryGetComponent(out FixedJoint2D fixedJoint))
                     {
                         fixedJoint.connectedBody = 
                             _grid[i - 1, j].GetComponent<Rigidbody2D>();
                     }

                 }
             }
         }
    }
}
