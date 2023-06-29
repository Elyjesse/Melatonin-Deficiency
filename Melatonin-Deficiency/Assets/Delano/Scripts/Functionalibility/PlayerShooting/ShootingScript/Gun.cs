using UnityEngine;

public class Gun : MonoBehaviour
{
    //weapon types
    public bool fullAuto;
    public bool singleShot;
    public bool burstAutoRifle;
    //gun properties

    public float damageDealing, range;
    public float bulletsPerShot;
    public static bool allowedToShoot;


    //ammo
    public float magSize, bulletsInBag, bulletsInMag, bulletsDiff;
    public bool magIsFull;

    //keyBinds

    public KeyCode firing = KeyCode.Mouse0;
    public KeyCode reloading = KeyCode.R;

    //object refrences

    public RaycastHit rHit;
    public Camera fpsCam;
    public PickItUp pickupTruck;

    // Update is called once per frame
    void Update()
    {
        
        if(pickupTruck.holdingArms == false)
        {
            allowedToShoot = false;
        }

        if(pickupTruck.holdingArms == true)
        {
            if (bulletsInMag <= magSize)
            {
                magIsFull = false;
            }

            if (bulletsInMag == magSize)
            {
                magIsFull = true;
            }
            if (bulletsInMag >= 0f)
            {
                allowedToShoot = true;
            }
            else
            {
                allowedToShoot = false;
            }

            if (allowedToShoot == true)
            {
                ShootingImplied();
            }

            if (burstAutoRifle == true)
            {
                bulletsPerShot = 3f;
            }

            else
            {
                bulletsPerShot = 1f;
            }
        }

        if (Input.GetKeyDown(reloading))
        {
            ReloadingTheGun();
        }

    }

    void ShootingImplied()
    {
        if (fullAuto == true)
        {
            if (Input.GetKey(firing))
            {
                print("Full Auto Firing");
                Shooting();
            }
        }
        else //this makes possible for both singleshot and burst shot
        {
            if (Input.GetKeyDown(firing))
            {
                print("Single Shot Firing");
                Shooting();
            }
        }
    }

    void Shooting()
    {
        bulletsInMag -=  bulletsPerShot;

        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out rHit, range))
        {
            Debug.Log(rHit.transform.name);

            EnemySwordsman enemies = rHit.transform.GetComponent<EnemySwordsman>();

            if(enemies != null)
            {
                enemies.TakeDMG(damageDealing * bulletsPerShot);
            }
        }
    }

    void ReloadingTheGun()
    {
        {
            if (magIsFull == false)
            {
                print("Reloading magazine");

                //calculate difference in bullets

                bulletsDiff = magSize - bulletsInMag;
                //magSize -= bulletsInMag = bulletsDiff;
                print("diff =");
                print(bulletsDiff);

                bulletsInBag-= bulletsDiff;

                bulletsInMag = magSize;

                bulletsDiff = 0f;

                magIsFull = true;
            }
        }
    }
}
