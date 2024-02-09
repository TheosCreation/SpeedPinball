using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Weapons : MonoBehaviour
{
    // Start is called before the first frame update

    public bool pistol = true;
    public bool shotgun = false;
    public bool assaultRifle = false;
    public bool bomba = false;
    public int m_CurrentWeapon = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_CurrentWeapon)
        {
            case 0:
                if (Input.GetMouseButtonDown(0)) { 
                   
                }
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
