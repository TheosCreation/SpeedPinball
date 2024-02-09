using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Weapons : MonoBehaviour
{
    // Start is called before the first frame update

    public bool pistol = true;
    [SerializeField] private float m_PistolRecoil = 1;
    public bool shotgun = false;
    public bool assaultRifle = false;
    public bool bomba = false;
    public int m_CurrentWeapon = 0;
    [SerializeField]private Transform m_gunPoint;
    [SerializeField] private GameObject m_bulletTrail;
    [SerializeField] private GameObject m_cameraRef;
    [SerializeField] private float m_weaponRange;
    [SerializeField] private Animator m_muzzleFlash;
    private Rigidbody2D rb;
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

    private void shoot()
    {
       // m_muzzleFlash.SetTrigger("Shoot");
        switch (m_CurrentWeapon)
        {
            case 0:
                m_cameraRef.GetComponent<scr_Camera>().ScreenShake(0.1f, 0.25f);
                var hit = Physics2D.Raycast(
                    m_gunPoint.position,
                    transform.up,
                    m_weaponRange, LayerMask.NameToLayer("Player")
                    ) ; 
                var trail = Instantiate(
                    m_bulletTrail,
                    m_gunPoint.position,
                    transform.rotation
                    );
                var trailScript = trail.GetComponent<scr_BulletTrail>();
                if (hit.collider != null )
                {

                    trailScript.SetTargetPos(hit.point);
                }
                else
                {
                    var endPos = m_gunPoint.position + transform.up * m_weaponRange;
                    trailScript.SetTargetPos(endPos);
                   
                }
               
                rb.velocity = new Vector2(rb.velocity.x- transform.up.x* m_PistolRecoil, rb.velocity.y - transform.up.y* m_PistolRecoil);

                //pistol
                break;
            case 1:
                //shotgun
                break;
            case 2:
                //ar
                break;
            case 3:
                //bomba
                break;
            default:
                break;
        }
    }
}
