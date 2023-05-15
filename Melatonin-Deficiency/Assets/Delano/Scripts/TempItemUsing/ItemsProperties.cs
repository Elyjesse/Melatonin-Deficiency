using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsProperties : MonoBehaviour
{
    public GameObject longSword;
    public GameObject dagger;
    public GameObject healthPotion;
    public GameObject fists;
    public GameObject Player;
    public GameObject clippingPoint;



    //short names consisting of first character of every word. example Health potion would be Hp;
    //UseDura == durability;
    //DuraCost == durabilityCost;
    //useStam = use of stamina;
    //stamCost = cost of stamina per action;
    //dmgDealing = ammount of damage dealt per hit;
    //dmgHeal = ammount healed when consuming certain things;
    //delayUse = delay used per action to prevent spamming using time.deltatime;
    public bool lSequipped, dEquipped, hPequipped, fEquipped;
    public bool lSusedura, dUseDura, hPuseDura, fUseDura;
    public bool lSuseStam, dUseStam, hPuseStam, fUseStam;
    public bool emptyHand;
    public bool usingRn;
    public bool noInput;

    public float lsDuraCost, dDuraCost, hPduraCost, fDuraCost;
    public float lSstamCost, dStamCost, hPstamCost, fStamCost;
    public float lSdmgDealing, dDmgDealing, fDmgDealing;
    public float hPheal;
    public float lSdelayUse, dDelayUse, hPdelayUse, fDelayUse;
    public float usesThisStamina, usesThisDmg, usesThisDura;

    //player part
    public float currentPlayerStam, maxStam, currentHp, maxHP, currentItemSlots, maxItemSlots;

    // Update is called once per frame
    void Update()
    {
        if(lSequipped == true)
        {
            usesThisStamina = lSstamCost;
            usesThisDmg = lSdmgDealing;
            usesThisDura = lsDuraCost;
            emptyHand = false;
        }

        if (dEquipped == true)
        {
            usesThisStamina = dStamCost;
            usesThisDmg = dDmgDealing;
            usesThisDura = dDuraCost;
            emptyHand = false;
        }


        if (hPequipped == true)
        {
            usesThisStamina = hPstamCost;
            usesThisDmg = hPheal;
            usesThisDura = hPduraCost;
            emptyHand = false;
        }

        if (fEquipped == true)
        {
            usesThisStamina = fStamCost;
            usesThisDmg = fDmgDealing;
            usesThisDura = fDuraCost;
            emptyHand = false;
        }


    }



}
