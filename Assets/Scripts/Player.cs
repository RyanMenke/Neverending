using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public float jumpHeight = 30f;
    public float runSpeed = 30f;

    public float horizontal;
    public float jumpComponent = 0;
    public float jumpTimeCounter = 0.25f;
    

    public bool isGrounded = false;
    public bool isJumping = false;
    public bool isOnWall;
    public bool jumpReleased;
    
    public Rigidbody2D body;
    
   public void MovementHandler()
        {
            horizontal = Input.GetAxisRaw("Horizontal");
        }

        

    public void JumpHandler()
    {
        if (Input.GetButton("Jump"))
        {
            if (isGrounded)
            {
                jumpComponent = (isJumping ? 1 : 0) * jumpHeight;
            }


            if (jumpTimeCounter > 0 && !jumpReleased)
            {
                jumpComponent = (jumpHeight - 2);
                jumpTimeCounter -= Time.deltaTime;
            }
        }
        
        if (Input.GetButtonUp("Jump") && isJumping)
        { 
            jumpReleased = true;
        }

        if (body.velocity.y <= 0 && !isGrounded)
        {
            //jumpComponent > -15.8f ? jumpComponent -= Time.deltaTime*30f : jumpComponent = -15.8f;
            if (body.velocity.y <= -15.8f)
            {
                // Debug.Log(jumpComponent);
                jumpComponent = -15.8f;
            }
        }
        
        if (!isGrounded)
        {
            if (jumpComponent > -15.8f)
            {
                jumpComponent -= Time.deltaTime*75;   
            }
        }

    }

    public void TouchingGround()
    {
        SetIsGrounded(true);
        SetIsJumping(false);
        jumpTimeCounter = .25f;
        jumpReleased = false;
    }

    public void LeavingGround()
    {
        SetIsGrounded(false);
        SetIsJumping(true);
    }
    
    public void setJumpTimeCounter(float newValue)
    {
        jumpTimeCounter = newValue;
    }
    
    public void SetIsGrounded(bool value)
    {
        isGrounded = value;
    }
    
    public void SetIsJumping(bool value)
    {
        isJumping = value;
    }

    public void ToggleIsGrounded()
    {
        isGrounded = !isGrounded;
    }

    public bool GetIsGrounded()
    {
        return isGrounded;
    }

    public bool GetIsJumping()
    {
        return isJumping;
    }

}
