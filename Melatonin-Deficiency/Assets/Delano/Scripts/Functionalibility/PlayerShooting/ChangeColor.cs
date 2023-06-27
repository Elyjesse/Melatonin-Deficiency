using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    //change color of material depending on the type of weapon

    //refrences

    public Gun weaponizeTheKids;
    public Renderer rendering;

    private void Start()
    {
        rendering = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (weaponizeTheKids.fullAuto == true)
        {
            rendering.material.color = Color.white;
            
        }

        if (weaponizeTheKids.burstAutoRifle == true)
        {
            rendering.material.color = Color.green;
        }

        if (weaponizeTheKids.singleShot == true)
        {
            rendering.material.color = Color.black;
        }
    }
}
