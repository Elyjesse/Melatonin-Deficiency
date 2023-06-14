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
    public float magezineSize, bulletsDispensed;
    public float bulletsLeft, BulletsInBag;
    public float bulletDiff;

    public bool allowToHoldButton; //only using with full-auto rifles. others are singleTap

    //prequisites

    public bool shootingRN, readyToShoot, reloading;

    //refrences

    public Camera firsplayerCam;
    public Transform attackPoint;
    public RaycastHit rHit;
    public LayerMask WhoIsEnemy;
    public KeyCode reload = KeyCode.G;


    public void InputForShooting()
    {
        if(allowToHoldButton == true)
        {
            shootingRN = Input.GetKey(KeyCode.Mouse0);
        }
        else
        {
            shootingRN = Input.GetKeyDown(KeyCode.Mouse0);
        }
        if (Input.GetKeyDown(reload) && bulletsLeft < magezineSize && !reloading)
        {


            //then do reload

            ReloadingTheGun();
        }

    }

    public void ReloadingTheGun()
    {
        //calculate how much more bullets need to add
        bulletsLeft -= magezineSize = bulletDiff;
        bulletDiff -= BulletsInBag;
        bulletsLeft = magezineSize;
    }

}
