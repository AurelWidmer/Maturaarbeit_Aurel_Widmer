using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groudCheck;
    public LayerMask groundLayer;

    private float horizontal;
    private float speed = 6f;
    [Range(0f, 20f)]
    public float jumpingPower = 8f;
    private bool isFacingRight = true;
    private int doubleJumpCounter = 0;
    private float doubleJumpPower = 10f;
    private bool isJumping = false;

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }
        if (isGrounded())
        {
            doubleJumpCounter = 0;
        
         {

        if (isGrounded())
        {
            isJumping = false;
            doubleJumpCounter = 0;
        }
    }
        }
    }

     public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && !isJumping && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            isJumping = true;
        }
    }

    public void DoubleJump(InputAction.CallbackContext context)
    {
        if (context.performed && !isJumping && !isGrounded() && doubleJumpCounter == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, doubleJumpPower);
            doubleJumpCounter += 1;
        }
    }
    
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groudCheck.position, 0.1f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
}
