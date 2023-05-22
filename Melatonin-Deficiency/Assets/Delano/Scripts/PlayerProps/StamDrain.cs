using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class StamDrain : MonoBehaviour
{

    public float dist;
    public Vector3 playerDist;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


/*
        new vector3 elk frame. daarna vergelijken met distance van vorige frame. daarna multiplyen met factor van drain (bijv 2.0f) en zo dus met afgelegde afstand stamina scalen 
 */
