using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stamina : MonoBehaviour
{
    public ItemsProperties props;

    public bool rechargingRn1;
    public bool rechargingRn2;

    public float rechargeRate;

    //public TextMeshProUGUI textMesh;

    // Update is called once per frame

    void Update()
    {
      //  textMesh.text = props.currentPlayerStam.ToString();
        if(props.currentPlayerStam >= props.maxStam)
        {
            props.currentPlayerStam = props.maxStam;
            //keep recharge on hold. 
        }

        if (props.usingRn == true)
        {
            props.currentPlayerStam -= props.usesThisStamina;
        }

        if (props.noInput == true)
        {
            rechargingRn1 = true;
            rechargingRn2 = false;
            StartCoroutine(WaitingSyst());
        }

        if(props.noInput == false)
        {
            rechargingRn1 = false;
            rechargingRn2 = true;
        }

        if(rechargingRn2 == true)
        {
            props.currentPlayerStam += Time.deltaTime * rechargeRate;
        }
        
        IEnumerator WaitingSyst()
        {
            yield return new WaitForSeconds(3f);

            if (rechargingRn1 == true)
            {
                props.currentPlayerStam += Time.deltaTime * rechargeRate;
                if (props.currentPlayerStam > props.maxStam)
                {
                    rechargeRate = 0f;
                    props.currentPlayerStam = props.maxStam;
                }
                if (props.currentPlayerStam < props.maxStam)
                {
                    rechargeRate = 6f;
                }
            }
        }
    }

}
