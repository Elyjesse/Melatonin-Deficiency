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
    public float minX = -60f;
    public float maxX = 60f;
    public float camSpd;
    public float sensX;
    public float sensY;
    public float rotX;
    public float rotY;

    public Camera cam;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //wasd movement below
        ver = Input.GetAxis("Vertical");
        vec3.z = ver;

        hor = Input.GetAxis("Horizontal");
        vec3.x = hor;

        transform.Translate(vec3 * moveSpd * Time.deltaTime);


        //cam movement below
        rotY += Input.GetAxis("Mouse X") * sensX;
        rotX += Input.GetAxis("Mouse Y") * sensY;

        rotX = Mathf.Clamp(rotX, minX, maxX);

        Quaternion target = Quaternion.Euler(-rotX, rotY, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * camSpd);
    }
}
