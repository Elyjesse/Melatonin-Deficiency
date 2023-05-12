using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectController : ScriptableObject
{

    public bool interactable;
    public bool hasWearAndTear;
    public bool usesStamina;

    public float staminaCost;
    public float durabilityLostOnUse;
}