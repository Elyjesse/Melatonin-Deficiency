using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Animations;

public class Health : MonoBehaviour
{
    //keybinds
    //if equipped the healing flask
    public KeyCode usingItems = KeyCode.Mouse2;
    public GameObject playerOne;

    //properties
    public float health, maxHealth, healthRegen;
    public float intervalOfHeal;

    private void Update()
    {
        if (health <= 0f)
        {
            Destroy(playerOne);
        }
    }
}
