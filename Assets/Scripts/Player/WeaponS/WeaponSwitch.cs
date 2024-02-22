using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public scr_Weapons currentWeapon;
    public int selectedWeapon = 0;
    public int maxWeaponCount = 0;
    //public PlayerStateMachine playerStateMachine;

    private void Start()
    {
        currentWeapon = GetComponentInChildren<scr_Weapons>();
        SelectWeapon();
    }
    public void WeaponNext()
    {
        if (selectedWeapon >= transform.childCount - 1)
        {
            selectedWeapon = 0;
        }
        else
        {
            selectedWeapon++;
        }
        SelectWeapon();
    }
    public void WeaponPrevious()
    {
        if (selectedWeapon <= 0)
        {
            selectedWeapon = transform.childCount - 1;
        }
        else
        {
            selectedWeapon--;
        }
        SelectWeapon();
    }
    public void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
                currentWeapon = weapon.gameObject.GetComponent<scr_Weapons>();
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
