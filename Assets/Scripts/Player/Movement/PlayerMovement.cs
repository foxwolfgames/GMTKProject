using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform orientation;
    [Header("Current Stats")]
    public float speed;

    [Header("Movement")]
    public float movementSpeed;
    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask groundMask;
    public bool isGrounded;

    private float horizontalInput;
    private float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        speed = 0;
    }

    private void Update()
    {
        Debug.DrawRay(transform.position + new Vector3(0, 0.2f, 0), Vector3.down * (playerHeight * 0.5f + 0.2f), Color.red);
        isGrounded = Physics.Raycast(transform.position + new Vector3(0, 0.2f, 0), Vector3.down, playerHeight * 0.5f + 0.2f, groundMask);
        if (isGrounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        SpeedControl();

        HandleInput();

        speed = rb.velocity.magnitude;
    }


    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void HandleInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * movementSpeed * 10f, ForceMode.Force);
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
}
