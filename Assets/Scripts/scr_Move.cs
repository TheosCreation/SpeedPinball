using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class scr_Move : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D m_rb;
    //private CircleCollider2D m_circleCollider2D;
    private Vector2 m_lastVelocity;
    public float m_speed = 0.1f;
    public float m_speedCap = 5.0f;
    public float m_turnDelay = 0.5f; //sets speed to this number when turning so slide aint that bad
    public float m_turnSpeed =  0.4f;
    public Vector3 m_direction;

    
 
    void Start()
    {
       m_rb = GetComponent<Rigidbody2D>();
       //m_circleCollider2D = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    
    void Update()
    {
        m_lastVelocity = m_rb.velocity;
        Movement();
        LookAtMouse();
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.W) && m_rb.velocity.y < m_speedCap)
        {
            float t_speed = 0; //temp speed 
            if (m_rb.velocity.y < -m_turnDelay)
            {
                t_speed = m_turnSpeed;
            }
            else
            {
                t_speed = m_speed;
            }
            m_rb.velocity = new Vector2(m_rb.velocity.x, m_rb.velocity.y + t_speed);
        }
        if (Input.GetKey(KeyCode.S) && m_rb.velocity.y > -m_speedCap)
        {
            float t_speed = 0; //temp speed 
            if (m_rb.velocity.y > m_turnDelay)
            {
                t_speed = m_turnSpeed;
            }
            else
            {
                t_speed = m_speed;
            }
            m_rb.velocity = new Vector2(m_rb.velocity.x, m_rb.velocity.y - t_speed);
        }
        /* WROTE THIS ENTIRE THING without knowing it was built in linear drag
        else {
            if(MathF.Abs(m_rb.velocity.y) > 0) { 
                m_rb.velocity = new Vector2(m_rb.velocity.x, m_rb.velocity.y - Mathf.Sign(m_rb.velocity.y)* m_slowSpeed);
            }
        }*/


        if (Input.GetKey(KeyCode.D) && m_rb.velocity.x < m_speedCap)
        {
            float t_speed = 0; //temp speed 
            if (m_rb.velocity.x < -m_turnDelay)
            {
                t_speed = m_turnSpeed;
            }
            else
            {
                t_speed = m_speed;
            }
            m_rb.velocity = new Vector2(m_rb.velocity.x + t_speed, m_rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.A) && m_rb.velocity.x > -m_speedCap)
        {
            float t_speed = 0; //temp speed 
            if (m_rb.velocity.x > m_turnDelay)
            {
                t_speed = m_turnSpeed;
            }
            else
            {
                t_speed = m_speed;
            }
            m_rb.velocity = new Vector2(m_rb.velocity.x - t_speed, m_rb.velocity.y);
        }
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
