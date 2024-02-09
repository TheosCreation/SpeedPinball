using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Camera : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject m_player;
    private Vector3 m_offset = new Vector3(0, 0, -10f);
    public float m_offsetAmount = 5.0f;
    public float m_smoothTime = 0.25f;
    public Vector3 m_velocity = Vector3.zero;
    private bool m_shake = false;
    private float m_magnitude = 0.2f;
    private float m_shakeDur = 2.0f;
    private float m_shakeElapsed = 0;
    
    // Update is called once per frame
    
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            m_offset = new Vector3(m_offset.x, m_offsetAmount, -10f);
        } 
        if (Input.GetKey(KeyCode.S)) {
            m_offset = new Vector3(m_offset.x, -m_offsetAmount, -10f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_offset = new Vector3(m_offsetAmount, m_offset.y, -10f);
        }
        if (Input.GetKey(KeyCode.A)) {
            m_offset = new Vector3(-m_offsetAmount, m_offset.y, -10f);
        } 
        //this is so it shows you were you are going
        Vector3 t_targetPos = m_player.transform.position + m_offset;
        transform.position = Vector3.SmoothDamp(transform.position, t_targetPos, ref m_velocity, m_smoothTime);
        if (m_shake) { 

            transform.position = new Vector3(transform.position.x+ Random.Range(-m_magnitude,m_magnitude), transform.position.y + Random.Range(-m_magnitude, m_magnitude), transform.position.z);
            m_shakeElapsed += 1 * Time.deltaTime;
            if (m_shakeElapsed > m_shakeDur) {
                m_shake = false;
                m_shakeElapsed = 0;
            }
        }
    }
    public void ScreenShake(float _magnitude, float _duration)
    {
        m_shake = true;
        m_magnitude = _magnitude;
        m_shakeDur = _duration;

    }
}