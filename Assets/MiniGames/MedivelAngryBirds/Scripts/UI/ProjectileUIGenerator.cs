using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProjectileUIGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _projectileUIPrefab;
    [SerializeField] private ProjectilesContainer _projectilesContainer;
    [SerializeField] private int _countOfUIProjectiles;
    [SerializeField] private Vector2 _startGenerationPoint;
    [SerializeField] private bool _isRightGenerate;
    [SerializeField] private float _distanceBetweenProjectiles;
    [SerializeField] private float _distanceBetweenRows;
    private Transform _tr;
    
    public List<GameObject> GeneratePilesOfProjectiles()
    {
        _tr = GetComponent<Transform>();
        _countOfUIProjectiles = _projectilesContainer.CountOfProjectiles;
        float radius = _projectileUIPrefab.GetComponent<CircleCollider2D>().bounds.size.x;
        List<GameObject> projectiles = new List<GameObject>();
        Vector2 instantiatePos = (Vector2) _tr.position + _startGenerationPoint;
        int sign = _isRightGenerate ? 1 : -1;
        int countPojectilesInFirstRow = GetCountObjectOfFirstRow(_countOfUIProjectiles);
        for (int i = 0; i < _countOfUIProjectiles; i++)
        {
            for (int j = 0; j < countPojectilesInFirstRow; j++)
            {
                var projectile = Instantiate(_projectileUIPrefab, instantiatePos, new Quaternion(), _tr);
                projectiles.Add(projectile);
                if (projectiles.Count==_countOfUIProjectiles)
                    return projectiles;
                instantiatePos = new Vector2(instantiatePos.x + sign * (radius + _distanceBetweenProjectiles),
                    instantiatePos.y);
            }
            float offsetX = -sign * (radius * countPojectilesInFirstRow) + sign * radius / 2;
            instantiatePos = new Vector2(instantiatePos.x+offsetX, instantiatePos.y + radius / 2 + _distanceBetweenRows);
            countPojectilesInFirstRow--;
        }

        return projectiles;
    }

    private int GetCountObjectOfFirstRow(int wholeCountOfObjects)
    {
        int i = 1;
        while (true)
        {
            int sum = 0;
            for (int j = 0; j < i; j++)
            {
                sum += j;
                if (sum >= wholeCountOfObjects)
                    return j;
            }
            i++;
        }
    }
}
