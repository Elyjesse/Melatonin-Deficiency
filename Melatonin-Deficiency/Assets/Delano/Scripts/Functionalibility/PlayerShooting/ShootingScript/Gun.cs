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
    public bool allowedToShoot;


    //ammo
    public float magSize, bulletsInBag, bulletsInMag, bulletsDiff;
    public bool magIsFull;

    //keyBinds

    public KeyCode firing = KeyCode.Mouse0;
    public KeyCode reloading = KeyCode.R;

    //object refrences

    public RaycastHit rHit;
    public Camera fpsCam;
    public EquippingWeapon equipp;

    // Update is called once per frame
    void Update()
    {
        if(bulletsInMag >= 0f)
        {
            allowedToShoot = true;
        }
        else
        {
            allowedToShoot = false;
        }

        if(allowedToShoot == true)
        {
            if (equipp.equipped == true)
            {
        ShootingImplied();
            }
        }

        if (burstAutoRifle)
        {
            bulletsPerShot = 3f;
        }

        else
        {
            bulletsPerShot = 1f;
        }

        if (Input.GetKeyDown(reloading))
        {
            
        }
    }

    void ShootingImplied()
    {
        if(fullAuto == true)
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
                print("reloading now");

                if (bulletsInMag == magSize)
                {
                    print("Mag is already full.");
                    magIsFull = true;
                }

                if (bulletsInMag <= magSize)
                {
                    magIsFull = false;
                }

                else if (magIsFull == false)
                {
                    print("Reloading magazine");

                    //calculate difference in bullets

                    bulletsInMag -= magSize = bulletsDiff;
                    bulletsDiff -= bulletsInBag;
                    bulletsInMag = magSize;
                }
            }
        }
    }
}