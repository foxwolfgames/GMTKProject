using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 horizontalInput;
    private Vector3 moveDirection;
    private Rigidbody rb;

    [Header("References")]
    public Transform orientation;

    [Header("Current Stats")]
    public float speed = 0;
    public int jump = 1;

    [Header("Movement")]
    private float currentSpeed;
    public float walkingSpeed = 10f;
    public float sprintingSpeed;
    private bool isSprinting = false;
    public float groundDrag = 5f;
    public float jumpForce = 12f;
    public float jumpCooldown = .25f;
    public float airMultiplier = .4f;
    public int jumpCount = 1;
    private bool isJumping;
    private bool isJumpOffCD = true;

    [Header("Ground Check")]
    public LayerMask playerMask;
    public bool isGrounded;
    public float groundJumpAllowance = 0.2f;

    public MovementState movementState;
    public enum MovementState { walking, sprinting, midair }

    public void ReceiveMovementInput(Vector2 horizontalValue)
    {
        horizontalInput = horizontalValue;
    }
    public void ReceiveJumpInput(bool jumpInput)
    {
        isJumping = jumpInput;
    }
    public void ReceiveSprintInput(bool sprintInput)
    {
        isSprinting = sprintInput;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        jump = jumpCount;
        currentSpeed = walkingSpeed;
        sprintingSpeed = walkingSpeed * 1.5f;
    }

    private void Update()
    {
        GroundCheck();
        StateHandler();
        SpeedControl();

        // Handle jumping
        if (isJumping && isJumpOffCD)
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
        speed = rb.velocity.magnitude;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void StateHandler()
    {
        if (isGrounded && isSprinting) // Sprinting
        {
            movementState = MovementState.sprinting;
            currentSpeed = sprintingSpeed;
        }
        else if (isGrounded) // Walking
        {
            movementState = MovementState.walking;
            currentSpeed = walkingSpeed;
        }
        else
        {
            movementState = MovementState.midair;
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVelocity.magnitude > currentSpeed)
        {
            Vector3 cappedVelocity = flatVelocity.normalized * currentSpeed;
            rb.velocity = new Vector3(cappedVelocity.x, rb.velocity.y, cappedVelocity.z);
        }
    }

    private void GroundCheck()
    {
        bool wasGrounded = isGrounded;
        Debug.DrawRay(transform.position + new Vector3(0, groundJumpAllowance, 0), Vector3.down * groundJumpAllowance * 2f, Color.red);
        isGrounded = Physics.Raycast(transform.position + new Vector3(0, groundJumpAllowance, 0), Vector3.down, groundJumpAllowance * 2f, ~playerMask);
        if (isGrounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        // When landing, reset jumps
        if (!wasGrounded && isGrounded)
            jump = jumpCount;
    }

    private void Move()
    {
        moveDirection = orientation.forward * horizontalInput.y + orientation.right * horizontalInput.x;

        if (isGrounded)
        {
            rb.AddForce(moveDirection.normalized * currentSpeed * 10f, ForceMode.Force);
        }
        else
        {
            rb.AddForce(moveDirection.normalized * currentSpeed * 10f * airMultiplier, ForceMode.Force);
        }
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
