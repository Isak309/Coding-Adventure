using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //create characters rigidbody
    private Rigidbody2D rigidbody2d;
    private float move;
    //speed of character
    public float topSpeed;
    //jump velocity of character
    public float jumpVelocity;
    public float jumpVelocity2;
    //Which way the sprite is facing
    bool facingRight = true;

    public Joystick joystick;

    //check if character is touching ground
    public bool isGrounded, canDoubleJump;
    public LayerMask groundLayers;
    private void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //get move direction
        move = joystick.Horizontal * topSpeed;

        float verticalMove = joystick.Vertical;
        //add velocity to the rigidbody in the move direction * our speed
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * topSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (verticalMove >= 0.5 && isGrounded)
        {
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
            canDoubleJump = true;
        }
        else //not using this right now
        {
            if(canDoubleJump && Input.GetButtonDown("Jump"))
            {
                rigidbody2d.velocity = Vector2.up * jumpVelocity2;
                canDoubleJump = false;
            }
        }

        //if we're facing negative direcetion and not facing right, flip
        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        //saying we are facing opposite direction
        facingRight = !facingRight;

        //get the local scale
        Vector3 theScale = transform.localScale;

        //flip on x axis
        theScale.x *= -1;

        //apply that to the local scale
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
