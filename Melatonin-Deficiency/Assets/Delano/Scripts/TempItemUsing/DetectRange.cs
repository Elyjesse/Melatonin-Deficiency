using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class DetectRange : MonoBehaviour
{

    //range detect
    public float distLs, distHP, distF, distD;

    public GameObject player;
    public GameObject other;
    public GameObject clippingPoint;
    public GameObject sword, healthpotion, fists, dagger;

    // Update is called once per frame
    void Update()
    {
        distLs = Vector3.Distance(player.transform.position, other.transform.position);
        distHP = Vector3.Distance(player.transform.position, other.transform.position);
        distF = Vector3.Distance(player.transform.position, other.transform.position);
        distD = Vector3.Distance(player.transform.position, other.transform.position);
    }
}

