using UnityEngine;

namespace MiniGames
{
    public class Projectile : PoolObject
    {
        protected Rigidbody2D rb; 
        protected float damage;
        protected Transform tr;
        [SerializeField] protected float lifeDuration;
        protected float elapsedTime;
        protected Animator animator;
        protected new Collider2D collider;
        protected float originRotate;

        public Projectile StartMove(Vector2 dir, float speed)
        {
            rb.velocity = dir * speed;
            return this;
        }

        public Projectile SetPosition(Vector2 position)
        {
            tr.position = position;
            return this;
        }
        public Projectile SetDamage(float damage)
        {
            this.damage = damage;
            return this;
        }

        protected void Update()
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > lifeDuration)
            {
                elapsedTime = 0;
                StartDeactivated();
            }
        }

        protected void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(gameObject,damage);
                StartDeactivated();
            }
        }

        protected void StartDeactivated()
        {
            collider.enabled = false;
            rb.velocity = Vector2.zero;
            animator.SetTrigger("Explosion");
        }

        public override void Activated()
        {
            gameObject.SetActive(true);
            tr.eulerAngles = new Vector3(0, 0, originRotate);
            collider.enabled = true;
            elapsedTime = 0;
        }
        public override void Deactivated()
        {
            gameObject.SetActive(false);
        }
        public override void Init()
        {
            rb = GetComponent<Rigidbody2D>();
            tr = GetComponent<Transform>();
            animator = GetComponent<Animator>();
            collider = GetComponent<Collider2D>();
            originRotate = tr.eulerAngles.z;
        }
    }
}