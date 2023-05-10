using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class DetectRange : MonoBehaviour
{
    //using scriptable objects
    public bool equipped;
    public bool breaksOverTime;
    public bool usesStamina;

    public float staminaCost;
    public float durability;
    public float damage;
    public float rangeOfHeldItem;


    //range detect
    public float range;

    public GameObject player;
    public GameObject other;
    public GameObject clippingPoint;

    // Update is called once per frame
    void Update()
    {
        if (equipped == true)
        {
            other.transform.position = clippingPoint.transform.position;
            other.transform.rotation = clippingPoint.transform.rotation;
        }

        if(equipped == false)
        {

        }

        range = Vector3.Distance(player.transform.position, other.transform.position);
        if (range < 5)
        {
            //pop up ui! gerrit zijn pakkie an

            //interaction code
            if (Input.GetKeyDown("e"))
            {
                equipped = true;


                if (Input.GetKeyDown("f"))
                {
                    equipped = false;
                }
            }
        }
    }
}
