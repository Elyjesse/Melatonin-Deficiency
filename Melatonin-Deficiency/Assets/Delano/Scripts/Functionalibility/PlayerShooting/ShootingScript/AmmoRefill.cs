using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class AmmoRefill : MonoBehaviour
{
    //refrences

    public Gun gunscript;

    //properties
    public float bulletsToGive;
    public bool bullletTypeGrenade, bulletTypeRifle;
    public float slots;
    //make randomizer ammo type
    //randomize bullets within one mag to three mags (incase of grenades it's f)
    //using random

    //instantiate on destroy/pickup of this object

    //first randomize slots within 1-4



    void PickItUp()
    {
        //how many slots?

        slots = Random.Range(1, 5);

        //assign weapon type to those random values


    }
}
