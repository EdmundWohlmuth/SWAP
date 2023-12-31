using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Transform orign;
    public GameObject bullet;
    public GameObject crosshair;

    public bool canShoot;
    public bool isAi;

    float fireRateTimer;
    float reloadTimer;
    int bulletSpeed = 30;
    public float aiSpreadModifier;

    public enum Weapon
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
    public Weapon currentWeapon;
    public WeaponData weaponData;
    public int ammo;

    // Start is called before the first frame update
    void Start()
    {
        ammo = weaponData.ammoBeforeReload;
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canShoot) FireRate();
        if (ammo <= 0) Reload();
    }

    public void Shoot(GameObject target)
    {
        if (weaponData == null)
        {
            Debug.LogError("weaponData not found");
            return;
        }


        
                
        else if (canShoot)
        {
            //Debug.Log("BANG!");           

            Vector3 bulletDirectrion = target.transform.position - orign.position;

            // instantiate bullet
            for (int i = 0; i < weaponData.projectilesPerShot; i++)
            {
                
                float spreadX = Random.Range(-weaponData.bulletSpread, weaponData.bulletSpread);
                float spreadY = Random.Range(-weaponData.bulletSpread, weaponData.bulletSpread);
                if (isAi)
                {
                    spreadX = spreadX * aiSpreadModifier;
                    spreadY = spreadY * aiSpreadModifier;
                }

                Vector3 directionWithSpread = bulletDirectrion + new Vector3(spreadX, spreadY, 0f);
                bulletDirectrion = directionWithSpread;

                GameObject currentBullet = Instantiate(bullet, orign.position, Quaternion.identity);
                currentBullet.GetComponent<Rigidbody2D>().AddForce(bulletDirectrion.normalized * bulletSpeed, ForceMode2D.Impulse);
                currentBullet.GetComponent<BulletController>().damage = weaponData.damagePerProjectile;
                if (isAi) currentBullet.GetComponent<BulletController>().isAi = true;
            }

            ammo--;
            fireRateTimer = 0;
            canShoot = false;
        }
    }

    void Reload()
    {
        //Debug.Log("Click");
        if (reloadTimer >= weaponData.reloadTime)
        {
            ammo = weaponData.ammoBeforeReload;
            reloadTimer = 0;
            canShoot = true;
        }
        else
        {
            reloadTimer += Time.deltaTime;
            canShoot = false;
        }
    }

    void FireRate()
    {
        if (weaponData == null)
        {
            Debug.LogError("weaponData not found");
            return;
        }

        if (fireRateTimer >= weaponData.fireRate)
        {
            fireRateTimer = weaponData.fireRate;
            canShoot = true;
        }
        else
        {
            fireRateTimer += Time.deltaTime;
            canShoot = false;
        }
    }
}
