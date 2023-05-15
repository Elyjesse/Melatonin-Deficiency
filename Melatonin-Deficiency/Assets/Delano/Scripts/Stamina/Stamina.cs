using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stamina : MonoBehaviour
{
    public ItemsProperties props;

    public bool rechargingRn;

    public float rechargeRate;

    public TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh.text = props.currentPlayerStam.ToString();
    }
    // Update is called once per frame

    void Update()
    {
        if (props.usingRn == true)
        {
            props.currentPlayerStam -= props.usesThisStamina;
        }

        if(props.noInput == true)
        {
            rechargingRn = true;
            StartCoroutine(WaitingSyst());
        }
        
        IEnumerator WaitingSyst()
        {
            yield return new WaitForSeconds(3f);

            if (rechargingRn == true)
            {
                props.currentPlayerStam += rechargeRate;
                if (props.currentPlayerStam > props.maxStam)
                {
                    rechargeRate = 0f;
                    props.currentPlayerStam = props.maxStam;
                }
                if (props.currentPlayerStam < props.maxStam)
                {
                    rechargeRate = 2f;
                }
            }
        }
    
    }

}
