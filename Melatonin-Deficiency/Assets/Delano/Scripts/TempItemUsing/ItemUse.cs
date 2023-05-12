using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class ItemUse : MonoBehaviour
{
    public RaycastHit rhit;
    public ItemsProperties props;
    // Update is called once per frame
    void Update()
    {
        if(props.emptyHand == true)
        {
            if (Input.GetKeyDown("e"))
            {
                if (Physics.Raycast(transform.position, transform.forward, out rhit, 2))
                {
                    if(rhit.transform.gameObject.tag == "interactable")
                    {
                        rhit.transform.position = props.clippingPoint.transform.position;
                    }
                }
            }
        }
    }
}
