using MiniGames;
using UnityEngine;

public class ProjectilesContainer : InitializeableMono
{
    private PoolMono<Projectile> _projectiles;
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private int _capacity;
    [SerializeField] private bool _autoExpand;
    public Projectile GetProjectile()
    {
        return _projectiles.GetFreeElement();
    }

    public override void Init()
    {
        _projectiles = new PoolMono<Projectile>(_projectilePrefab, _capacity, transform);
        _projectiles.AutoExpand = _autoExpand;
    }
}
