using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_BulletTrail : MonoBehaviour
{

    private Vector3 m_startPos;
    private Vector3 m_targetPos;
    private float m_progress;
    [SerializeField] private float m_speed = 0.1f;
    void Start()
    {
        m_startPos = transform.position.WithAxis(Axis.Z, -1);
    }
        
    void Update()
    {
        m_progress += Time.deltaTime * m_speed; 
        transform.position = Vector3.Lerp(m_startPos, m_targetPos, m_progress);
    }
    public void SetTargetPos(Vector3 targetPos)
    {
        m_targetPos = targetPos.WithAxis(Axis.Z,-1);
    }
}
