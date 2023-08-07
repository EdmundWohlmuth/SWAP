using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponData : ScriptableObject
{
    public AudioClip sound;

    public enum WeaponType
    {
        LightAssaultRifle,
        PumpShotgun,
        LightSMG,
        SemiAutoPistol,
        HeavyAssaultRifle,
        FullAutoShotgun,
        HeavySMG,
        HeavyRevolver
    }
    public WeaponType weaponType;

    // projectile settings
    public int ammoBeforeReload;
    public int damagePerProjectile;
    public int projectilesPerShot;
    public float reloadTime;

    public float fireRate;
    public float bulletSpread;

    public bool isAutoFire;
}
