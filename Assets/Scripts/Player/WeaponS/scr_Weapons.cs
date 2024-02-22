using UnityEngine;

public class scr_Weapons : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] protected Transform m_gunPoint;
    [SerializeField] protected GameObject m_bulletTrail;
    [SerializeField] protected GameObject m_cameraRef;
    [SerializeField] protected float m_weaponRange;
    [SerializeField] protected Animator m_muzzleFlash;
    [SerializeField] protected float m_recoil;
    [SerializeField] protected float m_damage;
    [SerializeField] protected bool isAutomatic;
    [SerializeField] protected float rateOfFire;
    protected Rigidbody2D rb;
    public LayerMask m_bulletPassThrough;
    protected bool isShooting;
    protected bool readyToShoot = true;

    public void StartShot()
    {
        isShooting = true;
    }

    public void EndShot()
    {
        isShooting = false;
    }
}
    