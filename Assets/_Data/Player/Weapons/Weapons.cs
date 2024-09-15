using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : SaiMonoBehaviour
{
    [SerializeField] protected List<WeaponAbtract> weapons;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWeapons();
    }

    protected virtual void LoadWeapons()
    {
        if (this.weapons.Count > 0) return;
        foreach (Transform child in transform)
        {
            WeaponAbtract weaponAbtract = child.GetComponent<WeaponAbtract>();
            if (weaponAbtract == null) continue;
            this.weapons.Add(weaponAbtract);
        }
        Debug.Log(transform.name + ": LoadWeapons", gameObject);
    }

    public virtual WeaponAbtract GetCurrentWeapon()
    {
        return this.weapons[0];
    }
}
