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
        SelectWeapon(selectedWeapon);
        
    }
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
            SelectWeapon(selectedWeapon);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            selectedWeapon = 1;
            SelectWeapon(selectedWeapon);
        }
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
        SelectWeapon(selectedWeapon);
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
        SelectWeapon(selectedWeapon);
    }
    public void SelectWeapon(int _selectedWeapon)
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == _selectedWeapon)
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
