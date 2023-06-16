using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippingWeapon : MonoBehaviour
{
    //refrences

    public Gun gunScript;
    public Rigidbody rb;
    public MeshCollider mC;
    public Transform player, gunContainer, fpsCam;
    public KeyCode interact = KeyCode.E;
    public KeyCode letDown = KeyCode.Q;

    //properties

    public float range;
    public float fwForce, uwForce;

    public bool equipped;
    public static bool slotsFull; //the same in every script.replacement for scriptableObjectChecker

    private void Update()
    {
        Vector3 distanceToPlayer = player.position -= transform.position;
        if (!equipped && distanceToPlayer.magnitude <= range && Input.GetKeyDown(interact) && !slotsFull)
        {
            Pickup();
        }

        //drop when press letDown
        if(equipped && Input.GetKeyDown(letDown))
        {
            Drop();
        }
    }

    void Pickup()
    {
        equipped = true;
        slotsFull = true;

        //make rb kinematic and make collider a trigger

        rb.isKinematic = true;
        mC.isTrigger = true;

        //enable gun script

        gunScript.enabled = true;
    }

    void Drop()
    {
        equipped = true;
        slotsFull = true;

        //revert rb kinematic and make collider a trigger

        rb.isKinematic = false;
        mC.isTrigger = false;

        //disabled gun script

        gunScript.enabled = false;
    }
}
