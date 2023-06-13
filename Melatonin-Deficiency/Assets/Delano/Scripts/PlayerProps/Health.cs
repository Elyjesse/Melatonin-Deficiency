using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Animations;

public class Health : MonoBehaviour
{
    public TextMeshProUGUI healthUI;

    public ItemsProperties props;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthUI.text = props.currentHp.ToString();
    }
}
