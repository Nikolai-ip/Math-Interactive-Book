using System.Linq;
using MiniGames;
using UnityEngine;
using UnityEngine.Events;

public class ProjectilesContainer : InitializeableMono
{
    private PoolMono<Projectile> _projectiles;
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private int _capacity;
    [SerializeField] private bool _autoExpand;
    public int CountOfProjectiles => _projectiles.Count();
    [SerializeField] private UnityEvent ProjectilesRunOut;
    private int _currentCapacity;
    public Projectile GetProjectile()
    {
        if (_currentCapacity == 0)
        {
            ProjectilesRunOut.Invoke();
            return null;
        }
        Projectile projectile = _projectiles.GetFreeElement();
       if (!_autoExpand) _currentCapacity--;
        return projectile;
    }

    public override void Init()
    {
        _projectiles = new PoolMono<Projectile>(_projectilePrefab, _capacity, transform);
        _projectiles.AutoExpand = _autoExpand;
        _currentCapacity = _capacity;
    }
}
