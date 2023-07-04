using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Animations;

public class Health : MonoBehaviour
{
    //keybinds
    public GameObject playerOne;

    //properties
    public float health;

    private void Update()
    {
        if (health <= 0f)
        {
            Destroy(playerOne);
        }
    }
}
