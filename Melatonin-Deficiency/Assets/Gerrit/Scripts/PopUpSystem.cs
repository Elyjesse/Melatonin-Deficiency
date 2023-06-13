using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PopUpSystem : MonoBehaviour
{

    public GameObject popUpBox;
    public Animator animator;
    private void Start()
    {
            popUpBox.SetActive(false);
            Cursor.visible = false;
    }
    
    public void Update() 
    { 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           
            if (!popUpBox.activeSelf)
            {
                popUpBox.SetActive(true);
                animator.SetTrigger("pop");
            }
            else
            {
                animator.SetTrigger("close");
                StartCoroutine(Close());
            }

            if (!popUpBox.activeSelf)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    private IEnumerator Close ()
    {
        yield return new WaitForSeconds(1f);
        popUpBox.SetActive(false);

    }

}
