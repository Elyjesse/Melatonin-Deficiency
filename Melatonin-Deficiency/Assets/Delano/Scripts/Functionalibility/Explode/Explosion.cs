using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float forceStrength;
    public float cookingTime;
    public float countdown;

    public float radiusOfExplosion;
    public float powerOfExplosion;
    public float distanceToExplosion;
    public bool explosionDone;
    public bool initializingDone;
    public float damageDealing;

    //using scriptableObjects for the health is impossible since they get locked on build.
    public Rigidbody rb;
    public Transform[] affectedByExplosion;
    public GameObject particleOnExplo;
    public ItemsProperties props;
    public EnemySwordsman enemies;

    // Start is called before the first frame update
    void Start()
    {
        countdown = cookingTime;
    }

    // Update is called once per frame
    void Update()
    {
        

        countdown -= Time.deltaTime;
        if(countdown <= 0)
        {
            ExplosionInitiating();
        }
    }

    void ExplosionInitiating()
    {
        if(initializingDone == false)
        {
        print("explosion initialized");
        }

        if(explosionDone == true)
        {
            //do nothing
        }
        else
        {
            //Instantiate particle system.
            

            Instantiate(particleOnExplo);

            particleOnExplo.transform.position = this.transform.position;

            Vector3 explosionPosition = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPosition, radiusOfExplosion);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                rb.AddExplosionForce(powerOfExplosion, explosionPosition, radiusOfExplosion, 3.0f);


                if(explosionDone == false)
                {
                print("explosion done");
                }
                explosionDone = true;
                initializingDone = true;

                GiveDamage();
                print("destroying initialized");
                Destroy(this.gameObject);

                //start coroutine and wait for 3 seconds to destroy particle

            }


        }


         void GiveDamage()
        {
            Vector3 explosionPosition = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPosition, radiusOfExplosion);
            foreach (Collider hit in colliders)
            {

            }
        }
        //add force in all directions and set ovjects within range airborne

        //calculate range within explosion. if closer to the epicentre of the explosion, more damage. perhaps a calculation?
        //max distance = radius. if(distanceTo radius (within range, closer = damage * 3, further = damage * 1)

        //all objects hit get the state "wasHit"


        //deal damage

        //smoothly delete object

        //keep particle going for a sec to prevent hard transition
    }
}
