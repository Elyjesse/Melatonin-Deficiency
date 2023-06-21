using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UiProps : MonoBehaviour
{
    //refrences
    public NavMeshAgent navigator;
    public NavMeshAgent navigator1;
    public GameObject player;

    //properties
    public float rangeOfView;
    public float dist;
    public float distToComrades;
    public bool checkWithinRange;

    //interaction

    private void Update()
    {
        //calculate distance within player and ai
        dist = Vector3.Distance(navigator.transform.position, player.transform.position);

        if(dist <= rangeOfView)
        {
            navigator.enabled = true;

            if(checkWithinRange == false)
            {
                print("navigator has activated again");
            }

            checkWithinRange = true;

            //follow the player
            navigator.SetDestination(player.transform.position);
        }
        else
        {
            if(checkWithinRange == true)
            {
                print("navmesh has shut down");

            }

            navigator.enabled = false;
            checkWithinRange = false;
        }
        
        //alarming nearby ai

        distToComrades = Vector3.Distance(navigator.transform.position, navigator1.transform.position);
        //ui works in duos, only one can alarm their teammate


        //shooting implemented next
    }
}
