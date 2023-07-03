using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;

public class KillingInTheName : MonoBehaviour
{
    public Collider colliderOfKnife;
    public Health healthOfPlayer;

    public float damageDealing;

    private void Start()
    {
        CollectingColl();
    }
    void CollectingColl()
    {
        colliderOfKnife = gameObject.GetComponent<BoxCollider>();
    }



    public void OnCollisionEnter(Collision coll)
    {
        DealingDamage();
    }

    void DealingDamage()
    {
        damageDealing -= healthOfPlayer.health;
    }

}
