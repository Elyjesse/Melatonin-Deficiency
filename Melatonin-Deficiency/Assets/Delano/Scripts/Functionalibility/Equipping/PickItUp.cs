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



    void Update()
    {
        if (Input.GetKeyDown(pickup))
        {
            PickItUpPls();
        }
    }

    void PickItUpPls()
    {
        if(Physics.Raycast(camPos.transform.position, camPos.transform.forward, out rHit, rangeOfPickup))
        {
            Debug.Log(rHit.collider.name);
        }
    }

    void DropThatNOW()
    {

    }
}
