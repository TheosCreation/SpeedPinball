using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody2D m_rb;
    public GameObject m_target;
    [SerializeField] private float m_detectRange;
    private float m_distanceToTarget;
    private SpriteRenderer spriteRenderer;

    //Movement variables
    public float m_speed = 0.1f;
    public float m_speedCap = 5.0f;
    public float m_turnDelay = 0.5f; //sets speed to this number when turning so slide aint that bad
    public float m_turnSpeed = 0.4f;
    public float m_health = 100;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (TargetInAttackRange())
        {
            MoveTowardsTarget();
        }
    }

    private void MoveTowardsTarget()
    {
        //m_rb.MovePosition(m_target.transform.position);
        Vector2 direction = m_target.transform.position - transform.position;
        m_rb.velocity += new Vector2(Mathf.Clamp(direction.x * m_speedCap, -m_speed, m_speedCap), Mathf.Clamp(direction.y * m_speed, -m_speedCap, m_speedCap));
    }

    private bool TargetInAttackRange()
    {
        m_distanceToTarget = Vector2.Distance(transform.position, m_target.transform.position);
        if (m_distanceToTarget <= m_detectRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void TakeDamage(float _Damage) {
        spriteRenderer.color = new Color(255, 0, 50, 1);
        StartCoroutine(DamageAnimation(0.2f));
        m_health -= _Damage;
        if (m_health <= 0) {
            Destroy(gameObject);
        }
    }

    IEnumerator DamageAnimation(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        spriteRenderer.color = new Color(0, 0, 255, 1);
    }
}
