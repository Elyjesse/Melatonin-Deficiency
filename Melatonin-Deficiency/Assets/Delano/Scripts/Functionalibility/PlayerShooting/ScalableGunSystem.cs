using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using Unity.VisualScripting;
using UnityEngine;

public class ScalableGunSystem : MonoBehaviour
{
    //gun stats
    public float damage;
    public float timeBetweenShots, spread, range, reloadSPD;
    public float magezineSize;
    public float bulletsLeft, BulletsInBag;
    public float bulletDiff;

    public bool allowToHoldButton; //only using with full-auto rifles. others are singleTap

    //prequisites

    public bool shootingRN, readyToShoot, reloading;

    //refrences

    public Camera firsplayerCam;
    public Transform attackPoint;
    public RaycastHit rHit;
    public LayerMask whoIsEnemy;
    public KeyCode reload = KeyCode.G;


    private void Update()
    {
        InputForShooting();
    }
    public void InputForShooting()
    {
        if(allowToHoldButton == true)
        {
            shootingRN = Input.GetKey(KeyCode.Mouse0);
            if (Input.GetKey(KeyCode.Mouse0))
            {
                print("shooting implied");
                if (readyToShoot && shootingRN && !reloading && bulletsLeft > 0)
                {
                    GiveEmHell();
                    //instantiate particle system at the base of the gun into the direction  of gun
                }
                else
                {
                    print("no more tears");
                }
            }
        }
        else
        {
            shootingRN = Input.GetKeyDown(KeyCode.Mouse0);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
            print("shooting implied");
                if (readyToShoot && shootingRN && !reloading && bulletsLeft > 0)
                {
                    GiveEmHell();
                    //instantiate particle system at the base of the gun into the direction  of gun
                }
                else
                {
                    print("no more tears");
                }
            }
        }
        if (Input.GetKeyDown(reload) && bulletsLeft < magezineSize && !reloading)
        {
            ReloadingTheGun();
        }

    }
    public void GiveEmHell()
    {
        readyToShoot = false;
        bulletsLeft--;

        //spread of the gun

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //direction of spread

        Vector3 directionOfBullets = firsplayerCam.transform.forward + new Vector3(x, y, 0);

        //raycast time
        if (Physics.Raycast(firsplayerCam.transform.position, directionOfBullets, out rHit, range))
        {
            Debug.Log(rHit.collider.name);

            if (gameObject.tag ==("Enemy"))
            {
                print("HasHit");
                
            }
        }

        Invoke("ResetShot", timeBetweenShots);
    }
    public void ResetShot()
    {
        readyToShoot = true;
    }

    public void ReloadingTheGun()
    {
        //calculate how much more bullets need to add
        bulletsLeft -= magezineSize = bulletDiff;
        bulletDiff -= BulletsInBag;
        bulletsLeft = magezineSize;
    }

}
