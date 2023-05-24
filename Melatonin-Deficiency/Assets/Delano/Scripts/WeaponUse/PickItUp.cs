using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Rendering.Universal.Internal;

public class PickItUp : MonoBehaviour
{
    public ItemsProperties props;

    public DetectRange rangeOf;
    public int rangeOfPickup;   

    public GameObject player;
    public GameObject clipp;
    public RaycastHit hitShit;

    // Update is called once per frame
    void Update()
    {

        if(props.equipped == true)
        {
            hitShit.collider.transform.position = clipp.transform.position;
        }
        //idee. dischtsbijzijnde object wordt geregistreeert, als het binnen rangeOfPickup is, ui popup. daaran input = equipped. controleren welk ding en bijbehorende properties koppelen
        //als properties zijn gekoppelt, koppel ui(gerrit) en daarna is het wapen klaar om te gebruiken inclusief matchende delay etc

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitShit))
        {
            if(hitShit.distance < rangeOfPickup)
            {
                if(gameObject.tag == "interactable")
                {
                    //ui popup
                    if (Input.GetKeyDown("e"))
                    {
                        props.equipped = true;
                        hitShit.collider.transform.position = clipp.transform.position;

                        //using short ifstatemens. if(object.tag == sowrd) etc. 
                    }

                    if (Input.GetKeyDown("e"))
                    {
                        if (props.equipped == true)
                        {
                            //swap current weapon for newest weapon
                            //oldweapon.transform.position = op grond gooien met bogje
                            //implement check for new weapon damage etc

                        }
                    }
                }
            }
        }
    }
}
