using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public MasterController movementJoystick;
    public MasterController rotationJoystick;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {



        Vector2 moveInput = new Vector2(movementJoystick.Horizontal, movementJoystick.Vertical);
        moveVelocity = moveInput.normalized * speed;

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
        this.transform.Rotate(new Vector3(0,0,rotationJoystick.Horizontal),speed);
    }
}