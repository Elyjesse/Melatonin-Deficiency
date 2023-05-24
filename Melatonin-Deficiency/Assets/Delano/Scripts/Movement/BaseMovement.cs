using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : MonoBehaviour
{
    //wasd
    public Vector3 vec3;
    public float moveSpd;
    public float hor;
    public float ver;

    //cam
    public float minX = -40f;
    public float maxX = 40f;
    public float camSpd;
    public float sensX;
    public float sensY;
    public float rotX;
    public float rotY;

    public Camera cam;
    public ItemsProperties prop;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(prop.currentPlayerStam == 0)
        {
            moveSpd = 0;
        }

        if (prop.currentPlayerStam > 0)
        {
            moveSpd = 3;
        }

        ver = Input.GetAxis("Vertical");
        vec3.z = ver;

        hor = Input.GetAxis("Horizontal");
        vec3.x = hor;

        transform.Translate(vec3 * moveSpd * Time.deltaTime);

        if (hor == 0 && ver == 0)
        {
            prop.noInput = true;
        }
        else
        {
            prop.noInput = false;
        }

        if(hor > 0 && ver > 0)
        {
            prop.currentPlayerStam -= 0.1f;
        }

        if (hor < 0 && ver < 0)
        {
            prop.currentPlayerStam -= 0.1f;
        }

        //cam

        rotY += Input.GetAxis("Mouse X") * sensX;
        rotX += Input.GetAxis("Mouse Y") * sensY;

        rotX = Mathf.Clamp(rotX, minX, maxX);

        Quaternion target = Quaternion.Euler(-rotX, rotY, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * camSpd);
    }
}
