using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform orientation;
    [Header("Current Stats")]
    public float speed = 0;
    public int jump = 1;

    [Header("Movement")]
    public float movementSpeed;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public int jumpCount = 1;
    private bool isJumpOffCD = true;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask groundMask;
    public bool isGrounded;

    private float horizontalInput;
    private float verticalInput;

    // How far from the ground player can be to jump again
    private float groundJumpAllowance = 0.2f;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    Vector3 moveDirection;

    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        jump = jumpCount;
    }

    private void Update()
    {
        GroundCheck();

        SpeedControl();

        HandleInput();

        speed = rb.velocity.magnitude;
    }


    private void FixedUpdate()
    {
        Move();
    }
    private void HandleInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpKey) && isJumpOffCD)
        {
            if (jump > 0)
            {
                jump--;
                Jump();
                isJumpOffCD = false;
                Invoke(nameof(ResetJumpCooldown), jumpCooldown);
            }
            else if (isGrounded)
            {
                Jump();
                isJumpOffCD = false;
                Invoke(nameof(ResetJumpCooldown), jumpCooldown);
            }
        }
    }

    private void Move()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (isGrounded)
        {
            rb.AddForce(moveDirection.normalized * movementSpeed * 10f, ForceMode.Force);
        }
        else
        {
            rb.AddForce(moveDirection.normalized * movementSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVelocity.magnitude > movementSpeed)
        {
            Vector3 cappedVelocity = flatVelocity.normalized * movementSpeed;
            rb.velocity = new Vector3(cappedVelocity.x, rb.velocity.y, cappedVelocity.z);
        }
    }
    private void GroundCheck()
    {
        bool wasGrounded = isGrounded;
        Debug.DrawRay(transform.position + new Vector3(0, groundJumpAllowance, 0), Vector3.down * groundJumpAllowance * 2f, Color.red);
        isGrounded = Physics.Raycast(transform.position + new Vector3(0, groundJumpAllowance, 0), Vector3.down, groundJumpAllowance * 2f, groundMask);
        if (isGrounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        // When landing, reset jumps
        if (!wasGrounded && isGrounded)
            jump = jumpCount;
    }

    private void Jump()
    {
        // Reset y velocity before jumping to ensure jumping is consistent
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJumpCooldown()
    {
        isJumpOffCD = true;
    }
}
