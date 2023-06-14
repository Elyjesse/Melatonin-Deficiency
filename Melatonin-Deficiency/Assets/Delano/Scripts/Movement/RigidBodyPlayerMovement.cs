using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class RigidBodyPlayerMovement : MonoBehaviour
{
    public float moveSpd;
    public float hor;
    public float ver;
    public float multiplier;
    public float walkStamUse;

    public Vector3 moveDir;

    public Transform orientations;

    Rigidbody thisRB;

    //ifgrounded
    public float playerHeight;
    public LayerMask whatsGrounded;
    public bool grounded;

    public float groundDrag;

    //jump(van halen)

    public float jumpForce;
    public float jumpcooldown;
    public float jumpStamConsume; //intergrated with stamina use system
    public float airMultiplier;
    public bool readyPlayerOne;
    public KeyCode jumpKey = KeyCode.Space;

    //stamina
    public ItemsProperties props;

    //kuru kuru kuruuuuuu
    //how it works, shoot raycast to floor to check if touched


    // Start is called before the first frame update
    void Start()
    {
        thisRB = GetComponent<Rigidbody>();
        thisRB.freezeRotation = true;
    }

    private void Update()
    {
        ThisInput();
        SpeedLimiter();

        //groundedcheck

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatsGrounded);

        //drag manager

        if (grounded)
        {
            thisRB.drag = groundDrag;
        }
        else
        {
            thisRB.drag = 0;
        }
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void ThisInput()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        //when to jump

        if(Input.GetKey(jumpKey) && readyPlayerOne && grounded)
        {
            readyPlayerOne = false;
            JumpingJack();
            Invoke(nameof(ResetJump), jumpcooldown);

        }
    }
    private void MovePlayer()
    {
        //find out movement direction

        moveDir = orientations.forward * ver + orientations.right * hor;
        //always walking in direction yr looking at
        if (grounded)
        {
        thisRB.AddForce(moveDir.normalized * moveSpd * multiplier, ForceMode.Force);
        }
        else if(!grounded)
        {
            thisRB.AddForce(moveDir.normalized * moveSpd * multiplier * airMultiplier, ForceMode.Force);
        }
    }

    private void SpeedLimiter()
    {
        Vector3 flatVel = new Vector3(thisRB.velocity.x, 0f, thisRB.velocity.z);
        //actual limiter
        if(flatVel.magnitude > moveSpd)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpd;
            thisRB.velocity = new Vector3(limitedVel.x, thisRB.velocity.y, limitedVel.z);

            //if faster than move speed make calculation and send a cap
        }
    }

    private void JumpingJack()
    {
        //first reset y velo to prevent forward jump
        thisRB.velocity = new Vector3(thisRB.velocity.x, 0f, thisRB.velocity.z);

        thisRB.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyPlayerOne = true;
    }
}
