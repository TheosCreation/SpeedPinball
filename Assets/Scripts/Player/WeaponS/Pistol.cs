using UnityEngine;

public class Pistol : scr_Weapons
{
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

        m_cameraRef.GetComponentInParent<scr_Camera>().ScreenShake(0.08f, 0.22f);
        var hit = Physics2D.Raycast(
            m_gunPoint.position,
            transform.up,
            m_weaponRange, ~m_bulletPassThrough); 
        var trail = Instantiate(
            m_bulletTrail,
            m_gunPoint.position,
            transform.rotation
            );
        var trailScript = trail.GetComponent<scr_BulletTrail>();
        if (hit.collider != null)
        {
            var hitEnemy = hit.collider.gameObject;
            if (hitEnemy.CompareTag("Enemy")) {
                hitEnemy.GetComponent<EnemyAI>().TakeDamage(m_damage);
            }    
            else if (hitEnemy.CompareTag("destructable")) {
                Destroy(hitEnemy);
            }
  


        
            trailScript.SetTargetPos(hit.point);
        }
        else
        {

            var endPos = m_gunPoint.position + transform.up * m_weaponRange;
            trailScript.SetTargetPos(endPos);

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

