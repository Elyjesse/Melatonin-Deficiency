using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PickItUp : MonoBehaviour
{
    //refrences

    public Camera camPos;
    public GameObject Player;
    public GameObject interactedGun;
    public Transform holdPos; // aka throwpoint
    public RaycastHit rHit;
    public Rigidbody gunRB;
    public Collider coll;
    public GameObject weaponPool;

    //keyBinds

    public KeyCode pickup = KeyCode.F;
    public KeyCode drop = KeyCode.Q;

    //properties

    public bool hisObjectActive;
    public float rangeOfPickup;
    public Vector3 currentAngle;
    public float throwForce, throwForceUp;
    public bool holdingArms;
    public bool hasDropped;
    public bool checkOne;

    void Update()
    {
        if (Input.GetKeyDown(pickup))
        {
            if(hisObjectActive == false)
            {
                checkOne = true;
                if (Physics.Raycast(camPos.transform.position, camPos.transform.forward, out rHit, rangeOfPickup))
                {
                    Debug.Log(rHit.transform.name);

                    if (rHit.transform.tag == "Interract")
                    {
                        holdingArms = true;
                        gunRB = rHit.transform.gameObject.GetComponent<Rigidbody>();
                        rHit.transform.gameObject.GetComponent<Collider>().isTrigger = true;
                        interactedGun = rHit.transform.gameObject;
                        rHit.transform.SetParent(holdPos);
                        rHit.transform.localPosition = Vector3.zero;
                        rHit.transform.localEulerAngles = Vector3.zero;
                        interactedGun.isStatic = true;
                        gunRB.isKinematic = true;
                        gunRB.useGravity = false;
                        checkOne = true;

                        interactedGun.transform.localEulerAngles = new Vector3(-90, 15, 55);
                    }

                }
            }
        }

        if(hisObjectActive == false)
        {
            if(checkOne == false)
            {
                print("sending to the shadow realm");
                SendToPool();
                checkOne = true;
            }
        }

        if (Input.GetKeyDown(drop))
        {
            DropThatNOW();
        }

    }
    void DropThatNOW()
    {
        //rather than using rigidbodu, assign a gameO bject and link that to the gameObject hiot with raycast
        gunRB = interactedGun.GetComponent<Rigidbody>();


        Vector3 forceToAdd = camPos.transform.forward * throwForce + transform.up * throwForceUp;
        gunRB.AddForce(forceToAdd, ForceMode.Impulse);
        interactedGun.transform.SetParent(null);
        print("dropping initialized");

        rHit.rigidbody.useGravity = true;
        rHit.rigidbody.isKinematic = true;
        hisObjectActive = false;
        rHit.collider.isTrigger = false;
        hasDropped = true;
        checkOne = false;
        holdingArms = false;
        if (hasDropped == true)
        {
            print("definetively dropped");
        }

        //throw the gun

    }

    void SendToPool()
    {
        interactedGun.transform.SetParent(weaponPool.transform);
    }
}