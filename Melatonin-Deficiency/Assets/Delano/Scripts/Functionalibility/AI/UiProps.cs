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

    //interaction

    private void Update()
    {
        //calculate distance within player and ai
        dist = Vector3.Distance(navigator.transform.position, player.transform.position);

        if(dist <= rangeOfView)
        {
            //follow the player
            navigator.SetDestination(player.transform.position);
        }
        else
        {
            navigator.Stop();
        }
        
        //patrolling


        //shooting implemented next
    }
}
