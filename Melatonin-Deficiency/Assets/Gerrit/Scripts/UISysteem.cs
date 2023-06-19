using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISysteem : MonoBehaviour
{
    public Slider healthP;
    public Slider stamP;
    public ItemsProperties props;
    public Stamina rechargingRn1;
    public Stamina rechargingRn2;
    public Stamina rechargeRate;
    public Stamina currentPlayerStam;
    public void SetStamina(int currentPlayerStam)
    {
        stamP.value = currentPlayerStam;
    }
}
