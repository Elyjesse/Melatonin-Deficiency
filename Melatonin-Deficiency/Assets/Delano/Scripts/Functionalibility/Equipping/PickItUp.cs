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

    public  bool hisObjectActive;
    public float rangeOfPickup;
    public Vector3 currentAngle;
    public float throwForce, throwForceUp;
    public bool holdingArms;
    public bool hasDropped;

    void Update()
    {
        if (Input.GetKeyDown(pickup))
        {
            if (Physics.Raycast(camPos.transform.position, camPos.transform.forward, out rHit, rangeOfPickup))
            {
                gunRB = rHit.transform.gameObject.GetComponent<Rigidbody>();
                coll = rHit.transform.gameObject.GetComponent<Collider>();
                interactedGun = rHit.transform.gameObject;

                if (rHit.transform.tag == "Interract")
                {
                    rHit.transform.position = holdPos.transform.position;
                    coll.isTrigger = true;
                    interactedGun.isStatic = true;
                    gunRB.isKinematic = true;
                    gunRB.useGravity = false;
                    currentAngle =new Vector3(-90, -15, -114);
                    interactedGun.transform.eulerAngles = currentAngle;
                    hisObjectActive = true;
                }
            }
        }
        if(hisObjectActive == true)
        {
            rHit.transform.SetParent(camPos.transform);
        }
        else
        {
                    interactedGun.transform.SetParent(weaponPool.transform);
                    print("parent set");
        }

        if (Input.GetKeyDown(drop))
        {
            DropThatNOW();
        }
        
    } 
    /*
    void PickItUpPls()
    {
        {
            Debug.Log(rHit.collider.name);

            rHit.transform.eulerAngles = camPos.transform.forward;
            rHit.transform.position = holdPos.transform.position;
            rHit.rigidbody.useGravity = false;
            rHit.rigidbody.isKinematic = false;
            rHit.collider.isTrigger = true;
            hisObjectActive = true; 

            
        }
    }
    */
    void DropThatNOW()
    {
        //rather than using rigidbodu, assign a gameO bject and link that to the gameObject hiot with raycast
        print("dropping initialized");

        rHit.rigidbody.useGravity = true;
        rHit.rigidbody.isKinematic = true;
        hisObjectActive= false;
        rHit.collider.isTrigger = false;
        hasDropped = true;
        if(hasDropped == true)
        {
            print("definetively dropped");
        }

        //throw the gun

        gunRB = interactedGun.GetComponent<Rigidbody>();


        Vector3 forceToAdd = camPos.transform.forward * throwForce + transform.up * throwForceUp;
        gunRB.AddForce(forceToAdd, ForceMode.Impulse);
        interactedGun.transform.SetParent(null);
    }
}
