using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : scr_Weapons
{
    // Start is called before the first frame update
    [SerializeField] private float m_PistolRecoil = 1.0f; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }
    }
    void shoot()
    {
        m_cameraRef.GetComponent<scr_Camera>().ScreenShake(0.1f, 0.25f);
        var hit = Physics2D.Raycast(
            m_gunPoint.position,
            transform.up,
            m_weaponRange, LayerMask.NameToLayer("Player")
            );
        var trail = Instantiate(
            m_bulletTrail,
            m_gunPoint.position,
            transform.rotation
            );
        var trailScript = trail.GetComponent<scr_BulletTrail>();
        if (hit.collider != null)
        {

            trailScript.SetTargetPos(hit.point);
        }
        else
        {
            var endPos = m_gunPoint.position + transform.up * m_weaponRange;
            trailScript.SetTargetPos(endPos);

        }

        rb.velocity = new Vector2(rb.velocity.x - transform.up.x * m_PistolRecoil, rb.velocity.y - transform.up.y * m_PistolRecoil);
    }
}

