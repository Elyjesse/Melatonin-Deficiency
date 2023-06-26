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

    //keyBinds

    public KeyCode pickup = KeyCode.F;
    public KeyCode drop = KeyCode.Q;

    //properties

    public static bool equippedThisObject;
    public float rangeOfPickup;
    public Vector3 currentAngle;

    void Update()
    {
        if (Input.GetKeyDown(pickup))
        {
            PickItUpPls();
            
        }
        if(equippedThisObject == true)
        {
            //rHit.transform.position = holdPos.transform.position;
            rHit.transform.SetParent(camPos.transform);
            rHit.transform.eulerAngles = holdPos.transform.eulerAngles;
        }
    } 

    void PickItUpPls()
    {
        if(Physics.Raycast(camPos.transform.position, camPos.transform.forward, out rHit, rangeOfPickup))
        {
            if(rHit.transform.gameObject.tag == "interactable")
            {
                Debug.Log(rHit.collider.name);

                rHit.transform.position = holdPos.transform.position;
                //currentAngle = new Vector3(-111, -556, 35);
                //rHit.transform.eulerAngles = currentAngle;
                rHit.rigidbody.useGravity = false;
                rHit.rigidbody.isKinematic = false;
                rHit.collider.isTrigger = true;
                equippedThisObject = true;
            }   
        }
    }

    void DropThatNOW()
    {
        //just yeet it with physics

        rHit.rigidbody.useGravity = true;
        rHit.rigidbody.isKinematic = true;
        equippedThisObject = false;
        rHit.collider.isTrigger = false;
    }
}
