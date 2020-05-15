﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("传送")]
    
    [Header("移动参数")]
    private Rigidbody2D rb; 
    private float xVelocity;
    public int speed;

    [Header("跳跃参数")]
    public float yVelocity;
    public float gravityScaleChange;
    public int jumpForce;
    public bool isJump;
    public bool isOnGround;
    public LayerMask groundLayer;
    public bool jumpPress;

    [Header("Coyote Time")]
    public float coyoteTime;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space ))
        {
            jumpPress = true;
        }
       
    }

    

    private void FixedUpdate()
    {
        PhysicsCheck();
        GroundMovement();
        Airmovement();
        yVelocity = rb.velocity.y;
        jumpPress = false;

        PoolManager.Instance.GetObj("Shadow");
    }

    void GroundMovement()
    {
        xVelocity = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(speed * xVelocity, rb.velocity.y);

    }

    void Airmovement()
    {
        if(yVelocity < 0)
        {
            rb.gravityScale += gravityScaleChange * Time.deltaTime;
           
        }
        if(jumpPress && isOnGround)
        {
            rb.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
        }
    }

    void PhysicsCheck()
    {
        if(rb.IsTouchingLayers(groundLayer))
        {
            isOnGround = true;
            rb.gravityScale = 9; 
        }
        else
        {
            if (isOnGround)
                Invoke("SetOnGround", coyoteTime);
            
        }
    }

    void SetOnGround()
    {
        isOnGround = false;
    }

    

    void FlipDirction()
    {
        if (xVelocity < 0)
        {
            transform.localScale = new Vector2(-30, 30);
        }
        else if (xVelocity > 0)
        {
            transform.localScale = new Vector2(30, 30);
        }
    }

}
