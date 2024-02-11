using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Weapons : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float m_PistolRecoil = 1;

    [SerializeField] protected Transform m_gunPoint;
    [SerializeField] protected GameObject m_bulletTrail;
    [SerializeField] protected GameObject m_cameraRef;
    [SerializeField] protected float m_weaponRange;
    [SerializeField] protected Animator m_muzzleFlash;
    protected Rigidbody2D rb;

}
    