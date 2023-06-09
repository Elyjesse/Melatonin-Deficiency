using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThrowingShit : MonoBehaviour
{
    //variables

    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    //settings
    public int maxThrowAmmo;
    public int throwableAmmo; //experiment. not needed yet. would love to add ammo
    public float throwCoolDown;
    public float throwForce;
    public float throwForceUp;

    public bool readyToThrow;

    //hotkeying
    public KeyCode throwKey = KeyCode.T;
    public KeyCode reload = KeyCode.R;
    // Start is called before the first frame update
    void Start()
    {
        readyToThrow = true;
    }

    public void Update()
    {

        if(Input.GetKeyDown(throwKey) && readyToThrow && throwableAmmo > 0)
        {
            THrow();
        }

        if(throwableAmmo > maxThrowAmmo)
        {
            throwableAmmo = maxThrowAmmo;
        }
        if (Input.GetKeyDown(reload))
        {
            throwableAmmo = maxThrowAmmo;
        }
    }

    private void THrow()
    {
        readyToThrow = false;

        //instantiating "object to throw"

        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

        //get rigidbody

        Rigidbody projectileRB = projectile.GetComponent<Rigidbody>();

        //may the force be with you

        Vector3 forceToAdd = cam.transform.forward * throwForce + transform.up * throwForceUp;

        projectileRB.AddForce(forceToAdd, ForceMode.Impulse);

        throwableAmmo -= 1;

        Invoke(nameof(ResetCountDown), throwCoolDown);
    }

    private void ResetCountDown()
    {
        readyToThrow = true;

    }
}
