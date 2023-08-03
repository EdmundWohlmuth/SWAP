using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Transform orign;
    public GameObject bullet;
    public GameObject crosshair;

    bool canShoot;
    public bool isAi;

    float fireRateTimer;
    float reloadTimer;
    int bulletSpeed = 30;

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
        ammo = weaponData.ammoBeforeReload;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canShoot) FireRate();
    }

    public void Shoot()
    {
        if (weaponData == null)
        {
            Debug.LogError("weaponData not found");
            return;
        }
       

        if (ammo <= 0) Reload();
        else if (canShoot)
        {
            //Debug.Log("BANG!");
            ammo--;
            Vector3 bulletDirectrion = crosshair.transform.position - orign.position;

            // instantiate bullet
            for (int i = 0; i < weaponData.projectilesPerShot; i++)
            {
                float spreadX = Random.Range(-weaponData.bulletSpread, weaponData.bulletSpread);
                float spreadY = Random.Range(-weaponData.bulletSpread, weaponData.bulletSpread);

                Vector3 directionWithSpread = bulletDirectrion + new Vector3(spreadX, spreadY, 0f);
                bulletDirectrion = directionWithSpread;

                GameObject currentBullet = Instantiate(bullet, orign.position, Quaternion.identity);
                currentBullet.GetComponent<Rigidbody2D>().AddForce(bulletDirectrion.normalized * bulletSpeed, ForceMode2D.Impulse);
            }
            

        }
    }

    void Reload()
    {
        Debug.Log("Click");
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
