using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PickItUp : MonoBehaviour
{
    //refrences

    public Camera camPos;
    public GameObject Player;
    public Transform holdPos; // aka throwpoint
    public RaycastHit rHit;
    public WeaponManager armsAbroad;

    //keyBinds

    public KeyCode pickup = KeyCode.F;
    public KeyCode drop = KeyCode.Q;

    //properties

    public  bool hisObjectActive;
    public float rangeOfPickup;
    public Vector3 currentAngle;
    public float throwForce, throwForceUp;
    public Rigidbody projectileRB;
    public bool holdingArms;

    void Update()
    {
        if (Input.GetKeyDown(pickup))
        {
            print("pickup initialized");
            if (Physics.Raycast(camPos.transform.position, camPos.transform.forward, out rHit, rangeOfPickup))
            {
                //assign number to the picked up item 


                //if holdingWeapons = full then unable to puckup new weapon, the new weapon will be switched and old weapon will be sent to the pool
                print("raycast initialized");
                if (rHit.transform.tag == "Interract")
                {
                    armsAbroad.holdingWeapons = rHit.transform.gameObject;
                    holdingArms = true;

                    if(armsAbroad.numberOfTheBeast <= armsAbroad.maxNumber)
                    {
                        print("tag checked");

                        if(holdingArms == false)
                        {
                            PickItUpPls();
                        }
                    }

                    if(holdingArms == true)
                    {
                        //sending equipped item to the pool
                        armsAbroad.ToTheShadowRealm();

                        PickItUpPls();
                    }


                }
            }
        }
        if(hisObjectActive == true)
        {
            rHit.transform.SetParent(camPos.transform);
        }

        if (Input.GetKeyDown(drop))
        {
            DropThatNOW();
        }
        
    } 

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

    void DropThatNOW()
    {
        print("dropping initialized");
        rHit.rigidbody.useGravity = true;
        rHit.rigidbody.isKinematic = true;
        hisObjectActive= false;
        rHit.collider.isTrigger = false;

        //throw the gun
        projectileRB = rHit.transform.GetComponent<Rigidbody>();
        Vector3 forceDirection = camPos.transform.forward;
        if (Physics.Raycast(camPos.transform.position, camPos.transform.forward, out rHit, 500f))
        {
            forceDirection = (rHit.point - holdPos.position).normalized;
        }

        //may the force be with you
        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwForceUp;
        projectileRB.AddForce(forceToAdd, ForceMode.Impulse);
    }
}
