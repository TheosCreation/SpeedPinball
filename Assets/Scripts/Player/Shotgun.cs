using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : scr_Weapons
{
    // Start is called before the first frame update

    [SerializeField] private float m_shotgunSpread = 0.2f;
    [SerializeField] private int m_shotgunCount = 5;

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
        m_cameraRef.GetComponent<scr_Camera>().ScreenShake(0.25f, 0.5f);
        for (int i = -m_shotgunCount; i < m_shotgunCount; i++)
        {
            // Calculate a random offset for each bullet
            Vector3 randomOffset = new Vector3(Random.Range(-m_shotgunSpread, m_shotgunSpread), Random.Range(-m_shotgunSpread, m_shotgunSpread), 0f);

            // Adjust the direction vector with the random offset
            Vector3 adjustedDirection = transform.up + randomOffset;

            var hit = Physics2D.Raycast(
                m_gunPoint.position,
                adjustedDirection,
                m_weaponRange,
                m_bulletPassThrough
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
                var endPos = m_gunPoint.position + adjustedDirection * m_weaponRange;
                trailScript.SetTargetPos(endPos);
            }
        }

        rb.velocity = new Vector2(rb.velocity.x - transform.up.x * m_recoil, rb.velocity.y - transform.up.y * m_recoil);
    }
}

