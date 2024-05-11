using UnityEngine;
using UnityEngine.Events;

public class EnemyCollisionController : MonoBehaviour
{
    [SerializeField] private float _forceForDie;
    private Rigidbody2D _rb;
    private float _elapsedTime;
    [SerializeField] private float _updateFrequencyMagnitude;
    private float _velocityMagnitude;
    private EnemyDieController _enemy;
    private bool _enable = true;
    [SerializeField] private Color _deadColor;
    private SpriteRenderer _sr;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _enemy = GetComponent<EnemyDieController>();
        _sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > _updateFrequencyMagnitude)
        {
            _elapsedTime = 0;
            _velocityMagnitude = _rb.velocity.magnitude;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!_enable) return;
        float hiterMagnitude = 0;
        if (other.collider.TryGetComponent(out Rigidbody2D hiter))
        {
            hiterMagnitude = hiter.velocity.magnitude;
        }
        float hitForce = _velocityMagnitude + hiterMagnitude;
        if (hitForce > _forceForDie)
        {
            _enable = false;
            _sr.color = _deadColor;
            _enemy.Die();
        }
    }
    
}
