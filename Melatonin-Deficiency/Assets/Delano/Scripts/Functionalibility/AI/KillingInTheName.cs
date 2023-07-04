using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;

public class KillingInTheName : MonoBehaviour
{
    public Collider colliderOfKnife;
    public Health healthOfPlayer;

    public float damageDealing;
    public bool healthRecieved;

    private void Start()
    {
        CollectingColl();
    }
    void CollectingColl()
    {
        colliderOfKnife = gameObject.GetComponent<BoxCollider>();
    }



    public void OnTriggerEnter(Collider coll)
    {
        if(coll.transform.tag == "Player")
        {
            print("has entered");
            print(coll.transform.tag);
            //get health script
            healthOfPlayer = coll.gameObject.GetComponent<Health>();
            print("health script recieved");
            DealingDamage();
        }
    }

    void DealingDamage()
    {
        damageDealing -= healthOfPlayer.health;
        print("dealingDamage");
    }

}
