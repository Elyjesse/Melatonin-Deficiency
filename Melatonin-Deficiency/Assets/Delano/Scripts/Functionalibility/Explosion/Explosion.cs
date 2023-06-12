using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float ExplosionDelay;
    public float countdown;
    public bool hasExploded = false;

    public GameObject grenades;

    // Start is called before the first frame update
    void Start()
    {
        countdown = ExplosionDelay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0f && hasExploded == false)
        {
            ExplosionInitializedd();
            hasExploded = true;
        }
    }

    void ExplosionInitializedd()
    {
        print("kaboom initialized");

        Instantiate(grenades, transform.position, transform.rotation);

        //get nearby forces and sent them airbourne

        //damage

        Destroy(gameObject);


    }
}
