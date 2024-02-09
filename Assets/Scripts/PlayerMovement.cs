using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    // Start is called before the first frame update
    private Rigidbody2D m_rb;
    private Vector2 m_lastVelocity;
    public float m_speed = 0.1f;
    public float m_speedCap = 3.0f;
    public float m_turnDelay = 0.5f; //sets speed to this number when turning so slide aint that bad
    public float m_turnSpeed =  0.4f;
    public Vector3 m_direction;

    
 
    void Start()
    {
       m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    
    void Update()
    {
        m_lastVelocity = m_rb.velocity;
        LookAtMouse();
        
    }
    public void ProcessMove(Vector2 input)
    {
        Debug.Log(input);
      
        m_rb.velocity = new Vector2(m_rb.velocity.x+(input.x * m_speed), m_rb.velocity.y+(input.y * m_speed));
        
    }

    private void OnCollisionEnter2D(Collision2D Collision)
    {
        m_direction = Vector2.Reflect(m_lastVelocity.normalized, Collision.contacts[0].normal);
        m_rb.velocity = m_direction * Mathf.Max(m_lastVelocity.magnitude, 0f);
    }
    public void LookAtMouse()
    {
        Vector2 i_mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = i_mousePos - new Vector2(transform.position.x, transform.position.y);
    }
}
