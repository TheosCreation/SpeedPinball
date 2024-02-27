using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D m_rb;
    private Vector2 m_lastVelocity;
    public Vector2 m_direction;
    public float m_baseAcceleration = 1.0f;
    public float m_baseMass = 1.0f;
    public float m_baseDrag = 1.0f;
    private float m_acceleration = 0.1f;
    public float m_movementVelocityCap = 20.0f;
    private float m_bounceMultiplier = 1.0f;
    public float m_defaultBounceMultiplier = 1.0f;
    public bool g_win = false;

    void Start()
    {
       m_rb = GetComponent<Rigidbody2D>();
       m_acceleration = m_baseAcceleration;
       m_rb.drag = m_baseDrag;
       m_rb.mass = m_baseMass;
        m_bounceMultiplier = m_defaultBounceMultiplier;
    }

    void Update()
    {
        m_lastVelocity = m_rb.velocity;
        LookAtMouse();
        if (Input.GetKey(KeyCode.Space))
        {
            ProcessHeavyAbility();
        }    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_rb.velocity *= 2;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            m_acceleration = m_baseAcceleration;
            m_rb.drag = m_baseDrag;
            transform.localScale = new Vector3(1,1,1);
            m_rb.mass = m_baseMass;
            m_bounceMultiplier = m_defaultBounceMultiplier;
            
        }

    }

    void OnCollisionEnter2D(Collision2D Collision)
    {
        m_direction = Vector2.Reflect(m_lastVelocity.normalized, Collision.contacts[0].normal);
        
        if (Collision.gameObject.CompareTag("Bouncy"))
        {
            //same velocity and reflects at an angle of somekind
            m_rb.velocity = (m_direction * Mathf.Max(m_lastVelocity.magnitude/1.5f, 0f))*m_bounceMultiplier;
        }
        else
        {
            //halfs the velocity and reflects at an angle of somekind
            m_rb.velocity = (m_direction * Mathf.Max(m_lastVelocity.magnitude / 3, 0f))* m_bounceMultiplier;
        }
    }
    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.CompareTag("Slower"))
        {
            m_rb.velocity /= 2;
        }    
        if (Collision.gameObject.CompareTag("win"))
        {
            g_win = true;
        }
    }
    public void ProcessMoveX(float input)
    {
        //process right
        if (m_rb.velocity.x < m_movementVelocityCap)
        {
            m_rb.velocity = new Vector2(m_rb.velocity.x + (input * m_acceleration), m_rb.velocity.y);
        }

        //process left
        if (m_rb.velocity.x > -m_movementVelocityCap)
        {
            m_rb.velocity = new Vector2(m_rb.velocity.x + (input * m_acceleration), m_rb.velocity.y);
        }
        
    }
    public void ProcessMoveY(float input)
    {
        //process up
        if (m_rb.velocity.y < m_movementVelocityCap)
        {
            m_rb.velocity = new Vector2(m_rb.velocity.x, m_rb.velocity.y + (input * m_acceleration));
        }
        //process down
        if (m_rb.velocity.y > -m_movementVelocityCap)
        {
            m_rb.velocity = new Vector2(m_rb.velocity.x, m_rb.velocity.y + (input * m_acceleration));
        }
    }
    public void LookAtMouse()
    {
        Vector2 i_mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = i_mousePos - new Vector2(transform.position.x, transform.position.y);
    }
    public void ProcessHeavyAbility() {
        m_rb.drag = 0.0f;
        m_acceleration = 0.1f;
        m_rb.mass = 120.0f;
        m_bounceMultiplier = 2f;
        transform.localScale = new Vector3(1.2f, 1.2f, 1);
        // make this not a hardcoded mess, maybe make a game controler or smthng
    }
}
