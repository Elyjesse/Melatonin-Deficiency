using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "potionH", menuName = "Slow Health Regen", order = 1)]

public class HealthPotion : Consumable
{
    public int healthOverTime;
}
