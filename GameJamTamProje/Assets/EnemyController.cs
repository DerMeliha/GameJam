using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform playerTarget;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float attackDistance;
    [SerializeField] private int attackDamage;
    [SerializeField] private float viewDistance;
    [SerializeField] private float viewAngle;
    [SerializeField] private PlayerHealth playerHealth;

    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    private Animator _animator;

    private Vector2 _direction;
    private float _distance;
    private float _angle;
    private bool _isAttacking;
    private float _attackTimer;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _animator = transform.GetComponent<Animator>();
        _attackTimer = 0f;
    }

    private void FixedUpdate()
    {
        _direction = playerTarget.position - transform.position;
        _distance = _direction.magnitude;
        _angle = Vector2.Angle(_direction, _sr.flipX ? Vector2.down : Vector2.up);

        if (_distance < viewDistance && _angle < viewAngle * 0.5f && !_isAttacking)
        {
            FollowToTarget();

            if (_distance < attackDistance && !_isAttacking)
            {
                Attack();
            }
        }
        else
        {
            _rb.velocity = Vector2.zero;
        }

        if (_isAttacking)
        {
            _attackTimer += Time.deltaTime;

            if (_attackTimer >=1.5f)
            {
                _isAttacking = false;
                _attackTimer = 0f;
            }
        }
    }

    private void FollowToTarget()
    {
        if (_isAttacking) return;

        _sr.flipX = _direction.x < 0;
        _rb.velocity = _direction.normalized * moveSpeed;
    }

    private void Attack()
    {
        _isAttacking = true;
        print("aa");
        _animator.SetTrigger("enemyAttack");
        playerHealth.TakeDamage(attackDamage);
    }
}