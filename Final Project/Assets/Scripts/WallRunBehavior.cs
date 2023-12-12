using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRunBehavior : MonoBehaviour
{
    [Header("Wallrunning")]
    public LayerMask whatIsWall;
    public LayerMask whatIsGround;
    public float wallRunForce;
    public float wallJumpUpForce;
    public float wallJumpSideForce;
    public float maxWallRunTime;
    private float wallRunTimer;

    [Header("Input")]
    public KeyCode jumpKey = KeyCode.Space;
    private float horizontalInput;
    private float verticalInput;

    [Header("Detection")]
    public float wallCheckDistance;
    public float minJumpHeight;
    private RaycastHit leftWallhit;
    private RaycastHit rightWallhit;
    private bool wallLeft;
    private bool wallRight;

    [Header("Exiting")]
    private bool exitingWall;
    public float exitWallTime;
    private float exitWallTimer; 


    [Header("Reference")]
    public Transform orientation;
    private PlayerBehavior movement;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movement = GetComponent<PlayerBehavior>();
    }

    void Update()
    {
        CheckforWall();
        StateMachine();
    }

    private void FixedUpdate()
    {
        if (movement.wallrunning)
            WallRunningMomvement();
    }

    private void CheckforWall()
    {
        wallRight = Physics.Raycast(transform.position, orientation.right, out rightWallhit, wallCheckDistance, whatIsWall);
        wallLeft = Physics.Raycast(transform.position, -orientation.right, out leftWallhit, wallCheckDistance, whatIsWall);
    }

    private bool AboveGround()
    {
        return !Physics.Raycast(transform.position, Vector3.down, minJumpHeight, whatIsGround);
    }

    private void StateMachine()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if ((wallLeft || wallRight) && verticalInput > 0 && AboveGround() && !exitingWall)
        {
            if (!movement.wallrunning)
                StartWallRun();

            if (Input.GetKeyDown(jumpKey))
                WallJump();
        }

        else if (exitingWall)
        {
            if (movement.wallrunning)
                StopWallRun();

            if (exitWallTimer > 0)
                exitWallTimer -= Time.deltaTime;

            if (exitWallTimer <= 0)
                exitingWall = false;

        }
        else
        {
            if (movement.wallrunning)
                StopWallRun();
        }
    }

    private void StartWallRun()
    {
        movement.wallrunning = true;
    }

    private void WallRunningMomvement()
    {
        rb.useGravity = false;
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        Vector3 wallNormal = wallRight ? rightWallhit.normal : leftWallhit.normal;

        float dotProduct = Vector3.Dot(transform.forward, wallNormal);

        Vector3 wallForward = dotProduct > 0f ? Vector3.Cross(transform.up, wallNormal) : Vector3.Cross(wallNormal, transform.up);

        Vector3 wallUpCross = Vector3.Cross(-orientation.forward, wallNormal);
        wallForward = Vector3.Cross(wallUpCross, wallNormal);

        rb.AddForce(wallForward * wallRunForce, ForceMode.Force);

        if(!(wallLeft && horizontalInput >0) && !(wallRight && horizontalInput < 0))
        rb.AddForce(-wallNormal * 100, ForceMode.Force);
    }

    private void StopWallRun()
    {
        rb.useGravity = true;
        movement.wallrunning = false;
    }

    private void WallJump()
    {
        exitingWall = true;
        exitWallTimer = exitWallTime;
        Vector3 wallNormal = wallRight ? rightWallhit.normal : leftWallhit.normal;

        Vector3 forceToApply = transform.up * wallJumpUpForce + wallNormal * wallJumpSideForce;

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(forceToApply, ForceMode.Impulse);
    }
}
