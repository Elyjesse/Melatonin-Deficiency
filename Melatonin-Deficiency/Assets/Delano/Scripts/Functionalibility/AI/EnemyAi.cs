using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent007;

    public Transform playerNav;

    public LayerMask whatsThaGround, whatsThaPlayer;


    //partolling ui

    public Vector3 walkPoint;
    public bool walkPointIsSetup;
    public float detectRange;

    //enemy attack ai

    public float attackInterval;
    public bool hasAttacked;
    //tets
}
