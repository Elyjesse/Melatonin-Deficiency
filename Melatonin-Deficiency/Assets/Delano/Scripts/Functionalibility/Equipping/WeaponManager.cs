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

    public int weaponPool;
    public int weaponsInInv;

    //keyBinds
    public KeyCode switching = KeyCode.Tab;

    //refernces
    public Gun burstAuto;
    public Gun automaticGun;
    public Gun singleShot;
    public PickItUp pickDatUp;

    private void Update()
    {
        if (Input.GetKeyDown(switching))
        {
            SwitchingTeams();
        }
    }

    public void SwitchingTeams()
    {
        //check how many weapons are in the "pool"

        //assign number to weapons differing from order of entry. 

        //switching with TAB within weapons. 
    }
}
