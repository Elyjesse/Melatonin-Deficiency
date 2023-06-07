using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyMovement : MonoBehaviour
{
    //variables

    //camera
    public float sensX;
    public float sensY;
    public float rotX;
    public float rotY;
    public float mouseX;
    public float mouseY;
    public float maxX;
    public float minX;

    //wasd

    //general
    public Transform orientation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensX;
        mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensY;

        rotX -= mouseY;
        rotY += mouseX;

        rotX = Mathf.Clamp(rotX, maxX, minX);

        transform.rotation = Quaternion.Euler(rotX, rotY, 0);
        orientation.rotation = Quaternion.Euler(0, rotY, 0);
    }
}
