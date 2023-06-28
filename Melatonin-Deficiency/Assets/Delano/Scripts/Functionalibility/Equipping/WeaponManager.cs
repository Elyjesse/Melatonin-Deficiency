using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    //on all weapons. usage of static bools possible?

    //properties
    public bool equipped;
    public bool holdingWeapon;
    public GameObject[] weaponsInPool;
    public GameObject holdingWeapons;

    public int weaponPool;
    public int numberOfTheBeast;
    public int maxNumber;

    //keyBinds
    public KeyCode switching = KeyCode.Tab;

    //refernces
    public PickItUp pickDatUp;

    private void Update()
    {
        if (Input.GetKeyDown(switching))
        {
            SwitchingTeams();
        }
    }

    public void ToTheShadowRealm()
    {
        //send the weapon currently equipped to the pool

    }

    public void SwitchingTeams()
    {
        //check how many weapons are in the "pool" checking with the pickup. pickup will assign numbers to it first. 

        //assign number/ID to weapons differing from order of entry. 

        //switching with TAB within weapons. 
    }
}
