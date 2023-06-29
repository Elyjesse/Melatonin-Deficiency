using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISysteem : MonoBehaviour
{
    public Slider healthP;
    public Slider stamP;
    public ItemsProperties props;
    public ItemsProperties maxStam;

    public void SetStamina(int maxStam)
    {
        stamP.value = maxStam; 
    }
}
