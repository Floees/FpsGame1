using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public Weapon WhatWeaponAmI;


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            FpsPlayer p = other.GetComponent<FpsPlayer>();

            if (p == null)
            {
                return;
            }

            if (WhatWeaponAmI == Weapon.BulletGun)
            {
                p.BulletGunPickedUp = true;
                p.CurrentWeapon = WhatWeaponAmI;
                p.EquipWeapon();
                return;
            }
            if (WhatWeaponAmI == Weapon.LaserGun)
            {
                p.LaserGunPickedUp = true;
                p.CurrentWeapon = WhatWeaponAmI;
                p.EquipWeapon();
                return;
            }

            Destroy(gameObject);
        }
    }
}
