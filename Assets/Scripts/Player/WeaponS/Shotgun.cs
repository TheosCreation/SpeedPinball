using UnityEngine;

public class Shotgun : scr_Weapons
{
    [SerializeField] private float m_shotgunSpread = 0.2f;
    [SerializeField] private int m_shotgunCount = 5;

    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }
    void Update()
    {
        if (isShooting && readyToShoot)
        {
            PerformShot();
        }
    }
  
    void PerformShot()
    {
        readyToShoot = false;

        m_cameraRef.GetComponent<scr_Camera>().ScreenShake(0.15f, 0.3f);
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
                ~m_bulletPassThrough
            );

            var trail = Instantiate(
                m_bulletTrail,
                m_gunPoint.position,
                transform.rotation
            );

            var trailScript = trail.GetComponent<scr_BulletTrail>();
            if (hit.collider != null)
            {
                var hitEnemy = hit.collider.gameObject;
                if (hitEnemy.CompareTag("Enemy"))
                {
                    hitEnemy.GetComponent<EnemyAI>().TakeDamage(m_damage);
                }
                trailScript.SetTargetPos(hit.point);
            }
            else
            {
                var endPos = m_gunPoint.position + adjustedDirection * m_weaponRange;
                trailScript.SetTargetPos(endPos);
            }
        }
        rb.velocity = new Vector2(rb.velocity.x - transform.up.x * m_recoil, rb.velocity.y - transform.up.y * m_recoil);
        Invoke("ResetShot", rateOfFire);


        if (!isAutomatic)
        {
            Invoke("EndShot", rateOfFire);
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }
}

