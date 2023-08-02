using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    Transform orign;

    public enum Weapon
    {
        LightAssaultRifle,
        PumpShotgun,
    }
    public Weapon currentWeapon;
    public WeaponData weaponData;
    public int ammo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
