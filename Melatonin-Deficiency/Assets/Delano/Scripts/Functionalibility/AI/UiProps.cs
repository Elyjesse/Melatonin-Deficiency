using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UiProps : MonoBehaviour
{
    //refrences
    public NavMeshAgent navigator;
    public GameObject player;

    //properties
    public float rangeOfView;
    public float dist;
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
        
        //patrolling


        //shooting implemented next
    }
}
