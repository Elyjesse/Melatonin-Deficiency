using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class StamDrain : MonoBehaviour
{
    public ItemsProperties props;

    public float use;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(props.equipped == true)
        {
            if(props.usingRn == true)
            {
                props.currentPlayerStam -= use * props.usesThisStamina;
            }
        }
    }
}


/*
        new vector3 elk frame. daarna vergelijken met distance van vorige frame. daarna multiplyen met factor van drain (bijv 2.0f) en zo dus met afgelegde afstand stamina scalen 
 */
