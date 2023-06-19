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


    //interaction

    private void Update()
    {
        navigator.SetDestination(player.transform.position);
    }
}
