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

    public int lsDuraCost, dDuraCost, hPduraCost, fDuraCost;
    public int lSstamCost, dStamCost, hPstamCost, fStamCost;
    public int lSdmgDealing, dDmgDealing, fDmgDealing;
    public int hPheal;
    public int lSdelayUse, dDelayUse, hPdelayUse, fDelayUse;
    public int usesThisStamina, usesThisDmg, usesThisDura;

    //player part
    public int currentPlayerStam, maxStam, currentHp, maxHP, currentItemSlots, maxItemSlots;

    // Update is called once per frame
    void Update()
    {
        if(lSequipped == true)
        {
            usesThisStamina = lSstamCost;
            usesThisDmg = lSdmgDealing;
            usesThisDura = lsDuraCost;
        }

        if (dEquipped == true)
        {
            usesThisStamina = dStamCost;
            usesThisDmg = dDmgDealing;
            usesThisDura = dDuraCost;
        }


        if (hPequipped == true)
        {
            usesThisStamina = hPstamCost;
            usesThisDmg = hPheal;
            usesThisDura = hPduraCost;
        }

        if (fEquipped == true)
        {
            usesThisStamina = fStamCost;
            usesThisDmg = fDmgDealing;
            usesThisDura = fDuraCost;
        }
    }



}
