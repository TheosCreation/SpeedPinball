using UnityEngine;

public class WeaponInput : MonoBehaviour
{
    private WeaponSwitch weaponSwitcher;
    private void Awake()
    {
        weaponSwitcher = GetComponentInChildren<WeaponSwitch>();
    }
    public void StartShot()
    {
        weaponSwitcher.currentWeapon.StartShot();
    }
    public void EndShot()
    {
        weaponSwitcher.currentWeapon.EndShot();
    }
}
