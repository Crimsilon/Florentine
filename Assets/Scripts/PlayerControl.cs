﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{


    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           // location to determin where the ground is
    // Start is called before the first frame update
    private float moveInput;
    public float moveSpeed;
    public float jumpPower;
    public bool facingRight;
    public bool grounded= false;
    const float k_GroundedRadius = .1f;                     // Radius of the overlap circle to determine if grounded

    // Update is called once per frame

    private void FixedUpdate()
    {
        grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                grounded = true;
        }
    }
    void Update()
    {

        moveInput = Input.GetAxis("Horizontal");
        
        Jump();
        
        Vector2 movement = new Vector2(moveInput * moveSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

        gameObject.GetComponent<Rigidbody2D>().velocity = movement;

        if (facingRight == false && moveInput > 0)
        {
            flip();
        }

        else if (facingRight == true && moveInput < 0)
        {
            flip();
        }

    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && grounded == true)
        { 
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpPower;
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}
